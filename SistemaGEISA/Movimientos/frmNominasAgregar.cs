using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeisaBD;
using System.Data.Common;
using DevExpress.XtraGrid.Views.Grid;


namespace SistemaGEISA
{
    public partial class frmNominasAgregar : DevExpress.XtraEditors.XtraForm
    {
        bool esContratistaNormal = false;
        enum tipoNominas
        {
            Semanal = 1,
            Quincenal = 2,
            Mensual = 3
        };

        enum tipoCargo
        {
            Extras = 1,
            Pagos = 2,
            Viaticos = 3,
            Faltas = 4,
            Vacaciones = 5
        };

        private DataTable dt;
        private bool sueldoCompartido = false;
        public DateTime FechaIni;
        public DateTime FechaFin;
        private Controler controler { get; set; }

        public Nominas nominas { get; set; }

        public NominaItem nominasDetalle { get; set; }

        private EmpleadoNomina empleadoNomina { get; set; }

        public frmNominasAgregar(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        private void frmNominasAgregar_Load(object sender, EventArgs e)
        {
            IniGrid();
            llenaCombos();

            if (nominas != null)
            {
                //Si es Contratista Principal puede modificar el complemento
                if ((nominas.Empleado.EsContratistaPrincipal.HasValue ? nominas.Empleado.EsContratistaPrincipal.Value : false) == true)
                    txtComplemento.ReadOnly = false;
                else
                {
                    esContratistaNormal = nominas.Empleado.EsContratista.HasValue ? (nominas.Empleado.EsContratista.Value ? true : false) : false;// Si es contratista normal solo se le paga sueldo fiscal
                    txtComplemento.ReadOnly = true;
                }

                //if ((nominas.Empleado.EsContratista.HasValue ? nominas.Empleado.EsContratista.Value : false) == true || (nominas.Empleado.EsContratista.HasValue ? nominas.Empleado.EsContratista.Value : false) == true)


                this.empleadoNomina = controler.Model.EmpleadoNomina.FirstOrDefault(X => X.EmpleadoId == this.nominas.EmpleadoId);
                //Si es sueldo compartido mostrar los 2 sueldos, si no solo el primer sueldo fiscal    
                if ((empleadoNomina.SueldoCompartido.HasValue ? empleadoNomina.SueldoCompartido.Value : false) == true)
                    lblSueldo2.Visible = txtSueldoFiscal2.Visible = sueldoCompartido = true;
                else
                    lblSueldo2.Visible = txtSueldoFiscal2.Visible = sueldoCompartido = false;

                luEmpleado.EditValue = nominas.EmpleadoId;
                luObra.EditValue = nominas.ObraId;
                txtCompensacion.Text = nominas.Compensacion.HasValue ? nominas.Compensacion.Value.ToString("N2") : "0.00";
                txtViaticos.Text = nominas.Viaticos.HasValue ? nominas.Viaticos.Value.ToString("N2") : "0.00";
                txtSueldoFiscal.Text = nominas.SueldoFiscal.HasValue ? nominas.SueldoFiscal.Value.ToString("N2") : "0.00";
                if (sueldoCompartido) // si no es sueldo compartido seteamos el sueldo Fiscal 2  
                {
                    if (esContratistaNormal)
                        txtSueldoFiscal2.ReadOnly = true;
                    else
                        txtSueldoFiscal2.Text = nominas.SueldoFiscal2.HasValue ? nominas.SueldoFiscal2.Value.ToString("N2") : "0.00";
                }
               
                if (esContratistaNormal)
                {
                    txtSueldoReal.Text = "0.00";
                    txtComplemento.Text = "0.00";
                    txtInfonavit.Text = "0.00";
                }else
                {
                    txtSueldoReal.Text = nominas.SueldoReal.HasValue ? nominas.SueldoReal.Value.ToString("N2") : "0.00";
                    txtComplemento.Text = nominas.Complemento.HasValue ? nominas.Complemento.Value.ToString("N2") : "0.00";
                    txtInfonavit.Text = nominas.Infonavit.HasValue ? nominas.Infonavit.Value.ToString("N2") : "0.00";
                }
              
                txtObservaciones.Text = nominas.Observaciones;
                chkViaticos.Checked = nominas.ViaticosActivo.HasValue ? nominas.ViaticosActivo.Value : false;
                chkCompensacion.Checked = nominas.CompensacionActivo.HasValue ? nominas.CompensacionActivo.Value : false;
                chkPagoEfectivo.Checked = nominas.esPagoEfectivo.HasValue ? nominas.esPagoEfectivo.Value : false;
                foreach (NominasDetalle serv in nominas.NominasDetalle.ToList())
                {
                    gv.AddNewRow();
                    int rowHandle = gv.GetRowHandle(gv.DataRowCount);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Id"], serv.Id);
                    gv.SetRowCellValue(rowHandle, gv.Columns["TipoCargoId"], serv.TipoCargoId);
                    gv.SetRowCellValue(rowHandle, gv.Columns["FechaDetalle"], serv.FechaDetalle);
                    gv.SetRowCellValue(rowHandle, gv.Columns["ObraId"], serv.ObraId);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Monto"], serv.Monto);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Observaciones"], serv.Observaciones);
                    gv.SetRowCellValue(rowHandle, gv.Columns["CargoDeduccion"], serv.CargoDeduccion);
                    gv.SetRowCellValue(rowHandle, gv.Columns["NumeroDiasHoras"], serv.NumeroDiasHoras.HasValue ? serv.NumeroDiasHoras.Value : (int?)null);

                    gv.UpdateCurrentRow();
                    gv.RefreshData();
                }
                llenaTotal();
            }
            else
            {
                chkViaticos.Checked = true;
                chkCompensacion.Checked = true;
                txtCompensacion.Text = "200.00";
                txtViaticos.Text = "800.00";
                txtSueldoReal.Text = "0.00";
                txtComplemento.Text = "0.00";
                txtInfonavit.Text = "0.00";
                lblTotalSueldo.Text = "$0.00";
                sueldoCompartido = false;
            }
        }

