using System.Drawing;

namespace System.Windows.Forms
{
    /// <summary>
    /// Контрол для редактирования матрицы смежности
    /// </summary>
    /// 

    public class AdjList : ListBox
    {

        public AdjList() {

        }

        public void Build(int[,] matrix)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Items.Add(alphabet[i % alphabet.Length]);
            }


            Invalidate();
        }

        private void addNode (object sender, System.EventArgs e) { 
            Items.Add("Тест");
        }
    }
}
