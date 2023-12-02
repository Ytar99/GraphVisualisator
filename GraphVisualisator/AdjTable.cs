using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;

namespace System.Windows.Forms
{
    /// <summary>
    /// Контрол для редактирования матрицы смежности
    /// </summary>
    public class AdjTable : DataGridView
    {
        private int[,] _matrix;

        public int[,] Matrix { get => _matrix; }


        public AdjTable()
        {
            VirtualMode = true;
            ColumnHeadersVisible = true;
            RowHeadersVisible = true;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }

        protected override void OnCellValuePushed(DataGridViewCellValueEventArgs e)
        {
            try
            {
                _matrix[e.RowIndex, e.ColumnIndex] = int.Parse(e.Value == null ? "0" : e.Value.ToString());
            }
            catch (Exception)
            {
                throw;
            }
            base.OnCellValuePushed(e);
        }

        protected override void OnCellValueNeeded(DataGridViewCellValueEventArgs e)
        {
            try
            {
                if (_matrix[e.RowIndex, e.ColumnIndex] == int.MaxValue)
                {
                    e.Value = "X";
                    this.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(228, 120, 120);
                }
                else
                {
                    e.Value = _matrix[e.RowIndex, e.ColumnIndex];

                }

            }
            catch (Exception)
            {
            }
            base.OnCellValueNeeded(e);
        }

        public void Build(int[,] matrix, int deleteIndex = -1, List<Node> nodes = null)
        {
            _matrix = matrix;

            if (deleteIndex > -1)
            {
                Rows.RemoveAt(deleteIndex);
                Columns.RemoveAt(deleteIndex);
            }

            ColumnCount = _matrix.GetLength(1);
            RowCount = _matrix.GetLength(0);

            if (nodes != null)
            {

                for (int i = 0; i < ColumnCount; i++)
                {
                    Columns[i].HeaderText = nodes[i].Label;
                    Rows[i].HeaderCell.Value = nodes[i].Label;

                    Rows[i].Cells[i].ReadOnly = true;
                    Rows[i].Cells[i].Style.BackColor = Color.LightGray;
                    Rows[i].Cells[i].Style.ForeColor = Color.Gray;
                }
            }

            Invalidate();
        }
    }
}
