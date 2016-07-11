using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GeisaBD;
using Reportes;
using System.Data.Entity.Core.Objects;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Reporting.WinForms;

namespace SistemaGEISA
{
    public partial class frmGastosAdministrativos : DevExpress.XtraEditors.XtraForm
    {

        private Controler _controler = new Controler();
        private Pagos pagosGeisa { get; set; }
        private Pagos pagosDiproe { get; set; }    
        //private Pagos pagosDiproe { get; set; }
        bool tienePermisoModificar, tienePermisoAgregar, tienePermisoCancelar;
        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }
        private List<Empresa> empresas { get; set; }
        public frmGastosAdministrativos()
        {
            InitializeComponent();
            Controler.PermisosEnFormulario(Name);
            btnAgregarGasto.Enabled = tienePermisoAgregar = Controler.TienePermiso(PermisosEnum.Agregar);
            btnEditarGasto.Enabled = tienePermisoModificar = Controler.TienePermiso(PermisosEnum.Actualizar);
            tienePermisoCancelar = Controler.TienePermiso(PermisosEnum.Cancelar);
        }
        public void llenaEmpresas() 
        {
            empresas = Controler.Model.Empresa.Where(E => !E.NombreComercial.Contains("FRANCISCO JAVIER")).OrderBy(D => D.NombreComercial).ToList();
            if (empresas != null) 
            {
                        label1.Text = empresas[0].NombreComercial;
                        label2.Text = empresas[1].NombreComercial;                    
             }            
        }

        public void llenaCbMeses() 
        {
            DataTable ds = new DataTable();
            ds.Columns.Add("codigo", typeof(int));
            ds.Columns.Add("descripcion", typeof(string));
            ds.Rows.Add(1, "ENERO");
            ds.Rows.Add(2, "FEBRERO");
            ds.Rows.Add(3, "MARZO");
            ds.Rows.Add(4, "ABRIL");
            ds.Rows.Add(5, "MAYO");
            ds.Rows.Add(6, "JUNIO");
            ds.Rows.Add(7, "JULIO");
            ds.Rows.Add(8, "AGOSTO");
            ds.Rows.Add(9, "SEPTIEMBRE");
            ds.Rows.Add(10, "OCTUBRE");
            ds.Rows.Add(11, "NOVIEMBRE");
            ds.Rows.Add(12, "DICIEMBRE");
            ds.AcceptChanges();

            cbMeses.DataSource = ds;
            cbMeses.ValueMember = "codigo";
            cbMeses.DisplayMember = "descripcion";
        }
        public void llenaGridEmpresas(DevExpress.XtraGrid.GridControl grid, int id) 
        {
            int meses = Convert.ToInt32(cbMeses.SelectedIndex + 1);
            //grid.DataSource = Controler.Model.GastosAdministrativos.Where(D => D.EmpresaId == id && D.Fecha.Year == editAño.Value && D.Fecha.Month == meses).OrderBy(D => D.Fecha).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("IdPago", typeof(int));
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Factura", typeof(string));
            dt.Columns.Add("Importe", typeof(double));
            dt.Columns.Add("NoReferencia", typeof(string));
            dt.Columns.Add("Concepto", typeof(int));
            dt.Columns.Add("Observaciones", typeof(string));
            dt.Columns.Add("Proveedor", typeof(string));
            dt.Columns.Add("Compartido", typeof(Boolean)).DefaultValue=false;
            dt.Columns.Add("GastoAdm", typeof(Boolean)).DefaultValue = false;
            grid.DataSource = dt;
            List<Factura> facturas = new List<Factura>();
            GridView gv = (GridView)grid.FocusedView;
            grid.DataSource = Controler.Model.getFacturasCompartidas(TipoMovimientoEnum.GastosAdministrativos.Id, meses,Convert.ToInt32(editAño.Value), id).ToList();
            
        }

        private void cbMeses_SelectedValueChanged(object sender, EventArgs e)
        {
            llenaGridEmpresas(grid1, empresas[0].Id);
            llenaGridEmpresas(grid2, empresas[1].Id);
            setValores();
        }

        private void editAño_ValueChanged(object sender, EventArgs e)
        {
            llenaGridEmpresas(grid1, empresas[0].Id);
            llenaGridEmpresas(grid2, empresas[1].Id);
            setValores();
        }

        private void btnAgregarGasto_Click(object sender, EventArgs e)
        {
            abrirForm(true);
        }

