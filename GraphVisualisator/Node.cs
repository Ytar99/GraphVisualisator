﻿using System.Collections.Generic;
using System.Drawing;

namespace System.Windows.Forms
{
    /// <summary>
    /// Структура связи между вершинами
    /// </summary>
    /// <param name="_node">Вершина, с которой устанавливается связь.</param>
    /// <param name="_weight">Вес связи.</param>

    public struct NodeLink
    {
        public Node node;
        public int linkWeight;
        public bool selected;

        public NodeLink(Node _node, int _weight, bool _selected)
        {
            this.node = _node;
            this.linkWeight = _weight;
            this.selected = _selected;
        }
    }

    public class Node : IDrawable, IDragable
    {
        public List<NodeLink> Linked { get; set; } = new List<NodeLink>();
        public string Label;
        public float Radius = 21f;
        public PointF Location;
        public int tableIndex;
        public bool Selected = false;


        public Node(string label, int index)
        {
            this.Label = label;
            this.tableIndex = index;

        }

        public void ChangeIndex(int index)
        {
            this.tableIndex = index;
        }

        public void Drag(PointF offset)
        {
            Location = Location.Add(offset);
        }

        public void EndDrag() { }

        public bool Hit(PointF point)
        {
            var p = point.Sub(Location);
            return Math.Pow(p.X, 2) + Math.Pow(p.Y, 2) <= Radius * Radius;
        }

        public void Paint(Graphics gr)
        {
            foreach (var item in Linked)
            {
                gr.DrawLink(Location, item.node.Location, Radius, item.linkWeight.ToString(), item.selected);
            }

            var state = gr.Save();
            gr.TranslateTransform(Location.X, Location.Y);

            if (Selected)
            {
                gr.DrawCircle(Radius, new Pen(Color.Blue) { Width = 3 });
            }
            else
            {
                gr.DrawCircle(Radius, Pens.Black);

            }

            if (!string.IsNullOrEmpty(Label))
            {
                gr.DrawCenteredString(Label, SystemFonts.CaptionFont, SystemBrushes.ControlDarkDark, Radius);
            }
            gr.Restore(state);
        }

        public void Paint(Graphics gr, bool isBezier)
        {
            foreach (var item in Linked)
            {
                gr.DrawLink(Location, item.node.Location, Radius, item.linkWeight.ToString(), item.selected, isBezier);
            }

            var state = gr.Save();
            gr.TranslateTransform(Location.X, Location.Y);

            if (Selected)
            {
                gr.DrawCircle(Radius, new Pen(Color.Blue) { Width = 3 });
            }
            else
            {
                gr.DrawCircle(Radius, Pens.Black);

            }

            if (!string.IsNullOrEmpty(Label))
            {
                gr.DrawCenteredString(Label, SystemFonts.CaptionFont, SystemBrushes.ControlDarkDark, Radius);
            }
            gr.Restore(state);
        }

        public IDragable StartDrag(PointF p)
        {
            return this;
        }

        public override string ToString()
        {
            return string.Format("Node: {0} ({1})", Label, Selected);
        }
    }
}
