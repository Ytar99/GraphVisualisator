using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConjTable.Demo
{
    public partial class PathsForm : Form
    {
        private int[,] _conjMatrix;
        private int[,] _weightMatrix;
        private int[,] _pathMatrix;
        MainForm mainForm;

        public PathsForm(MainForm parentForm, int[,] weightMatrix, int[,] pathMatrix, List<Node> nodes)
        {
            InitializeComponent();

            mainForm = parentForm;

            _weightMatrix = new int[weightMatrix.GetLength(0), weightMatrix.GetLength(1)];
            _pathMatrix = new int[pathMatrix.GetLength(0), pathMatrix.GetLength(1)];
            _conjMatrix = new int[mainForm.conjTable1.Matrix.GetLength(0), mainForm.conjTable1.Matrix.GetLength(1)];

            for (int i = 0; i < weightMatrix.GetLength(0); i++)
                for (int j = 0; j < weightMatrix.GetLength(1); j++)
                {
                    _weightMatrix[i, j] = weightMatrix[i, j];
                    _pathMatrix[i, j] = pathMatrix[i, j];
                    _conjMatrix[i, j] = mainForm.conjTable1.Matrix[i, j];
                }

            distTable1.Build(_weightMatrix, -1, nodes);

        }

        private void distTable1_SelectionChanged(object sender, EventArgs e)
        {
            var selectedCell = distTable1.SelectedCells[0];
            var nodeFrom = mainForm.conjPanel1.FindNodeByIndex(selectedCell.RowIndex);
            var nodeTo = mainForm.conjPanel1.FindNodeByIndex(selectedCell.ColumnIndex);

            var pathString = mainForm.conjPanel1.RestorePath(_weightMatrix, _pathMatrix, nodeFrom, nodeTo);

            mainForm.conjPanel1.SelectPath(_conjMatrix, nodeFrom.tableIndex, nodeTo.tableIndex, mainForm.conjPanel1.RestorePathArray(_weightMatrix, _pathMatrix, nodeFrom, nodeTo));
            if (pathString == null || nodeFrom == nodeTo)
            {
                textBox1.Text = "Выберите ячейку из матрицы расстояний";
                return;
            }

            textBox1.Text = "Путь из [" + nodeFrom.Label + "] в [" + nodeTo.Label + "] равен " + selectedCell.Value.ToString() + ":" + Environment.NewLine + "> " + pathString.ToString();
        }
    }
}