        private void setValores()
        {
            //List<double> valores = GastosCompartidos.getValores(Convert.ToInt32(cbMeses.SelectedIndex + 1), cbMeses.Text, (int)editAño.Value);

            double totalGastosCompartidos = 0;
            double totalGastosDiproe = 0;
            double totalGastosGeisa = 0;
            double totalGastosCompartidosDivididos = 0;
            double totalGC_Geisa = 0;
            double totalGC_Diproe = 0;

            for (int i = 0; i < gv1.RowCount; i++)
            {
                    double importe=0;
                    double.TryParse(gv1.GetRowCellValue(i, gv1.Columns["Importe"]).ToString(), out importe);
                    totalGastosDiproe += importe;
                    if (Convert.ToBoolean(gv1.GetRowCellValue(i, gv1.Columns["Compartido"])) == true)
                    {
                        totalGastosCompartidos += importe;
                        totalGC_Diproe += importe;
                    }
            }

            for (int i = 0; i < gv2.RowCount; i++)
            {
                    double importe=0;
                    double.TryParse(gv2.GetRowCellValue(i, gv2.Columns["Importe"]).ToString(), out importe);
                    totalGastosGeisa += importe;
                    if (Convert.ToBoolean(gv2.GetRowCellValue(i, gv2.Columns["Compartido"])) == true)
                    {
                        totalGastosCompartidos += importe;
                        totalGC_Geisa += importe;
                    }
            }

            totalGastosCompartidosDivididos = totalGastosCompartidos / 2;

            txtGastosDi.Text = totalGastosDiproe.ToString("c2");
            txtGastosGei.Text = totalGastosGeisa.ToString("c2");
            txtTotCompartidos.Text = totalGastosCompartidos.ToString("c2");
            txtCompIguales.Text = totalGastosCompartidosDivididos.ToString("c2");
            txtGcDiproe.Text = totalGC_Diproe.ToString("C2");
            txtGcGeisa.Text = totalGC_Geisa.ToString("C2");
            txtSaldoPendiente.Text = (totalGastosCompartidosDivididos - (totalGC_Geisa > totalGC_Diproe ? totalGC_Diproe : totalGC_Geisa)).ToString("c2");
        }

        private void frmGastosAdministrativos_Load(object sender, EventArgs e)
        {
            btnAgregarGasto.Enabled = btnEditarGasto.Enabled = tienePermisoAgregar || tienePermisoModificar;
            llenaEmpresas();
            llenaCbMeses();
            editAño.Value = DateTime.Now.Year;
            cbMeses.SelectedValue = DateTime.Now.Month;
            if (empresas != null)
            {
                llenaGridEmpresas(grid1, empresas[0].Id);
                llenaGridEmpresas(grid2, empresas[1].Id);
            }
            setValores();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            new frmPrint("GastosCompartidos", new ReportDataSource { Name = "GastosCompartidos", Value = new BindingSource { DataSource = new GastosCompartidos(Convert.ToInt32(cbMeses.SelectedIndex + 1), cbMeses.Text, (int)editAño.Value).Items } }, null).Show();
        }

        private void gv1_DoubleClick(object sender, EventArgs e)
        {
            var view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            var pt = view.GridControl.PointToClient(Control.MousePosition);
            var info = view.CalcHitInfo(pt);

            if (info.InRow || info.InRowCell)
            {
                btnEditarGasto_Click(sender, null);
            }
        }

        private void gv2_DoubleClick(object sender, EventArgs e)
        {
            gv1_DoubleClick(sender, e);
        }

        private void btnEditarGasto_Click(object sender, EventArgs e)
        {
            var row = gv1.IsFocusedView ?  gv1.GetFocusedRow(): gv2.GetFocusedRow();
            if (row != null)
            {
                abrirForm(false);
            }
            else
            {
                new frmMessageBox(true) { Message = "Favor de seleccionar el elemento a editar.", Title = "Confirmación" }.ShowDialog();
            }
        }