        private void llenaTotal()
        {
            double total = 0;
            total += Convert.ToDouble(string.IsNullOrEmpty(txtSueldoFiscal.Text) ? 0 : Convert.ToDouble(txtSueldoFiscal.Text));

            total += Convert.ToDouble(string.IsNullOrEmpty(txtSueldoFiscal2.Text) ? 0 : Convert.ToDouble(txtSueldoFiscal2.Text));

            total += Convert.ToDouble(string.IsNullOrEmpty(txtComplemento.Text) ? 0 : Convert.ToDouble(txtComplemento.Text));

            total += Convert.ToDouble(chkCompensacion.Checked && !string.IsNullOrEmpty(txtCompensacion.Text) ? txtCompensacion.Text : "0");

            total += Convert.ToDouble(chkViaticos.Checked && !string.IsNullOrEmpty(txtViaticos.Text) ? txtViaticos.Text : "0");

            total -= Convert.ToDouble(string.IsNullOrEmpty(txtInfonavit.Text) ? 0 : Convert.ToDouble(txtInfonavit.Text));

            total += Convert.ToDouble(colMonto.SummaryItem.SummaryValue != null ? colMonto.SummaryItem.SummaryValue : 0);

            lblTotalSueldo.Text = total.ToString("c2");

            Console.WriteLine(total);
        }

        private void llenaCombos()
        {
            var empleadosNomina = controler.Model.Nominas.Where(N => N.PeriodoInicio >= this.FechaIni && N.PeriodoFin <= this.FechaFin).Select(I => I.EmpleadoId).ToList();
            var todoEmpleados = controler.Model.Empleado.Where(E => E.Activo == true).ToList();


            luObra.Properties.DataSource = controler.Model.Obra.ToList();
            luObra.Properties.DisplayMember = "Nombre";
            luObra.Properties.ValueMember = "Id";

            if (nominas == null)
                luEmpleado.Properties.DataSource = todoEmpleados.Where(x => !empleadosNomina.Contains(x.Id)).OrderBy(O => O.NombreCompleto).ToList();
            else
                luEmpleado.Properties.DataSource = todoEmpleados.ToList();

            luEmpleado.Properties.DisplayMember = "NombreCompleto";
            luEmpleado.Properties.ValueMember = "Id";

            luObrasDetalle.DataSource = controler.Model.Obra.OrderBy(O => O.Nombre).ToList();
            luObrasDetalle.DisplayMember = "Nombre";
            luObrasDetalle.ValueMember = "Id";

            DataTable dtEstatus = new DataTable();
            dtEstatus.Columns.Add("Id", typeof(int));
            dtEstatus.Columns.Add("Nombre", typeof(string));
            dtEstatus.Rows.Add(new object[] { 1, "EXTRAS" });
            dtEstatus.Rows.Add(new object[] { 2, "PAGOS" });
            dtEstatus.Rows.Add(new object[] { 3, "VIATICOS" });
            dtEstatus.Rows.Add(new object[] { 4, "FALTAS" });
            dtEstatus.Rows.Add(new object[] { 5, "VACACIONES" });
            luTipo.DataSource = dtEstatus.DefaultView;
            luTipo.ValueMember = "Id";
            luTipo.DisplayMember = "Nombre";
        }

