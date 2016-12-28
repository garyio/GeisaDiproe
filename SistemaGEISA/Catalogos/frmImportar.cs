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
using System.Data.Common;
using System.IO;

namespace SistemaGEISA
{
    public partial class frmImportar : DevExpress.XtraEditors.XtraForm
    {
        public string ruta = "";

        private Controler controler { get; set; }

        public frmImportar(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        private void frmImportar_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "(CSV Delimitado por Comas) | *.csv";
            openFileDialog.Title = "Seleccione el Archivo CSV";
            openFileDialog.FileName = string.Empty;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtRuta.Text = "";
                ruta = openFileDialog.FileName;
                txtRuta.Text = ruta;

            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            List<ArticuloExterno> articulos = new List<ArticuloExterno>();
            
            //Leo el archivo csv
            try
            {
                var reader = new StreamReader(File.OpenRead(@ruta), Encoding.GetEncoding("iso-8859-1"));                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (string.IsNullOrEmpty(values[0].Trim()) == false && line!=null)
                    {
                        ArticuloExterno item = new ArticuloExterno();
                        item._Nombre = values[0].ToString().Trim().ToUpper();
                        item._Unidad = values[1].ToString().Trim().ToUpper();
                        item._CostoUnitario = values[2].ToString().Trim().ToUpper();
                        articulos.Add(item);
                    }
                }
                reader.Dispose();
                
            }
            catch (Exception ex)
            {
                new frmMessageBox(true) { Message = "Error en la Importaciòn: \n" + ex.InnerException , Title = "Error" }.ShowDialog();
                
                return;
            }

            progressBar1.Maximum = articulos.Count();
            progressBar1.Step = 1;
            progressBar1.Value = 0;


            //Guardo el archivo csv
            var error = string.Empty;
            var isNew = false;
            var SaveAndNew = sender.ToString() == "Guardar y Nuevo" ? true : false;

            if (articulos.Count()>0)
            {

                foreach (ArticuloExterno articuloExterno in articulos)
                {
                    //bool esNuevo = getEstadoArticulo(articuloExterno);
                    
                        Articulos articulo;
                        if (controler.Model.Articulos.Where(A => A.Descripcion.Trim().ToUpper() == articuloExterno._Nombre).Count() > 0)
                            articulo = controler.Model.Articulos.FirstOrDefault(A => A.Descripcion.Trim().ToUpper() == articuloExterno._Nombre);
                        else
                            articulo = new Articulos();

                        articulo.Descripcion = articuloExterno._Nombre;
                        //Unidad Medida
                        if (controler.Model.UnidadMedida.Where(U => U.Nombre.Trim().ToUpper() == articuloExterno._Unidad).Count() <= 0)
                            if (crearUnidad(articuloExterno._Unidad) == false) break;
                        controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, controler.Model.UnidadMedida.ToList());
                        
                        articulo.UnidadMedida = controler.Model.UnidadMedida.FirstOrDefault(U => U.Nombre.Trim().ToUpper() == articuloExterno._Unidad);
                        double amount;
                        articulo.PrecioCompra = double.TryParse(articuloExterno._CostoUnitario, out amount) ? amount : 0;
                        articulo.PrecioVenta = 0;    
                        articulo.FechaAlta = DateTime.Today;
                        articulo.Activo = true;
                        articulo.Existencia = 1;
                        
                        if (!articulo.NoEsNuevo) controler.Model.AddToArticulos(articulo);
                        progressBar1.PerformStep();
                       
                }
                try
                {
                    controler.Model.SaveChanges();
                }
                catch (Exception ex)
                {
                    error = ex.GetBaseException().Message;
                    Cursor.Current = Cursors.Default;
                }
                finally
                {
                    
                    var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                    var message = string.Empty;

                    if (!isNew)
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("Los Articulos han sido actualizados exitosamente.") : string.Concat("No se pudieron actualizar los Articulos:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("Los Articulos han sido generados exitosamente.") : string.Concat("No se pudieron generar los Articulos:\n", error);
                    }

                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                }

                Cursor.Current = Cursors.Default;
                if (string.IsNullOrEmpty(error))
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }

        private bool getEstadoArticulo(ArticuloExterno articulo)
        {
            if (controler.Model.Articulos.Where(A => A.Descripcion == articulo._Nombre).Count() > 0)
            {
                return true;
            }
            else
                return false;

        }

        public bool crearUnidad(string nombreUnidad)
        {
            var error = string.Empty;

            DbTransaction transaccion = null;

            try
            {
                transaccion = controler.Model.BeginTransaction();      
                UnidadMedida edo = new UnidadMedida();                 
                edo.Nombre = nombreUnidad;
                edo.Activo = true;
                if(!edo.NoEsNuevo)controler.Model.AddToUnidadMedida(edo);

                controler.Model.SaveChanges();
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                if (transaccion != null)
                {
                    transaccion.Rollback();
                }
                error = ex.GetBaseException().Message;
            }
            finally
            {
                controler.Model.CloseConnection();             
            }

            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }
    }
}
