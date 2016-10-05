using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeisaBD;
using DevExpress.XtraEditors.Controls;
using System.Collections;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Globalization;

namespace Reportes
{
    public partial class frmNominaSemanal : DevExpress.XtraEditors.XtraForm
    {
        private DateTime fechaIni, fechaFin;
        public frmNominaSemanal()
        {
            InitializeComponent();
        }

        private void frmNominaSemanal_Load(object sender, EventArgs e)
        {
            llenaCombos();
            rgOpcion.EditValue = 4;
            monthCalendar.SelectionStart = DateTime.Today;
        }

        private void llenaCombos()
        {
            using (GEISAEntities obra = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                ckListObra.DataSource = obra.Obra.OrderBy(o => o.Nombre).ToList();
                ckListObra.DisplayMember = "Nombre";
                ckListObra.ValueMember = "Id";
                ckListObra.IncrementalSearch = true;

            }

            using (GEISAEntities empleado = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                chkListEmpleados.DataSource = empleado.Empleado.ToList().OrderBy(o => o.NombreCompleto);
                chkListEmpleados.DisplayMember = "NombreCompleto";
                chkListEmpleados.ValueMember = "Id";
                chkListEmpleados.SortOrder = System.Windows.Forms.SortOrder.Ascending;
                chkListEmpleados.IncrementalSearch = true;
            }
        }

        private void chkTodosObras_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodosObras.Checked == true)
                ckListObra.CheckAll();
            else
                ckListObra.UnCheckAll();
        }

        private void chkGeisa_CheckedChanged(object sender, EventArgs e)
        {
            ckListObra.UnCheckAll();
            ckListObra.ForceInitialize();
            for (int i = 0; i < (ckListObra.DataSource as IList).Count; i++)
            {
                Obra obra = ckListObra.GetItem(i) as Obra;
                //Obra CurrentObra= obra.SelectedValue as Obra;
                if (obra.EmpresaId == TipoEmpresa.GEISA.Id)
                    if (chkGeisa.Checked == false)
                        ckListObra.SetItemCheckState(i, CheckState.Unchecked);
                    else
                        ckListObra.SetItemCheckState(i, CheckState.Checked);
                else
                    ckListObra.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void chkDiproe_CheckedChanged(object sender, EventArgs e)
        {
            ckListObra.UnCheckAll();
            ckListObra.ForceInitialize();
            for (int i = 0; i < (ckListObra.DataSource as IList).Count; i++)
            {
                Obra obra = ckListObra.GetItem(i) as Obra;
                //Obra CurrentObra= obra.SelectedValue as Obra;
                if (obra.EmpresaId == TipoEmpresa.DIPROE.Id)
                    if (chkDiproe.Checked == false)
                        ckListObra.SetItemCheckState(i, CheckState.Unchecked);
                    else
                        ckListObra.SetItemCheckState(i, CheckState.Checked);
                else
                    ckListObra.SetItemCheckState(i, CheckState.Unchecked);

            }
        }

        private void chkTodosEmpleados_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodosEmpleados.Checked == true)
                chkListEmpleados.CheckAll();
            else
                chkListEmpleados.UnCheckAll();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            string Empleados = string.Empty;
            string obras = string.Empty;
            if (chkListEmpleados.CheckedItems.Count > 0)
            {
                foreach (Empleado item in chkListEmpleados.CheckedItems)
                {
                    Empleados = Empleados + string.Concat(item.Id, ",");
                }
                Empleados = Empleados.TrimEnd(',');
            }
            else
            {
                GEISAEntities Empleado = new GEISAEntities(GEISAEntities.DefaultConnectionString);
                foreach (Empleado item in Empleado.Empleado.ToList())
                {
                    Empleados = Empleados + string.Concat(item.Id, ",");
                }
                Empleados = Empleados.TrimEnd(',');
            }

            if (ckListObra.CheckedItems.Count > 0)
            {
                foreach (Obra item in ckListObra.CheckedItems)
                {
                    obras = obras + string.Concat(item.Id, ",");
                }
                obras = obras.TrimEnd(',');
            }
            else
            {
                GEISAEntities obra = new GEISAEntities(GEISAEntities.DefaultConnectionString);
                foreach (Obra item in obra.Obra.ToList())
                {
                    obras = obras + string.Concat(item.Id, ",");
                }
                obras = obras.TrimEnd(',');
            }

            if (chkListEmpleados.ItemCount > 0 && ckListObra.ItemCount > 0 && monthCalendar.SelectionRange.Start != null && this.fechaIni!=DateTime.MinValue && this.fechaFin!=DateTime.MinValue )
            {
                source.DataSource = new NominasSemanal(obras,Empleados,this.fechaIni,this.fechaFin,Convert.ToInt32(rgOpcion.EditValue)).Items;
                System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                pg.Margins.Top = 1;
                pg.Margins.Bottom = 1;
                pg.Margins.Left = 1;
                pg.Margins.Right = 1;
                //System.Drawing.Printing.PaperSize size = new PaperSize();
                //size.RawKind = (int)PaperKind.Letter;
                //pg.PaperSize = size;
                this.viewer.SetPageSettings(pg);
                this.viewer.ZoomPercent = 100;
                this.viewer.LocalReport.DisplayName = this.Text;
                this.viewer.RefreshReport();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            chkListEmpleados.UnCheckAll();
            ckListObra.UnCheckAll();
            monthCalendar.SelectionStart = DateTime.Today;
            rgOpcion.EditValue = 1;
            chkTodosEmpleados.Checked = false;
            chkGeisa.Checked = false;
            chkDiproe.Checked = false;
            chkTodosObras.Checked = false;
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
            lblNomina.Text = "Nomina Del \n" + fechaIni.ToShortDateString() + " al " + fechaFin.ToShortDateString();
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
    }
}