        private void IniGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("TipoCargoId", typeof(string));
            dt.Columns.Add("FechaDetalle", typeof(DateTime));
            dt.Columns.Add("ObraId", typeof(int));
            dt.Columns.Add("Monto", typeof(double));
            dt.Columns.Add("Observaciones", typeof(string));
            dt.Columns.Add("CargoDeduccion", typeof(int));
            dt.Columns.Add("NumeroDiasHoras", typeof(int));
            grid.DataSource = dt;
        }

        private void txtSueldoFiscal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Funciones.validaNumeroDecimal(txtSueldoFiscal.Text))
                Funciones.soloNumerosDec(sender, e);
        }

        private void txtSueldoFiscal_Leave(object sender, EventArgs e)
        {
            double amount = 0;
            if (!string.IsNullOrEmpty(txtSueldoFiscal.Text) && double.TryParse(txtSueldoFiscal.Text, out amount))
                txtSueldoFiscal.Text = Convert.ToDouble(txtSueldoFiscal.Text).ToString("N2");
            else
                txtSueldoFiscal.Text = Convert.ToDouble("0").ToString("N2");
        }

        private void txtInfonavit_KeyPress(object sender, KeyPressEventArgs e)
        {

            Funciones.soloNumerosDec(sender, e);
        }

        private void txtInfonavit_Leave(object sender, EventArgs e)
        {
            double amount = 0;
            if (!string.IsNullOrEmpty(txtInfonavit.Text) && double.TryParse(txtInfonavit.Text, out amount))
                txtInfonavit.Text = Convert.ToDouble(txtInfonavit.Text).ToString("N2");

        }

        private void txtCompensacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumerosDec(sender, e);
            llenaTotal();
        }

        private void txtCompensacion_Leave(object sender, EventArgs e)
        {
            double amount = 0;
            if (!string.IsNullOrEmpty(txtInfonavit.Text) && double.TryParse(txtInfonavit.Text, out amount))
                txtInfonavit.Text = Convert.ToDouble(txtInfonavit.Text).ToString("N2");
        }

        private void txtViaticos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumerosDec(sender, e);
            llenaTotal();
        }

        private void txtViaticos_Leave(object sender, EventArgs e)
        {
            double amount = 0;
            if (!string.IsNullOrEmpty(txtInfonavit.Text) && double.TryParse(txtInfonavit.Text, out amount))
                txtViaticos.Text = Convert.ToDouble(txtViaticos.Text).ToString("N2");
        }

        private void chkCompensacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCompensacion.Checked)
                txtCompensacion.Enabled = true;
            else
                txtCompensacion.Enabled = false;
            llenaTotal();
        }

        private void chkViaticos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViaticos.Checked)
                txtViaticos.Enabled = true;
            else
                txtViaticos.Enabled = false;
            llenaTotal();
        }

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            areValid &= isValid = luEmpleado.EditValue != null ? true : false;
            controler.SetError(luEmpleado, isValid ? string.Empty : "Valor Obligatorio.");

            areValid &= isValid = Funciones.validaNumeroDecimal(txtSueldoFiscal.Text);
            controler.SetError(txtSueldoFiscal, isValid ? string.Empty : "Valor Obligatorio.");

            areValid &= isValid = Funciones.validaNumeroDecimal(txtSueldoFiscal2.Text);
            controler.SetError(txtSueldoFiscal2, isValid ? string.Empty : "Valor Obligatorio.");

            areValid &= isValid = luObra.EditValue != null ? true : false;
            controler.SetError(luObra, isValid ? string.Empty : "Valor Obligatorio.");

            areValid &= isValid = string.IsNullOrEmpty(txtComplemento.Text) ? false : true;
            controler.SetError(txtComplemento, isValid ? string.Empty : "Valor Obligatorio.");


            //areValid &= isValid = gv.DataRowCount > 0 ? true : false;
            //controler.SetError(grid, isValid ? string.Empty : "Favor de llenar la Nomina Completa.");

            return areValid;

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

                    if (nominas == null)
                    {
                        nominas = new Nominas();
                        isNew = true;
                    }

                    nominas.Empleado = controler.GetObjectFromContext(luEmpleado.GetSelectedDataRow() as Empleado);
                    nominas.ObraId = luObra.GetSelectedDataRow() != null ? controler.GetObjectFromContext(luObra.GetSelectedDataRow() as Obra).Id : Convert.ToInt32((int?)null);
                    nominas.CompensacionActivo = chkCompensacion.Checked;
                    nominas.Compensacion = chkCompensacion.Checked ? Convert.ToDouble(txtCompensacion.Text) : (double?)null;
                    nominas.ViaticosActivo = chkViaticos.Checked;
                    nominas.Viaticos = chkViaticos.Checked ? Convert.ToDouble(txtViaticos.Text) : (double?)null;
                    nominas.SueldoFiscal = Convert.ToDouble(string.IsNullOrEmpty(txtSueldoFiscal.Text) ? "0" : txtSueldoFiscal.Text);
                    if (sueldoCompartido && !esContratistaNormal)
                        nominas.SueldoFiscal2 = Convert.ToDouble(string.IsNullOrEmpty(txtSueldoFiscal2.Text) ? "0" : txtSueldoFiscal2.Text);
                    else
                        nominas.SueldoFiscal2 = (double)0;
                    nominas.Complemento = Convert.ToDouble(string.IsNullOrEmpty(txtComplemento.Text) ? "0" : txtComplemento.Text);
                    nominas.PeriodoInicio = (isNew ? this.FechaIni : nominas.PeriodoInicio);
                    nominas.PeriodoFin = (isNew ? this.FechaFin : nominas.PeriodoFin);
                    nominas.Observaciones = txtObservaciones.Text.ToUpper();
                    nominas.SueldoReal = Convert.ToDouble(string.IsNullOrEmpty(txtSueldoReal.Text) ? "0" : txtSueldoReal.Text);
                    nominas.Infonavit = Convert.ToDouble(string.IsNullOrEmpty(txtInfonavit.Text) ? "0" : txtInfonavit.Text);
                    nominas.esPagoEfectivo = chkPagoEfectivo.Checked;
                    if (!nominas.NoEsNuevo) controler.Model.AddToNominas(nominas);

                    NominasDetalle detalle = null;

                    for (int i = 0; i < gv.RowCount; i++)
                    {

                        DataRow row = gv.GetDataRow(i);

                        if (row != null)
                        {
                            var id = (int?)null;
                            if (string.IsNullOrEmpty(row["Id"].ToString()) || Convert.ToInt32(row["Id"]) == 0)
                            {
                                detalle = new NominasDetalle();
                                id = (int?)null;

                                int? tipoCargoId = string.IsNullOrEmpty(row["TipoCargoId"].ToString()) ? (int?)null : Convert.ToInt32(row["TipoCargoId"]);
                                //if (tipoCargoId.HasValue)
                                //{
                                //    if (tipoCargoId.Value == Convert.ToInt32(tipoCargo.Vacaciones))
                                //    {
                                //        empleadoNomina.DiasVacaciones -= 1;
                                //    }
                                //}
                            }
                            else
                            {
                                id = Convert.ToInt32(row["Id"].ToString());
                                detalle = !isNew ? controler.Model.NominasDetalle.FirstOrDefault(D => D.Id == id) : null;
                            }
                            detalle.Nominas = this.nominas;
                            detalle.TipoCargoId = string.IsNullOrEmpty(row["TipoCargoId"].ToString()) ? Convert.ToInt32((int?)null) : Convert.ToInt32(row["TipoCargoId"]);
                            detalle.FechaDetalle = string.IsNullOrEmpty(row["FechaDetalle"].ToString()) ? (DateTime?)null : Convert.ToDateTime(row["FechaDetalle"]);
                            detalle.ObraId = string.IsNullOrEmpty(row["ObraId"].ToString()) ? Convert.ToInt32((int?)null) : Convert.ToInt32(row["ObraId"]);
                            detalle.Monto = string.IsNullOrEmpty(row["Monto"].ToString()) ? Convert.ToDouble((double?)null) : Convert.ToDouble(row["Monto"]);
                            detalle.Observaciones = string.IsNullOrEmpty(row["Observaciones"].ToString()) ? string.Empty : row["Observaciones"].ToString();
                            detalle.CargoDeduccion = string.IsNullOrEmpty(row["CargoDeduccion"].ToString()) ? (int?)null : Convert.ToInt32(row["CargoDeduccion"].ToString());
                            detalle.NumeroDiasHoras = string.IsNullOrEmpty(row["NumeroDiasHoras"].ToString()) ? (int?)null : Convert.ToInt32(row["NumeroDiasHoras"].ToString());
                            if (!detalle.NoEsNuevo) controler.Model.AddToNominasDetalle(detalle);

                        }
                    }


                    controler.Model.SaveChanges();
                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    if (isNew) nominas = null;
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
                        message = string.IsNullOrEmpty(error) ? string.Concat("La Nomina ha sido actualizada exitosamente.") : string.Concat("No se pudo actualizar la Nomina:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("La Nomina ha sido generada exitosamente.") : string.Concat("No se pudo generar la Nomina:\n", error);
                    }

                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                }

                if (string.IsNullOrEmpty(error))
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void pagosAdeudosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string boton = sender.ToString();
            var form = new frmNominasOtrosExtras(controler);
            var formExtras = new frmNominasExtras(controler);
            int tipoCargoId;
            bool isNew = (boton.Equals("Extras") || boton.Equals("Pagos/Adeudos") || boton.Equals("Viaticos") || boton.Equals("Faltas") || boton.Equals("Vacaciones")) ? true : false;

            if (nominasDetalle == null || (boton.Equals("Extras") || boton.Equals("Pagos/Adeudos") || boton.Equals("Viaticos") || boton.Equals("Faltas") || boton.Equals("Vacaciones")))
            {
                nominasDetalle = null;
                if (boton == "Extras")
                {
                    formExtras.opcion = tipoCargoId = (int)tipoCargo.Extras;
                    formExtras.empleado = luEmpleado.GetSelectedDataRow() != null ? luEmpleado.GetSelectedDataRow() as Empleado : null;
                    formExtras.Text = "Captura de Extras - " + (isNew ? "Nuevo" : "Editar");
                    formExtras.obra = luObra.EditValue != null ? (luObra.GetSelectedDataRow() as Obra) : null;

                }
                else if (boton == "Pagos/Adeudos")
                {
                    form.opcion = tipoCargoId = (int)tipoCargo.Pagos;
                    form.Text = "Captura de Adeudos/Deducciones - " + (isNew ? "Nuevo" : "Editar");
                }
                else if (boton == "Viaticos")
                {
                    form.opcion = tipoCargoId = (int)tipoCargo.Viaticos;
                    form.label1.Visible = false;
                    form.rgTipoNomina.Visible = false;
                    form.Text = "Captura de Viaticos - " + (isNew ? "Nuevo" : "Editar");
                }
                else if (boton == "Vacaciones")
                {
                    form.opcion = tipoCargoId = (int)tipoCargo.Vacaciones;
                    form.label1.Visible = false;
                    form.rgTipoNomina.Visible = false;
                    form.lblMonto.Visible = false;
                    form.txtMonto.Visible = false;
                    form.Text = "Captura de Vacaciones - " + (isNew ? "Nuevo" : "Editar");
                }
                else //(clickedButton == faltasToolStripMenuItem)
                {
                    form.opcion = tipoCargoId = (int)tipoCargo.Faltas;
                    form.label1.Visible = false;
                    form.rgTipoNomina.Visible = false;
                    form.Text = "Captura de Faltas - " + (isNew ? "Nuevo" : "Editar");
                }

                if (this.nominas != null)
                    form.nominas = this.nominas;
                else
                    form.nominas = null;
                form.nominasDetalle = null;
            }
            else
            {
                if (nominasDetalle.TipoCargoId == Convert.ToInt32(tipoCargo.Extras))
                {
                    formExtras.opcion = tipoCargoId = (int)tipoCargo.Extras;
                    formExtras.Text = "Captura de Extras - " + (isNew ? "Nuevo" : "Editar");
                }
                else if (nominasDetalle.TipoCargoId == Convert.ToInt32(tipoCargo.Pagos))
                {
                    form.opcion = tipoCargoId = (int)tipoCargo.Pagos;
                    form.Text = "Captura de Adeudos/Deducciones - " + (isNew ? "Nuevo" : "Editar");
                }
                else if (nominasDetalle.TipoCargoId == Convert.ToInt32(tipoCargo.Viaticos))
                {
                    form.opcion = tipoCargoId = (int)tipoCargo.Viaticos;
                    form.label1.Visible = false;
                    form.rgTipoNomina.Visible = false;
                    form.Text = "Captura de Viaticos - " + (isNew ? "Nuevo" : "Editar");
                }
                else if (nominasDetalle.TipoCargoId == Convert.ToInt32(tipoCargo.Vacaciones))
                {
                    form.opcion = tipoCargoId = (int)tipoCargo.Vacaciones;
                    form.label1.Visible = false;
                    form.rgTipoNomina.Visible = false;
                    form.lblMonto.Visible = false;
                    form.txtMonto.Visible = false;
                    form.Text = "Captura de Vacaciones - " + (isNew ? "Nuevo" : "Editar");
                }
                else //(clickedButton == faltasToolStripMenuItem)
                {
                    form.opcion = tipoCargoId = (int)tipoCargo.Faltas;
                    form.label1.Visible = false;
                    form.rgTipoNomina.Visible = false;
                    form.Text = "Captura de Faltas - " + (isNew ? "Nuevo" : "Editar");
                }

                form.nominas = formExtras.nominas = this.nominas;
                form.nominasDetalle = formExtras.nominasDetalle = this.nominasDetalle;
            }

            if (boton == "Extras" || (nominasDetalle != null ? (Convert.ToInt32(nominasDetalle.TipoCargoId) == 1 ? true : false) : false))
                formExtras.ShowDialog();
            else
                form.ShowDialog();

            if ((form.detalleNominas.Count > 0 || formExtras.detalleNominas.Count > 0) && (boton.Equals("Editar") || boton.Equals("DevExpress.XtraGrid.Views.Grid.GridView")))
                gv.DeleteRow(gv.FocusedRowHandle);

            foreach (NominaItem detalle in (tipoCargoId == 1 ? formExtras.detalleNominas.ToList() : form.detalleNominas.ToList()))
            {
                gv.AddNewRow();
                int rowHandle = gv.GetRowHandle(gv.DataRowCount);
                gv.SetRowCellValue(rowHandle, gv.Columns["Id"], detalle.Id);
                gv.SetRowCellValue(rowHandle, gv.Columns["TipoCargoId"], detalle.TipoCargoId);
                gv.SetRowCellValue(rowHandle, gv.Columns["FechaDetalle"], detalle.FechaDetalle);
                gv.SetRowCellValue(rowHandle, gv.Columns["ObraId"], detalle.ObraId);
                gv.SetRowCellValue(rowHandle, gv.Columns["Monto"], detalle.Monto);
                gv.SetRowCellValue(rowHandle, gv.Columns["Observaciones"], detalle.Observaciones);
                gv.SetRowCellValue(rowHandle, gv.Columns["CargoDeduccion"], detalle.CargoDeduccion.HasValue ? detalle.CargoDeduccion.Value : (int?)null);
                gv.SetRowCellValue(rowHandle, gv.Columns["NumeroDiasHoras"], detalle.NumeroDiasHoras.HasValue ? detalle.NumeroDiasHoras.Value : (int?)null);

                gv.UpdateCurrentRow();
                gv.RefreshData();

            }

            //if (boton == "Extras")
            formExtras.Dispose();
            //else
            form.Dispose();

            grid.RefreshDataSource();
            gv_FocusedRowChanged(null, null);

        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.DataRowCount > 0 && gv.SelectedRowsCount == 1 && gv.IsLoading == false)
            {
                DataRow row = gv.GetFocusedDataRow() as DataRow;
                if (row != null)
                {
                    //if (string.IsNullOrEmpty(row["Id"].ToString()) || Convert.ToInt32(row["Id"]) == 0)
                    //{                        
                    nominasDetalle = new NominaItem();
                    if (!string.IsNullOrEmpty(row["Id"].ToString()))
                        nominasDetalle.Id = Convert.ToInt32(row["Id"]);
                    nominasDetalle.NominasId = this.nominas != null ? this.nominas.Id : Convert.ToInt32((int?)null);
                    nominasDetalle.TipoCargoId = string.IsNullOrEmpty(row["TipoCargoId"].ToString()) ? (int?)null : Convert.ToInt32(row["TipoCargoId"]);
                    nominasDetalle.FechaDetalle = string.IsNullOrEmpty(row["FechaDetalle"].ToString()) ? (DateTime?)null : Convert.ToDateTime(row["FechaDetalle"]);
                    nominasDetalle.ObraId = string.IsNullOrEmpty(row["ObraId"].ToString()) ? (int?)null : Convert.ToInt32(row["ObraId"]);
                    nominasDetalle.Monto = string.IsNullOrEmpty(row["Monto"].ToString()) ? (double?)null : Convert.ToDouble(row["Monto"]);
                    nominasDetalle.Observaciones = string.IsNullOrEmpty(row["Observaciones"].ToString()) ? string.Empty : Convert.ToString(row["Observaciones"]);
                    nominasDetalle.CargoDeduccion = string.IsNullOrEmpty(row["CargoDeduccion"].ToString()) ? (int?)null : Convert.ToInt32(row["CargoDeduccion"]);
                    nominasDetalle.NumeroDiasHoras = string.IsNullOrEmpty(row["NumeroDiasHoras"].ToString()) ? (int?)null : Convert.ToInt32(row["NumeroDiasHoras"]);
                    //}
                    //else
                    //{
                    //    int id = Convert.ToInt32(row["Id"]);
                    //    var item = controler.Model.NominasDetalle.FirstOrDefault(N => N.Id == id);
                    //}
                }
                else
                    nominasDetalle = null;
            }

        }

        private void gv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                frmMessageBox confirm = new frmMessageBox(false);
                confirm.Title = "Confirmación";
                confirm.Message = "¿Desea Eliminar el Registro de la Nomina?";
                confirm.ShowDialog();
                if (confirm.DialogResult == System.Windows.Forms.DialogResult.No)
                    return;
                //if (MessageBox.Show("Eliminar Registro?", "Confirmación", MessageBoxButtons.YesNo) != DialogResult.Yes)
                //    return;
                GridView view = sender as GridView;
                DataRow row = gv.GetDataRow(gv.FocusedRowHandle);
                if (row != null)
                {
                    if (string.IsNullOrEmpty(row["Id"].ToString()) || Convert.ToInt32(row["Id"]) == 0)
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
            gv_FocusedRowChanged(null, null);
        }

        private void eliminarDetalleArticulo(int idDetalle)
        {
            NominasDetalle detalle = controler.Model.NominasDetalle.FirstOrDefault(A => A.Id == idDetalle);

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
                    new frmMessageBox(true) { Message = "Error al quitar el Registro: " + ex.GetBaseException().Message, Title = "Error" }.ShowDialog();
                    if (transaccion != null) transaccion.Rollback();
                }
                finally
                {
                    controler.Model.CloseConnection();
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "No es posible eliminar este Registro.", Title = "Error" }.ShowDialog();
            }


        }

        private void txtSueldoFiscal_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSueldoFiscal.Text) && Funciones.validaNumeroDecimal(txtSueldoFiscal.Text) && !esContratistaNormal && !chkPagoEfectivo.Checked)
            {
                txtComplemento.Text = (Convert.ToDouble(string.IsNullOrEmpty(txtSueldoReal.Text) ? "0" : txtSueldoReal.Text) - (Convert.ToDouble(string.IsNullOrEmpty(txtSueldoFiscal.Text) ? "0" : txtSueldoFiscal.Text) + Convert.ToDouble(string.IsNullOrEmpty(txtSueldoFiscal2.Text) ? "0" : txtSueldoFiscal2.Text))).ToString("N2");                
            }
            llenaTotal();
        }

        private void luEmpleado_EditValueChanged(object sender, EventArgs e)
        {
            Empleado empleado = luEmpleado.GetSelectedDataRow() as Empleado;
            //Refresco Informacion del Empleado
            controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, controler.Model.Empleado.Where(E => E.Id == empleado.Id).ToList());
            EmpleadoNomina _empleadoNomina = controler.Model.EmpleadoNomina.Where(X => X.EmpleadoId == empleado.Id).DefaultIfEmpty(null).SingleOrDefault();
            int? idNomina = _empleadoNomina!= null ? _empleadoNomina.Id: (int?)null;
                
            if (idNomina.HasValue)
                controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, controler.Model.EmpleadoNomina.Where(EN => EN.Id == idNomina.Value).ToList());
            //******************************
            
            if (empleado != null)
            {
                esContratistaNormal = empleado.EsContratista.HasValue ? (empleado.EsContratista.Value ? true : false) : false;
                try
                {
                    this.empleadoNomina = controler.Model.EmpleadoNomina.Where(X => X.EmpleadoId == empleado.Id).DefaultIfEmpty(null).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    this.empleadoNomina = null;
                }

                if (empleadoNomina != null)
                {
                    txtSueldoFiscal.Text = "0.00";
                    if (esContratistaNormal)
                    {
                        txtSueldoFiscal2.Text = "0.00";
                        txtInfonavit.Text = "0.00";
                        txtSueldoReal.Text = "0.00";
                        txtComplemento.Text = "0.00";
                    }
                    else
                    {
                        txtSueldoFiscal2.Text = "0.00";
                        txtInfonavit.Text = empleadoNomina.MontoRetener.HasValue ? empleadoNomina.MontoRetener.Value.ToString("N2") : "0.00";
                        txtSueldoReal.Text = empleadoNomina.EmpleadoHistorial.FirstOrDefault(E => E.FechaFin == null) != null ? empleadoNomina.EmpleadoHistorial.FirstOrDefault(E => E.FechaFin == null).Sueldo.Value.ToString("N2") : "0.00";
                        txtComplemento.Text = (Convert.ToDouble(string.IsNullOrEmpty(txtSueldoReal.Text) ? "0" : txtSueldoReal.Text) - (Convert.ToDouble(string.IsNullOrEmpty(txtSueldoFiscal.Text) ? "0" : txtSueldoFiscal.Text) + Convert.ToDouble(string.IsNullOrEmpty(txtSueldoFiscal2.Text) ? "0" : txtSueldoFiscal2.Text))).ToString("N2");
                    }
                    
                    if (empleadoNomina.TipoNomina.HasValue)
                    {
                        if (empleadoNomina.TipoNomina == Convert.ToInt32(tipoNominas.Mensual))
                            lblPeriodoPago.Text = "MENSUAL";
                        else if (empleadoNomina.TipoNomina == Convert.ToInt32(tipoNominas.Quincenal))
                            lblPeriodoPago.Text = "QUINCENAL";
                        else
                            lblPeriodoPago.Text = "SEMANAL";
                    }
                    else
                    {
                        lblPeriodoPago.Text = "PERIODO PENDIENTE";
                    }

                    //Solo se muestra el suedo fical 2, si el empleado es de sueldo compartido
                    lblSueldoCompartido.Text = empleadoNomina.SueldoCompartido.HasValue ? (empleadoNomina.SueldoCompartido.Value ? "SUELDO COMPARTIDO" : "SUELDO COMPLETO") : "SUELDO COMPLETO";
                    if ((empleadoNomina.SueldoCompartido.HasValue ? empleadoNomina.SueldoCompartido.Value : false) == true && !esContratistaNormal)
                        lblSueldo2.Visible = txtSueldoFiscal2.Visible = sueldoCompartido = true;
                    else
                        lblSueldo2.Visible = txtSueldoFiscal2.Visible = sueldoCompartido = false;

                    //Si es Contratista Principal puede modificar el complemento
                    if ((empleado.EsContratistaPrincipal.HasValue ? (empleado.EsContratistaPrincipal.Value ? true:false) : false) == true)
                        txtComplemento.ReadOnly = false;
                    else
                        txtComplemento.ReadOnly = true;
                }
                else
                {
                    //new frmMessageBox(true) { Message = "No fue posible obtener el Sueldo Real, Favor de Capturar.", Title = "Aviso" }.ShowDialog();
                    this.empleadoNomina = null;
                    txtInfonavit.Text = "0.00";
                    txtSueldoReal.Text = "0.00";
                    lblPeriodoPago.Text = "PERIODO PENDIENTE";
                    lblSueldoCompartido.Text = "SUELDO COMPLETO";
                    sueldoCompartido = false;
                }
            }
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            if (nominasDetalle != null)
            {
                var view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
                var pt = view.GridControl.PointToClient(Control.MousePosition);
                var info = view.CalcHitInfo(pt);

                if (info.InRow || info.InRowCell)
                {
                    btnEditar_Click(sender, e);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRowsCount == 1)
            {
                pagosAdeudosToolStripMenuItem_Click(sender, e);
            }
            else
            {
                new frmMessageBox(true) { Message = "Favor de seleccionar el elemento a editar.", Title = "Confirmación" }.ShowDialog();
            }
        }

        private void gv_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            llenaTotal();
        }

        private void gv_RowCountChanged(object sender, EventArgs e)
        {
            llenaTotal();
        }

        private void gv_RowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            llenaTotal();
        }

        private void txtSueldoFiscal2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Funciones.validaNumeroDecimal(txtSueldoFiscal2.Text))
                Funciones.soloNumerosDec(sender, e);
        }

        private void txtSueldoFiscal2_Leave(object sender, EventArgs e)
        {
            double amount = 0;
            if (!string.IsNullOrEmpty(txtSueldoFiscal2.Text) && double.TryParse(txtSueldoFiscal2.Text, out amount))
                txtSueldoFiscal2.Text = Convert.ToDouble(txtSueldoFiscal2.Text).ToString("N2");
            else
                txtSueldoFiscal2.Text = Convert.ToDouble("0").ToString("N2");
        }

        private void txtSueldoFiscal2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSueldoFiscal2.Text) && Funciones.validaNumeroDecimal(txtSueldoFiscal2.Text))
            {
                txtComplemento.Text = (Convert.ToDouble(string.IsNullOrEmpty(txtSueldoReal.Text) ? "0" : txtSueldoReal.Text) - (Convert.ToDouble(string.IsNullOrEmpty(txtSueldoFiscal.Text) ? "0" : txtSueldoFiscal.Text) + Convert.ToDouble(string.IsNullOrEmpty(txtSueldoFiscal2.Text) ? "0" : txtSueldoFiscal2.Text))).ToString("N2");
                llenaTotal();
            }
        }

        private void txtComplemento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtComplemento.ReadOnly == false)
            {
                if (Funciones.validaNumeroDecimal(txtComplemento.Text))
                    Funciones.soloNumerosDec(sender, e);
            }
        }

        private void txtComplemento_Leave(object sender, EventArgs e)
        {
            double amount = 0;
            if (txtComplemento.ReadOnly == false)
            {
                if (!string.IsNullOrEmpty(txtComplemento.Text) && double.TryParse(txtComplemento.Text, out amount))
                    txtComplemento.Text = Convert.ToDouble(txtComplemento.Text).ToString("N2");
                else
                    txtComplemento.Text = Convert.ToDouble("0").ToString("N2");
            }
        }

        private void txtComplemento_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtComplemento.Text) && Funciones.validaNumeroDecimal(txtComplemento.Text))
            {
                //txtComplemento.Text = (Convert.ToDouble(string.IsNullOrEmpty(txtSueldoReal.Text) ? "0" : txtSueldoReal.Text) - (Convert.ToDouble(string.IsNullOrEmpty(txtSueldoFiscal.Text) ? "0" : txtSueldoFiscal.Text) + Convert.ToDouble(string.IsNullOrEmpty(txtSueldoFiscal2.Text) ? "0" : txtSueldoFiscal2.Text))).ToString("N2");
                llenaTotal();
            }
        }

        private void chkPagoEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            Empleado _empleado = luEmpleado.GetSelectedDataRow() as Empleado;
            if (chkPagoEfectivo.Checked && _empleado!=null)
            {
                chkViaticos.Checked = false;
                chkCompensacion.Checked = false;
                txtCompensacion.Text = "0.00";
                txtViaticos.Text = "0.00";
                txtSueldoReal.Text = "0.00";
                txtComplemento.Text = "0.00";
                txtInfonavit.Text = "0.00";                
                txtSueldoFiscal2.Text = "0.00";
                txtCompensacion.ReadOnly = true;
                txtViaticos.ReadOnly = true;
                txtComplemento.ReadOnly = true;
                txtSueldoFiscal2.ReadOnly = true;
            }
            else
            {
                txtCompensacion.ReadOnly = false;
                txtViaticos.ReadOnly = false;

                if ((_empleado.EsContratistaPrincipal.HasValue ? (_empleado.EsContratistaPrincipal.Value ? true : false) : false) == true)
                    txtComplemento.ReadOnly = false;
                else
                    txtComplemento.ReadOnly = true;

                txtSueldoFiscal2.ReadOnly = false;

                if (empleadoNomina != null)
                    txtSueldoReal.Text = empleadoNomina.EmpleadoHistorial.FirstOrDefault(E => E.FechaFin == null) != null ? empleadoNomina.EmpleadoHistorial.FirstOrDefault(E => E.FechaFin == null).Sueldo.Value.ToString("N2") : "0.00";
                else
                    txtSueldoReal.Text = "0.00";
            }
            llenaTotal();
        }

    }
}
