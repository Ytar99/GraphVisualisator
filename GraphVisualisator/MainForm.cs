using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GraphVisualisator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        int[,] _matrix = new int[,]
            {
                {0, 1, 6, 0},
                {0, 0, 4, 1},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
            };



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            conjPanel1.Build(_matrix, -1);
            conjTable1.Build(_matrix, -1, conjPanel1.Nodes.ToList());
            conjList1.Build(conjPanel1.Nodes.ToList());
        }

        private void conjTable1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            conjPanel1.Build(conjTable1.Matrix);
        }

        private void deleteNode_button_Click(object sender, EventArgs e)
        {
            if (conjList1.SelectedItem != null)
            {
                int deletedIndex = conjList1.SelectedIndex;
                int[,] oldMatrix = conjTable1.Matrix;
                int[,] newMatrix = new int[oldMatrix.GetLength(0) - 1, oldMatrix.GetLength(1) - 1];

                for (int i = 0; i < newMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < newMatrix.GetLength(1); j++)
                    {
                        int newI = i;
                        int newJ = j;

                        if (i >= deletedIndex)
                            newI = i + 1;

                        if (j >= deletedIndex)
                            newJ = j + 1;

                        newMatrix[i, j] = oldMatrix[newI, newJ];
                    }
                }

                conjPanel1.Build(newMatrix, deletedIndex);
                conjTable1.Build(newMatrix, deletedIndex, conjPanel1.Nodes.ToList());
                conjList1.Items.Remove(conjList1.SelectedItem);
            }


        }
        private void addNode_button_Click(object sender, EventArgs e)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int[,] oldMatrix = conjTable1.Matrix;
            int newIndex = oldMatrix.GetLength(0);

            int[,] newMatrix = new int[oldMatrix.GetLength(0) + 1, oldMatrix.GetLength(1) + 1];

            for (int i = 0; i < oldMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < oldMatrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = oldMatrix[i, j];
                }
            }


            for (int i = 0; i < newMatrix.GetLength(0); i++)
            {
                newMatrix[i, newIndex] = 0;
                newMatrix[newIndex, i] = 0;
            }

            Node newNode = new Node(alphabet[newIndex % alphabet.Length].ToString(), newIndex);

            conjPanel1.AddNode(newMatrix, newNode);
            conjTable1.Build(newMatrix, -1, conjPanel1.Nodes.ToList());
            conjList1.Items.Add(conjPanel1.Nodes.Last().Label);
        }

        private void renameNode_button_Click(object sender, EventArgs e)
        {
            using (RenameDialog form = new RenameDialog())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string newName = form.NewName;

                    conjPanel1.RenameNode(conjTable1.Matrix, conjList1.SelectedIndex, newName);
                    conjTable1.Build(conjTable1.Matrix, -1, conjPanel1.Nodes.ToList());
                    conjList1.Items[conjList1.SelectedIndex] = newName;
                }

            }
        }

        private void conjList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conjList1.SelectedItem != null)
            {
                deleteNode_button.Enabled = true;
                renameNode_button.Enabled = true;
            }
            else
            {
                deleteNode_button.Enabled = false;
                renameNode_button.Enabled = false;
            }
        }


        private void calcFloyd_button_Click(object sender, EventArgs e)
        {
            int matrixSize = conjTable1.Matrix.GetLength(0);
            int[,] weightMatrix = new int[matrixSize, matrixSize];
            int INF = int.MaxValue;
            int[,] pathMatrix = new int[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; ++i)
                for (int j = 0; j < matrixSize; j++)
                {
                    weightMatrix[i, j] = conjTable1.Matrix[i, j];

                    if (weightMatrix[i, j] == 0)
                        weightMatrix[i, j] = INF;

                    if (i == j)
                        weightMatrix[i, j] = 0;

                    pathMatrix[i, j] = j;
                }

            for (int k = 0; k < matrixSize; ++k)
            {
                for (int i = 0; i < matrixSize; ++i)
                {
                    for (int j = 0; j < matrixSize; ++j)
                    {
                        if (weightMatrix[i, k] != INF && weightMatrix[k, j] != INF)
                        {
                            if (weightMatrix[i, j] > weightMatrix[i, k] + weightMatrix[k, j])
                            {
                                weightMatrix[i, j] = weightMatrix[i, k] + weightMatrix[k, j];
                                pathMatrix[i, j] = pathMatrix[i, k];
                            }
                        }
                    }
                }
            }

            using (PathsForm form = new PathsForm(this, weightMatrix, pathMatrix, conjPanel1.Nodes.ToList()))
            {
                DialogResult dr = form.ShowDialog();
                conjPanel1.Build(conjTable1.Matrix);
                form.Dispose();
            }
        }

        private void bezier_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            conjPanel1.isBezier = bezier_checkbox.Checked;
            conjPanel1.Build(conjTable1.Matrix);
        }
    }
}
