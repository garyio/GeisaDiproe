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
using System.Data.Common;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using SistemaGEISA.Movimientos;
using DevExpress.XtraGrid.Views.Base;
using System.IO;

namespace SistemaGEISA
{
    public partial class frmComprobante : XtraForm
    {
        private double nominas_tot = 0, nodeducibles_tot = 0, biaticos_tot = 0, facturas_tot = 0, devolucion_tot = 0;
        public Controler controler { get; set; }
        public Empleado empleado { get; set; }
        public CajaChica cajaChica { get; set; }
        public CajaChicaDetalle cajaDetalle { get; set; }
        public Factura factura { get; set; }
        public CajaChicaComprobante cajaComprobante { get; set; }

        DataTable dt;
        
        public frmComprobante(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        public void limpiar()
        {
            txtNominas.Text = "";
            txtFacturas.Text = "";
            txtNoDeducibles.Text = "";
            txtObservaciones.Text = "";
            txtBiaticos.Text = "";
        }
        
        private void llenaGridF()
        {

            //if (objetos == null)
            //{
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("TipoComprobanteId", typeof(int));
            dt.Columns.Add("Folio", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Importe", typeof(double));
            dt.Columns.Add("ObraId", typeof(int));
            dt.Columns.Add("ProveedorId", typeof(int));
            dt.Columns.Add("Observaciones", typeof(string));
            
            luTipoComprobante.DataSource = controler.Model.TipoComprobante.ToList();
            luTipoComprobante.DisplayMember = "Comprobante";
            luTipoComprobante.ValueMember = "Id";

            luObraComprobante.DataSource = controler.Model.Obra.ToList();
            luObraComprobante.DisplayMember = "Nombre";
            luObraComprobante.ValueMember = "Id";

            luProveedor.DataSource = controler.Model.Proveedor.ToList();
            luProveedor.DisplayMember = "NombreFiscal";
            luProveedor.ValueMember = "Id";

            grid.DataSource = dt;
        }

        private void frmComprobante_Load(object sender, EventArgs e)
        {
            llenaGridF();

            if (cajaDetalle != null)
                llenaComprobantes();
            //llenaObra();
        }

        private void llenaComprobantes()
        {
            foreach (CajaChicaComprobante c in cajaDetalle.CajaChicaComprobante.ToList())
            {
                gv.AddNewRow();
                int rowHandle = gv.GetRowHandle(gv.DataRowCount);
                //if (gv.IsNewItemRow(rowHandle))
                //{
                    //c.Id, c.TipoComprobanteId, c.Folio, c.Fecha, c.Importe, c.ObraId, c.ProveedorId, c.Observaciones);
                    gv.SetRowCellValue(rowHandle, gv.Columns[0], c.Id);
                    gv.SetRowCellValue(rowHandle, gv.Columns[1], c.TipoComprobanteId);
                    gv.SetRowCellValue(rowHandle, gv.Columns[2], c.Folio);
                    gv.SetRowCellValue(rowHandle, gv.Columns[3], c.Fecha);
                    gv.SetRowCellValue(rowHandle, gv.Columns[4], c.Importe);
                    gv.SetRowCellValue(rowHandle, gv.Columns[5], c.ObraId);
                    gv.SetRowCellValue(rowHandle, gv.Columns[6], c.ProveedorId);
                    gv.SetRowCellValue(rowHandle, gv.Columns[7], c.Observaciones);
                //}

                    gv.UpdateCurrentRow();
                    gv.RefreshData();
            }

            if (cajaDetalle != null) txtObservaciones.Text = cajaDetalle.Observaciones;
        }

        private bool gridValido()
        {

            bool isValid = true;
            for (int i = 0; i < gv.RowCount; i++)
            {
                DataRow row = gv.GetDataRow(i);
                if (row != null)
                {
                    isValid = gv.IsValidRowHandle(i);
                    if (!isValid) return isValid;
                }

            }
            return isValid = gv.DataRowCount > 0 ? true : false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;


            if (!gridValido()) 
            { 
                new frmMessageBox(true) { Message = "Valores no Validos, Valor de Verificar.", Title = "Advertencia" }.ShowDialog();
                return;
            }
            DbTransaction transaccion = null;
            try
            {
                transaccion = controler.Model.BeginTransaction();

                if (cajaDetalle == null)
                {
                    cajaDetalle = new CajaChicaDetalle();
                    isNew = true;
                }

                cajaDetalle.Fecha = Convert.ToDateTime(dtimeFecha.Value.ToShortDateString());
                cajaDetalle.Nominas = nominas_tot;
                cajaDetalle.Facturas = facturas_tot;
                cajaDetalle.Biaticos = biaticos_tot;
                cajaDetalle.NoDeducibles = nodeducibles_tot;
                cajaDetalle.Devolucion = devolucion_tot;
                cajaDetalle.Observaciones = txtObservaciones.Text.ToUpper();
                cajaDetalle.CajaChica = controler.GetObjectFromContext(cajaChica);
                cajaDetalle.ObservacionesConcatenadas = getObservaciones();

                if (!cajaDetalle.NoEsNuevo) controler.Model.AddToCajaChicaDetalle(cajaDetalle);

                for (int i = 0; i < gv.RowCount; i++)
                {
                    DataRow row = gv.GetDataRow(i);

                    if (row != null)
                    {
                        if (string.IsNullOrEmpty(row["Id"].ToString()))
                        {
                            cajaComprobante = new CajaChicaComprobante();
                            cajaComprobante.CajaChicaDetalle = controler.GetObjectFromContext(cajaDetalle);
                        }
                        else
                        {
                            int idComprobante = Convert.ToInt32(row["Id"].ToString());
                            cajaComprobante = controler.Model.CajaChicaComprobante.Where(c => c.Id == idComprobante).SingleOrDefault();
                        }

                        cajaComprobante.Folio = row["Folio"].ToString();
                        cajaComprobante.Fecha = Convert.ToDateTime(row["Fecha"].ToString());
                        cajaComprobante.Importe = Convert.ToDouble(row["Importe"].ToString());
                        cajaComprobante.ObraId = string.IsNullOrEmpty(row["ObraId"].ToString()) ? (int?)null : Convert.ToInt32(row["ObraId"].ToString());
                        cajaComprobante.ProveedorId = string.IsNullOrEmpty(row["ProveedorId"].ToString()) ? (int?)null : Convert.ToInt32(row["ProveedorId"].ToString());
                        cajaComprobante.TipoComprobanteId = Convert.ToInt32(row["TipoComprobanteId"].ToString());
                        cajaComprobante.Observaciones = gv.GetRowCellValue(i, "Observaciones").ToString().ToUpper();

                        if (!cajaComprobante.NoEsNuevo)
                        {
                            controler.Model.AddToCajaChicaComprobante(cajaComprobante);

                            if (cajaComprobante.TipoComprobanteId == TipoComprobante.Deducible.Id)
                                factura = new Factura();
                        }
                        else
                        {
                            if (cajaComprobante.TipoComprobanteId == TipoComprobante.Deducible.Id)
                            {
                                int idComprobante =Convert.ToInt32(row["Id"].ToString());
                                factura = controler.Model.Factura.Where(f => f.CajaComprobanteId == idComprobante).SingleOrDefault();

                                if (factura == null) factura = new Factura();
                            }
                        }

                        if (cajaComprobante.TipoComprobanteId == TipoComprobante.Deducible.Id)
                        {
                            factura.NoFactura = row["Folio"].ToString();
                            factura.Fecha = Convert.ToDateTime(row["Fecha"].ToString());
                            factura.Importe = Convert.ToDouble(row["Importe"].ToString());
                            factura.Observaciones = row["Observaciones"].ToString().ToUpper();
                            factura.ProveedorId = string.IsNullOrEmpty(row["ProveedorId"].ToString()) ? (int?)null : Convert.ToInt32(row["ProveedorId"].ToString());
                            factura.ObraId = string.IsNullOrEmpty(row["ObraId"].ToString()) ? (int?)null : Convert.ToInt32(row["ObraId"].ToString());
                            factura.Saldo = factura.Importe;
                            factura.CajaChicaComprobante = controler.GetObjectFromContext(cajaComprobante);
                            if (!factura.NoEsNuevo) controler.Model.AddToFactura(factura);
                        }
                    }
                }

                controler.Model.SaveChanges();
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                if (isNew) cajaDetalle = null;
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
                    message = string.IsNullOrEmpty(error) ? string.Concat("Los comprobantes han sido actualizado exitosamente.") : string.Concat("No se pudieron actualizar los comprobantes:\n", error);
                }
                else
                {
                    message = string.IsNullOrEmpty(error) ? string.Concat("Los comprobantes han sido generado exitosamente.") : string.Concat("No se pudieron generar los comprobantes:\n", error);
                }

                new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
            }

            if (string.IsNullOrEmpty(error))
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private string getObservaciones()
        {
            try
            {
                string Observacion = string.IsNullOrEmpty(txtObservaciones.Text) ? string.Empty : txtObservaciones.Text.ToUpper(); 

                for (int i = 0; i < gv.RowCount; i++)
                {
                    DataRow row = gv.GetDataRow(i);

                    if (row != null)
                    {
                        if (!string.IsNullOrEmpty(gv.GetRowCellValue(i, "Observaciones").ToString().ToUpper()))
                        Observacion = Observacion +
                            (string.IsNullOrEmpty(Observacion) ? "" : Environment.NewLine) +
                            gv.GetRowCellValue(i, "Observaciones").ToString().ToUpper();
                    }
                }
                return Observacion.Trim('\r').Trim('\n');
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private void Calc_TipoComprobante()
        {
            facturas_tot = 0; nominas_tot = 0; nodeducibles_tot = 0; biaticos_tot = 0; devolucion_tot = 0;

                if (gv.DataRowCount > 0)
                {
                    for (var i = 0; i < gv.RowCount; i++)
                    {
                        DataRow row = gv.GetDataRow(i);

                        if (row != null)
                        {
                            if (string.IsNullOrEmpty(gv.GetRowCellValue(i, "Importe").ToString()) == false && Convert.ToDouble(gv.GetRowCellValue(i, "Importe")) > 0)
                            {
                                if (gv.GetRowCellValue(i, "TipoComprobanteId").ToString() == "1") //DEDUCIBLE
                                {
                                    facturas_tot += Convert.ToDouble(gv.GetRowCellValue(i, "Importe"));
                                    txtFacturas.Text = facturas_tot.ToString("c2");
                                }
                                else if (gv.GetRowCellValue(i, "TipoComprobanteId").ToString() == "2")// NOMINA
                                {
                                    nominas_tot += Convert.ToDouble(gv.GetRowCellValue(i, "Importe"));
                                    txtNominas.Text = nominas_tot.ToString("c2");
                                }
                                else if (gv.GetRowCellValue(i, "TipoComprobanteId").ToString() == "3")// NO DEDUCIBLES
                                {
                                    nodeducibles_tot += Convert.ToDouble(gv.GetRowCellValue(i, "Importe"));
                                    txtNoDeducibles.Text = nodeducibles_tot.ToString("c2");
                                }
                                else if (gv.GetRowCellValue(i, "TipoComprobanteId").ToString() == "4")//BIATICOS
                                {
                                    biaticos_tot += Convert.ToDouble(gv.GetRowCellValue(i, "Importe"));
                                    txtBiaticos.Text = biaticos_tot.ToString("c2");
                                }
                                else if (gv.GetRowCellValue(i, "TipoComprobanteId").ToString() == "5")//DEVOLUCION
                                {
                                    devolucion_tot += Convert.ToDouble(gv.GetRowCellValue(i, "Importe"));
                                    //txtBiaticos.Text = biaticos_tot.ToString("c2");
                                }
                            }
                        }
                    }
                }
            }

        private void gv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn colTipoComprobante = view.Columns["TipoComprobanteId"];
            GridColumn colFolio = view.Columns["Folio"];
            GridColumn colFecha = view.Columns["Fecha"];
            GridColumn colImporte = view.Columns["Importe"];
            GridColumn colProveedor = view.Columns["Proveedor"];

            //Get the value of the first column
            int t_TipoComprobanteId;
            Int32.TryParse(view.GetRowCellValue(e.RowHandle, colTipoComprobante).ToString(), out t_TipoComprobanteId);
            if (t_TipoComprobanteId == 0)
            { e.Valid = false; view.SetColumnError(colTipoComprobante, "Campo Tipo de Comprobante es Obligatorio."); return;}

            //string t_Folio = view.GetRowCellValue(e.RowHandle, colFolio).ToString();
            //if (string.IsNullOrEmpty(t_Folio))
            //{ e.Valid = false; view.SetColumnError(colFolio, "Campo Folio es Obligatorio."); return; }

            DateTime t_Fecha = string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, colFecha).ToString()) ? DateTime.MinValue : Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, colFecha));
            if (t_Fecha == null || string.IsNullOrEmpty(t_Fecha.ToString()) || t_Fecha == DateTime.MinValue)
            { e.Valid = false; view.SetColumnError(colFecha, "Campo Fecha es Obligatorio."); return; }

