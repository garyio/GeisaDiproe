using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GeisaBD;
using System.Data.Common;
using Reportes;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Reporting.WinForms;

namespace SistemaGEISA
{
    public partial class frmContrareciboNew : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }

        public Contrarecibo contrarecibo { get; set; }

        private DataTable dt;

        public frmContrareciboNew(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        private void frmContrareciboNew_Load(object sender, EventArgs e)
        {
            dtFecha.EditValue = DateTime.Now;
            llenaCombos();
            llenaGrid();
           
            if (contrarecibo != null)
            {
                txtFolio.Text = contrarecibo.Folio.ToString();
                luProveedor.EditValue = contrarecibo.ProveedorId.HasValue ? contrarecibo.ProveedorId : contrarecibo.ClienteId;
                rgOpcion.EditValue = contrarecibo.Proveedor != null ? 2 : 1; 
                luEmpresa.EditValue = contrarecibo.EmpresaId;
                dtFecha.EditValue = contrarecibo.FechaRegistro;

                dtFechaPago.EditValue = contrarecibo.FechaPago.AddDays(contrarecibo.Proveedor != null ? ( contrarecibo.Proveedor.PlazoCredito.HasValue ? (int)contrarecibo.Proveedor.PlazoCredito : 0) : 0) ;
                obtenerFacturas();
            }
            else
            {
                int? folio = controler.Model.Contrarecibo.Select(C => C.Folio).DefaultIfEmpty(0).Max();
                txtFolio.Text = (folio + 1).ToString();
            }

            btnImprimir.Visible = contrarecibo != null;
        }

        #region Funciones
        private void llenaCombos()
        {
            if (this.contrarecibo == null)
            {
                luProveedor.Properties.DataSource = controler.Model.Proveedor.Where(D => D.Activo == true).ToList();
                luProveedor.Properties.DisplayMember = "NombreComercial";
                luProveedor.Properties.ValueMember = "Id";
                lblProveedor.Text = "Proveedor";
            }
            else
            {
                if (this.contrarecibo.ProveedorId.HasValue)
                {
                    luProveedor.Properties.DataSource = controler.Model.Proveedor.Where(D => D.Activo == true).ToList();
                    lblProveedor.Text = "Proveedor";
                }
                else
                {
                    luProveedor.Properties.DataSource = controler.Model.Cliente.Where(E => E.Activo == true).ToList();
                    lblProveedor.Text = "Cliente";
                }
                luProveedor.Properties.DisplayMember = "NombreComercial";
                luProveedor.Properties.ValueMember = "Id";
            }


            luEmpresa.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luEmpresa.Properties.DisplayMember = "NombreComercial";
            luEmpresa.Properties.ValueMember = "Id";
        }

        private void llenaGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("NoFactura", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Importe", typeof(double));
            dt.Columns.Add("ObraId", typeof(int));
            dt.Columns.Add("Observaciones", typeof(string));
            dt.Columns.Add("tipoComprobante", typeof(int)).DefaultValue = 1;
            //dt.Columns.Add("Saldo", typeof(double));
            
            //dt.Columns.Add("ContrareciboId", typeof(int));
            //dt.Columns.Add("ProveedorId", typeof(int));
            
            grid.DataSource = dt;

            luObra.DataSource = controler.Model.Obra.ToList();
            luObra.DisplayMember = "Nombre";
            luObra.ValueMember = "Id";
        }

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            areValid &= controler.CheckEmptyText(txtFolio);

            areValid &= isValid = luProveedor.GetSelectedDataRow() != null;
            controler.SetError(luProveedor, isValid ? string.Empty : "Seleccione un Proveedor");

            areValid &= isValid = luEmpresa.GetSelectedDataRow() != null;
            controler.SetError(luEmpresa, isValid ? string.Empty : "Seleccione una Empresa");

            if (areValid)
            {
                if (gv.DataRowCount==0)
                {
                    new frmMessageBox(true) { Message = "Favor de ingresar facturas al Contra Recibo.", Title = "Error" }.ShowDialog();
                    areValid &= false;
                }
            }

            try
            {
                int proveedorId = luProveedor.EditValue != null ? Convert.ToInt32(luProveedor.EditValue) : 0;
                for (int i = 0; i < gv.DataRowCount; i++)
                {
                    bool status = true;
                    DataRow row = gv.GetDataRow(i);

                    if (row != null && proveedorId != 0)
                    {
                        int folioContrarecibo = Convert.ToInt32(txtFolio.Text);
                        string folio = row["NoFactura"].ToString();
                        status = controler.Model.Contrarecibo.Include("Factura").Where(c => c.ProveedorId == proveedorId && (c.Factura.Where(f => f.NoFactura == folio).Count() > 0) && c.Folio != folioContrarecibo).Count() > 0 ? false : true;
                        if (status == false)
                        {
                            Contrarecibo recibo = controler.Model.Contrarecibo.Include("Factura").Where(c => c.ProveedorId == proveedorId && (c.Factura.Where(f => f.NoFactura == folio).Count() > 0)).SingleOrDefault();
                            new frmMessageBox(true) { Message = "Factura detectada en el Contrarecibo #" + recibo.Folio + " con el mismo Proveedor, Favor de Verificar.", Title = "Error" }.ShowDialog();
                            areValid = false;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            
            return areValid;
        }

        private int CrearFolio()
        {
            int valor = Convert.ToInt32(txtFolio.Text);

            Contrarecibo cr = controler.Model.Contrarecibo.FirstOrDefault(C => C.Folio == valor);

            while (cr != null)
            {
                valor += 1;
                cr = controler.Model.Contrarecibo.FirstOrDefault(C => C.Folio == valor);
            }

            return valor;
        }

        private void obtenerFacturas()
        {
            foreach (Factura serv in controler.Model.Factura.Where(D => D.ContrareciboId == contrarecibo.Id).ToList())
            {
                gv.AddNewRow();
                var newRowHandle = gv.FocusedRowHandle;

                gv.SetRowCellValue(newRowHandle, "Id", serv.Id);
                gv.SetRowCellValue(newRowHandle, "NoFactura", serv.NoFactura);
                gv.SetRowCellValue(newRowHandle, "Fecha", serv.Fecha);
                gv.SetRowCellValue(newRowHandle, "Importe", serv.Importe);
                gv.SetRowCellValue(newRowHandle, "ObraId", serv.ObraId);
                gv.SetRowCellValue(newRowHandle, "Observaciones", serv.Observaciones);
                gv.SetRowCellValue(newRowHandle, "tipoComprobante", serv.tipoComprobante);
                gv.UpdateCurrentRow();
                gv.RefreshData();
            }
        }

        private void imprimir()
        {
            try
            {
                List<ReportParameter> paramReport = new List<ReportParameter>();
                Empresa empresa = luEmpresa.GetSelectedDataRow() as Empresa;
                Proveedor prov = luProveedor.GetSelectedDataRow() as Proveedor;

                paramReport.Add(new ReportParameter("Folio", contrarecibo.Folio.ToString()));
                paramReport.Add(new ReportParameter("Proveedor", prov.NombreFiscal));
                paramReport.Add(new ReportParameter("Fecha", contrarecibo.FechaRegistro.ToShortDateString()));
                paramReport.Add(new ReportParameter("Empleado", contrarecibo.UsuarioLoaded.EmpleadoNombre));

                Image Logo = Funciones.ArrayAImage(empresa.Imagen);
                string strPathAppUser = string.Concat(Application.UserAppDataPath + "\\Logo.jpg");

                Logo.Save(strPathAppUser, System.Drawing.Imaging.ImageFormat.Jpeg);

                paramReport.Add(new ReportParameter("PathLogo", strPathAppUser));

                new frmPrint("Contrarecibos", new ReportDataSource { Name = "dsDatos", Value = new BindingSource { DataSource = new Contrarecibos(contrarecibo.Id).Items } }, paramReport).ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Controles
        private void luProveedor_EditValueChanged(object sender, EventArgs e)
        {
            Proveedor prov = luProveedor.GetSelectedDataRow() as Proveedor;
            if(prov!=null)
                if(prov.PlazoCredito!=null)
                    dtFechaPago.EditValue = Convert.ToDateTime(dtFecha.EditValue).AddDays(Convert.ToInt32(controler.GetObjectFromContext(luProveedor.GetSelectedDataRow() as Proveedor).PlazoCredito));            
                else
                    dtFechaPago.EditValue = Convert.ToDateTime(dtFecha.EditValue);
        }

        private void gv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            gv.ClearColumnErrors();
            DataRowView CurrentRow = (DataRowView)e.Row;
            for (int nColumn = 1; nColumn < CurrentRow.Row.ItemArray.Length - 1; nColumn++)
            {
                if (CurrentRow.Row[nColumn].ToString() == "" && nColumn!=4 && nColumn!=5)
                {
                    e.Valid = false;
                    gv.SetColumnError(gv.Columns[nColumn], "Este Campo no debe ser vacio");
                }
            }
        }

        private void gv_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        #endregion

        #region Botones
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            gv.CloseEditor();
            gv.UpdateCurrentRow();

            var error = string.Empty;
            var isNew = false;

            if (isValid())
            {
                DbTransaction transaccion = null;

                try
                {
                    transaccion = controler.Model.BeginTransaction();

                    if (contrarecibo == null)
                    {
                        contrarecibo = new Contrarecibo();
                        contrarecibo.Folio = CrearFolio();
                        isNew = true;
                    }

                    contrarecibo.FechaRegistro = (DateTime)dtFecha.EditValue;
                    contrarecibo.FechaPago = (DateTime)dtFechaPago.EditValue;
                    contrarecibo.UsuarioId = frmPrincipal.UsuarioDelSistema.Id;
                    if ((Int32)rgOpcion.EditValue == 1)
                    {
                        contrarecibo.Cliente = controler.GetObjectFromContext(luProveedor.GetSelectedDataRow() as Cliente);
                        contrarecibo.Proveedor = null; // no puede tener valor en proveedor y cliente a la ves, debe ser uno u otro
                    }
                    else
                    {
                        contrarecibo.Proveedor = controler.GetObjectFromContext(luProveedor.GetSelectedDataRow() as Proveedor);
                        contrarecibo.Cliente = null; // no puede tener valor en proveedor y cliente a la ves, debe ser uno u otro
                    }
                    contrarecibo.Empresa = controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa);

                    bool camposPendientes = false;
                    for (int i = 0; i < gv.RowCount; i++)
                    {
                        DataRow row = gv.GetDataRow(i);
                        if (row != null)
                        {
                            if (camposPendientes == false)
                            {
                                camposPendientes = string.IsNullOrEmpty(row["ObraId"].ToString());
                                if (camposPendientes)
                                    break;
                            }
                        }
                    }
                    contrarecibo.pendienteCampos = camposPendientes;
                    if (!contrarecibo.NoEsNuevo) controler.Model.AddToContrarecibo(contrarecibo);

                    Factura factura = null;

                    
                    for (int i = 0; i < gv.RowCount; i++)
                    {
                        DataRow row = gv.GetDataRow(i);

                        if (row != null)
                        {
                            
                            if (!Convert.IsDBNull(row["Id"]))
                            {
                                var id = Convert.ToInt32(row["Id"]);
                                factura = controler.Model.Factura.Where(D => D.Id == id).FirstOrDefault();
                            }
                            else
                            {
                                factura = new Factura();
                            }

                            factura.NoFactura = row["NoFactura"].ToString().ToUpper();
                            factura.Fecha = Convert.ToDateTime(row["Fecha"]);
                            factura.Importe = Convert.ToDouble(row["Importe"]);
                            //factura.Saldo = Convert.ToDouble(row["Importe"]);
                            factura.Saldo = getSaldoFactura(factura, Convert.ToDouble(row["Importe"]));
                            factura.Observaciones = row["Observaciones"].ToString().ToUpper();
                            factura.Contrarecibo = contrarecibo;

                            if ((Int32)rgOpcion.EditValue == 1)
                            {
                                factura.Cliente = controler.GetObjectFromContext(luProveedor.GetSelectedDataRow() as Cliente);
                                factura.Proveedor = null; // no puede tener valor en proveedor y cliente a la ves, debe ser uno u otro
                            }
                            else
                            {
                                factura.Proveedor = controler.GetObjectFromContext(luProveedor.GetSelectedDataRow() as Proveedor);
                                factura.Cliente = null; // no puede tener valor en proveedor y cliente a la ves, debe ser uno u otro
                            }
                            
                            //factura.Proveedor = controler.GetObjectFromContext(luProveedor.GetSelectedDataRow() as Proveedor);
                            factura.ObraId = string.IsNullOrEmpty(row["ObraId"].ToString()) ? (int?)null : Convert.ToInt32(row["ObraId"]);
                            factura.tipoComprobante = Convert.ToInt32(string.IsNullOrEmpty(row["tipoComprobante"].ToString()) ? 1 : Convert.ToInt32(row["tipoComprobante"]));
                            if (!factura.NoEsNuevo) controler.Model.AddToFactura(factura);
                        }
                    }

                    controler.Model.SaveChanges();
                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    if (isNew) contrarecibo = null;
                    if (transaccion != null) transaccion.Rollback();
                    error = ex.InnerException.Message;
                }
                finally
                {
                    controler.Model.CloseConnection();

                    var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                    var message = string.Empty;

                    if (!isNew)
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Contra Recibo ha sido actualizado exitosamente.") : string.Concat("No se pudo actualizar el Contra Recibo:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Contra Recibo ha sido generado exitosamente.") : string.Concat("No se pudo generar el Contra Recibo:\n", error);
                    }

                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                }

                if (string.IsNullOrEmpty(error))
                {
                    imprimir();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void actualizaPagosFactura(Factura factura, double importe)
        {
            if (factura != null)
            {
                if (factura.Id != 0)
                {
                    PagosFactura pagoFactura = controler.Model.PagosFactura.Where(F => F.FacturaId == factura.Id).OrderBy(O => O.Id).FirstOrDefault();
                    pagoFactura.SaldoActual = importe;
                }
            }
        }

        private double getSaldoFactura(Factura factura, double Importe)
        {
            if(factura!=null)
            {
                if(factura.Id!=0 && factura.PagosFactura.Count() > 0)
                    actualizaPagosFactura(factura,Importe);
                return Importe - controler.Model.getAbonosTotales(factura.Id, 0).Select(A => A.MontoPagar).DefaultIfEmpty(0).Sum().Value; 
            }
            else
                return Importe;            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar esta factura?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                DataRow row = gv.GetFocusedDataRow() as DataRow;

                if (row != null)
                {
                    Factura factura = null;
                    
                    if (!Convert.IsDBNull(row["Id"]))
                    {
                        var id = Convert.ToInt32(row["Id"]);

                        int num = controler.Model.PagosFactura.Where(P => P.FacturaId == id).ToList().Count();

                        if (num == 0)
                        {
                            factura = controler.Model.Factura.Where(D => D.Id == id).FirstOrDefault();
                            controler.Model.DeleteObject(factura);
                            gv.DeleteRow(gv.FocusedRowHandle); 
                        }
                        else
                            new frmMessageBox(true) { Message = "Esta factura ya tiene pagos asignados.", Title = "Advertencia" }.ShowDialog();
                    }
                    else
                        gv.DeleteRow(gv.FocusedRowHandle);
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimir();
        }
        #endregion

        private void rgOpcion_EditValueChanged(object sender, EventArgs e)
        {
                if ((int)rgOpcion.EditValue == 1)
                {
                    luProveedor.Properties.DataSource = controler.Model.Cliente.Where(D => D.Activo == true).ToList();
                    luProveedor.Properties.DisplayMember = "NombreFiscal";
                    luProveedor.Properties.ValueMember = "Id";
                    lblProveedor.Text = "Cliente";
                    luProveedor.EditValue = this.contrarecibo != null ? contrarecibo.ClienteId : null;
                }
                else
                {
                    luProveedor.Properties.DataSource = controler.Model.Proveedor.Where(D => D.Activo == true).ToList();
                    luProveedor.Properties.DisplayMember = "NombreComercial";
                    luProveedor.Properties.ValueMember = "Id";
                    lblProveedor.Text = "Proveedor";
                    luProveedor.EditValue = this.contrarecibo != null ? contrarecibo.ProveedorId : null;
                }
        }
    }
}
