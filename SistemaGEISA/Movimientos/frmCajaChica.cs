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
using DevExpress.XtraGrid.Views.Grid;
namespace SistemaGEISA
{
    public partial class frmCajaChica : DevExpress.XtraEditors.XtraForm
    {

        DataTable dt;
        private Controler _controler = new Controler();

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }
        public Empleado empleado { get; set; }

        private CajaChica cajaChica { get; set; }
        public frmCajaChica()
        {
            InitializeComponent();
        }
        public void llenaGrid()
        {
            //grid.DataSource = Controler.Model.CajaChica.ToList();
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("NombreResidente", typeof(String));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("saldo", typeof(double));
            grid.DataSource = dt;

            foreach (CajaChica c in Controler.Model.CajaChica.ToList())
            {
                gv.AddNewRow();
                int rowHandle = gv.GetRowHandle(gv.DataRowCount);
                gv.SetRowCellValue(rowHandle, gv.Columns[0], c.EmpleadoId);
                gv.SetRowCellValue(rowHandle, gv.Columns[1], c.NombreResidente);
                gv.SetRowCellValue(rowHandle, gv.Columns[2], c.Fecha);
                gv.SetRowCellValue(rowHandle, gv.Columns[3], getSaldo(c.Id));
                gv.UpdateCurrentRow();
                gv.RefreshData();
            }
        }

        private void abrirForm(bool nuevo)
        {
            var form = new frmCajaChicaDetalle(Controler);

            form.Text = "Caja chica : "+(nuevo ? "Nuevo":"Editar");
            if (!nuevo)
            {
                int empleadoId = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, "Id").ToString());
                cajaChica = Controler.Model.CajaChica.Where(c => c.EmpleadoId == empleadoId).SingleOrDefault();
                form.cajaChica = cajaChica;
            }
            else
            {
                form.cajaChica = null;
            }
            form.nuevo = nuevo;
            form.ShowDialog();
            llenaGrid();
            grid.RefreshDataSource();
            //grid.RefreshDataSource();
            //if (nuevo)
            //{
            //    llenaGrid();
            //}
            //else
            //{
            //    grid.RefreshDataSource();
            //}
            //gv_FocusedRowChanged(null, null);
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            var view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            var pt = view.GridControl.PointToClient(Control.MousePosition);
            var info = view.CalcHitInfo(pt);

            if (info.InRow || info.InRowCell)
            {
                btnEditar_Click(null, null);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRowsCount == 1)
            {
                abrirForm(false);
            }
            else
            {
                new frmMessageBox(true) { Message = "Favor de seleccionar el elemento a editar.", Title = "Confirmación" }.ShowDialog();
            }
        }

        private double getSaldo(int id)
        {

            var Datos = Controler.Model.CajaChicaDetalle.Where(D => D.CajaChicaId == id).ToList();
            double tipoComprobantes = 0;
            double saldo = 0;
            double deposito = 0;
            foreach (CajaChicaDetalle CajaDetalle in Datos)
            {
                tipoComprobantes += Convert.ToDouble(CajaDetalle.Biaticos);
                tipoComprobantes += Convert.ToDouble(CajaDetalle.Nominas);
                tipoComprobantes += Convert.ToDouble(CajaDetalle.Facturas);
                tipoComprobantes += Convert.ToDouble(CajaDetalle.NoDeducibles);
                deposito += Convert.ToDouble(CajaDetalle.Deposito);
            }
            return (saldo = deposito - tipoComprobantes);
        }

        private void frmCajaChica_Load(object sender, EventArgs e)
        {
            llenaGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            abrirForm(true);
        }

        private void gv_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "saldo")
            {
                    double saldo =Convert.ToDouble(gv.GetRowCellValue(e.RowHandle, "saldo"));
                    if (saldo < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    
            }
        }
    }
}