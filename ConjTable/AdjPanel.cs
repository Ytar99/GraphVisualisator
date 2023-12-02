using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace System.Windows.Forms
{
    public class AdjPanel : Panel
    {
        private IList<Node> _nodes;
        private PointF _offset;
        private PointF _mouseDown;
        private IDragable _dragged;
        private PointF Center { get => new PointF(ClientRectangle.Width / 2f, ClientRectangle.Height / 2); }

        public IList<Node> Nodes { get => _nodes; }
        public bool isBezier = false;

        public AdjPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable, true);
        }

        public void Build(int[,] conjMatrix, int deleteIndex = -1)
        {
            if (conjMatrix.GetLength(0) != conjMatrix.GetLength(1))
                throw new ArgumentException("Матрица смежности должна быть квадратной");

            if (_nodes == null)
                CreateNodes(conjMatrix);
            else
                UpdateNodes(conjMatrix, deleteIndex);

            Invalidate();
        }

        public Node FindNodeByIndex(int index)
        {
            foreach (Node n in _nodes)
            {
                if (n.tableIndex == index) return n;
            }

            return null;
        }

        public string RestorePath(int[,] weights, int[,] paths, Node from, Node to)
        {
            int temp = 0;
            int size = weights.GetLength(0);
            /*string result = from.Label + " -> " + to.Label + ": ";*/
            string result = "";

            if (from.tableIndex >= size)
            {
                Console.WriteLine("Узел [" + from.Label + "] за границами матрицы");
                return result + "нет пути";
            }

            if (to.tableIndex >= size)
            {
                Console.WriteLine("Узел [" + to.Label + "] за границами матрицы");
                return result + "нет пути";
            }

            if (weights[from.tableIndex, to.tableIndex] == int.MaxValue)
            {
                return result + "нет пути";
            }

            result += from.Label + " → ";
            temp = from.tableIndex;

            while (temp != to.tableIndex)
            {
                temp = paths[temp, to.tableIndex];
                Node n = FindNodeByIndex(temp);
                if (n != null)
                    result += FindNodeByIndex(temp).Label + " → ";

            }

            result = result.Substring(0, result.Length - 3);

            return result;
        }

        public int[] RestorePathArray(int[,] weights, int[,] paths, Node from, Node to)
        {
            int temp = 0;
            int size = weights.GetLength(0);
            List<int> result = new List<int>();

            if (from.tableIndex >= size)
            {
                Console.WriteLine("Узел [" + from.Label + "] за границами матрицы");
                return result.ToArray();
            }

            if (to.tableIndex >= size)
            {
                Console.WriteLine("Узел [" + to.Label + "] за границами матрицы");
                return result.ToArray();
            }

            if (weights[from.tableIndex, to.tableIndex] == int.MaxValue)
            {
                return result.ToArray();
            }

            result.Add(from.tableIndex);
            temp = from.tableIndex;

            while (temp != to.tableIndex)
            {
                temp = paths[temp, to.tableIndex];
                Node n = FindNodeByIndex(temp);
                if (n != null)
                    result.Add(FindNodeByIndex(temp).tableIndex);
            }

            return result.ToArray();
        }

        public void AddNode(int[,] conjMatrix, Node node)
        {
            _nodes.Add(node);
            UpdateNodes(conjMatrix, -1);

            Invalidate();
        }

        public void RenameNode(int[,] conjMatrix, int renameIndex, string newName)
        {
            _nodes[renameIndex].Label = newName;
            UpdateNodes(conjMatrix, -1);

            Invalidate();
        }

        public void SelectPath(int[,] conjMatrix, int fromIndex, int toIndex, int[] selectedLinks)
        {
            FindNodeByIndex(fromIndex).Selected = true;
            FindNodeByIndex(toIndex).Selected = true;

            UpdateNodes(conjMatrix, -1, selectedLinks);
            Invalidate();
        }

        private int SearchLink(int[] selectedLinks, int[] link)
        {
            var len = link.Length;
            var limit = selectedLinks.Length - len;
            for (var i = 0; i <= limit; i++)
            {
                var k = 0;
                for (; k < len; k++)
                {
                    if (link[k] != selectedLinks[i + k]) break;
                }
                if (k == len) return i;
            }
            return -1;
        }

        private void UpdateNodes(int[,] conjMatrix, int deleteIndex, int[] selectedLinks = null)
        {
            if (deleteIndex > -1)
            {
                _nodes.RemoveAt(deleteIndex);

                for (int i = 0; i < _nodes.Count; i++)
                {
                    if (_nodes[i].tableIndex != i)
                        _nodes[i].tableIndex = i;
                }
            }

            foreach (var item in _nodes)
            {
                item.Selected = selectedLinks == null ? false : selectedLinks.Contains(item.tableIndex);

                item.Linked.Clear();
            }


            for (int i = 0; i < conjMatrix.GetLength(0); i++)
                for (int j = 0; j < conjMatrix.GetLength(1); j++)
                    if (conjMatrix[i, j] != 0)
                    {
                        int[] link = { i, j };
                        if (selectedLinks != null && SearchLink(selectedLinks, link) > -1)
                        {
                            _nodes[i].Linked.Add(new NodeLink(_nodes[j], conjMatrix[i, j], true));
                        }
                        else
                        {
                            _nodes[i].Linked.Add(new NodeLink(_nodes[j], conjMatrix[i, j], false));
                        }
                    }
        }

        private void CreateNodes(int[,] conjMatrix)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            _nodes = Enumerable.Range(0, conjMatrix.GetLength(0)).Select(i => new Node(alphabet[i % alphabet.Length].ToString(), i)).ToList();

            for (int i = 0; i < conjMatrix.GetLength(0); i++)
                for (int j = 0; j < conjMatrix.GetLength(1); j++)
                {
                    if (conjMatrix[i, j] != 0)
                        _nodes[i].Linked.Add(new NodeLink(_nodes[j], conjMatrix[i, j], false));
                }
            ArrangeNodes();
        }

        //Первичная расстановка вершин в вершинах многоугольника
        private void ArrangeNodes()
        {
            int i = 0;
            var r = Math.Min(ClientRectangle.Width, ClientRectangle.Height) * 0.9 / 2f;
            int count = _nodes.Count;
            foreach (var node in _nodes.Cast<Node>())
            {
                var x = r * Math.Cos(2 * Math.PI * i / count);
                var y = r * Math.Sin(2 * Math.PI * i / count);
                node.Location = new PointF((float)x, (float)y);
                i++;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_nodes == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TranslateTransform(Center.X, Center.Y);
            e.Graphics.TranslateTransform(_offset.X, _offset.Y);

            foreach (var item in _nodes)
                item.Paint(e.Graphics, isBezier);
        }

        private PointF ToClient(PointF p)
        {
            return p.Sub(_offset).Sub(Center);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseDown = e.Location;
                var p = ToClient(e.Location);
                //ищем объект под мышкой
                var hitted = _nodes.FirstOrDefault(n => n.Hit(p));
                if (hitted != null)
                    _dragged = hitted.StartDrag(p);//начинаем тащить
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var shift = new PointF(e.Location.X - _mouseDown.X, e.Location.Y - _mouseDown.Y);
                _mouseDown = e.Location;

                if (_dragged != null)
                    _dragged.Drag(shift);//двигаем объект
                else
                    _offset = new PointF(_offset.X + shift.X, _offset.Y + shift.Y);//сдвигаем канвас

                Invalidate();
            }
            var p = ToClient(e.Location);
            //ищем объект под мышкой
            var hitted = _nodes.FirstOrDefault(n => n.Hit(p));
            //Меняем курсор, если над вершиной 
            Cursor = hitted != null ? Cursors.Hand : Cursors.Default;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (_dragged != null)
                _dragged.EndDrag();
            _dragged = null;
            Invalidate();
        }
    }
}
