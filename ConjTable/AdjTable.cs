using System.Drawing;

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
                e.Value = _matrix[e.RowIndex, e.ColumnIndex];
            }
            catch (Exception)
            {
                throw;
            }
            base.OnCellValueNeeded(e);
        }

        public void Build(int[,] matrix)
        {
            _matrix = matrix;
            ColumnCount = _matrix.GetLength(1);
            RowCount = _matrix.GetLength(0);

            foreach (DataGridViewColumn column in Columns)
            {
                column.HeaderText = "Col";
            }

            foreach (DataGridViewRow row in Rows)
            {
                row.HeaderCell.Value = "Row";
            }

            Invalidate();
        }
    }
}
