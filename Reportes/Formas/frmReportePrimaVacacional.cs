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
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;

namespace Reportes
{
    public partial class frmReportePrimaVacacional : DevExpress.XtraEditors.XtraForm
    {
        enum tipoNominas
        {
            Semanal = 1,
            Quincenal = 2,
            Mensual = 3
        };

        int diasLaborables = 0;

        GEISAEntities controler = new GEISAEntities(GEISAEntities.DefaultConnectionString);
        private string puesto { get; set; }
        private double sueldoReal=0;
        private Empleado empleado { get; set; }
        private EmpleadoNomina empleadoNomina { get; set; }
        private EmpleadoHistorial historial { get; set; }
        private double total;

        public frmReportePrimaVacacional()
        {
            InitializeComponent();
        }

        private void llenaCombos()
        {
            using (GEISAEntities empleado = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                luEmpleado.Properties.DataSource = empleado.Empleado.Where(E => E.Activo == true).ToList().OrderBy(o => o.NombreCompleto);
                luEmpleado.Properties.DisplayMember = "NombreCompleto";
                luEmpleado.Properties.ValueMember = "Id";
            }

            using (GEISAEntities empresa = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                chkEmpresa.DataSource = empresa.Empresa.ToList().OrderBy(o => o.NombreFiscal);
                chkEmpresa.DisplayMember = "NombreFiscal";
                chkEmpresa.ValueMember = "Id";
            }

            
        }

