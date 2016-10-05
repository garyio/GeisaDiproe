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
using Reportes;
using System.Data.Entity.Core.Objects;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Reporting.WinForms;
using System.Data.Entity;
using System.Data.Common;
using System.Globalization;

namespace SistemaGEISA
{
    public partial class frmBuscarIngresos : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }

        public frmBuscarIngresos(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;

        }

        private void frmBuscarIngresos_Load(object sender, EventArgs e)
        {
            grid.DataSource = controler.Model.getFacturasBuscador();
        }

        private void gv_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                var category = View.GetRowCellValue(e.RowHandle, "FechaCancelacion");
                if (category != null)
                {
                    if (!string.IsNullOrEmpty(category.ToString()))
                    {
                        e.Appearance.ForeColor = Color.Red;

                    }
                }

            }
        }
    }
}
