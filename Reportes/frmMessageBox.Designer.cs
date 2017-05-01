namespace Reportes
{
    partial class frmMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageBox));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelBorder = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelInner = new System.Windows.Forms.TableLayoutPanel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.buttonNo = new DevExpress.XtraEditors.SimpleButton();
            this.buttonYes = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelBorder.SuspendLayout();
            this.tableLayoutPanelInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelBorder, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.buttonNo, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.buttonYes, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(399, 138);
            this.tableLayoutPanelMain.TabIndex = 4;
            // 
            // tableLayoutPanelBorder
            // 
            this.tableLayoutPanelBorder.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanelBorder.ColumnCount = 1;
            this.tableLayoutPanelMain.SetColumnSpan(this.tableLayoutPanelBorder, 3);
            this.tableLayoutPanelBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBorder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBorder.Controls.Add(this.tableLayoutPanelInner, 0, 0);
            this.tableLayoutPanelBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBorder.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelBorder.Name = "tableLayoutPanelBorder";
            this.tableLayoutPanelBorder.RowCount = 1;
            this.tableLayoutPanelBorder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBorder.Size = new System.Drawing.Size(393, 94);
            this.tableLayoutPanelBorder.TabIndex = 3;
            // 
            // tableLayoutPanelInner
            // 
            this.tableLayoutPanelInner.ColumnCount = 2;
            this.tableLayoutPanelInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInner.Controls.Add(this.labelMessage, 1, 0);
            this.tableLayoutPanelInner.Controls.Add(this.pictureBoxIcon, 0, 0);
            this.tableLayoutPanelInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInner.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanelInner.Name = "tableLayoutPanelInner";
            this.tableLayoutPanelInner.RowCount = 1;
            this.tableLayoutPanelInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInner.Size = new System.Drawing.Size(383, 84);
            this.tableLayoutPanelInner.TabIndex = 2;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(53, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(327, 84);
            this.labelMessage.TabIndex = 1;
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxIcon.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pictureBoxIcon.Size = new System.Drawing.Size(44, 78);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxIcon.TabIndex = 0;
            this.pictureBoxIcon.TabStop = false;
            // 
            // buttonNo
            // 
            this.buttonNo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.buttonNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonNo.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonNo.Image = ((System.Drawing.Image)(resources.GetObject("buttonNo.Image")));
            this.buttonNo.Location = new System.Drawing.Point(230, 103);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(80, 32);
            this.buttonNo.TabIndex = 5;
            this.buttonNo.Text = "No";
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // buttonYes
            // 
            this.buttonYes.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.buttonYes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonYes.Image = global::Reportes.Properties.Resources.Si;
            this.buttonYes.Location = new System.Drawing.Point(316, 103);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(80, 32);
            this.buttonYes.TabIndex = 4;
            this.buttonYes.Text = "Si";
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // frmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 138);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMessageBox_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelBorder.ResumeLayout(false);
            this.tableLayoutPanelInner.ResumeLayout(false);
            this.tableLayoutPanelInner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBorder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInner;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private DevExpress.XtraEditors.SimpleButton buttonNo;
        private DevExpress.XtraEditors.SimpleButton buttonYes;
    }
}