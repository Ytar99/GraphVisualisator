using System.Collections.Generic;
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

        public void Build(List<Node> nodes = null)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                Items.Add(nodes[i].Label);
            }


            Invalidate();
        }

        private void addNode (object sender, System.EventArgs e) { 
            Items.Add("Тест");
        }
    }
}