            double t_Importe_Resul;
            double.TryParse(view.GetRowCellValue(e.RowHandle, colImporte).ToString(), out t_Importe_Resul);

            if (t_Importe_Resul==0 || string.IsNullOrEmpty(t_Importe_Resul.ToString()))
            { e.Valid = false; view.SetColumnError(colImporte, "Campo Importe es Obligatorio."); return; }
            else { Calc_TipoComprobante(); }

            //int t_Proveedor;
            //Int32.TryParse(view.GetRowCellValue(e.RowHandle, colProveedor).ToString(), out t_Proveedor);
            //if (t_Proveedor==0)
            //{ e.Valid = false; view.SetColumnError(colProveedor, "Campo Proveedor es Obligatorio."); return; }
        }

        private void gv_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            string msg = string.Empty;
            
                DbTransaction transaccion = null;
            
                try
                {
                    transaccion = controler.Model.BeginTransaction();
                    for (int i = 0; i < gv.DataRowCount; i++)
                    {
                        if (eliminaComprobante(Convert.ToInt32(gv.GetRowCellValue(i, "Id"))))
                        {

                        }
 
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
                        message = string.IsNullOrEmpty(error) ? string.Concat("Las Comprobaciones se generaron exitosamente.") : string.Concat("Error al Crear las Comprobaciones:\n", error);
                        new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                        if (!string.IsNullOrEmpty(error))
                            transaccion.Rollback();
                }

                if (string.IsNullOrEmpty(error))
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
        }

