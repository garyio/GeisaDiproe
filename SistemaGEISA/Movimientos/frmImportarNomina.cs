using GeisaBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGEISA
{
    public partial class frmImportarNomina : DevExpress.XtraEditors.XtraForm
    {
        public DateTime fechaIni, fechaFin, fechaIniSource, fechaFinSource;
        private Controler controler { get; set; }

        public frmImportarNomina(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        private void frmImportarNomina_Load(object sender, EventArgs e)
        {
            llenaCombos();
            monthCalendar_DateSelected(null, null);
        }

        private void llenaCombos()
        {
            luObra.DataSource = controler.Model.Obra.ToList();
            luObra.DisplayMember = "Nombre";
            luObra.ValueMember = "Id";

            luEmpleado.DataSource = controler.Model.Empleado.Where(D => D.Activo == true).ToList();
            luEmpleado.DisplayMember = "NombreCompleto";
            luEmpleado.ValueMember = "Id";

        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {

            if (monthCalendar.SelectionRange.Start.DayOfWeek == DayOfWeek.Sunday)
            {
                fechaIni = FirstDayOfWeek(monthCalendar.SelectionRange.Start.AddDays(-1)).AddDays(1);
                fechaFin = LastDayOfWeek(monthCalendar.SelectionRange.Start.AddDays(-1)).AddDays(1);
            }
            else
            {
                fechaIni = FirstDayOfWeek(monthCalendar.SelectionRange.Start).AddDays(1);
                fechaFin = LastDayOfWeek(monthCalendar.SelectionRange.Start).AddDays(1);
            }
            lblSemana.Text = "Nomina Del \n" + fechaIni.ToShortDateString() + " al " + fechaFin.ToShortDateString();
            llenaGrid();
            //grid.DataSource = Controler.Model.Nominas.Where(N => N.PeriodoInicio >= fechaIni && N.PeriodoFin <= fechaFin).ToList();
        }

        private void llenaGrid()
        {
            if (chkActual.Checked)
            {
                if (rgOpcion.EditValue != null)
                {

                    if (Convert.ToInt32(rgOpcion.EditValue) == 1)
                    {
                        grid.DataSource = controler.Model.Nominas.Where(N => N.PeriodoInicio >= fechaIni && N.PeriodoFin <= fechaFin).ToList();
                    }
                    else if (Convert.ToInt32(rgOpcion.EditValue) == 2) //semanal
                    {
                        List<Nominas> items = controler.Model.Nominas.Where(N => N.PeriodoInicio >= fechaIni && N.PeriodoFin <= fechaFin).ToList();
                        List<Nominas> itemsOk = new List<Nominas>();
                        foreach (Nominas item in items)
                        {
                            EmpleadoNomina empleadoNomina = item.Empleado.EmpleadoNomina.FirstOrDefault();
                            if (empleadoNomina != null)
                            {

                                int? tipoNomina = empleadoNomina.TipoNomina.HasValue ? Convert.ToInt32(empleadoNomina.TipoNomina) : (int?)null;
                                if ((tipoNomina.HasValue ? tipoNomina.Value : 0) == 1)
                                    itemsOk.Add(item);
                            }
                        }
                        grid.DataSource = itemsOk.ToList();
                    }
                    else if (Convert.ToInt32(rgOpcion.EditValue) == 3) // quincenal
                    {
                        List<Nominas> items = controler.Model.Nominas.Where(N => N.PeriodoInicio >= fechaIni && N.PeriodoFin <= fechaFin).ToList();
                        List<Nominas> itemsOk = new List<Nominas>();
                        foreach (Nominas item in items)
                        {
                            EmpleadoNomina empleadoNomina = item.Empleado.EmpleadoNomina.FirstOrDefault();
                            if (empleadoNomina != null)
                            {

                                int? tipoNomina = empleadoNomina.TipoNomina.HasValue ? Convert.ToInt32(empleadoNomina.TipoNomina) : (int?)null;
                                if ((tipoNomina.HasValue ? tipoNomina.Value : 0) == 2)
                                    itemsOk.Add(item);
                            }
                        }
                        grid.DataSource = itemsOk.ToList();
                    }
                    else // mensual
                    {
                        List<Nominas> items = controler.Model.Nominas.Where(N => N.PeriodoInicio >= fechaIni && N.PeriodoFin <= fechaFin).ToList();
                        List<Nominas> itemsOk = new List<Nominas>();
                        foreach (Nominas item in items)
                        {
                            EmpleadoNomina empleadoNomina = item.Empleado.EmpleadoNomina.FirstOrDefault();
                            if (empleadoNomina != null)
                            {

                                int? tipoNomina = empleadoNomina.TipoNomina.HasValue ? Convert.ToInt32(empleadoNomina.TipoNomina) : (int?)null;
                                if ((tipoNomina.HasValue ? tipoNomina.Value : 0) == 3)
                                    itemsOk.Add(item);
                            }
                        }
                        grid.DataSource = itemsOk.ToList();
                    }
                }

            }
            else if (chkTodos.Checked)
            {
                grid.DataSource = controler.Model.Nominas.ToList();
            }
            else
            {
                return;
            }

            //if(this.fechaIni !=null && this.fechaFin!=null)
            //    grid.DataSource = Controler.Model.Nominas.Where(N => N.PeriodoInicio >= fechaIni && N.PeriodoFin <= fechaFin).ToList();
        }

        public static DateTime FirstDayOfWeek(DateTime date)
        {
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }

        public static DateTime LastDayOfWeek(DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }

        private void chkActual_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkActual.Checked)
            {
                chkTodos.Checked = false;
                rgOpcion.Enabled = true;
            }
            else
            {
                grid.DataSource = null;
                rgOpcion.EditValue = null;
                rgOpcion.Enabled = false;
            }
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                chkActual.Checked = false;
                llenaGrid();
            }
            else
            {
                grid.DataSource = null;
            }
        }

        private void rgOpcion_EditValueChanged(object sender, EventArgs e)
        {
            llenaGrid();
        }

        private void chkTodasSemanas_CheckedChanged(object sender, EventArgs e)
        {
            llenaGrid();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

            if (gv.DataRowCount > 0)
            {
                DbTransaction transaccion = null;
                try
                {
                    transaccion = controler.Model.BeginTransaction();
                    for (int i = 0; i < gv.RowCount; i++)
                    {
                        Nominas nomina = gv.GetRow(i) as Nominas;

                        if (nomina != null)
                        {

                            //var id = Convert.ToInt32(row["Id"].ToString());
                            //NominasDetalle detalleNomina = controler.Model.NominasDetalle.FirstOrDefault(D => D.Id == id);

                            Nominas nominas = new Nominas();
                            nominas.Empleado = nomina.Empleado;
                            nominas.ObraId = nomina.ObraId;
                            nominas.CompensacionActivo = nomina.CompensacionActivo;
                            nominas.Compensacion = nomina.Compensacion;
                            nominas.ViaticosActivo = nomina.ViaticosActivo;
                            nominas.Viaticos = nomina.Viaticos;
                            nominas.SueldoFiscal = nomina.SueldoFiscal;
                            nominas.PeriodoInicio = this.fechaIniSource;
                            nominas.PeriodoFin = this.fechaFinSource;
                            nominas.Observaciones = nomina.Observaciones;
                            nominas.SueldoReal = nomina.SueldoReal;
                            nominas.Infonavit = nomina.Infonavit;
                            nominas.esPagoEfectivo = nomina.esPagoEfectivo;
                            if (!nominas.NoEsNuevo) controler.Model.AddToNominas(nominas);

                            foreach(NominasDetalle item in nomina.NominasDetalle.ToList()){
                                NominasDetalle detalle = new NominasDetalle();
                                detalle.Nominas = nominas;
                                detalle.TipoCargoId = item.TipoCargoId;
                                detalle.FechaDetalle = item.FechaDetalle;
                                detalle.ObraId = item.ObraId;
                                detalle.Monto = item.Monto;
                                detalle.Observaciones = item.Observaciones;
                                detalle.CargoDeduccion = item.CargoDeduccion;
                                detalle.NumeroDiasHoras = item.NumeroDiasHoras;
                                if (!detalle.NoEsNuevo) controler.Model.AddToNominasDetalle(detalle);
                            }
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
            else
            {
                new frmMessageBox(true) { Message = "No hay Informacion a Importar, Seleccione otra Semana.", Title = "Aviso" }.ShowDialog();
            }
        }
    }
}
