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
using System.Data.Common;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;

namespace SistemaGEISA
{
    public partial class frmIngresosFactura : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dt;

        public Factura factura;
        public Controler controler { get; set; }

        public Empresa empresa;
        public Obra obra { get; set; }

        public Cliente cliente { get; set; }
        public Boolean isNew=true;
        private List<int?> FoliosGeisa=new List<int?>();
        private List<int?> FoliosDiproe = new List<int?>(); 
        public frmIngresosFactura(Controler _controler)
        {
            InitializeComponent();
            controler = _controler ?? new Controler();
        }

        private void verificaAbonos()
        {
            if (factura != null)
                if (controler.Model.PagosFactura.Where(P => P.FacturaId == this.factura.Id).Count()>0)
                {
                    lblCancelada.Visible = true;                   
                    lblCancelada.Text = "No es Posible Modificarla el Monto con Abonos Asociados";
                    txtImporte.ReadOnly = true;

                }

            //Console.WriteLine(controler.Model.PagosFactura.Where(P => P.FacturaId == this.factura.Id).Count());
            //Console.WriteLine(controler.Model.PagosFactura.Where(P => P.FacturaId == this.factura.Id).DefaultIfEmpty().Count());
        }

        private void frmIngresosFactura_Load(object sender, EventArgs e)
        {
            //SI TIENE ABONOS O NOTAS DE CREDITO, NO SE PUEDE MODIFICAR EL IMPORTE 
            verificaAbonos();

            llenaCombos();
            lblObra.Text = obra.Nombre;            
            if (factura==null)
            {
                luEmpresa.EditValue = this.empresa.Id;
                luCliente.EditValue = this.cliente.Id;
                luObra.EditValue = this.obra.Id;                
                deFecha.EditValue = DateTime.Today;
                txtFolio.Text = getFolio().ToString();
                radioGroup.EditValue = 5;
                deFechaIngreso.EditValue = DateTime.Today;                
            }
            else
            {
                luEmpresa.EditValue = factura.EmpresaId;
                luCliente.EditValue = factura.ClienteId == null ? this.obra.ClienteId : factura.ClienteId;
                luObra.EditValue = factura.ObraId;
                txtFolio.Text = factura.FolioNum.ToString(); //txtFolio.ReadOnly = true;
                deFecha.EditValue = factura.Fecha;
                txtImporte.Text = factura.Importe.ToString("N2");
                txtObservaciones.Text = factura.Observaciones;

                if (factura.Obra_Civil != null && factura.Obra_Civil != false)
                {
                    if (factura.Obra_Civil.Value)
                    radioGroup.EditValue = TipoFactura.OBRA_CIVIL;
                }else if(factura.Subcontratistas != null && factura.Subcontratistas!=false)
                {
                    if (factura.Subcontratistas.Value)
                    radioGroup.EditValue = TipoFactura.SUBCONTRATISTAS;
                }
                else if (factura.Suministros != null && factura.Suministros!=false)
                {
                    if (factura.Suministros.Value)
                    radioGroup.EditValue = TipoFactura.SUMINISTROS;
                }
                else if (factura.Extra!=null && factura.Extra!=false)
                {
                    if (factura.Extra.Value)
                    radioGroup.EditValue = TipoFactura.EXTRAS;
                }
                else if (factura.Mantenimiento != null && factura.Mantenimiento !=false)
                {
                    if (factura.Mantenimiento.Value)
                        radioGroup.EditValue = TipoFactura.MANTENIMIENTO;
                }
                else
                {
                    radioGroup.EditValue = TipoFactura.NO_APLICA;
                }

                txtOC.Text = factura.OrdenCompra;
                txtCadex.Text = factura.Cadex;
                deFechaIngreso.EditValue = factura.FechaIngreso;
                //cbExtra.Checked = factura.Extra.HasValue ? factura.Extra.Value : false;
                if (factura.FechaCancelacion != null)
                {
                    luEmpresa.Properties.ReadOnly = true;
                    luObra.Properties.ReadOnly = true;
                    txtFolio.ReadOnly = true;
                    deFecha.Properties.ReadOnly = true;
                    txtImporte.ReadOnly = true;
                    txtObservaciones.ReadOnly = true;
                    radioGroup.Properties.ReadOnly = true;
                    luCliente.Properties.ReadOnly = true;
                    deFechaIngreso.Properties.ReadOnly = true;
                    txtOC.ReadOnly = true;
                    txtCadex.ReadOnly = true;
                    //cbExtra.Enabled = false;
                    lblCancelada.Visible = true;
                    btnAgregar.Enabled = false;
                    btnGuardar.Enabled = false;
                }
            }
        }

