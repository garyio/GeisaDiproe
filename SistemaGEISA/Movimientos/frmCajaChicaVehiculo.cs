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
using System.Data.Common;
using System.IO;

namespace SistemaGEISA
{
    public partial class frmCajaChicaVehiculo : DevExpress.XtraEditors.XtraForm
    {
        private Controler _controler = new Controler();

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }
        public Vehiculo vehiculo { get; set; }

        private VehiculoCajaChica vehiculoCajaChica { get; set; }
        
        public void llenaGrid()
        {
            grid.DataSource = Controler.Model.VehiculoCajaChica.ToList();
        }

        private void abrirForm(bool nuevo)
        {
            var form = new frmCajaChicaDetalleVehiculo(Controler);

            form.Text = "Caja chica Vehículo : "+(nuevo ? "Nuevo":"Editar");
            if (!nuevo)
            {
                form.VehiculoCajaChica = vehiculoCajaChica;
            }
            else
            {
                form.VehiculoCajaChica = null;
            }
            form.nuevo = nuevo;
            form.ShowDialog();

            if (nuevo)
            {
                llenaGrid();
            }
            else
            {
                grid.RefreshDataSource();
            }
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

        private void frmCajaChicaVehiculo_Load(object sender, EventArgs e)
        {
            llenaGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            abrirForm(true);
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.DataRowCount > 0)
            {
                vehiculoCajaChica = gv.GetFocusedRow() as VehiculoCajaChica;
            }
        }
        public frmCajaChicaVehiculo()
        {
            InitializeComponent();
        }

        private void gv_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0 && gv.GetFocusedDataRow()!=null)
            {
                Vehiculo vehiculo= (gv.GetFocusedRow() as VehiculoCajaChica).Vehiculo;
                if (vehiculo != null)
                {
                    if (vehiculo.VigenciaFin < DateTime.Today)
                        //VENCIDO
                        e.Appearance.ForeColor = Color.Red;
                    else if (vehiculo.Estatus == false)
                        //INACTIVO
                        e.Appearance.ForeColor = Color.Navy;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar esta Caja Chica?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes && gv.SelectedRowsCount==1)
            {
                VehiculoCajaChica cajachica = gv.GetFocusedRow() as VehiculoCajaChica;

                if (cajachica != null)
                {
                    DbTransaction transaccion = null;

                    try
                    {
                        transaccion = Controler.Model.BeginTransaction();
                        List<VehiculoCajaChicaDetalle> cargos = Controler.Model.VehiculoCajaChicaDetalle.Where(V => V.VehiculoCajaChicaId == cajachica.Id).ToList();
                        if (cargos != null)
                        {
                            foreach (VehiculoCajaChicaDetalle cargo in cargos)
                            {
                                Controler.Model.DeleteObject(cargo);
                            }
                        }

                        Controler.Model.DeleteObject(cajachica);

                        Controler.Model.SaveChanges();
                        transaccion.Commit();
                        new frmMessageBox(true) { Message = "La Caja chica ha sido Eliminada.", Title = "Aviso" }.ShowDialog();
                        gv.DeleteRow(gv.FocusedRowHandle);
                        llenaGrid();
                    }
                    catch (Exception ex)
                    {
                        new frmMessageBox(true) { Message = "Error al quitar La Caja chica: " + ex.GetBaseException().Message, Title = "Error" }.ShowDialog();
                        if (transaccion != null) transaccion.Rollback();
                    }
                    finally
                    {
                        Controler.Model.CloseConnection();
                    }
                }
                else
                {
                    new frmMessageBox(true) { Message = "No es posible eliminar este La Caja chica.", Title = "Error" }.ShowDialog();
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione La Caja chica a Eliminar.", Title = "Aviso" }.ShowDialog();
            }
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Funciones.Print(grid);
        }

        private void btnExportar_Click(object sender, EventArgs e)
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
            } //
        }
    }
}