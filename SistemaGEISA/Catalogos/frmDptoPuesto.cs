using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.XtraGrid.Views.Base;
using GeisaBD;
using System.Data.Common;
using DevExpress.XtraEditors.Controls;

namespace SistemaGEISA
{
    public partial class frmDptoPuesto : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler;
        private DataTable dt;

        public frmDptoPuesto()
        {
            InitializeComponent();
            controler = new Controler();
        }

        private void frmDptoPuesto_Load(object sender, EventArgs e)
        {
            llenaGrid();
        }

        private void llenaGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Tipo", typeof(int));

            grid.DataSource = dt;


            DataTable dtTipo = new DataTable();
            dtTipo.Columns.Add("Id", typeof(int));
            dtTipo.Columns.Add("Text");
            dtTipo.Rows.Add(new object[] { 1, "DEPARTAMENTO" });
            dtTipo.Rows.Add(new object[] { 2, "PUESTO" });
            luTipo.DataSource = dtTipo.DefaultView;
            luTipo.ValueMember = "Id";
            luTipo.DisplayMember = "Text";

                controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, controler.Model.Dpto_Puesto.ToList());

            foreach (Dpto_Puesto edo in controler.Model.Dpto_Puesto.ToList())
            {
                gv.AddNewRow();
                gv.SetRowCellValue(gv.FocusedRowHandle, "Id", edo.Id);
                gv.SetRowCellValue(gv.FocusedRowHandle, "Nombre", edo.Nombre);
                gv.SetRowCellValue(gv.FocusedRowHandle, "Tipo", edo.Tipo);

                gv.UpdateCurrentRow();
                gv.RefreshData();
            }
        }

        private void gv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var View = sender as ColumnView;
            View.SetRowCellValue(e.RowHandle, View.Columns["Id"], 0);
        }

        private void gv_ValidateRow(object sender, ValidateRowEventArgs e)
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

        private void gv_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

            gv.CloseEditor();
            gv.CloseEditForm();

            DbTransaction transaccion = null;

            try
            {
                transaccion = controler.Model.BeginTransaction();

                Dpto_Puesto edo = null;

                for (var i = 0; i < gv.RowCount; i++)
                {
                    var row = gv.GetDataRow(i);
                    if (row != null)
                    {
                        var Id = Convert.ToInt32(row["Id"].ToString());
                        if (Id == 0)
                        {
                            edo = new Dpto_Puesto();
                        }
                        else
                        {
                            edo = controler.Model.Dpto_Puesto.FirstOrDefault(E => E.Id == Id);
                        }
                        edo.Nombre = row["Nombre"].ToString().ToUpper().Trim();
                        edo.Tipo = Convert.ToInt32(row["Tipo"]);

                        if (Id == 0)
                        {
                            controler.Model.AddToDpto_Puesto(edo);
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
    }
}
