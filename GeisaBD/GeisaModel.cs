using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace GeisaBD
{
public partial class GEISAEntities    
{
        private static string _DbConnection = @"Server=SERVIDOR\BSDEV;Database=Geisa_Actual;Persist Security Info=True;User=sa;Password=gadipa90;";
        private static string _EfConnection = "metadata=res://*/GeisaModel.csdl|res://*/GeisaModel.ssdl|res://*/GeisaModel.msl;provider=System.Data.SqlClient;provider connection string='";
        private static string _DefaultConnectionString;
        public static string DefaultConnectionString
        {
            get
            {
                return _DefaultConnectionString ?? (_DefaultConnectionString = string.Concat(_EfConnection, _DbConnection, "'"));
            }
        }

        public static void SetDbConnection(string server, string user, string password, string database)
        {
            _DbConnection = "Server=" + server + ";Database=" + database + ";Persist Security Info=True;User=" + user + ";Password=" + password + ";";
            _DefaultConnectionString = string.Concat(_EfConnection, _DbConnection, "'");
        }

        public static string RefreshDbConnection()
        {
            return _DefaultConnectionString = string.Concat(_EfConnection, _DbConnection, "'");
        }

        public DbTransaction BeginTransaction()
        {
            if (this.Connection == null) return null;

            if (this.Connection == null) throw new ApplicationException("No Existing Connection to DB");
            if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();

            return this.Connection.BeginTransaction();
        }

        public bool ConnectionIsOpen()
        {
            return this.Connection == null || this.Connection.State == System.Data.ConnectionState.Open;
        }

        public void CloseConnection()
        {
            if (this.Connection == null) return;

            if (this.Connection.State != System.Data.ConnectionState.Closed) this.Connection.Close();
        }
    }
}

