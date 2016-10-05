using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SistemaGEISA
{
    public partial class frmConexion : DevExpress.XtraEditors.XtraForm
    {
        public frmConexion()
        {
            InitializeComponent();
        }

        private void frmConexion_Load(object sender, EventArgs e)
        {
            txtServer.Text = Convert.ToString(Properties.Settings.Default.Servidor);
            txtUser.Text = Convert.ToString(Properties.Settings.Default.Usuario);
            txtPassw.Text = Convert.ToString(Properties.Settings.Default.Contraseña);
            txtDatabase.Text = Convert.ToString(Properties.Settings.Default.BaseDatos);
        }

        private string CheckConnection(string server, string user, string password, string database)
        {
            this.Cursor = Cursors.WaitCursor;
            string connectionString = string.Concat("server=", server, ";user=", user, ";password=", password, ";database=", string.IsNullOrEmpty(database) ? "' '" : database);
            string sqlQuery = "SELECT NAME FROM SYS.DATABASES where NAME='" + database + "'";

            string newLine = (char)0xD + string.Empty + (char)0xA;
            string success0 = string.Concat("FALLO: No se encuentra el servidor SQL ", server);
            string success1 = string.Concat("OK: El servidor SQL existe", newLine, "FALLO: El Usuario o el Password no es valido");
            string success2 = string.Concat("OK: El servidor SQL existe", newLine, "FALLO: No se encuentra la base de datos ", database);
            string success3 = string.Concat("OK: El servidor SQL existe", newLine, "OK: El Usuario o el Password es valido", newLine, "FALLO: No se encuentra la base de datos ", database);
            string success4 = string.Concat("OK: El servidor SQL existe", newLine, "OK: El Usuario o el Password es valido", newLine, "OK: La base de datos existe");

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        this.Cursor = Cursors.Default;
                        return sqlDataReader == null || !sqlDataReader.HasRows ? success3 : success4;
                    }
                }
                catch (SqlException exception)
                {
                    this.Cursor = Cursors.Default;
                    switch (exception.Number)
                    {
                        case -1: return success0;
                        case 2: return success0;
                        case 4060: return success2;
                        case 18456: return success1;
                        default: return success0;
                    }
                }
            }
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            txtTest.Text = string.Empty;
            txtTest.Text = CheckConnection(txtServer.Text, txtUser.Text, txtPassw.Text, txtDatabase.Text);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["Servidor"] = txtServer.Text;
            Properties.Settings.Default["Usuario"] = txtUser.Text;
            Properties.Settings.Default["Contraseña"] = txtPassw.Text;
            Properties.Settings.Default["BaseDatos"] = txtDatabase.Text;

            try
            {
                Properties.Settings.Default.Save();
            }
            catch
            {
                new frmMessageBox(true) { Message = "No se ha podido guardar los cambios.", Title = "Error" }.ShowDialog();
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