        private bool eliminaComprobante(int idComprobante)
        {
            return true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            new frmComprobanteProveedor(controler).ShowDialog();
            luProveedor.DataSource = controler.Model.Proveedor.ToList();
            luProveedor.DisplayMember = "NombreFiscal";
            luProveedor.ValueMember = "Id";
            gv.RefreshData();
        }

        private void gv_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            Calc_TipoComprobante();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gv.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gv.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gv.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gv.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gv.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gv.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        private void gv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                frmMessageBox confirm = new frmMessageBox(false);
                confirm.Title = "Confirmación";
                confirm.Message = "¿Desea Eliminar el Registro?";
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
                        Calc_TipoComprobante();
                    }
                    else
                    {
                        //Eliminar desde la bd el detalleArticulo
                        eliminarDetalleArticulo(Convert.ToInt32(row["Id"]));
                        Calc_TipoComprobante();
                    }
                }

            }
            gv_RowUpdated(null, null);
        }

        private void eliminarDetalleArticulo(int idDetalle)
        {
            CajaChicaComprobante detalleArticulo = controler.Model.CajaChicaComprobante.FirstOrDefault(A => A.Id == idDetalle);

            if (detalleArticulo != null)
            {
                DbTransaction transaccion = null;

                try
                {                    
                    transaccion = controler.Model.BeginTransaction();
                    foreach (Factura fact in detalleArticulo.Factura)
                    {
                        controler.Model.DeleteObject(fact);
                    }
                    controler.Model.DeleteObject(detalleArticulo);

                    controler.Model.SaveChanges();
                    transaccion.Commit();
                    new frmMessageBox(true) { Message = "El Registro se Elimino Exitosamente.", Title = "Aviso" }.ShowDialog();
                    gv.DeleteRow(gv.FocusedRowHandle);
                }
                catch (Exception ex)
                {
                    new frmMessageBox(true) { Message = "Error al quitar el Registro: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                    if (transaccion != null) transaccion.Rollback();
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "No es posible eliminar este Registro.", Title = "Error" }.ShowDialog();
            }

            controler.Model.CloseConnection();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            KeyEventArgs key = new KeyEventArgs(Keys.Delete);
            gv_KeyDown(null, key);
        }

        }

    }