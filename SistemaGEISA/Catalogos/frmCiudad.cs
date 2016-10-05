using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GeisaBD;
using System.Data.Common;
using DevExpress.XtraGrid.Views.Base;

namespace SistemaGEISA
{
    public partial class frmCiudad : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler;
        public Estado edo;

        private DataTable dt;
        public frmCiudad()
        {
            InitializeComponent();
            controler = new Controler();

            llenaEdo();
        }

        private void frmCiudad_Load(object sender, EventArgs e)
        {
            if (edo != null)
            {
                lookupEstado.SelectedText = edo.Nombre;
            }
        }

        private void llenaEdo()
        {
            lookupEstado.Properties.DataSource = controler.Model.Estado.ToList();
            lookupEstado.Properties.DisplayMember = "Nombre";
            lookupEstado.Properties.ValueMember = "Id";
        }

        private void llenaGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));

            grid.DataSource = dt;

            controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, controler.Model.Ciudad.ToList());

            foreach (Ciudad cd in controler.Model.Ciudad.Where(C => C.EstadoId == edo.Id).ToList())
            {
                gv.AddNewRow();
                gv.SetRowCellValue(gv.FocusedRowHandle, "Id", cd.Id);
                gv.SetRowCellValue(gv.FocusedRowHandle, "Nombre", cd.Nombre);

                gv.UpdateCurrentRow();
                gv.RefreshData();
            }
        }

        private bool isValid()
        {
            var isValid = true;

            isValid &= lookupEstado.GetSelectedDataRow() != null;
            controler.SetError(lookupEstado, isValid ? string.Empty : "Seleccione un Estado");

            return isValid;
        }

        private void lookupEstado_EditValueChanged(object sender, EventArgs e)
        {
            edo = lookupEstado.GetSelectedDataRow() as Estado;

            if (edo != null)
            {
                llenaGrid();
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

            if (isValid())
            {
                DbTransaction transaccion = null;

                try
                {
                    transaccion = controler.Model.BeginTransaction();

                    Ciudad cd = null;

                    for (var i = 0; i < gv.RowCount; i++)
                    {
                        var row = gv.GetDataRow(i);
                        if (row != null)
                        {
                            var Id = Convert.ToInt32(row["Id"].ToString());
                            if (Id == 0)
                            {
                                cd = new Ciudad();
                            }
                            else
                            {
                                cd = controler.Model.Ciudad.FirstOrDefault(C => C.Id == Id);
                            }
                            cd.Estado = edo;
                            cd.Nombre = row["Nombre"].ToString().ToUpper().Trim();

                            if (Id == 0)
                            {
                                controler.Model.AddToCiudad(cd);
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
            }

            if (string.IsNullOrEmpty(error))
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
    }
}