        private void abrirForm(bool nuevo)
        {
            Pagos pago = gv1.IsFocusedView ? pagosDiproe : pagosGeisa;
            if (pagosGeisa != null || pagosDiproe!=null)
            {
                if ((pago.TipoMovimientoId == TipoMovimientoEnum.GastosAdministrativos.Id || nuevo == true))
                {
                    var form = new frmAgregarGastosAd(Controler);
                    form.Text = "Gastos Administrativos : " + (nuevo ? "Nuevo" : "Editar");
                    form.tienePermisoAgregar = tienePermisoAgregar;
                    form.tienePermisoModificar = tienePermisoModificar;
                    form.tienePermisoCancelar = tienePermisoCancelar;
                    if (!nuevo) form.pagos = pago;
                    form.tipoMovimientoId = TipoMovimientoEnum.GastosAdministrativos.Id;

                    form.ShowDialog();

                    if (empresas != null)
                    {
                        llenaGridEmpresas(grid1, empresas[0].Id);
                        llenaGridEmpresas(grid2, empresas[1].Id);
                    }
                }
                else if ((pago.TipoMovimientoId == TipoMovimientoEnum.TarjetaCredito.Id || nuevo == true))
                {
                    var form = new frmTarjetasPagosNew(Controler);
                    form.Text = "Tarjetas Pago : " + (nuevo ? "Nuevo" : "Editar");
                    form.tienePermisoAgregar = tienePermisoAgregar;
                    form.tienePermisoModificar = tienePermisoModificar;
                    form.tienePermisoCancelar = tienePermisoCancelar;
                    if (!nuevo) form.pagos = pago;
                    form.tipoMovimientoId = TipoMovimientoEnum.TarjetaCredito.Id;
                    form.ShowDialog();

                    if (empresas != null)
                    {
                        llenaGridEmpresas(grid1, empresas[0].Id);
                        llenaGridEmpresas(grid2, empresas[1].Id);
                    }
                    else { grid1.RefreshDataSource(); grid2.RefreshDataSource(); }

                }
                else
                {
                    var form = new frmReposicionGastosNew(Controler);
                    form.Text = "Reposición de Gastos : " + (nuevo ? "Nuevo" : "Editar");
                    form.tienePermisoAgregar = tienePermisoAgregar;
                    form.tienePermisoModificar = tienePermisoModificar;
                    form.tienePermisoCancelar = tienePermisoCancelar;
                    if (!nuevo) form.pagos = pago;
                    form.tipoMovimientoId = TipoMovimientoEnum.Reposicion_Gastos.Id;
                    form.ShowDialog();

                    if (empresas != null)
                    {
                        llenaGridEmpresas(grid1, empresas[0].Id);
                        llenaGridEmpresas(grid2, empresas[1].Id);
                    }
                    else { grid1.RefreshDataSource(); grid2.RefreshDataSource(); }
                }
            }
            else
            {
                var form = new frmAgregarGastosAd(Controler);
                form.Text = "Gastos Administrativos : " + (nuevo ? "Nuevo" : "Editar");
                form.tienePermisoAgregar = tienePermisoAgregar;
                form.tienePermisoModificar = tienePermisoModificar;
                form.tienePermisoCancelar = tienePermisoCancelar;
                if (!nuevo) form.pagos = pago;
                form.tipoMovimientoId = TipoMovimientoEnum.GastosAdministrativos.Id;
                form.ShowDialog();

                if (empresas != null)
                {
                    llenaGridEmpresas(grid1, empresas[0].Id);
                    llenaGridEmpresas(grid2, empresas[1].Id);
                }
            }
            setValores();
        }

        private void botones(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    btnAgregarGasto.Visible = true;
                    btnEditarGasto.Visible = false;
                    break;
                case 2:
                    btnAgregarGasto.Visible = true;
                    btnEditarGasto.Visible = true;
                    break;
            }
        }

        private void gv1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
            if (gv1.RowCount > 0)
            {
                try
                {
                    int id = Convert.ToInt32(gv1.GetRowCellValue(gv1.FocusedRowHandle, "IdPago"));
                    pagosDiproe = Controler.Model.Pagos.FirstOrDefault(p => p.Id == id);
                    botones(2);
                }
                catch (Exception ex)
                {
                    pagosDiproe = null;
                }
            }
        }

        private void gv2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv2.RowCount > 0)
            {
                try
                {
                    int id = Convert.ToInt32(gv2.GetRowCellValue(gv2.FocusedRowHandle, "IdPago"));
                    pagosGeisa = Controler.Model.Pagos.FirstOrDefault(p => p.Id == id);
                    botones(2);
                }
                catch (Exception ex)
                {
                    pagosGeisa = null;
                }
            }
        }

        private void gv1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            gv1_FocusedRowChanged(null, null);
        }

        private void gv2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            gv2_FocusedRowChanged(null, null);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            llenaGridEmpresas(grid1, empresas[0].Id);
            llenaGridEmpresas(grid2, empresas[1].Id);
            setValores();
        }

     
            
        
    }
}
