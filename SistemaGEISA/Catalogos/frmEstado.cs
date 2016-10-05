using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.XtraGrid.Views.Base;
using GeisaBD;
using System.Data.Common;

namespace SistemaGEISA
{
    public partial class frmEstado : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler;
        private DataTable dt;
        public frmEstado()
        {
            InitializeComponent();
            controler = new Controler();
        }

        private void llenaGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));

            grid.DataSource = dt;

            controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, controler.Model.Estado.ToList());

            foreach (Estado edo in controler.Model.Estado.ToList())
            {
                gv.AddNewRow();
                gv.SetRowCellValue(gv.FocusedRowHandle, "Id", edo.Id);
                gv.SetRowCellValue(gv.FocusedRowHandle, "Nombre", edo.Nombre);

                gv.UpdateCurrentRow();
                gv.RefreshData();
            }
        }

        private void gv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var View = sender as ColumnView;
            View.SetRowCellValue(e.RowHandle, View.Columns["Id"], 0);
        }

        private void gv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            gv.ClearColumnErrors();
            var CurrentRow = (DataRowView)e.Row;
            for (var nColumn = 1; nColumn < CurrentRow.Row.ItemArray.Length - 1; nColumn++)
            {
                if (CurrentRow.Row[nColumn].ToString() == string.Empty)
                {
                    e.Valid = false;
                    gv.SetColumnError(gv.Columns[nColumn], "Este Campo no debe ser vacio");
                }
            }
        }

        private void gv_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

            DbTransaction transaccion = null;

            try
            {
                transaccion = controler.Model.BeginTransaction();

                Estado edo = null;

                for (var i = 0; i < gv.RowCount; i++)
                {
                    var row = gv.GetDataRow(i);
                    if (row != null)
                    {
                        var Id = Convert.ToInt32(row["Id"].ToString());
                        if (Id == 0)
                        {
                            edo = new Estado();
                        }
                        else
                        {
                            edo = controler.Model.Estado.FirstOrDefault(E => E.Id == Id);
                        }
                        edo.Nombre = row["Nombre"].ToString().ToUpper().Trim();

                        if (Id == 0)
                        {
                            controler.Model.AddToEstado(edo);
                        }
                    }
                }

                controler.Model.SaveChanges();
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                if (transaccion != null)
                {
                    transaccion.Rollback();
                }
                error = ex.InnerException.Message;
            }
            finally
            {
                controler.Model.CloseConnection();

                var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                var message = string.Empty;

                if (!isNew)
                {
                    message = string.IsNullOrEmpty(error) ? string.Concat("Los registros han sido actualizado exitosamente.") : string.Concat("No se pudo actualizar los registros:\n", error);
                }
                else
                {
                    message = string.IsNullOrEmpty(error) ? string.Concat("Los registros han sido generados exitosamente.") : string.Concat("No se pudo generar los registros:\n", error);
                }

                new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
            }

            if (string.IsNullOrEmpty(error))
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void frmEstado_Load(object sender, EventArgs e)
        {
            llenaGrid();
        }
    }
}
