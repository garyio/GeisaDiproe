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

    public partial class frmConceptos : DevExpress.XtraEditors.XtraForm
    {
        private Controler _controler = new Controler();

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }

        private Conceptos conceptos { get; set; }
        public frmConceptos()
        {
            InitializeComponent();
            Controler.PermisosEnFormulario(Name);
            btnNuevo.Enabled = Controler.TienePermiso(PermisosEnum.Agregar);
            btnEditar.Enabled = Controler.TienePermiso(PermisosEnum.Actualizar);
            llenaGrid();
        }
        private void llenaGrid()
        {
            grid.DataSource = Controler.Model.Conceptos.ToList();
        }
        private void botones(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    btnNuevo.Visible = true;
                    toolStripSeparator1.Visible = false;
                    btnEditar.Visible = false;
                    break;
                case 2:
                    btnNuevo.Visible = true;
                    toolStripSeparator1.Visible = true;
                    btnEditar.Visible = true;
                    break;
            }
        }
        private void abrirForm(bool nuevo)
        {
            var form = new frmConceptosNew(Controler);
            form.Text = "Conceptos : " + (nuevo ? "Nuevo" : "Editar");
            if (!nuevo)
            {
                form.conceptos = conceptos;
            }
            else
            {
                form.conceptos = null;
            }

            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                llenaGrid();
            }

            gv_FocusedRowChanged(null, null);
        }
        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.DataRowCount > 0)
            {
                conceptos = gv.GetFocusedRow() as Conceptos;

                if (conceptos != null)
                {
                    botones(2);
                }
            }
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
        private void frmConceptos_Load(object sender, EventArgs e)
        {
            llenaGrid();

            if (gv.DataRowCount == 0)
            {
                botones(1);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            abrirForm(true);
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
    }
}