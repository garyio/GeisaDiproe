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
    public partial class frmFacturasPendientes : XtraForm
    {
        private Controler _controler = new Controler();

        public Obra obra;

        public int idCliente=0;
        public string source = string.Empty;
        public Empleado empleado { get; set; }

        public Cliente cliente { get; set; }
        private Controler controler { get { return _controler; } }

        public bool isGastoAdm=false;
        public Proveedor proveedor;
        DataTable dt;

        public List<DataRow> rowSelected;
        public List<Factura> pagadas = new List<Factura>();
        public frmFacturasPendientes()
        {
            InitializeComponent();
        }

        private void frmFacturasPendientes_Load(object sender, EventArgs e)
        {
            if (proveedor != null && empleado != null)
            {
                this.Text = "Facturas - Contrar-recibos";
            }

            if (proveedor != null)
                this.Text = proveedor.NombreComercial;
            else if (cliente != null)
                this.Text = cliente.NombreFiscal;
            else
                this.Text = empleado.NombreCompleto;

            facturasPendientes();
        }

        private void llenaGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Seleccion", typeof(bool));
            dt.Columns.Add("NoFactura", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Importe", typeof(double));
            dt.Columns.Add("Saldo", typeof(double));
            dt.Columns.Add("Proveedor", typeof(string));
            dt.Columns.Add("Obra", typeof(string));
            dt.Columns.Add("Observaciones", typeof(string));
            dt.Columns.Add("ConceptosId", typeof(string));

            luConceptos.DataSource = controler.Model.Conceptos.ToList();
            luConceptos.DisplayMember = "Nombre";
            luConceptos.ValueMember = "Id";

            grid.DataSource = dt;
        }

        private void facturasPendientes()
        {
            llenaGrid();

            List<Factura> facturas= new List<Factura>();// = controler.Model.Factura.Where(f => f.Saldo > 0).ToList();

            if (obra != null && idCliente>0)
            {
                foreach (getDetalleIngresos_Result item in controler.Model.getDetalleIngresos(this.obra.Id,this.idCliente).ToList())
                {
                    Factura invoice;
                    if(source!=string.Empty)
                        //invoice = controler.Model.Factura.FirstOrDefault(f => f.Id == item.Id && item.Saldo >= 0 && item.FechaCancelacion == null);
                        invoice = controler.Model.Factura.FirstOrDefault(f => f.Id == item.Id && item.FechaCancelacion == null);
                    else
                        invoice = controler.Model.Factura.FirstOrDefault(f => f.Id == item.Id && item.Saldo>0 && item.FechaCancelacion==null);
                    
                    if(invoice!=null)
                        facturas.Add(invoice);
                }
                
            }else if(proveedor != null){
                if (isGastoAdm)
                    facturas = controler.Model.Factura.Where(D => D.ProveedorId == proveedor.Id && D.ContrareciboId != null && D.Saldo > 0).ToList();
                else
                    facturas = controler.Model.Factura.Where(D => D.ProveedorId == proveedor.Id && D.Saldo > 0).ToList();
            }
            else
            {
                facturas = controler.Model.Factura.Where(D => D.Saldo > 0 && D.CajaComprobanteId != null).ToList();
            }

                foreach (Factura serv in facturas)
                {
                    Factura existe;
                    if (pagadas != null)
                    {
                        try
                        {
                            existe = pagadas.FirstOrDefault(F => F.Id == serv.Id);
                        }
                        catch (Exception e)
                        {
                            existe = null;
                        }
                    }
                    else
                        existe = null;


                    if (existe == null)
                    {
                        gv.AddNewRow();
                        var newRowHandle = gv.FocusedRowHandle;

                        gv.SetRowCellValue(newRowHandle, "Id", serv.Id);
                        gv.SetRowCellValue(newRowHandle, "Seleccion", false);
                        gv.SetRowCellValue(newRowHandle, "NoFactura", serv.NoFactura);
                        gv.SetRowCellValue(newRowHandle, "Fecha", serv.Fecha);
                        gv.SetRowCellValue(newRowHandle, "Importe", serv.Importe);
                        gv.SetRowCellValue(newRowHandle, "Saldo", serv.Saldo);
                        gv.SetRowCellValue(newRowHandle, "Proveedor", serv.NombreProveedor);
                        gv.SetRowCellValue(newRowHandle, "Obra", serv.ObraNombre);
                        gv.SetRowCellValue(newRowHandle, "Observaciones", serv.Observaciones);
                        gv.SetRowCellValue(newRowHandle, "ConceptosId", serv.ConceptosId);

                        gv.UpdateCurrentRow();
                        gv.RefreshData();
                    }
                }//foreach
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            rowSelected = new List<DataRow>();

            for (var i = 0; i < gv.DataRowCount; i++)
            {
                var cellSelecion = false;
                if (!string.IsNullOrEmpty(gv.GetRowCellValue(i, "Seleccion").ToString()))
                    cellSelecion = Convert.ToBoolean(gv.GetRowCellValue(i, "Seleccion"));

                if (cellSelecion)
                {
                    rowSelected.Add(gv.GetDataRow(i));
                }
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}