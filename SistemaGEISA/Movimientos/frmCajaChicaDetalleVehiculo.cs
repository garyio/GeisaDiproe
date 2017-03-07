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

namespace SistemaGEISA
{
    public partial class frmCajaChicaDetalleVehiculo : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }
        public VehiculoCajaChica VehiculoCajaChica { get; set; }

        public VehiculoCajaChicaDetalle cargo { get; set; }

        public Empleado empleado { get; set; }

        public bool nuevo { get; set; }
        public frmCajaChicaDetalleVehiculo(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        public void llenaGrid()
        {
            grid.DataSource = controler.Model.VehiculoCajaChicaDetalle.Where(D=> D.VehiculoCajaChicaId == VehiculoCajaChica.Id).OrderByDescending(O => O.Fecha).ToList();
        }
        

        public void llenaVehiculo()
        {
            //List<int> cajachica = controler.Model.VehiculoCajaChica.Select(x => x.VehiculoId).ToList();
            //if(nuevo)
            //    luVehiculo.Properties.DataSource = controler.Model.Vehiculo.Where(V => !cajachica.Contains(V.Id) && V.Estatus==true).ToList();
            //else
            //    luVehiculo.Properties.DataSource = controler.Model.Vehiculo.Where(v => v.Estatus==true).ToList();

            List<int> datosCaja;
            if (VehiculoCajaChica == null)
                datosCaja = controler.Model.VehiculoCajaChica.Select(x => x.VehiculoId).ToList();
            else
                datosCaja = controler.Model.VehiculoCajaChica.Where(x => x.VehiculoId != VehiculoCajaChica.VehiculoId).Select(x => x.VehiculoId).ToList();

            luVehiculo.Properties.DataSource = controler.Model.Vehiculo.Where(D => D.Estatus == true && !datosCaja.Contains(D.Id)).ToList();
            luVehiculo.Properties.DisplayMember = "VehiculoCompleto";
            luVehiculo.Properties.ValueMember = "Id";
        }

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            areValid &= isValid = luVehiculo.GetSelectedDataRow() != null;
            controler.SetError(luVehiculo, isValid ? string.Empty : "Seleccione un Vehículo");

            return areValid;
        }

        private void frmCajaChicaDetalleVehiculo_Load(object sender, EventArgs e)
        {
            llenaVehiculo();
            if (!nuevo)
            {        
                luVehiculo.EditValue = VehiculoCajaChica.VehiculoId;
                luVehiculo.Properties.ReadOnly = true;
                btnCargos.Visible = true;
                btnGuardar.Visible = false;
                toolStripSeparator1.Visible = false;
                llenaGrid();
            }
            else
            {
                
                btnGuardar.Visible = true;
                btnCargos.Visible = false;
                toolStripSeparator1.Visible = false;
                luVehiculo.Enabled = true;
                luVehiculo.Enabled = true;
            }
        }

        private void luVehiculo_EditValueChanged(object sender, EventArgs e)
        {
            llenaVehiculo();
        }

        private void btnCargos_Click(object sender, EventArgs e)
        {
            //var form = new frmCargos(controler);
            //form.cajaChica = VehiculoCajaChica;
            //form.ShowDialog();
            //if (form.DialogResult == DialogResult.OK)
            //{
            //    llenaGrid();
            //}
            if(VehiculoCajaChica!=null)
                abrirForm(true);
            else
                new frmMessageBox(true) { Message = "Favor de crear primero la Caja Chica, Para poder agregar Cargos.", Title = "Aviso" }.ShowDialog();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

            if (isValid())
            {
                if (VehiculoCajaChica == null)
                {
                    VehiculoCajaChica = new VehiculoCajaChica();
                    isNew = true;
                }

                VehiculoCajaChica.Vehiculo = luVehiculo.GetSelectedDataRow() as Vehiculo;
                VehiculoCajaChica.Fecha = DateTime.Now;
                controler.Model.AddToVehiculoCajaChica(VehiculoCajaChica);

                try
                {
                    controler.Model.SaveChanges();
                    btnCargos.Visible = true;
                    btnGuardar.Visible = false;
                    toolStripSeparator1.Visible = false;
                }
                catch (Exception ex)
                {
                    error = ex.GetBaseException().Message;
                }
                finally
                {
                    var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                    var message = string.Empty;
                    message = string.IsNullOrEmpty(error) ? string.Concat("La caja chica generada exitosamente.") : string.Concat("No se pudo generar:\n", error);
                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                }

                if (string.IsNullOrEmpty(error))
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }

        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            if (gv.SelectedRowsCount == 1 && VehiculoCajaChica!=null)
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
            var form = new frmCargos(controler);
            form.Text = "Cargos : " + (nuevo ? "Nuevo" : "Editar");
            form.cajaChica = VehiculoCajaChica;
            if (nuevo)
                form.cargo = null;
            else
                form.cargo = cargo;
            form.ShowDialog();          
            llenaGrid();                                    
            gv_FocusedRowChanged(null, null);
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.GetFocusedRow() != null && gv.IsLoading==false)
            {
                cargo = gv.GetFocusedRow() as VehiculoCajaChicaDetalle;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar esta Caja Chica?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes && gv.SelectedRowsCount==1)
            {
                VehiculoCajaChicaDetalle cargo = gv.GetFocusedRow() as VehiculoCajaChicaDetalle;

                if (cargo != null)
                {
                    DbTransaction transaccion = null;

                    try
                    {
                        transaccion = controler.Model.BeginTransaction();
                        controler.Model.DeleteObject(cargo);
                        controler.Model.SaveChanges();
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
                        controler.Model.CloseConnection();  
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
    }
}