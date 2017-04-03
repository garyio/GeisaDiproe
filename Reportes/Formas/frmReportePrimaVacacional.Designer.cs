namespace Reportes
{
    partial class frmReportePrimaVacacional
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresosMensualesPorEmpresa));
            this.source = new System.Windows.Forms.BindingSource();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEmpresa = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSueldoFiscal = new System.Windows.Forms.TextBox();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.luEmpleado = new DevExpress.XtraEditors.LookUpEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDiasPagar = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEmpresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpleado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // source
            // 
            this.source.DataSource = typeof(Reportes.IngresosMensualesItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa:";
            // 
            // chkEmpresa
            // 
            this.chkEmpresa.CheckOnClick = true;
            this.chkEmpresa.Location = new System.Drawing.Point(146, 54);
            this.chkEmpresa.Name = "chkEmpresa";
            this.chkEmpresa.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.chkEmpresa.Size = new System.Drawing.Size(278, 95);
            this.chkEmpresa.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.chkEmpresa.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Empleado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Sueldo Fiscal:";
            // 
            // txtSueldoFiscal
            // 
            this.txtSueldoFiscal.Location = new System.Drawing.Point(173, 159);
            this.txtSueldoFiscal.Name = "txtSueldoFiscal";
            this.txtSueldoFiscal.Size = new System.Drawing.Size(100, 21);
            this.txtSueldoFiscal.TabIndex = 24;
            // 
            // txtComplemento
            // 
            this.txtComplemento.Location = new System.Drawing.Point(173, 186);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(100, 21);
            this.txtComplemento.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Complemento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Total:";
            // 
            // luEmpleado
            // 
            this.luEmpleado.Location = new System.Drawing.Point(148, 16);
            this.luEmpleado.Name = "luEmpleado";
            this.luEmpleado.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luEmpleado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEmpleado.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreCompleto", "Nombre", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.luEmpleado.Properties.NullText = "";
            this.luEmpleado.Size = new System.Drawing.Size(289, 20);
            this.luEmpleado.TabIndex = 60;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(173, 228);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Popup += new System.EventHandler(this.dateEdit1_Properties_CalendarTimeProperties_Popup);
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "Periodo a Pagar:";
            // 
            // lblDiasPagar
            // 
            this.lblDiasPagar.AutoSize = true;
            this.lblDiasPagar.Location = new System.Drawing.Point(59, 268);
            this.lblDiasPagar.Name = "lblDiasPagar";
            this.lblDiasPagar.Size = new System.Drawing.Size(98, 13);
            this.lblDiasPagar.TabIndex = 63;
            this.lblDiasPagar.Text = "Total Dias a Pagar:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(173, 260);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 64;
            // 
            // frmIngresosMensualesPorEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 528);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblDiasPagar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.luEmpleado);
            this.Controls.Add(this.txtComplemento);
            this.Controls.Add(this.txtSueldoFiscal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkEmpresa);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIngresosMensualesPorEmpresa";
            this.Text = "REPORTE PRIMA VACACIONAL";
            this.Load += new System.EventHandler(this.frmIngresosMensualesPorEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEmpresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpleado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource source;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.CheckedListBoxControl chkEmpresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSueldoFiscal;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LookUpEdit luEmpleado;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDiasPagar;
        private System.Windows.Forms.TextBox textBox1;
    }
}