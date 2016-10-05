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

namespace Reportes
{
    public partial class frmVehiculosGasolina : DevExpress.XtraEditors.XtraForm
    {
        public frmVehiculosGasolina()
        {
            InitializeComponent();
        }

        private void llenaCombos()
        {

            using (GEISAEntities empresa = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                ckListEmpresas.DataSource = empresa.Empresa.ToList().OrderBy(o => o.Id);
                ckListObra.DisplayMember = "NombreFiscal";
                ckListObra.ValueMember = "Id";
            }

            using (GEISAEntities obra = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                ckListObra.DataSource = obra.Obra.OrderBy(o => o.Nombre).ToList();
                ckListObra.DisplayMember = "Nombre";
                ckListObra.ValueMember = "Id";
                ckListObra.IncrementalSearch = true;
                //ckListBox.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            }

            using (GEISAEntities vehiculos = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                ckListVehiculos.DataSource = vehiculos.Vehiculo.ToList().OrderBy(o => o.VehiculoCompleto);
                ckListVehiculos.DisplayMember = "VehiculoCompleto";
                ckListVehiculos.ValueMember = "Id";
                ckListVehiculos.IncrementalSearch = true;
            }

                DataTable dtTipos = new DataTable();
                dtTipos.Columns.Add("Id", typeof(int));
                dtTipos.Columns.Add("Text");
                dtTipos.Rows.Add(new object[] { 1, "EFECTIVO" });
                dtTipos.Rows.Add(new object[] { 2, "TICKET CAR" });
                dtTipos.Rows.Add(new object[] { 3, "VALES" });

                ckListTipoDeposito.DataSource = dtTipos.DefaultView;
                ckListTipoDeposito.DisplayMember = "Text";
                ckListTipoDeposito.ValueMember = "Id";
                ckListTipoDeposito.IncrementalSearch = true;            
        }

        private void frmVehiculosGasolina_Load(object sender, EventArgs e)
        {
            dateIni.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateFin.EditValue = ((DateTime)dateIni.EditValue).AddMonths(1).AddSeconds(-1);
            llenaCombos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ckListEmpresas.DataSource = null;
            ckListObra.DataSource = null;
            ckListTipoDeposito.DataSource = null;
            ckListVehiculos.DataSource = null;
            ckDiproe.Checked = ckGeisa.Checked = ckTodos.Checked = ckTodosDepositos.Checked = false;
            dateIni.EditValue = DateTime.Today;
            dateFin.EditValue = DateTime.Today;
        }

        private void ckTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTodos.Checked == true)
                ckListObra.CheckAll();
            else
                ckListObra.UnCheckAll();
        }

        private void ckGeisa_CheckedChanged(object sender, EventArgs e)
        {
            ckListObra.UnCheckAll();
            ckListObra.ForceInitialize();
            for (int i = 0; i < (ckListObra.DataSource as IList).Count; i++)
            {
                Obra obra = ckListObra.GetItem(i) as Obra;
                //Obra CurrentObra= obra.SelectedValue as Obra;
                if (obra.EmpresaId == TipoEmpresa.GEISA.Id)
                    if (ckGeisa.Checked == false)
                        ckListObra.SetItemCheckState(i, CheckState.Unchecked);
                    else
                        ckListObra.SetItemCheckState(i, CheckState.Checked);
                else
                    ckListObra.SetItemCheckState(i, CheckState.Unchecked);
            }  
        }

        private void ckDiproe_CheckedChanged(object sender, EventArgs e)
        {
            ckListObra.UnCheckAll();
            ckListObra.ForceInitialize();
            for (int i = 0; i < (ckListObra.DataSource as IList).Count; i++)
            {
                Obra obra = ckListObra.GetItem(i) as Obra;
                //Obra CurrentObra= obra.SelectedValue as Obra;
                if (obra.EmpresaId == TipoEmpresa.DIPROE.Id)
                    if (ckDiproe.Checked == false)
                        ckListObra.SetItemCheckState(i, CheckState.Unchecked);
                    else
                        ckListObra.SetItemCheckState(i, CheckState.Checked);
                else
                    ckListObra.SetItemCheckState(i, CheckState.Unchecked);

            } 
        }

        private void ckTodosDepositos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTodosDepositos.Checked == true)
                ckListTipoDeposito.CheckAll();
            else
                ckListTipoDeposito.UnCheckAll();
        }

        private void ckTodosVehiculos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTodosVehiculos.Checked == true)
                ckListVehiculos.CheckAll();
            else
                ckListVehiculos.UnCheckAll();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            string empresas = string.Empty;
            string vehiculos = string.Empty;
            string tipoDepositos = string.Empty;
            string obras = string.Empty;

            if (ckListEmpresas.CheckedItems.Count > 0)
            {
                foreach (Empresa item in ckListEmpresas.CheckedItems)
                {
                    empresas = empresas + string.Concat(item.Id, ",");
                }
                empresas = empresas.TrimEnd(',');
            }
            else
            {
                GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
                foreach (Empresa item in model.Empresa.ToList())
                {
                    empresas = empresas + string.Concat(item.Id, ",");
                }
                empresas = empresas.TrimEnd(',');
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

            if (ckListVehiculos.CheckedItems.Count > 0)
            {
                foreach (Vehiculo item in ckListVehiculos.CheckedItems)
                {
                    vehiculos = vehiculos + string.Concat(item.Id, ",");
                }
                vehiculos = vehiculos.TrimEnd(',');
            }
            else
            {
                GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
                foreach (Vehiculo item in model.Vehiculo.ToList())
                {
                    vehiculos = vehiculos + string.Concat(item.Id, ",");
                }
                vehiculos = vehiculos.TrimEnd(',');
            }

            if (ckListTipoDeposito.CheckedItems.Count > 0)
            {
                foreach (var item in ckListTipoDeposito.CheckedItems)
                {
                    var dataRowView = (DataRowView)item;
                    tipoDepositos = tipoDepositos + string.Concat(dataRowView["Id"].ToString(), ",");
                }
                tipoDepositos = tipoDepositos.TrimEnd(',');
            }
            else
            {
                foreach (var item in ckListTipoDeposito.Items)
                {
                    tipoDepositos = tipoDepositos + string.Concat(item, ",");
                }
                tipoDepositos = tipoDepositos.TrimEnd(',');
            }

            if (ckListEmpresas.ItemCount>0 && ckListObra.ItemCount>0 && ckListTipoDeposito.ItemCount>0 && ckListVehiculos.ItemCount>0)
            {
                this.viewer.LocalReport.EnableExternalImages = true;
                source.DataSource = new VehiculoDetalleGasolina((DateTime)dateIni.EditValue, (DateTime)dateFin.EditValue, empresas, vehiculos, tipoDepositos, obras).Items;
                this.viewer.ZoomPercent = 100;
                this.viewer.LocalReport.DisplayName = this.Text;
                this.viewer.RefreshReport();

            }

        }
    }
}
