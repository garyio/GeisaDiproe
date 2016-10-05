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

namespace SistemaGEISA
{
    public partial class frmVehiculosNew : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }
        public Vehiculo vehiculo { get; set; }
        public frmVehiculosNew(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }
        private bool isValid()
        {
            bool areValid = true;
            bool isValid = true;

            areValid &= isValid = deFecha.EditValue == null ? false : true;
            controler.SetError(deFecha, isValid ? string.Empty : "Valor Obligatorio, Favor de Seleccionar.");

            areValid &= isValid = lookupEmpresa.EditValue == null ? false : true;
            controler.SetError(lookupEmpresa, isValid ? string.Empty : "Valor Obligatorio, Favor de Seleccionar.");

            areValid &= isValid = string.IsNullOrEmpty(txtMarca.Text) ? false : true;
            controler.SetError(txtMarca, isValid ? string.Empty : "Valor Obligatorio, Favor de Ingresar.");

            areValid &= isValid = string.IsNullOrEmpty(txtSubMarca.Text) ? false : true;
            controler.SetError(txtSubMarca, isValid ? string.Empty : "Valor Obligatorio, Favor de Ingresar.");

            areValid &= isValid = string.IsNullOrEmpty(txtPlacas.Text) ? false : true;
            controler.SetError(txtPlacas, isValid ? string.Empty : "Valor Obligatorio, Favor de Ingresar.");

            areValid &= isValid = lookupTipo.EditValue ==null ? false : true;
            controler.SetError(lookupTipo, isValid ? string.Empty : "Valor Obligatorio, Favor de Seleccionar.");

            areValid &= isValid = rgEstatus.EditValue == null ? false : true;
            controler.SetError(rgEstatus, isValid ? string.Empty : "Valor Obligatorio, Favor de Seleccionar.");

            return areValid;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

            if (isValid())
            {
                if (vehiculo == null)
                {
                    vehiculo = new Vehiculo();
                    isNew = true;
                }

                vehiculo.Fecha = (DateTime)deFecha.EditValue;
                vehiculo.Empresa = lookupEmpresa.GetSelectedDataRow() as Empresa;
                vehiculo.Marca = txtMarca.Text.Trim();
                vehiculo.SubMarca = txtSubMarca.Text.Trim();
                vehiculo.Modelo = (string)spinModelo.Value.ToString().Trim();
                vehiculo.Color = txtColor.Text.Trim();
                vehiculo.Placas = txtPlacas.Text.Trim();
                vehiculo.VigenciaInicio = deVigIni.EditValue ==null ? (DateTime?)null : (DateTime)deVigIni.EditValue;
                vehiculo.Estatus = Convert.ToInt32(rgEstatus.EditValue) == 1 ? true : false;
                vehiculo.Empleado = lookupEmpleado.GetSelectedDataRow() as Empleado;
                vehiculo.TipoVehiculo = lookupTipo.EditValue==null ? (int?)null : (int)lookupTipo.EditValue;
                vehiculo.Transmision = lookupTransmision.EditValue == null ? (int?)null : (int)lookupTransmision.EditValue;
                vehiculo.Poliza = txtPoliza.Text.Trim();
                vehiculo.Compañia = txtCompañia.Text.Trim();
                vehiculo.NumNeumaticos = Convert.ToInt32(spinNeumaticos.Value);
                vehiculo.NumRefacciones = Convert.ToInt32(spinRefacciones.Value);
                vehiculo.VigenciaFin = deVigFin.EditValue==null ? (DateTime?)null : (DateTime)deVigFin.EditValue;


                if (!vehiculo.NoEsNuevo)
                {
                    controler.Model.AddToVehiculo(vehiculo);
                }
                try
                {
                    controler.Model.SaveChanges();
                }
                catch (Exception ex)
                {
                    error = ex.InnerException.Message;
                }
                finally
                {
                    var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                    var message = string.Empty;

                    if (!isNew)
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Vehíchulo ha sido actualizado exitosamente.") : string.Concat("No se pudo actualizar el Vehíchulo:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Vehíchulo ha sido generado exitosamente.") : string.Concat("No se pudo generar el Vehíchulo:\n", error);
                    }

                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                }

                if (string.IsNullOrEmpty(error))
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }

        private void frmVehiculosNew_Load(object sender, EventArgs e)
        {
            llenaCombos();
            if (vehiculo != null)
            {
                deFecha.EditValue = vehiculo.Fecha;
                lookupEmpresa.EditValue = vehiculo.EmpresaId;
                txtMarca.Text = vehiculo.Marca;
                txtSubMarca.Text = vehiculo.SubMarca;
                spinModelo.Value = Convert.ToDecimal(vehiculo.Modelo);                
                txtColor.Text = vehiculo.Color;
                txtPlacas.Text = vehiculo.Placas;
                deVigIni.EditValue = vehiculo.VigenciaInicio;
                rgEstatus.EditValue = vehiculo.Estatus == true ? 1 : 2;
                lookupEmpleado.EditValue = vehiculo.EmpleadoId;
                lookupTipo.EditValue = vehiculo.TipoVehiculo;
                lookupTransmision.EditValue = vehiculo.Transmision;
                txtPoliza.Text = vehiculo.Poliza;
                txtCompañia.Text = vehiculo.Compañia;
                spinNeumaticos.Value = vehiculo.NumNeumaticos.Value;
                spinRefacciones.Value = vehiculo.NumRefacciones.Value;
                deVigFin.EditValue = vehiculo.VigenciaFin;
            }
            else {
                deFecha.EditValue = DateTime.Today;
                spinModelo.EditValue = (int)2015;
                deVigIni.EditValue = deVigFin.EditValue = DateTime.Today;
                spinNeumaticos.EditValue = (int)4;
                spinRefacciones.EditValue = (int)1;
                rgEstatus.EditValue = 1;
            }
        }

        private void llenaCombos()
        {
            lookupEmpresa.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            lookupEmpresa.Properties.DisplayMember = "NombreFiscal";
            lookupEmpresa.Properties.ValueMember = "Id";

            lookupEmpleado.Properties.DataSource = controler.Model.Empleado.Where(D => D.Activo == true).ToList();
            lookupEmpleado.Properties.DisplayMember = "NombreCompleto";
            lookupEmpleado.Properties.ValueMember = "Id";

            DataTable dtVehiculos = new DataTable();
            dtVehiculos.Columns.Add("Id", typeof(int));
            dtVehiculos.Columns.Add("Text");
            dtVehiculos.Rows.Add(new object[] { 1, "PICK UP" });
            dtVehiculos.Rows.Add(new object[] { 2, "SEDAN" });
            dtVehiculos.Rows.Add(new object[] { 3, "CAMION" });
            dtVehiculos.Rows.Add(new object[] { 4, "MOTOCICLETA" });
            lookupTipo.Properties.DataSource = dtVehiculos.DefaultView;
            lookupTipo.Properties.ValueMember = "Id";
            lookupTipo.Properties.DisplayMember = "Text";

            DataTable dtTransmision = new DataTable();
            dtTransmision.Columns.Add("Id", typeof(int));
            dtTransmision.Columns.Add("Text");
            dtTransmision.Rows.Add(new object[] { 1, "ESTANDAR" });
            dtTransmision.Rows.Add(new object[] { 2, "AUTOMATICO" });
            dtTransmision.Rows.Add(new object[] { 3, "TIPTRONIC" });
            lookupTransmision.Properties.DataSource = dtTransmision.DefaultView;
            lookupTransmision.Properties.ValueMember = "Id";
            lookupTransmision.Properties.DisplayMember = "Text";
        }
    }
}