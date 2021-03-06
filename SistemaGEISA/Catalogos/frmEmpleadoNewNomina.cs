﻿using System;
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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;

namespace SistemaGEISA
{
    public partial class frmEmpleadoNewNomina : DevExpress.XtraEditors.XtraForm
    {
        enum tipoNominas
        {
            Semanal=1,
            Quincenal = 2,
            Mensual = 3
        };

        private DataTable dt;
        public Controler controler { get; set; }

        public EmpleadoNomina empleadoNominda { get; set; }

        public Empleado empleado { get; set; }


        public frmEmpleadoNewNomina(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;            
        }

        private void frmEmpleadoNewNomina_Load(object sender, EventArgs e)
        {
            this.empleadoNominda = controler.Model.EmpleadoNomina.FirstOrDefault(X => X.EmpleadoId == this.empleado.Id);
            IniGrid();
            llenaCombos();

            if (empleadoNominda != null)
            {
                bool sueldoCompartido = empleadoNominda.SueldoCompartido.HasValue ? empleadoNominda.SueldoCompartido.Value : false;

                if (sueldoCompartido == true)
                {
                    chkGeisaDiproe.EditValue = true;
                }
                else
                {
                    luEmpresa.EditValue = empleadoNominda.EmpresaId.Value;
                    chkGeisaDiproe.EditValue = false ;
                }

                rgTipoNomina.EditValue = empleadoNominda.TipoNomina;
                
                txtTelefono.Text = empleadoNominda.Telefono;
                txtCelular.Text = empleadoNominda.Celular;
                dtFechaNacimiento.EditValue = empleadoNominda.FechaNacimiento;
                txtNss.Text = empleadoNominda.Nss;
                txtDomicilio.Text = empleadoNominda.Domicilio;
                txtRfc.Text = empleadoNominda.Rfc;
                txtCurp.Text = empleadoNominda.Curp;
                txtCreditoInfonavit.Text = empleadoNominda.CreditoInfonavit;
                txtMontoInfonavit.Text = empleadoNominda.MontoRetener.HasValue ? empleadoNominda.MontoRetener.Value.ToString("N2") : string.Empty;
                txtCtaBancaria.Text = empleadoNominda.CuentaBanco;
                txtClabe.Text = empleadoNominda.Cable;
                luBancos.EditValue = empleadoNominda.BancosId;
                spinVacaciones.EditValue = empleadoNominda.DiasVacaciones;
                txtHorasExtras.Text = empleadoNominda.MontoHoraExtra.HasValue ? empleadoNominda.MontoHoraExtra.Value.ToString("N2") : string.Empty;
                
                

                if (dt.Rows.Count > 0)
                {
                    dt.Rows.Clear();
                }
                foreach (EmpleadoHistorial serv in empleadoNominda.EmpleadoHistorial.ToList())
                {
                    gv.AddNewRow();
                    var newRowHandle = gv.FocusedRowHandle;

                    gv.SetRowCellValue(newRowHandle, "Id", serv.Id);
                    gv.SetRowCellValue(newRowHandle, "FechaInicio", serv.FechaInicio);
                    gv.SetRowCellValue(newRowHandle, "FechaFin", serv.FechaFin);
                    gv.SetRowCellValue(newRowHandle, "Puesto", serv.Puesto);
                    gv.SetRowCellValue(newRowHandle, "Departamento", serv.Departamento);
                    gv.SetRowCellValue(newRowHandle, "Sueldo", serv.Sueldo);
                    gv.SetRowCellValue(newRowHandle, "Observaciones", serv.Observaciones);
                    gv.UpdateCurrentRow();
                    gv.RefreshData();
                }
            }
            else
            {
                rgTipoNomina.EditValue = tipoNominas.Semanal;
            }
        }

        private void llenaCombos()
        {
            luEmpresa.Properties.DataSource = controler.Model.Empresa.Where(E => E.Activo==true).ToList();
            luEmpresa.Properties.DisplayMember = "NombreFiscal";
            luEmpresa.Properties.ValueMember = "Id";

            luBancos.Properties.DataSource = controler.Model.Bancos.ToList();
            luBancos.Properties.DisplayMember = "Nombre";
            luBancos.Properties.ValueMember = "Id";

            luDepartamento.DataSource = controler.Model.Dpto_Puesto.Where(D => D.Tipo== 1).ToList();
            luDepartamento.DisplayMember = "Nombre";
            luDepartamento.ValueMember = "Id";

            luPuestos.DataSource = controler.Model.Dpto_Puesto.Where(D => D.Tipo == 2).ToList();
            luPuestos.DisplayMember = "Nombre";
            luPuestos.ValueMember = "Id";

            dtFechaNacimiento.EditValue = DateTime.Today;

        }