        private void llenaCombos()
        {
            limpiaValores();            
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("FolioNum", typeof(int));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Subtotal", typeof(double));
            dt.Columns.Add("Iva", typeof(double));
            dt.Columns.Add("Total", typeof(double));
            dt.Columns.Add("Observaciones", typeof(string));
            dt.Columns.Add("Empresa", typeof(string));
            dt.Columns.Add("Obra", typeof(string));
            dt.Columns.Add("Tipo", typeof(int));
            dt.Columns.Add("FechaIngreso", typeof(DateTime));
            dt.Columns.Add("Cadex", typeof(string));
            dt.Columns.Add("OrdenCompra", typeof(string));
            dt.Columns.Add("ClienteId", typeof(int));

            luEmpresa.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luEmpresa.Properties.DisplayMember = "NombreFiscal";
            luEmpresa.Properties.ValueMember = "Id";

            luObra.Properties.DataSource = controler.Model.Obra.ToList();
            luObra.Properties.DisplayMember = "Nombre";
            luObra.Properties.ValueMember = "Id";

            lookupEmpresa.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            lookupEmpresa.DisplayMember = "NombreFiscal";
            lookupEmpresa.ValueMember = "Id";

            lookupObra.DataSource = controler.Model.Obra.ToList();
            lookupObra.DisplayMember = "Nombre";
            lookupObra.ValueMember = "Id";

            luCliente.Properties.DataSource = controler.Model.Cliente.Where(D => D.Activo == true).ToList();
            luCliente.Properties.DisplayMember = "NombreFiscal";
            luCliente.Properties.ValueMember = "Id";

            lookupCliente.DataSource = controler.Model.Cliente.Where(D => D.Activo == true).ToList();
            lookupCliente.DisplayMember = "NombreFiscal";
            lookupCliente.ValueMember = "Id";

            Dictionary<int, string> facturas = new Dictionary<int, string>();

            facturas.Add(1, "OBRA CIVIL");
            facturas.Add(2, "SUBCONTRATISTAS");
            facturas.Add(3, "SUMINISTROS");
            facturas.Add(4,"EXTRAS");
            facturas.Add(5, "N/A");
            facturas.Add(6, "MANTENIMIENTO");
            lookupTipoFactura.DataSource = facturas;
            lookupTipoFactura.DisplayMember = "Value";
            lookupTipoFactura.ValueMember = "Key";

            grid.DataSource = dt;
        }

        private int? getFolio()
        {
            int? folio=0;
            int empresaId = (luEmpresa.GetSelectedDataRow() as Empresa).Id;
            if (FoliosDiproe.Count<=0 && empresaId == 1)
            {
                folio = controler.Model.Factura.Where(P =>
                    P.EmpresaId == empresaId
                    && P.ContrareciboId == null && P.ProveedorId == null && P.ProveedorOtro == null && P.ReposicionGastosId == null && P.CajaComprobanteId == null && P.ConceptosId == null).Select(I => I.FolioNum).Max();
                folio = folio.HasValue ? folio + 1 : 1;
            }
            else if (FoliosGeisa.Count <= 0 && empresaId==2)
            {
                folio = controler.Model.Factura.Where(P =>
                    P.EmpresaId == empresaId
                    && P.ContrareciboId == null && P.ProveedorId == null && P.ProveedorOtro == null && P.ReposicionGastosId == null && P.CajaComprobanteId == null && P.ConceptosId == null).Select(I => I.FolioNum).Max();
                folio = folio.HasValue ? folio + 1 : 1;
            }
            else
            {
                if (FoliosDiproe.Count > 0 && empresaId == 1)
                    folio = FoliosDiproe.Max(f => f.Value)+1;  
                else
                    folio = FoliosGeisa.Max(f => f.Value) + 1;  
            }
            return folio;
        }

        private void limpiaValores()
        {
            txtFolio.Text = "";
            txtImporte.Text = "";
            txtObservaciones.Text = "";
            deFecha.EditValue = DateTime.Today;
            radioGroup.EditValue = TipoFactura.NO_APLICA;
            //cbExtra.Checked = false;
            luEmpresa.EditValue = null;
            luObra.EditValue = null;
            deFechaIngreso.EditValue = DateTime.Today;
            txtOC.Text = "";
            txtCadex.Text = "";
            luCliente.EditValue = null;
        }

