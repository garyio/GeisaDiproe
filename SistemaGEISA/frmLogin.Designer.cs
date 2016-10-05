namespace SistemaGEISA
{
    partial class frmLogin
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            this.btnEntrar = new DevExpress.XtraEditors.SimpleButton();
            this.btnParametros = new DevExpress.XtraEditors.SimpleButton();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.Label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.Panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            this.Panel3.SuspendLayout();
            this.Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Gray;
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.panelControl1.Controls.Add(this.lblError);
            this.panelControl1.Controls.Add(this.btnSalir);
            this.panelControl1.Controls.Add(this.btnEntrar);
            this.panelControl1.Controls.Add(this.btnParametros);
            this.panelControl1.Controls.Add(this.Panel5);
            this.panelControl1.Controls.Add(this.Panel3);
            this.panelControl1.Controls.Add(this.Label3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(304, 190);
            this.panelControl1.TabIndex = 2;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(3, 122);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(301, 25);
            this.lblError.TabIndex = 12;
            this.lblError.Text = "Error";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = global::SistemaGEISA.Properties.Resources.Logout;
            this.btnSalir.ImageIndex = 1;
            this.btnSalir.Location = new System.Drawing.Point(224, 154);
            this.btnSalir.LookAndFeel.SkinName = "Whiteprint";
            this.btnSalir.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 31);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEntrar
            // 
            this.btnEntrar.Image = global::SistemaGEISA.Properties.Resources.In;
            this.btnEntrar.ImageIndex = 0;
            this.btnEntrar.Location = new System.Drawing.Point(147, 154);
            this.btnEntrar.LookAndFeel.SkinName = "Whiteprint";
            this.btnEntrar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEntrar.Margin = new System.Windows.Forms.Padding(0);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(75, 31);
            this.btnEntrar.TabIndex = 10;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnParametros
            // 
            this.btnParametros.Image = global::SistemaGEISA.Properties.Resources.BaseDatos;
            this.btnParametros.ImageIndex = 2;
            this.btnParametros.Location = new System.Drawing.Point(5, 154);
            this.btnParametros.LookAndFeel.SkinName = "Whiteprint";
            this.btnParametros.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnParametros.Name = "btnParametros";
            this.btnParametros.Size = new System.Drawing.Size(100, 31);
            this.btnParametros.TabIndex = 9;
            this.btnParametros.Text = "Parámetros";
            this.btnParametros.Click += new System.EventHandler(this.btnParametros_Click);
            // 
            // Panel5
            // 
            this.Panel5.BackColor = System.Drawing.Color.Transparent;
            this.Panel5.Controls.Add(this.Panel6);
            this.Panel5.Controls.Add(this.PictureBox3);
            this.Panel5.Location = new System.Drawing.Point(54, 88);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(200, 30);
            this.Panel5.TabIndex = 8;
            // 
            // Panel6
            // 
            this.Panel6.Controls.Add(this.txtContraseña);
            this.Panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel6.Location = new System.Drawing.Point(30, 0);
            this.Panel6.Name = "Panel6";
            this.Panel6.Padding = new System.Windows.Forms.Padding(5);
            this.Panel6.Size = new System.Drawing.Size(170, 30);
            this.Panel6.TabIndex = 5;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtContraseña.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtContraseña.Location = new System.Drawing.Point(5, 5);
            this.txtContraseña.MaxLength = 15;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(160, 25);
            this.txtContraseña.TabIndex = 0;
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // PictureBox3
            // 
            this.PictureBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.PictureBox3.Image = global::SistemaGEISA.Properties.Resources.login;
            this.PictureBox3.Location = new System.Drawing.Point(0, 0);
            this.PictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(30, 30);
            this.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox3.TabIndex = 4;
            this.PictureBox3.TabStop = false;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.Transparent;
            this.Panel3.Controls.Add(this.Panel4);
            this.Panel3.Controls.Add(this.PictureBox2);
            this.Panel3.Location = new System.Drawing.Point(54, 57);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(200, 30);
            this.Panel3.TabIndex = 7;
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.Transparent;
            this.Panel4.Controls.Add(this.txtUsuario);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(30, 0);
            this.Panel4.Name = "Panel4";
            this.Panel4.Padding = new System.Windows.Forms.Padding(5);
            this.Panel4.Size = new System.Drawing.Size(170, 30);
            this.Panel4.TabIndex = 5;
            // 
            // txtUsuario
            // 
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsuario.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsuario.Location = new System.Drawing.Point(5, 5);
            this.txtUsuario.MaxLength = 20;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(160, 25);
            this.txtUsuario.TabIndex = 0;
            // 
            // PictureBox2
            // 
            this.PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.PictureBox2.Image = global::SistemaGEISA.Properties.Resources.login_user;
            this.PictureBox2.Location = new System.Drawing.Point(0, 0);
            this.PictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(30, 30);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox2.TabIndex = 4;
            this.PictureBox2.TabStop = false;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Label3.Location = new System.Drawing.Point(139, 9);
            this.Label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(161, 29);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "Iniciar Sesión";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnEntrar;
            this.Appearance.BackColor = System.Drawing.Color.Gray;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(304, 190);
            this.Controls.Add(this.panelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.Panel5.ResumeLayout(false);
            this.Panel6.ResumeLayout(false);
            this.Panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            this.Panel3.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        internal System.Windows.Forms.Label lblError;
        private DevExpress.XtraEditors.SimpleButton btnSalir;
        private DevExpress.XtraEditors.SimpleButton btnEntrar;
        private DevExpress.XtraEditors.SimpleButton btnParametros;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.Panel Panel6;
        internal System.Windows.Forms.TextBox txtContraseña;
        internal System.Windows.Forms.PictureBox PictureBox3;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.TextBox txtUsuario;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.Label Label3;
    }
}