        private void IniGrid()
        {            
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("FechaInicio", typeof(DateTime));
            dt.Columns.Add("FechaFin", typeof(DateTime));
            dt.Columns.Add("Puesto", typeof(string));
            dt.Columns.Add("Departamento", typeof(string));
            dt.Columns.Add("Sueldo", typeof(double));
            dt.Columns.Add("Observaciones", typeof(string));

            grid.DataSource = dt;
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
                    }
                    else
                    {
                        //Eliminar desde la bd el detalleArticulo
                        eliminarRegistro(Convert.ToInt32(row["Id"]));
                    }
                }

            }
        }

        private void eliminarRegistro(int idDetalle)
        {
            EmpleadoHistorial detalle = controler.Model.EmpleadoHistorial.FirstOrDefault(A => A.Id == idDetalle);

            if (detalle != null)
            {
                DbTransaction transaccion = null;

                try
                {
                    transaccion = controler.Model.BeginTransaction();
                    controler.Model.DeleteObject(detalle);

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

        private void gv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn colFechaInicio = view.Columns["FechaInicio"];
            GridColumn colPuesto = view.Columns["Puesto"];
            GridColumn colDepartamento = view.Columns["Departamento"];
            view.ClearColumnErrors();

            string t_FechaInicio = view.GetRowCellValue(e.RowHandle, colFechaInicio).ToString();
            if (string.IsNullOrEmpty(t_FechaInicio))
            { e.Valid = false; view.SetColumnError(colFechaInicio, "Ingresar un Valor Valido."); return; }
            else { e.Valid = true;  }

            string estatus = view.GetRowCellValue(e.RowHandle, colPuesto).ToString();
            if (string.IsNullOrEmpty(estatus))
            { e.Valid = false; view.SetColumnError(colPuesto, "Ingresar un Valor Valido."); return; }
            else { e.Valid = true; }

            string estatus_Dpto = view.GetRowCellValue(e.RowHandle, colDepartamento).ToString();
            if (string.IsNullOrEmpty(estatus_Dpto))
            { e.Valid = false; view.SetColumnError(colDepartamento, "Ingresar un Valor Valido."); return; }
            else { e.Valid = true; }       
        }

        private void gv_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void txtTelefono_TabIndexChanged(object sender, EventArgs e)
        {
            txtTelefono.Select(0, 0);
        }

        private void txtCelular_TabIndexChanged(object sender, EventArgs e)
        {
            txtCelular.Select(0, 0);
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
                    if (empleadoNominda == null)
                    {
                        empleadoNominda = new EmpleadoNomina();                        
                        isNew = true;
                        empleadoNominda.Fecha = DateTime.Today;
                    }

                    empleadoNominda.Empleado = this.empleado;
                    if (chkGeisaDiproe.Checked)
                    {
                        empleadoNominda.Empresa = null;
                        empleadoNominda.SueldoCompartido = true;
                    }
                    else
                    {
                        empleadoNominda.Empresa = controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa); ;
                        empleadoNominda.SueldoCompartido = false;
                    }

                    //empleadoNominda.Empresa = controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa);
                    empleadoNominda.Bancos = controler.GetObjectFromContext(luBancos.GetSelectedDataRow() as Bancos);
                    empleadoNominda.Telefono = txtTelefono.Text;
                    empleadoNominda.Celular = txtCelular.Text;
                    empleadoNominda.FechaNacimiento = (DateTime)dtFechaNacimiento.EditValue;
                    empleadoNominda.Nss = txtNss.Text.ToUpper();
                    empleadoNominda.Domicilio = txtDomicilio.Text.ToUpper();
                    empleadoNominda.Rfc = txtRfc.Text.ToUpper();
                    empleadoNominda.Curp = txtCurp.Text.ToUpper();
                    empleadoNominda.CuentaBanco = txtCtaBancaria.Text.ToUpper();
                    empleadoNominda.Cable = txtClabe.Text.ToUpper();
                    empleadoNominda.CreditoInfonavit = txtCreditoInfonavit.Text.ToUpper();
                    empleadoNominda.MontoRetener = string.IsNullOrEmpty(txtMontoInfonavit.Text) ? (double?)null : Convert.ToDouble(txtMontoInfonavit.Text);
                    empleadoNominda.DiasVacaciones = Convert.ToInt32(spinVacaciones.Value);
                    empleadoNominda.MontoHoraExtra = string.IsNullOrEmpty(txtHorasExtras.Text) ? (double?)null : Convert.ToDouble(txtHorasExtras.Text);
                    empleadoNominda.TipoNomina = rgTipoNomina.EditValue!=null ? Convert.ToInt32(rgTipoNomina.EditValue): Convert.ToInt32(tipoNominas.Semanal);

                    if (!empleadoNominda.NoEsNuevo) controler.Model.AddToEmpleadoNomina(empleadoNominda);

                    EmpleadoHistorial detalle;
                    //List<EmpleadoHistorial> historial;
                    //if (empleadoNominda.EmpleadoHistorial.Count > 0)
                    //    historial = empleadoNominda.EmpleadoHistorial.ToList();
                    //else
                    //    historial = new List<EmpleadoHistorial>();

                    for (int i = 0; i < gv.RowCount; i++)
                    {
                        DataRow row = gv.GetDataRow(i);

                        if (row != null)
                        {
                            var id = (int?)null;
                            if (string.IsNullOrEmpty(row["Id"].ToString()))
                            {
                                detalle = new EmpleadoHistorial();
                                id = (int?)null;

                            }
                            else
                            {
                                id = Convert.ToInt32(row["Id"].ToString());
                                detalle = !isNew ? controler.Model.EmpleadoHistorial.FirstOrDefault(D => D.Id == id) : null;
                            }

                            detalle.EmpleadoNomina = this.empleadoNominda;
                            detalle.Departamento = Convert.ToInt32(row["Departamento"]);
                            detalle.Puesto = Convert.ToInt32(row["Puesto"]);
                            detalle.FechaInicio = row["FechaInicio"].ToString()!=""? Convert.ToDateTime(row["FechaInicio"]):(DateTime?)null;
                            detalle.FechaFin = row["FechaFin"].ToString()!=""?Convert.ToDateTime(row["FechaFin"]):(DateTime?)null;
                            detalle.Sueldo = Convert.ToDouble(row["Sueldo"] != null || row["Sueldo"].ToString()!="" ? row["Sueldo"] : (double?)null);
                            detalle.Observaciones = row["Observaciones"].ToString();
                            if (!detalle.NoEsNuevo) controler.Model.AddToEmpleadoHistorial(detalle);

                        }
                    }

                    controler.Model.SaveChanges();
                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    if (isNew) empleadoNominda = null;
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
                        message = string.IsNullOrEmpty(error) ? string.Concat("La Nomina ha sido actualizada exitosamente.") : string.Concat("No se pudo actualizar la Nomina:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("La Nomina ha sido generada exitosamente.") : string.Concat("No se pudo generar la Nomina:\n", error);
                    }

                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();

                    if (string.IsNullOrEmpty(error))
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                }

            }

            
        }//btnGuardar

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;


            areValid &= isValid = gv.DataRowCount > 0 ? true : false;
            controler.SetError(grid, isValid ? string.Empty : "Favor de Ingresar al menos 1 Registro en el Historial.");

            if (!chkGeisaDiproe.Checked)
            {
                areValid &= isValid = luEmpresa.EditValue != null ? true : false;
                controler.SetError(luEmpresa, isValid ? string.Empty : "Seleccione una Empresa");
            }

            return areValid;
        }

        private void frmEmpleadoNewNomina_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumerosDec(sender, e);
        }

        private void txtHorasExtras_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumerosDec(sender, e);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var form = new frmDptoPuesto();
            form.ShowDialog();

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, controler.Model.Dpto_Puesto.ToList());

                luDepartamento.DataSource = controler.Model.Dpto_Puesto.Where(D => D.Tipo == 1).ToList();
                luDepartamento.DisplayMember = "Nombre";
                luDepartamento.ValueMember = "Id";

                luPuestos.DataSource = controler.Model.Dpto_Puesto.Where(D => D.Tipo == 2).ToList();
                luPuestos.DisplayMember = "Nombre";
                luPuestos.ValueMember = "Id";
            }
            form.Dispose();

        }

        private void txtMontoInfonavit_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMontoInfonavit.Text = Convert.ToDouble(txtMontoInfonavit.Text).ToString("N2");
            }
            catch (Exception ex)
            {

            }
        }

        private void txtMontoInfonavit_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumerosDec(sender, e);
        }

        private void chkGeisaDiproe_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(chkGeisaDiproe.EditValue) == true)
                luEmpresa.Enabled = false;
            else
                luEmpresa.Enabled = true;
        }
    }
}