        private bool gridValido()
        {

            bool isValid = true;
            if (gv.DataRowCount > 0)
            {
                for (int i = 0; i < gv.RowCount; i++)
                {
                    DataRow row = gv.GetDataRow(i);
                    DataRow row2 = gv.GetRow(i) as DataRow;
                    if (row != null)
                    {
                        isValid = gv.IsValidRowHandle(i);
                        if (!isValid) return isValid;
                    }

                }
            }
            else
                isValid = false;

            return isValid = gv.DataRowCount > 0 ? true : false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            gv.UpdateCurrentRow();
            gv.CloseEditor();

            if (!gridValido())
            {
                new frmMessageBox(true) { Message = "Valores no Validos, Valor de Verificar.", Title = "Advertencia" }.ShowDialog();
                return;
            }
            DbTransaction transaccion = null;

            try
            {
                transaccion = controler.Model.BeginTransaction();
                for (int i = 0; i < gv.RowCount; i++)
                {
                    DataRow row = gv.GetDataRow(i);

                    if (row != null)
                    {
                        Factura facturaNew;
                        if (string.IsNullOrEmpty(row["Id"].ToString()))
                            facturaNew = new Factura();                        
                        else
                        {
                            int idfacturaNew = Convert.ToInt32(row["Id"].ToString());
                            facturaNew = controler.Model.Factura.Where(c => c.Id == idfacturaNew).SingleOrDefault();
                        }
                        facturaNew.FolioNum = Convert.ToInt32(row["FolioNum"]);
                        facturaNew.NoFactura = Convert.ToInt32(row["FolioNum"]).ToString();
                        facturaNew.Fecha = Convert.ToDateTime(row["Fecha"].ToString());
                        facturaNew.Importe = Convert.ToDouble(row["Total"].ToString());
                        facturaNew.Saldo = facturaNew.Importe;
                        facturaNew.Observaciones =  gv.GetRowCellValue(i, "Observaciones").ToString().ToUpper();
                        facturaNew.ObraId =Convert.ToInt32(gv.GetRowCellValue(i, "Obra"));
                        facturaNew.EmpresaId = Convert.ToInt32(gv.GetRowCellValue(i, "Empresa"));
                        facturaNew.ClienteId = Convert.ToInt32(gv.GetRowCellValue(i, "ClienteId"));
                        int tipoFact = Convert.ToInt32(row["Tipo"]);
                        if (tipoFact == TipoFactura.OBRA_CIVIL)
                        { facturaNew.Obra_Civil = true; facturaNew.Subcontratistas = facturaNew.Suministros = facturaNew.Extra = facturaNew.Mantenimiento = false; }
                        else if (tipoFact == TipoFactura.SUBCONTRATISTAS)
                        { facturaNew.Subcontratistas = true; facturaNew.Obra_Civil = facturaNew.Suministros = facturaNew.Extra = facturaNew.Mantenimiento = false; }
                        else if (tipoFact == TipoFactura.SUMINISTROS)
                        { facturaNew.Suministros = true; facturaNew.Obra_Civil = facturaNew.Subcontratistas = facturaNew.Extra = facturaNew.Mantenimiento = false; }
                        else if (tipoFact == TipoFactura.EXTRAS)
                        { facturaNew.Extra = true; facturaNew.Obra_Civil =facturaNew.Subcontratistas = facturaNew.Suministros  = facturaNew.Mantenimiento = false; }
                        else if (tipoFact == TipoFactura.MANTENIMIENTO)
                        { facturaNew.Mantenimiento = true; facturaNew.Obra_Civil = facturaNew.Subcontratistas = facturaNew.Suministros = facturaNew.Extra = false; }
                        facturaNew.FechaIngreso = string.IsNullOrEmpty(row["FechaIngreso"].ToString()) ? (DateTime?)null : Convert.ToDateTime(row["FechaIngreso"]);
                        facturaNew.Cadex = row["Cadex"].ToString();
                        facturaNew.OrdenCompra = row["OrdenCompra"].ToString();
                        //facturaNew.Extra = Convert.ToBoolean(row["Extra"]);
                        if (!facturaNew.NoEsNuevo) controler.Model.AddToFactura(facturaNew);
                    }
                }

                controler.Model.SaveChanges();
                transaccion.Commit();

            }
            catch (Exception ex)
            {
                if (transaccion != null) transaccion.Rollback();
                error = ex.GetBaseException().Message;
            }
            finally
            {
                controler.Model.CloseConnection();

                var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                var message = string.Empty;

                if (!isNew)
                {
                    message = string.IsNullOrEmpty(error) ? string.Concat("Las Facturas han sido actualizadas exitosamente.") : string.Concat("No se pudieron actualizar las Facturas:\n", error);
                }
                else
                {
                    message = string.IsNullOrEmpty(error) ? string.Concat("Las Facturas han sido generadas exitosamente.") : string.Concat("No se pudieron generar las Facturas:\n", error);
                }

                new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
            }

            if (string.IsNullOrEmpty(error))
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void gv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn colFolio = view.Columns["Folio"];
            GridColumn colFecha = view.Columns["Fecha"];
            GridColumn colProveedor = view.Columns["ProveedorId"];
            GridColumn colImporte = view.Columns["Importe"];

            //string t_Folio = view.GetRowCellValue(e.RowHandle, colFolio).ToString();
            //if (string.IsNullOrEmpty(t_Folio))
            //{ e.Valid = false; view.SetColumnError(colFolio, "Campo Folio es Obligatorio."); return; }

            DateTime t_Fecha = string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, colFecha).ToString()) ? DateTime.MinValue : Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, colFecha));
            if (t_Fecha == null || string.IsNullOrEmpty(t_Fecha.ToString()) || t_Fecha == DateTime.MinValue)
            { e.Valid = false; view.SetColumnError(colFecha, "Campo Fecha es Obligatorio."); return; }

            double t_Importe_Resul;
            double.TryParse(view.GetRowCellValue(e.RowHandle, colImporte).ToString(), out t_Importe_Resul);

            if (t_Importe_Resul == 0 || string.IsNullOrEmpty(t_Importe_Resul.ToString()))
            { e.Valid = false; view.SetColumnError(colImporte, "Campo Importe es Obligatorio."); return; }

            //int t_Proveedor;
            //Int32.TryParse(view.GetRowCellValue(e.RowHandle, colProveedor).ToString(), out t_Proveedor);
            //if (t_Proveedor == 0)
            //{ e.Valid = false; view.SetColumnError(colProveedor, "Campo Proveedor es Obligatorio."); return; }
        }

        private void gv_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Eliminar Registro?", "Confirmación", MessageBoxButtons.YesNo) != DialogResult.Yes)                
                    return;
                GridView view = sender as GridView;
                DataRow row = gv.GetDataRow(gv.FocusedRowHandle);
                if (row != null)
                {
                    if(Convert.ToInt32(row["Empresa"])==1)
                        FoliosDiproe.Remove(Convert.ToInt32(row["FolioNum"]));
                    else
                        FoliosGeisa.Remove(Convert.ToInt32(row["FolioNum"]));
                }
                view.DeleteRow(view.FocusedRowHandle);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                gv.AddNewRow();
                var rowHandle = gv.GetRowHandle(gv.DataRowCount);
                if(factura!=null)
                    gv.SetRowCellValue(rowHandle, gv.Columns["Id"], factura.Id);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Tipo"], radioGroup.EditValue);
                    gv.SetRowCellValue(rowHandle, gv.Columns["FolioNum"], Convert.ToInt32(txtFolio.Text));
                    gv.SetRowCellValue(rowHandle, gv.Columns["Fecha"], deFecha.EditValue);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Subtotal"], getSubtotal());
                    gv.SetRowCellValue(rowHandle, gv.Columns["Iva"], getIva());
                    gv.SetRowCellValue(rowHandle, gv.Columns["Total"], Convert.ToDouble(txtImporte.Text));
                    gv.SetRowCellValue(rowHandle, gv.Columns["Empresa"], luEmpresa.EditValue);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Obra"], luObra.EditValue);                
                    gv.SetRowCellValue(rowHandle, gv.Columns["Observaciones"], txtObservaciones.Text);
                    gv.SetRowCellValue(rowHandle, gv.Columns["FechaIngreso"], deFechaIngreso.EditValue);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Cadex"], txtCadex.Text);
                    gv.SetRowCellValue(rowHandle, gv.Columns["OrdenCompra"], txtOC.Text);
                    gv.SetRowCellValue(rowHandle, gv.Columns["ClienteId"], Convert.ToInt32(luCliente.EditValue)); 
                    gv.UpdateCurrentRow();
                    gv.RefreshData();
                if(Convert.ToInt32(luEmpresa.EditValue)==1)
                    FoliosDiproe.Add(Convert.ToInt32(txtFolio.Text));
                else
                     FoliosGeisa.Add(Convert.ToInt32(txtFolio.Text));
                //limpiaValores();
                IniValores();
                //txtFolio.Text=getFolio().ToString();

                //PONGO EDITABLE EL CAMPO IMPORTE EN CASO DE QUE ESTE DESHABILITADO
                txtImporte.ReadOnly = false;
                lblCancelada.Text = string.Empty;
            }
        }

        private void IniValores()
        {
            //luEmpresa.EditValue = this.empresa.Id;
            luObra.EditValue = this.obra.Id;
            txtFolio.Text = getFolio().ToString();
            deFecha.EditValue = DateTime.Today;
            txtImporte.Text = "";
            txtObservaciones.Text = "";
            //cbExtra.Checked = false;
            radioGroup.EditValue = TipoFactura.NO_APLICA;
            deFechaIngreso.EditValue = DateTime.Today;
            txtOC.Text = "";
            txtCadex.Text = "";
        }

        private double getIva()
        {

            return Convert.ToDouble(txtImporte.Text) - getSubtotal();
        }

        private double getSubtotal()
        {
            double importe = Convert.ToDouble(txtImporte.Text);
            DateTime fecha = Convert.ToDateTime(deFecha.EditValue);
            double ivaActual = controler.Model.Iva.FirstOrDefault(i => i.FechaFin == null).Iva1.Value;
            Iva ivaFactura = controler.Model.Iva.FirstOrDefault(f => fecha >= f.FechaInicio && fecha <= f.FechaFin);

            if (ivaFactura!=null)
            {
                return (importe / (ivaFactura.Iva1.Value + 1));
                
            }
            else
            {
                return (importe / (ivaActual + 1));
            }
        }

        private Boolean isValid()
        {
            bool areValid=true;
            bool isValid=true;            

            DateTime fecha = Convert.ToDateTime(deFecha.EditValue);
            string importe = txtImporte.Text;

            areValid &= isValid = luEmpresa.EditValue== null ? false : true;
            controler.SetError(luEmpresa, isValid ? string.Empty : "Valor Obligatorio, Favor de Seleccionar");

            areValid &= isValid = luCliente.EditValue == null ? false : true;
            controler.SetError(luCliente, isValid ? string.Empty : "Valor Obligatorio, Favor de Seleccionar");

            areValid &= isValid = luObra.EditValue == null ? false : true;
            controler.SetError(luObra, isValid ? string.Empty : "Valor Obligatorio, Favor de Seleccionar");

            areValid &= isValid = string.IsNullOrEmpty(txtFolio.Text) ? false : true;
            controler.SetError(txtFolio, isValid ? string.Empty : "Valor Obligatorio, Favor de Seleccionar");

            areValid &= isValid = string.IsNullOrEmpty(importe) ? false : true;
            controler.SetError(txtImporte, isValid ? string.Empty : "Valor Obligatorio, Favor de Seleccionar");            

            int folio = Convert.ToInt32(txtFolio.Text);
            if ( Convert.ToInt32(luEmpresa.EditValue) == 1)
            {
                if (controler.Model.Factura.Where(f => f.FolioNum == folio && f.EmpresaId == 1).Count() > 0 && this.Text != "Facturas : Editar")
                {
                    areValid &= isValid = false;
                    controler.SetError(txtFolio, isValid ? string.Empty : "Folio Actualmente en Uso, No es posible Guardar.");
                    //new frmMessageBox(true) { Message = "Folio Actualmente en Uso, No es posible Guardar.", Title = "Aviso" }.ShowDialog();
                }
            }
            else
            {
                if (controler.Model.Factura.Where(f => f.FolioNum == folio && f.EmpresaId == 2).Count() > 0 && this.Text != "Facturas : Editar")
                {
                    areValid &= isValid = false;
                    controler.SetError(txtFolio, isValid ? string.Empty : "Folio Actualmente en Uso, No es posible Guardar.");
                    //new frmMessageBox(true) { Message = "Folio Actualmente en Uso, No es posible Guardar.", Title = "Aviso" }.ShowDialog();
                }
            }

            double _Importe;
            if (!double.TryParse(txtImporte.Text, out _Importe))
            {
                areValid &= isValid = false;
                controler.SetError(txtImporte, isValid ? string.Empty : "Importe, solo cantidades Numericas.");
                //new frmMessageBox(true) { Message = "Importe, solo cantidades Numericas.", Title = "Aviso" }.ShowDialog();
            }


            return areValid;            
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumeros(sender, e);
        }

        private void txtFolio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumeros(sender, e);
        }

        private void luEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (luEmpresa.IsLoading == false && luEmpresa.GetSelectedDataRow() != null && this.factura==null)
            {
                txtFolio.Text = getFolio().Value.ToString();
            }
        }
    }
}