        private void frmReportePrimaVacacional_Load(object sender, EventArgs e)
        {
            llenaCombos();
            btnLimpiar_Click(null, null);
            editAño.Value = DateTime.Today.Year;
            chkEmpresa.Enabled = false;
            txtSueldoFiscal.ReadOnly = true;
            editAño.ReadOnly = true;
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            chkEmpresa.UnCheckAll();
            txtSueldoFiscal.Text = "0.00";
            txtComplemento.Text = "0.00";
            txtDiasPagar.Text = "0.00";
            txtDiasPagar.Text = "0";
            editAño.Value = DateTime.Now.Year;
            lblTotal.Text = "Total: 0.00";
            total = 0;
            empleado = null;
            empleadoNomina = null;
            historial = null;
            puesto = string.Empty;
            sueldoReal = 0;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            string Empresas = string.Empty;

            if (chkEmpresa.CheckedItems.Count > 0)
            {
                foreach (Empresa item in chkEmpresa.CheckedItems)
                {
                    Empresas = Empresas + string.Concat(item.Id, ",");
                }
                Empresas = Empresas.TrimEnd(',');
            }
            else
            {
                GEISAEntities Cliente = new GEISAEntities(GEISAEntities.DefaultConnectionString);
                foreach (Empresa item in Cliente.Empresa.ToList())
                {
                    Empresas = Empresas + string.Concat(item.Id, ",");
                }
                Empresas = Empresas.TrimEnd(',');
            }


            if (chkEmpresa.ItemCount > 0 && this.empleado != null && this.empleadoNomina != null)
            {
                List<ReportParameter> paramReport = new List<ReportParameter>();
                Empresa empresa;

                //Valido empresa seleccionada para resumen de facturas rpeorte.
                bool geisa = false, diproe = false;
                foreach (Empresa item in chkEmpresa.CheckedItems)
                {
                    if (item == TipoEmpresa.GEISA || item == TipoEmpresa.GEISA_PERIFERICA)
                        geisa = true;
                    if (item == TipoEmpresa.DIPROE)
                        diproe = true;
                }

                if (geisa && diproe)
                    this.viewer.LocalReport.Refresh();

                this.viewer.LocalReport.EnableExternalImages = true;

                GEISAEntities _empresa = new GEISAEntities(GEISAEntities.DefaultConnectionString);
                empresa = geisa ? TipoEmpresa.GEISA : TipoEmpresa.DIPROE;
                if (empresa.Imagen != null)
                {
                    Image Logo = Funciones.ArrayAImage(empresa.Imagen);
                    string strPathAppUser = string.Concat(Application.UserAppDataPath + "\\Logo.jpg");
                    Logo.Save(strPathAppUser, System.Drawing.Imaging.ImageFormat.Jpeg);
                    paramReport.Add(new ReportParameter("PathLogo", strPathAppUser));                        
                }
                else
                {
                    paramReport.Add(new ReportParameter("PathLogo", string.Empty));
                    
                }
                paramReport.Add(new ReportParameter("Empresa", empresa.NombreFiscal));
                paramReport.Add(new ReportParameter("EmpresaDireccion", "DOM: " + empresa.Direccion.ToUpper() + "\n" + "CP: " + empresa.Domicilio.CodigoPostal + "  " + empresa.Ciudad + "\n" + "TEL: " + empresa.Telefono + "\n" + "RFC: " + empresa.RFC ));
                paramReport.Add(new ReportParameter("Fiscal", txtSueldoFiscal.Text));
                paramReport.Add(new ReportParameter("Complemento",txtComplemento.Text));
                paramReport.Add(new ReportParameter("NombreCompleto", this.empleado.NombreCompleto));
                paramReport.Add(new ReportParameter("Puesto", this.puesto));
                paramReport.Add(new ReportParameter("RFC", this.empleado.RFC));
                paramReport.Add(new ReportParameter("CURP", this.empleadoNomina.Curp));
                paramReport.Add(new ReportParameter("IMSS", this.empleadoNomina.Nss));
                paramReport.Add(new ReportParameter("Concepto", "PRIMA VACACIONAL " + editAño.Value));
                paramReport.Add(new ReportParameter("DiasVacaciones", diasVacaciones().ToString()));
                paramReport.Add(new ReportParameter("Mensaje", "Recibí de " + empresa.NombreFiscal + " la cantidad de: "+ total.ToString("c2")));
                paramReport.Add(new ReportParameter("CantidadNumeros","\"" + Funciones.Num2Text(total.ToString()) + "\"" ));
                paramReport.Add(new ReportParameter("Total", this.total.ToString()));

                if(paramReport != null)
                    this.viewer.LocalReport.SetParameters(paramReport);

                //source.DataSource = new IngresosMensualesPorEmpresa(obras, (DateTime)dateIni.EditValue, (DateTime)dateFin.EditValue, Empresas, Clientees).Items;
                System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                
                pg.Margins.Top = 19;
                pg.Margins.Bottom = 4;
                pg.Margins.Left = 19;
                pg.Margins.Right = 4;
                //System.Drawing.Printing.PaperSize size = new PaperSize();
                //size.RawKind = (int)PaperKind.Letter;
                //pg.PaperSize = size;

                this.viewer.SetPageSettings(pg);                
                this.viewer.ZoomPercent = 100;
                this.viewer.LocalReport.DisplayName = this.Text;
                this.viewer.RefreshReport();
            }
        }


        private int diasVacaciones()
        {
            EmpleadoHistorial _empleadoHistorial;
            double añosTrabajados = 0;
            if (empleadoNomina != null)
            {
                bool sueldoCompartido = empleadoNomina.SueldoCompartido.HasValue ? empleadoNomina.SueldoCompartido.Value : false;

                if(sueldoCompartido)
                    _empleadoHistorial = empleadoNomina.EmpleadoHistorial.Where(E => E.FechaFin == null && E.FechaFin2 == null).DefaultIfEmpty(null).FirstOrDefault();
                else
                    _empleadoHistorial = empleadoNomina.EmpleadoHistorial.Where(E => E.FechaFin == null).DefaultIfEmpty(null).FirstOrDefault();
                //double diasFechaActual = DateTime.Today.Subtract(DateTime.Today).TotalDays;
                //double diasFechaActual = DateTime.Today.Subtract(DateTime.Today).TotalDays;
                if (_empleadoHistorial == null)
                    _empleadoHistorial = empleadoNomina.EmpleadoHistorial.FirstOrDefault();
                if (_empleadoHistorial == null)
                    return 6;

                añosTrabajados = (DateTime.Today - (_empleadoHistorial.FechaInicio.HasValue ? _empleadoHistorial.FechaInicio.Value : DateTime.Today)).TotalDays / 365;
                if (añosTrabajados <= 1)
                    return 6;
                else if (añosTrabajados > 1 && añosTrabajados <= 2)
                    return 8;
                else if (añosTrabajados > 2 && añosTrabajados <= 3)
                    return 10;
                else if (añosTrabajados > 3 && añosTrabajados <= 4)
                    return 12;
                else if (añosTrabajados > 4 && añosTrabajados <= 9)
                    return 14;
                else if (añosTrabajados > 9 && añosTrabajados <= 14)
                    return 16;
                else if (añosTrabajados > 14 && añosTrabajados <= 19)
                    return 18;
                else
                    return 20;
            }
            else
            {
                return 6;
            }        
        }

