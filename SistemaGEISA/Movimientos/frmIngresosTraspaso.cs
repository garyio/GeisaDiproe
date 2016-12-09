using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeisaBD;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using System.Data.Common;
using System.Data;
using DevExpress.XtraEditors;

namespace SistemaGEISA
{
    public partial class frmIngresosTraspaso : DevExpress.XtraEditors.XtraForm
    {
        public getDetalleIngresos_Result itemOrigen { get; set; }
        public getDetalleIngresos_Result itemDestino { get; set; }
        private Controler controler { get; set; }
        public Obra obraDefault;
        public Cliente clienteDefault;
        public Empresa empresaDefault;

        public frmIngresosTraspaso(Controler _controler, Obra _obra, Cliente _cliente, Empresa _empresa)
        {
            InitializeComponent();
            controler = _controler ?? new Controler();
            this.obraDefault = _obra;
            this.clienteDefault = _cliente;
            this.empresaDefault = _empresa;
        }

        private void frmIngresosTraspaso_Load(object sender, EventArgs e)
        {
            llenaCombos();

            //Asigno valores por default
            luObraOrigen.EditValue = this.obraDefault.Id;
            luClientesOrigen.EditValue =  this.clienteDefault.Id;
            luEmpresaOrigen.EditValue = luEmpresaDestino.EditValue = this.empresaDefault.Id;
            grid1.DataSource = controler.Model.getDetalleIngresos(this.obraDefault.Id, this.clienteDefault.Id, true,false).ToList();
        }

        private void llenaCombos()
        {
            luObraOrigen.Properties.DataSource = controler.Model.Obra.OrderBy(O => O.Nombre).ToList();
            luObraOrigen.Properties.DisplayMember = "Nombre";
            luObraOrigen.Properties.ValueMember = "Id";

            luObraDestino.Properties.DataSource = controler.Model.Obra.Where(O => O.Id != this.obraDefault.Id).OrderBy(O => O.Nombre).ToList();
            luObraDestino.Properties.DisplayMember = "Nombre";
            luObraDestino.Properties.ValueMember = "Id";

            luEmpresaOrigen.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luEmpresaOrigen.Properties.DisplayMember = "NombreComercial";
            luEmpresaOrigen.Properties.ValueMember = "Id";

            luEmpresaDestino.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luEmpresaDestino.Properties.DisplayMember = "NombreComercial";
            luEmpresaDestino.Properties.ValueMember = "Id";

            luClientesOrigen.Properties.DataSource = controler.Model.Cliente.OrderBy(O => O.NombreFiscal).ToList();
            luClientesOrigen.Properties.DisplayMember = "NombreFiscal";
            luClientesOrigen.Properties.ValueMember = "Id";

            luClienteDestino.Properties.DataSource = controler.Model.Cliente.Where(C => C.Id != this.clienteDefault.Id).OrderBy(O => O.NombreFiscal).ToList();
            luClienteDestino.Properties.DisplayMember = "NombreFiscal";
            luClienteDestino.Properties.ValueMember = "Id";

        }

        private void gv1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv1.GetFocusedRow() != null)
            {
                itemOrigen = gv1.GetFocusedRow() as getDetalleIngresos_Result;

            }
        }

        private void gv2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv2.GetFocusedRow() != null)
            {
                itemDestino = gv2.GetFocusedRow() as getDetalleIngresos_Result;

            }
        }

        private void luObraDestino_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookup = (sender != null ? sender : (LookUpEdit)null) as LookUpEdit;
            Obra obra = luObraDestino.GetSelectedDataRow() as Obra;            
            //Pongo automaticamente el cliente de la obra.
            if (lookup != null ? (lookup.Name == "luObraDestino") : false)
                luClienteDestino.EditValue = obra != null ? obra.ClienteId : (int?)null;
            
            Cliente cliente = luClienteDestino.GetSelectedDataRow() as Cliente;
            Empresa empresa = luEmpresaDestino.GetSelectedDataRow() as Empresa;

            if (luObraDestino.IsLoading == false && obra != null && cliente != null && empresa != null)
            {
                grid2.DataSource = controler.Model.getDetalleIngresos(obra.Id, cliente.Id, false,false).ToList().Where(F => F.FechaCancelacion == null);
            }
        }

        //private void gv1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
            //if (gv1.FocusedColumn.FieldName == "Seleccion" && luEmpresaOrigen.EditValue != null && luClientesOrigen.EditValue != null && luEmpresaOrigen.EditValue != null)
            //{
            //    for (int i = 0; i < gv1.DataRowCount; i++)
            //    {
            //        getDetalleIngresos_Result currentRow = gv1.GetFocusedRow() as getDetalleIngresos_Result;
            //        if (Convert.ToBoolean(gv1.GetRowCellValue(i, "Seleccion")) == true && gv1.GetRowCellValue(i, "Id").ToString() != currentRow.Id.ToString())
            //        {
            //            gv1.SetRowCellValue(i, "Seleccion", false);
            //        }                    

            //    }
            //}

        //}

        //private void gv2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
            //if (gv2.FocusedColumn.FieldName == "Seleccion" && luEmpresaDestino.EditValue != null && luClienteDestino.EditValue != null && luEmpresaDestino.EditValue != null)
            //{
            //    for (int i = 0; i < gv2.DataRowCount; i++)
            //    {
            //        getDetalleIngresos_Result currentRow = gv2.GetFocusedRow() as getDetalleIngresos_Result;
            //        if (Convert.ToBoolean(gv2.GetRowCellValue(i, "Seleccion")) == true && gv2.GetRowCellValue(i, "Id").ToString() != currentRow.Id.ToString())
            //        {
            //            gv2.SetRowCellValue(i, "Seleccion", false);
            //        }

            //    }
            //}
        //}







    }
}
