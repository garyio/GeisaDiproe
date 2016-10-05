using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GeisaBD;
using System.Data.Common;
using Reportes;
using Microsoft.Reporting.Common;
using Microsoft.Reporting.WinForms;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing;

namespace SistemaGEISA
{
    public partial class frmOrdenesDetalle : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }

        DataTable dt;

        string estadoOrden = string.Empty;

        private int? folio;

        public Iva iva;

        public Ordenes orden { get; set; }

        int tipoOrden;

        public bool tienePermisoAgregar, tienePermisoCancelar, tienePermisoModificar;

        public frmOrdenesDetalle(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        private void verificaCancelados()
        {
            if (orden != null)
                if (orden.FechaCancelacion != null)
                {                    
                    lblCancelada.Visible = true;
                    //foreach (Control c in Controls)
                    //{                        
                    //    c.Enabled = false;
                    //}
                    btnImprimir.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnCancelar.Enabled = false;
                    grid.Enabled = false;
                }
        }

        private void frmOrdenesDetalle_Load(object sender, EventArgs e)
        {
            IniGrid();
            llenaCombos();
            verificaCancelados();

            if (orden != null)
            {
                this.folio = orden.Folio.Value;
                txtFolio.Text = orden.FolioCompleto;
                dtFecha.EditValue = orden.Fecha;
                luSolicitadoPor.EditValue = orden.EmpleadoId;
                luObra.EditValue = orden.ObraId;
                txtObservaciones.Text = orden.Observaciones;
                if (orden.TipoMovimientoId == TipoMovimientoEnum.OrdenCompra.Id)
                    rgTipoMovimiento.EditValue = 1;
                else
                    rgTipoMovimiento.EditValue = 2;
                luEmpresa.EditValue = orden.EmpresaId;
                luProveedor.EditValue = orden.ProveedorId;
                luCompradoPor.EditValue = orden.CompradorId;
                txtLugarEntrega.Text = orden.LugarEntrega;

                foreach (DetalleArticulos serv in orden.DetalleArticulos.ToList())
                {
                    gv.AddNewRow();

                    var rowHandle = gv.GetRowHandle(gv.DataRowCount);
                    Articulos art;
                    if (serv.ArticuloId > 0)
                        art = controler.Model.Articulos.FirstOrDefault(A => A.Id == serv.ArticuloId);
                    else
                        art = null;

                    gv.SetRowCellValue(rowHandle, gv.Columns["Id"], serv.Id);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Estado"], serv.Estado);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Concepto"], serv.ArticuloId);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Unidad"], serv.UnidadId);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Cantidad"], serv.Cantidad);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Costo"], serv.Costo);
                    if (art != null)
                        gv.SetRowCellValue(rowHandle, gv.Columns["existenciaTotal"], art.existenciaTotal);

                    gv.UpdateCurrentRow();
                    gv.RefreshData();
                }
                iva = orden.Iva;
                rgTipoMovimiento.Properties.ReadOnly = true;
            }
            else
            {
                //valores por defecto
                dtFecha.EditValue = DateTime.Today;
                luEmpresa.EditValue = TipoEmpresa.GEISA.Id;
                rgTipoMovimiento.EditValue = 1;
                //llenaFolio();
                iva = controler.Model.Iva.FirstOrDefault(i => i.FechaFin == null);
            }

            if (iva != null)
                txtIva.Text = (iva.Iva1 * 100).ToString();
            else
            {
                new frmMessageBox(true) { Message = "Error al Obtener el Iva. ", Title = "Error" }.ShowDialog();
                txtIva.Text = "16";
            }


        }

        private void llenaFolio()
        {
            if (orden == null)
            {
                if (luEmpresa.EditValue == null || rgTipoMovimiento.EditValue == null)
                    txtFolio.Text = "N/A";
                else
                {
                    //int? folio;
                    //int tipoOrden = Convert.ToInt32(rgTipoMovimiento.EditValue);
                    int empresaId = Convert.ToInt32(luEmpresa.EditValue);
                    if (tipoOrden == 1)
                        folio = controler.Model.Ordenes.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.OrdenCompra.Id).Select(P => P.Folio).DefaultIfEmpty(0).Max();
                    else
                        folio = controler.Model.Ordenes.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.SalidaAlmacen.Id).Select(P => P.Folio).DefaultIfEmpty(0).Max();

                    folio = folio == null || folio == 0 ? 1 : folio.Value + 1;
                    txtFolio.Text = (empresaId == TipoEmpresa.GEISA.Id ? "G" : "D") + (tipoOrden == 1 ? "OC" : "SA") + "-" + folio.Value.ToString() + "-" + DateTime.Now.Year.ToString().Substring(2, 2).ToString();
                }
            }
        }


        private void IniGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Concepto", typeof(string));
            dt.Columns.Add("Unidad", typeof(Int32));
            dt.Columns.Add("Cantidad", typeof(double));
            dt.Columns.Add("Costo", typeof(double));
            dt.Columns.Add("Importe", typeof(double));
            dt.Columns.Add("Estado", typeof(int));
            dt.Columns.Add("existenciaTotal", typeof(double));
            grid.DataSource = dt;
        }

        private void llenaCombos()
        {
            luObra.Properties.DataSource = controler.Model.Obra.ToList();
            luObra.Properties.DisplayMember = "Nombre";
            luObra.Properties.ValueMember = "Id";

            luEmpresa.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luEmpresa.Properties.DisplayMember = "NombreComercial";
            luEmpresa.Properties.ValueMember = "Id";

            luProveedor.Properties.DataSource = controler.Model.Proveedor.Where(D => D.Activo == true).ToList();
            luProveedor.Properties.DisplayMember = "NombreComercial";
            luProveedor.Properties.ValueMember = "Id";

            luCompradoPor.Properties.DataSource = controler.Model.Empleado.Where(D => D.Activo == true).ToList();
            luCompradoPor.Properties.DisplayMember = "NombreCompleto";
            luCompradoPor.Properties.ValueMember = "Id";

            luSolicitadoPor.Properties.DataSource = controler.Model.Empleado.Where(D => D.Activo == true).ToList();
            luSolicitadoPor.Properties.DisplayMember = "NombreCompleto";
            luSolicitadoPor.Properties.ValueMember = "Id";

            luUnidad.DataSource = controler.Model.UnidadMedida.Where(D => D.Activo == true).ToList();
            luUnidad.DisplayMember = "Nombre";
            luUnidad.ValueMember = "Id";

            luArticulos.DataSource = controler.Model.Articulos.Where(D => D.Activo == true).ToList();
            luArticulos.DisplayMember = "Descripcion";
            luArticulos.ValueMember = "Id";

            DataTable dtEstatus = new DataTable();
            dtEstatus.Columns.Add("Id", typeof(int));
            dtEstatus.Columns.Add("Estatus", typeof(string));
            dtEstatus.Rows.Add(new object[] { 1, "ENTREGADO" });
            dtEstatus.Rows.Add(new object[] { 2, "EN CURSO" });
            dtEstatus.Rows.Add(new object[] { 3, "POR ENTREGAR" });
            luEstatus.DataSource = dtEstatus.DefaultView;
            luEstatus.ValueMember = "Id";
            luEstatus.DisplayMember = "Estatus";
        }

        private void gv_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Costo" || e.Column.FieldName == "Cantidad")
            {
                double Cantidad = 0;
                double costo = 0;

                if (!string.IsNullOrEmpty(gv.GetRowCellValue(e.RowHandle, "Costo").ToString()))
                {
                    costo = Convert.ToDouble(gv.GetRowCellValue(e.RowHandle, "Costo"));
                }
                if (!string.IsNullOrEmpty(gv.GetRowCellValue(e.RowHandle, "Cantidad").ToString()))
                {
                    Cantidad = Convert.ToDouble(gv.GetRowCellValue(e.RowHandle, "Cantidad"));
                }
                if (Cantidad > 0)
                {
                    gv.SetRowCellValue(e.RowHandle, gv.Columns["Importe"], costo * Cantidad);
                }
                else
                {
                    //new frmMessageBox(true)
                    //{
                    //    Message = "La Cantidad debe ser mayor a 0.",
                    //    Title = "Error"
                    //}.ShowDialog();
                    gv.SetRowCellValue(e.RowHandle, gv.Columns["Importe"], costo);
                }
                gv_RowUpdated(null, null);

            }
            else if (e.Column.FieldName == "Concepto")
            {
                var idArticulo = (gv.GetRowCellValue(e.RowHandle, "Concepto") != null ? Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, "Concepto")) : (int?)null);
                Articulos articulo = idArticulo != null ? controler.Model.Articulos.FirstOrDefault(A => A.Id == idArticulo) : null;
                gv.SetRowCellValue(e.RowHandle, gv.Columns["Unidad"], articulo != null ? articulo.UnidadId : -1);
                gv.SetRowCellValue(e.RowHandle, gv.Columns["Costo"], articulo != null ? articulo.PrecioCompra : 0);
                gv.SetRowCellValue(e.RowHandle, gv.Columns["existenciaTotal"], controler.Model.Articulos.FirstOrDefault(A => A.Id == idArticulo).existenciaTotal);
                gv.GetRowCellValue(e.RowHandle, "existenciaTotal");
                gv_RowUpdated(null, null);
            }

        }

        private void gv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn colId = view.Columns["Id"];
            GridColumn colConcepto = view.Columns["Concepto"];
            GridColumn colUnidad = view.Columns["Unidad"];
            GridColumn colCantidad = view.Columns["Cantidad"];
            GridColumn colCosto = view.Columns["Costo"];
            GridColumn colImporte = view.Columns["Importe"];
            view.ClearColumnErrors();

            string t_Concepto = view.GetRowCellValue(e.RowHandle, colConcepto).ToString();
            if (string.IsNullOrEmpty(t_Concepto))
            { e.Valid = false; view.SetColumnError(colConcepto, "Ingresar un Valor Valido."); }
            else { e.Valid = true; view.ClearColumnErrors(); }

            string estatus = view.GetRowCellValue(e.RowHandle, colEstatus).ToString();
            if (string.IsNullOrEmpty(estatus))
            { e.Valid = false; view.SetColumnError(colEstatus, "Ingresar un Valor Valido."); }
            else { e.Valid = true; }

            string unidad = view.GetRowCellValue(e.RowHandle, colUnidad).ToString();
            if (string.IsNullOrEmpty(unidad))
            { e.Valid = false; view.SetColumnError(colUnidad, "Ingresar un Valor Valido."); }
            else { e.Valid = true; }

            double cantidad;
            double.TryParse(view.GetRowCellValue(e.RowHandle, colCantidad).ToString(), out cantidad);
            if (cantidad == 0)
            { e.Valid = false; view.SetColumnError(colCantidad, "Ingresar un Valor Valido."); }
            else { e.Valid = true; }

            double costo;
            double.TryParse(view.GetRowCellValue(e.RowHandle, colCosto).ToString(), out costo);
            if (costo < 0 || string.IsNullOrEmpty(costo.ToString()))
            { e.Valid = false; view.SetColumnError(colCosto, "Ingresar un Valor Valido."); }
            else { e.Valid = true; }

            double importe;
            double.TryParse(view.GetRowCellValue(e.RowHandle, colImporte).ToString(), out importe);
            if (importe < 0 || string.IsNullOrEmpty(importe.ToString()))
            { e.Valid = false; view.SetColumnError(colImporte, "Ingresar un Valor Valido."); }
            else { e.Valid = true; }

        }

        private void gv_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gv_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            int entregado = 0, enCurso = 0, porEntregar = 0;
            int filas = 0;
            double total = 0;

            for (int i = 0; i < gv.RowCount; i++)
            {
                DataRow row = gv.GetDataRow(i);

                if (row != null)
                {
                    filas++;
                    total += Convert.ToDouble(row["Importe"].ToString());
                    if (Convert.ToInt32(row["Estado"].ToString()) == 1)
                        entregado++;
                    else if (Convert.ToInt32(row["Estado"].ToString()) == 2)
                        enCurso++;
                    else
                        porEntregar++;

                }
            }

            if (entregado == filas)
                estadoOrden = "ENTREGADO";
            //else if (enCurso > 1)
            //    estadoOrden = "EN CURSO";
            else
                estadoOrden = "POR ENTREGAR";

            double ivaAmount = total * (iva == null ? (0.16) : (iva.Iva1.Value));
            txtImporte.Text = (total + ivaAmount).ToString("C2");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var form = new frmArticulosNew(this.controler);
            form.Text = "Articulo : Nuevo";
            form.articulo = null;
            form.ShowDialog();
            controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, controler.Model.Articulos.ToList());

            luArticulos.DataSource = controler.Model.Articulos.Where(D => D.Activo == true).ToList();
            luArticulos.DisplayMember = "Descripcion";
            luArticulos.ValueMember = "Id";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmMessageBox confirm = new frmMessageBox(false);
            confirm.Title = "Confirmación";
            confirm.Message = "¿Desea cancelar la Orden?";
            confirm.ShowDialog();
            if (confirm.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                string error = string.Empty;

                DbTransaction transaccion = null;

                try
                {
                    if (orden != null)
                    {
                        transaccion = controler.Model.BeginTransaction();
                        orden.FechaCancelacion = DateTime.Today;

                        controler.Model.SaveChanges();
                        transaccion.Commit();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    if (transaccion != null) transaccion.Rollback();
                    error = ex.InnerException.Message;
                }
                finally
                {
                    controler.Model.CloseConnection();

                    var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                    var message = string.Empty;

                    message = string.IsNullOrEmpty(error) ? string.Concat("La Orden ha sido cancelada exitosamente.") : string.Concat("No se pudo cancelar la Orden:\n", error);
                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                }

                if (string.IsNullOrEmpty(error))
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void rgTipoMovimiento_EditValueChanged(object sender, EventArgs e)
        {
            tipoOrden = Convert.ToInt32(rgTipoMovimiento.EditValue);
            llenaFolio();

            if (tipoOrden == 2)
            {
                luProveedor.Visible = false;
                lblProveedor.Visible = false;
            }
            else
            {
                luProveedor.Visible = true;
                lblProveedor.Visible = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

            gv.CloseEditor();
            gv.CloseEditForm();

            if (isValid())
            {
                DbTransaction transaccion = null;
                try
                {
                    transaccion = controler.Model.BeginTransaction();
                    if (orden == null)
                    {
                        orden = new Ordenes();
                        isNew = true;
                        llenaFolio();
                        orden.Folio = this.folio.Value; 
                    }
                    orden.FolioCompleto = txtFolio.Text;                
                    orden.Fecha = (DateTime)dtFecha.EditValue;
                    orden.FechaRegistro = DateTime.Today;
                    orden.EmpresaId = controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa).Id;
                    orden.ProveedorId = controler.GetObjectFromContext(luProveedor.GetSelectedDataRow() as Proveedor).Id;
                    orden.EmpleadoId = controler.GetObjectFromContext(luSolicitadoPor.GetSelectedDataRow() as Empleado).Id;
                    orden.CompradorId = controler.GetObjectFromContext(luCompradoPor.GetSelectedDataRow() as Empleado).Id;
                    orden.LugarEntrega = txtLugarEntrega.Text.ToUpper().Trim();
                    orden.Observaciones = txtObservaciones.Text.ToUpper().Trim();
                    orden.Total = double.Parse(txtImporte.Text, NumberStyles.Currency);
                    orden.EstadoOrden = this.estadoOrden;

                    if (Convert.ToInt32(rgTipoMovimiento.EditValue) == 1)
                        orden.TipoMovimientoId = TipoMovimientoEnum.OrdenCompra.Id;
                    else
                        orden.TipoMovimientoId = TipoMovimientoEnum.SalidaAlmacen.Id;
                    orden.Iva = this.iva;
                    orden.ObraId = controler.GetObjectFromContext(luObra.GetSelectedDataRow() as Obra).Id;
                    if (!orden.NoEsNuevo) controler.Model.AddToOrdenes(orden);

                    DetalleArticulos detalle = null;

                    for (int i = 0; i < gv.RowCount; i++)
                    {
                        DataRow row = gv.GetDataRow(i);

                        if (row != null)
                        {
                            var id = (int?)null;
                            if (string.IsNullOrEmpty(row["Id"].ToString()))
                            {
                                detalle = new DetalleArticulos();
                                id = (int?)null;

                            }
                            else
                            {
                                id = Convert.ToInt32(row["Id"].ToString());
                                detalle = !isNew ? controler.Model.DetalleArticulos.FirstOrDefault(D => D.Id == id) : null;
                            }

                            detalle.ArticuloId = string.IsNullOrEmpty(row["Concepto"].ToString())? Convert.ToInt32((int?)null) : Convert.ToInt32(row["Concepto"]);
                            detalle.Cantidad = string.IsNullOrEmpty(row["Cantidad"].ToString()) ? Convert.ToDouble((double?)null) : Convert.ToDouble(row["Cantidad"]);
                            detalle.Estado = string.IsNullOrEmpty(row["Estado"].ToString()) ? Convert.ToInt32((int?)null) : Convert.ToInt32(row["Estado"]);
                            detalle.UnidadId = string.IsNullOrEmpty(row["Unidad"].ToString()) ? Convert.ToInt32((int?)null) : Convert.ToInt32(row["Unidad"]);
                            detalle.Costo = string.IsNullOrEmpty(row["Costo"].ToString()) ? Convert.ToInt32((int?)null) : Convert.ToDouble(row["Costo"]);
                            detalle.Ordenes = this.orden;


                            if (!detalle.NoEsNuevo) controler.Model.AddToDetalleArticulos(detalle);

                        }
                    }

                    controler.Model.SaveChanges();
                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    if (isNew) orden = null;
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
                        message = string.IsNullOrEmpty(error) ? string.Concat("La Orden ha sido actualizada exitosamente.") : string.Concat("No se pudo actualizar la Orden:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("La Orden ha sido generado exitosamente.") : string.Concat("No se pudo generar el Pago:\n", error);
                    }

                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                }


            }

            if (string.IsNullOrEmpty(error))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;


            areValid &= isValid = gv.DataRowCount > 0 ? true : false;
            controler.SetError(grid, isValid ? string.Empty : "Favor de Ingresar al menos 1 Articulo.");

            areValid &= isValid = rgTipoMovimiento.EditValue != null ? true : false;
            controler.SetError(rgTipoMovimiento, isValid ? string.Empty : "Seleccione un tipo de Orden");

            if (tipoOrden == 1)
            {
                areValid &= isValid = luProveedor.EditValue != null ? true : false;
                controler.SetError(luProveedor, isValid ? string.Empty : "Seleccione un Proveedor");
            }

            areValid &= isValid = luEmpresa.EditValue != null ? true : false;
            controler.SetError(luEmpresa, isValid ? string.Empty : "Seleccione una Empresa");

            areValid &= isValid = luSolicitadoPor.EditValue != null ? true : false;
            controler.SetError(luSolicitadoPor, isValid ? string.Empty : "Seleccione un Empleado");

            areValid &= isValid = luCompradoPor.EditValue != null ? true : false;
            controler.SetError(luCompradoPor, isValid ? string.Empty : "Seleccione un Empleado");

            areValid &= isValid = luCompradoPor.EditValue != null ? true : false;
            controler.SetError(luCompradoPor, isValid ? string.Empty : "Seleccione una Comprador");

            areValid &= isValid = gv.HasColumnErrors ? false : true;
            controler.SetError(grid, isValid ? string.Empty : "No es posible Guardar con Errores");

            return areValid;
        }


        private void gv_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gv.SetRowCellValue(e.RowHandle, gv.Columns["Estado"], 3);
            gv.SetRowCellValue(e.RowHandle, gv.Columns["Cantidad"], 1);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (isValid() && orden!=null)
            {
                try
                {
                    List<ReportParameter> paramReport = new List<ReportParameter>();
                    Empresa empresa = luEmpresa.GetSelectedDataRow() as Empresa;
                    Proveedor prov = luProveedor.GetSelectedDataRow() as Proveedor;
                    Obra obra = luObra.GetSelectedDataRow() as Obra;
                    Empleado comprador = luCompradoPor.GetSelectedDataRow() as Empleado;
                    Empleado solicito = luSolicitadoPor.GetSelectedDataRow() as Empleado;

                    paramReport.Add(new ReportParameter("Fecha", Convert.ToDateTime(dtFecha.EditValue).ToShortDateString()));
                    paramReport.Add(new ReportParameter("Empresa", empresa.NombreFiscal.ToUpper()));
                    paramReport.Add(new ReportParameter("EmpresaDireccion", "DOM: " + empresa.Direccion.ToUpper() + "\n" + "CP: " + empresa.Domicilio.CodigoPostal + "  " + empresa.Ciudad + "\n" + "TEL: " + empresa.Telefono + "\n" + "RFC: " + empresa.RFC));
                    paramReport.Add(new ReportParameter("Proveedor", prov.NombreFiscal.ToUpper()));
                    paramReport.Add(new ReportParameter("Folio", txtFolio.Text));
                    paramReport.Add(new ReportParameter("TipoOrden", this.tipoOrden == 1 ? "ORDEN DE COMPRA" : "SALIDA DE ALMACEN"));
                    paramReport.Add(new ReportParameter("Obra", obra.Nombre.ToUpper()));
                    paramReport.Add(new ReportParameter("ProveedorDireccion", prov.Direccion.ToUpper()));
                    paramReport.Add(new ReportParameter("Comprador", comprador.NombreCompleto.ToUpper()));
                    paramReport.Add(new ReportParameter("SolicitadoPor", solicito.NombreCompleto.ToUpper()));
                    paramReport.Add(new ReportParameter("Observaciones", txtObservaciones.Text.ToUpper()));
                    paramReport.Add(new ReportParameter("LugarEntrega", txtLugarEntrega.Text.ToUpper()));
                    paramReport.Add(new ReportParameter("Cancelada", orden.FechaCancelacion != null ? orden.FechaCancelacion.Value.ToShortDateString():""));

                    if (empresa.Imagen != null)
                    {
                        Image Logo = Funciones.ArrayAImage(empresa.Imagen);
                        string strPathAppUser = string.Concat(Application.UserAppDataPath + "\\Logo.jpg");
                        Logo.Save(strPathAppUser, System.Drawing.Imaging.ImageFormat.Jpeg);
                        paramReport.Add(new ReportParameter("PathLogo", strPathAppUser));
                    }
                    else
                    {
                        paramReport.Add(new ReportParameter("PathLogo", string.Empty));
                    }
                   

                    new frmPrint("Ordenes", new ReportDataSource { Name = "dsOrdenes", Value = new BindingSource { DataSource = new OrdenesReporte(orden.Id).items } }, paramReport).ShowDialog();
                }
                catch (Exception ex)
                {
                    frmMessageBox confirm = new frmMessageBox(true);
                    confirm.Title = "Error";
                    confirm.Message = "No se Pudo Generar el Reporte,Favor de Verificar los Valores.";
                    confirm.ShowDialog();
                }
            }
        }

        private void gv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                frmMessageBox confirm = new frmMessageBox(false);
                confirm.Title = "Confirmación";
                confirm.Message = "¿Desea Eliminar el Articulo de la Orden?";
                confirm.ShowDialog();
                if (confirm.DialogResult == System.Windows.Forms.DialogResult.No)
                return;
                //if (MessageBox.Show("Eliminar Registro?", "Confirmación", MessageBoxButtons.YesNo) != DialogResult.Yes)
                //    return;
                GridView view = sender as GridView;
                DataRow row = gv.GetDataRow(gv.FocusedRowHandle);
                if (row != null)
                {
                    if (string.IsNullOrEmpty(row["Id"].ToString()))
                    {
                        //eliminar el row del detalleArticulo
                        view.DeleteRow(view.FocusedRowHandle);
                    }
                    else
                    {
                        //Eliminar desde la bd el detalleArticulo
                        eliminarDetalleArticulo(Convert.ToInt32(row["Id"]));
                    }
                }
                
            }
            gv_RowUpdated(null, null);
        }

        private void eliminarDetalleArticulo(int idDetalle)
        {
            DetalleArticulos detalleArticulo = controler.Model.DetalleArticulos.FirstOrDefault(A => A.Id == idDetalle);

            if (detalleArticulo != null)
            {
                DbTransaction transaccion = null;

                try
                {
                    transaccion = controler.Model.BeginTransaction();
                    controler.Model.DeleteObject(detalleArticulo);
                    
                    controler.Model.SaveChanges();
                    transaccion.Commit();
                    new frmMessageBox(true) { Message = "El articulo se Elimino Exitosamente.", Title = "Aviso" }.ShowDialog();
                    gv.DeleteRow(gv.FocusedRowHandle);
                }
                catch (Exception ex)
                {
                    new frmMessageBox(true) { Message = "Error al quitar el Articulo: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                    if (transaccion != null) transaccion.Rollback();
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "No es posible eliminar este Articulo.", Title = "Error" }.ShowDialog();
            }

            controler.Model.CloseConnection();
        }
    }
}