        private void luEmpleado_EditValueChanged(object sender, EventArgs e)
        {
            btnLimpiar_Click(null, null);
            empleado = luEmpleado.GetSelectedDataRow() as Empleado;
            empleadoNomina = controler.EmpleadoNomina.Where(X => X.EmpleadoId == empleado.Id).DefaultIfEmpty(null).FirstOrDefault();
            if(empleadoNomina != null)
                historial = empleadoNomina.EmpleadoHistorial.Where(E => E.FechaFin == null) != null ? empleadoNomina.EmpleadoHistorial.Where(E => E.FechaFin == null).FirstOrDefault() : null;
            if (historial != null)
                puesto = controler.Dpto_Puesto.Where(D => D.Id == historial.Puesto).FirstOrDefault().Nombre;
            else
                puesto = "N/a";
            sueldoReal = historial != null ? historial.Sueldo.Value : 0;
            txtDiasPagar.Text = diasVacaciones().ToString();
            if (empleado != null)
            {
                chkEmpresa.Enabled = true;
                txtSueldoFiscal.ReadOnly = false;
                editAño.ReadOnly = false;
            }
            else
            {
                chkEmpresa.Enabled = false;
                txtSueldoFiscal.ReadOnly = true;
                editAño.ReadOnly = true;
            }

            //obtengo los dias laborables
            if (empleadoNomina != null)
            {
                if (empleadoNomina.TipoNomina.HasValue)
                {
                    if (empleadoNomina.TipoNomina == Convert.ToInt32(tipoNominas.Mensual))
                    {
                        txtTipoPago.Text = "MENSUAL";
                        diasLaborables = 30;
                    }
                    else if (empleadoNomina.TipoNomina == Convert.ToInt32(tipoNominas.Quincenal))
                    {
                        txtTipoPago.Text = "QUINCENAL";
                        diasLaborables = 15;
                    }
                    else
                    {
                        txtTipoPago.Text = "SEMANAL";
                        diasLaborables = 7;
                    }
                }
                else
                {
                    txtTipoPago.Text = "PERIODO PENDIENTE";
                    diasLaborables = 7;
                    new frmMessageBox(true) { Message = "No se capturo el Tipo de Nomina para este Empleado por Default se usara 7 dias laborables", Title = "Aviso" }.ShowDialog();

                }
            }
            else
            {
                txtTipoPago.Text = "PERIODO PENDIENTE";
                diasLaborables = 7;
                new frmMessageBox(true) { Message = "No se capturo el Tipo de Nomina para este Empleado por Default se usara 7 dias laborables", Title = "Aviso" }.ShowDialog();
            }
        }

        private void txtSueldoFiscal_TextChanged(object sender, EventArgs e)
        {
            double sueldoFiscal = string.IsNullOrEmpty(txtSueldoFiscal.Text) ? 0 : Convert.ToDouble(txtSueldoFiscal.Text);
            txtComplemento.Text  = ((this.sueldoReal / diasLaborables * diasVacaciones() * 0.25) - sueldoFiscal).ToString("N2");
            this.total = sueldoFiscal + Convert.ToDouble(txtComplemento.Text);
            lblTotal.Text = "Total:" + this.total.ToString("c2");            
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
    }

}
