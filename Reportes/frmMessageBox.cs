using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Reportes
{
    public partial class frmMessageBox : DevExpress.XtraEditors.XtraForm
    {
        public string Message
        {
            get
            {
                return labelMessage.Text;
            }
            set
            {
                labelMessage.Text = value;
            }
        }
        public string Title
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;

                if (value == "Error")
                {
                    pictureBoxIcon.Image = System.Drawing.SystemIcons.Error.ToBitmap();
                }
                else
                {
                    if (value == "Confirmación")
                    {
                        pictureBoxIcon.Image = System.Drawing.SystemIcons.Information.ToBitmap();
                    }
                    else
                    {
                        if (value == "Advertencia")
                        {
                            pictureBoxIcon.Image = System.Drawing.SystemIcons.Warning.ToBitmap();
                        }
                        else
                        {
                            pictureBoxIcon.Image = System.Drawing.SystemIcons.Exclamation.ToBitmap();
                        }
                    }
                }
            }
        }

        public frmMessageBox(Boolean isMessageOk)
        {
            InitializeComponent();

            if (isMessageOk)
            {
                buttonYes.Text = "Aceptar";
                buttonYes.Click += (sender, e) =>
                {
                    DialogResult = DialogResult.OK;
                    Close();
                };
                buttonNo.Visible = false;
            }
            else
            {
                buttonNo.Click += (sender, e) =>
                {
                    DialogResult = DialogResult.No;
                    Close();
                };
                buttonYes.Click += (sender, e) =>
                {
                    DialogResult = DialogResult.Yes;
                    Close();
                };
            }
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
         
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
         
        }

        private void frmMessageBox_Load(object sender, EventArgs e)
        {

        }
    }
}
