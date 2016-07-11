using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Reportes
{
    class conexion
    {
        SqlConnection cnn;
        string server;
        string user;
        string passw;
        string database;

        public conexion(string s, string u, string p, string d)
        {
            server = s;
            user = u;
            passw = p;
            database = d;

            cnn = new SqlConnection(GetConnectionString());
        }

        private string GetConnectionString()
        {
            return "server=" + server + ";database=" + database + ";user=" + user + ";password=" + passw;
        }

        public DataSet getDataset(string SQL, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda;
            DataSet ds;

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL;
                cmd.Connection = cnn;

                cmd.Parameters.Clear();

                if (param != null)
                {
                    foreach (SqlParameter p in param)
                    {
                        cmd.Parameters.Add(p);
                    }
                }

                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Parameters.Clear();
                    if (cmd.Connection.State == ConnectionState.Open) cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
        }

        public DataTable consultar(string sql)
        {
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, cnn);

            //Creo el DataTable 
            DataTable dt = new DataTable();

            //Relleno el adaptador con los datos en memoria 
            Adapter.Fill(dt);

            return dt;
        }

        public bool IsDbConnectionOK()
        {
            string sqlQuery = "SELECT NAME FROM SYS.DATABASES where NAME='" + database + "'";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        return sqlDataReader != null || sqlDataReader.HasRows;
                    }
                }
            }
            catch { return false; }
        }
    }
}
