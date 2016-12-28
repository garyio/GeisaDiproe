using System;
using System.Collections.Generic;
using System.Linq;
using GeisaBD;
using System.Data;
using System.Data.Common;

namespace SistemaGEISA
{
    public partial class frmTarjetasCreditoNew : DevExpress.XtraEditors.XtraForm
    {
         private Controler controler { get; set; }
         public TarjetasCredito tarjetaCredito { get; set; }

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            areValid &= isValid = luBanco.GetSelectedDataRow() != null;
            controler.SetError(luBanco, isValid ? string.Empty : "Seleccione un Banco.");

            areValid &= isValid = luEmpleado.GetSelectedDataRow() != null;
            controler.SetError(luEmpleado, isValid ? string.Empty : "Seleccione un Empleado.");

            areValid &= isValid = controler.CheckEmptyText(txtNumCuenta);
            controler.SetError(txtNumCuenta, isValid ? string.Empty : "Inserte un Numero de Cuenta.");

            areValid &= isValid = controler.CheckEmptyText(txtNumTarjeta);
            controler.SetError(txtNumTarjeta, isValid ? string.Empty : "Inserte un Numero de Tarjeta.");


            return areValid;
        }

        public frmTarjetasCreditoNew(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        private void llenaEmpleado()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("NombreEmpleado", typeof(string));
            foreach (Empleado e in controler.Model.Empleado.ToList())
            {
                dt.Rows.Add(e.Id, e.NombreCompleto);
            }
            luEmpleado.Properties.DataSource = dt;
            luEmpleado.Properties.DisplayMember = "NombreEmpleado";
            luEmpleado.Properties.ValueMember = "Id";
        }

        private void llenaBanco()
        {
            luBanco.Properties.DataSource = controler.Model.Bancos.ToList();
            luBanco.Properties.DisplayMember = "Nombre";
            luBanco.Properties.ValueMember = "Id";
        }

        private void frmTarjetasCreditoNew_Load(object sender, EventArgs e)
        {
            llenaBanco();
            llenaEmpleado();
            if (tarjetaCredito != null)
            {
                luBanco.EditValue = tarjetaCredito.BancosId;
                txtNumTarjeta.Text = tarjetaCredito.NumeroTarjeta.ToString();
                txtNumCuenta.Text = tarjetaCredito.NumeroCuenta.ToString();
                luEmpleado.EditValue = tarjetaCredito.EmpleadoId;
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

            if (isValid())
            {
                DbTransaction transaccion = null;
                try
                {
                    transaccion = controler.Model.BeginTransaction();
                    if (tarjetaCredito == null)
                    {
                        tarjetaCredito = new TarjetasCredito();
                        isNew = true;
                    }

                    //tarjetaCredito.Bancos = luBanco.GetSelectedDataRow() as Bancos;
                    tarjetaCredito.BancosId = Convert.ToInt32(luBanco.EditValue);
                    tarjetaCredito.NumeroTarjeta = Convert.ToInt64(txtNumTarjeta.Text);
                    tarjetaCredito.NumeroCuenta = Convert.ToInt64(txtNumCuenta.Text);
                    tarjetaCredito.EmpleadoId = Convert.ToInt32(luEmpleado.EditValue); 


                    if (!tarjetaCredito.NoEsNuevo)
                    {
                        controler.Model.AddToTarjetasCredito(tarjetaCredito);
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
                    var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                    var message = string.Empty;

                    if (!isNew)
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("La Cuenta ha sido actualizado exitosamente.") : string.Concat("No se pudo actualizar la Cuenta:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("La Cuenta ha sido generado exitosamente.") : string.Concat("No se pudo generar la Cuenta:\n", error);
                        controler.Model.CloseConnection();
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
    }
}
