using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GeisaBD;

namespace SistemaGEISA
{
    public partial class frmAgregarFacturas : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }
        public Proveedor proveedor { get; set; }
        private DataTable dt;
        public frmAgregarFacturas(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        private void obtenerFacturas()
        {
            if (dt.Rows.Count > 0)
            {
                dt.Rows.Clear();
            }
            foreach (Factura serv in controler.Model.Factura.Where(D => D.ProveedorId == proveedor.Id && D.Saldo > 0).ToList())
            {
                gv.AddNewRow();
                var newRowHandle = gv.FocusedRowHandle;

                gv.SetRowCellValue(newRowHandle, "Id", serv.Id);
                gv.SetRowCellValue(newRowHandle, "NoFactura", serv.NoFactura);
                gv.SetRowCellValue(newRowHandle, "Fecha", serv.Fecha);
                gv.SetRowCellValue(newRowHandle, "Importe", serv.Importe);
                gv.SetRowCellValue(newRowHandle, "Saldo", serv.Saldo);
                gv.SetRowCellValue(newRowHandle, "Observaciones", serv.Observaciones);
                gv.SetRowCellValue(newRowHandle, "ContrareciboId", serv.ContrareciboId);
                gv.SetRowCellValue(newRowHandle, "ProveedorId", serv.ProveedorId);
                gv.SetRowCellValue(newRowHandle, "ObraId", serv.ObraId);

                gv.UpdateCurrentRow();
                gv.RefreshData();
            }
        }
        private void llenaGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("NoFactura", typeof(int));
            dt.Columns.Add("Fecha", typeof(string));
            dt.Columns.Add("Importe", typeof(float));
            dt.Columns.Add("Saldo", typeof(float));
            dt.Columns.Add("Observaciones", typeof(string));
            dt.Columns.Add("ContrareciboId", typeof(int));
            dt.Columns.Add("ProveedorId", typeof(int));
            dt.Columns.Add("ObraId", typeof(int));
            grid.DataSource = dt;
        }

        private void frmAgregarFacturas_Load(object sender, EventArgs e)
        {
            llenaGrid();
            obtenerFacturas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
        }
    }
}
