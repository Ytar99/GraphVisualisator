using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms
{
    internal static class Helper
    {
        private const int GapAngle = 8;//Зазор в градусах между точками входа смежных рёбер

        private static Pen LinkPen = new Pen(Color.Red) { CustomEndCap = new AdjustableArrowCap(5, 10, false) };
        private static Pen LinkSelectedPen = new Pen(Color.Blue) { CustomEndCap = new AdjustableArrowCap(5, 10, false), Width = 3 };

        // Шрифт меток весов
        private static FontFamily weightFontFamily = new FontFamily("Arial");
        private static Font weightFont = new Font(
           weightFontFamily,
           12,
           FontStyle.Bold,
           GraphicsUnit.Pixel);
        private static SolidBrush weightBrush = new SolidBrush(Color.White);

        public static PointF Sub(this PointF pt1, PointF pt2)
        {
            return new PointF(pt1.X - pt2.X, pt1.Y - pt2.Y);
        }

        public static PointF Add(this PointF pt1, PointF pt2)
        {
            return new PointF(pt1.X + pt2.X, pt1.Y + pt2.Y);
        }

        /// <summary>
        /// Середина отрезка между точками
        /// </summary>
        public static PointF Mid(this PointF pt1, PointF pt2)
        {
            return new PointF((pt2.X + pt1.X) / 2, (pt2.Y + pt1.Y) / 2);
        }
        /// <summary>
        /// Рисование связи между вершинами
        /// </summary>
        /// <param name="g">Где рисовать? Объект <see cref="Graphics"/>.</param>
        /// <param name="from">Центр вершины, от которой идёт связь.</param>
        /// <param name="to">Центр вершины, к которой идёт связь.</param>
        /// <param name="radius">Отступ от вершины.</param>
        /// <param name="straight">Рисовать ребро прямой или кривой Безье?</param>
        public static void DrawLink(this Graphics g, PointF from, PointF to, float radius, string label, bool selected = false, bool isBezier = false)
        {
            //Считаем точки входа ребёр графа в вершины
            var pt1 = new Vector(to.X - from.X, to.Y - from.Y); pt1.Normalize(); pt1 *= radius;
            var pt2 = new Vector(from.X - to.X, from.Y - to.Y); pt2.Normalize(); pt2 *= radius;
            pt1 = pt1.Rotate(GapAngle);
            pt2 = pt2.Rotate(-GapAngle);
            pt1 = pt1.Add(from);
            pt2 = pt2.Add(to);
            if (isBezier)
                DrawBezierLink(g, pt1.ToPointF(), pt2.ToPointF(), label, selected);
            else
                DrawStraightLink(g, pt1.ToPointF(), pt2.ToPointF(), label, selected);
        }

        private static void DrawStraightLink(Graphics g, PointF from, PointF to, string Label, bool selected)
        {
            var mid = from.Mid(to);
            var pt2 = mid.Mid(to);

            var v = new Vector(from.Y - to.Y, to.X - from.X);
            v.Normalize();

            var shift = new PointF(pt2.X + (float)v.X, pt2.Y + (float)v.Y);

            if (selected)
            {
                g.DrawLine(LinkSelectedPen, from, to);
            }
            else
            {
                g.DrawLine(LinkPen, from, to);
            }

            g.DrawLineCenteredString(Label, weightFont, weightBrush, 18f, shift);
            /*g.DrawString(Label, SystemFonts.CaptionFont, SystemBrushes.ControlDarkDark, mid.X, mid.Y);*/
        }

        private static void DrawBezierLink(Graphics g, PointF from, PointF to, string Label, bool selected)
        {
            //Середина отрезка между крайними точками
            var mid = from.Mid(to);
            //Четверть отрезка от первой крайней точки
            var pt1 = mid.Mid(from);
            //Четверть отрезка от второй крайней точки
            var pt2 = mid.Mid(to);
            //Вектор, перпендикулярный направлению связи
            var v = new Vector(from.Y - to.Y, to.X - from.X);
            var l = v.Length * 0.08; // Кривизна
            //Нормализуем вектор
            v.Normalize();
            v *= l;
            //Опорные точки для кривой Безье
            pt1 = v.Add(pt1).ToPointF();
            pt2 = v.Add(pt2).ToPointF();

            /*var shift = new PointF(pt2.X + (float)v.X * (float)0.75, pt2.Y + (float)v.Y * (float)0.75);*/
            var shift = new PointF(pt2.X - (float)v.X / (float)2.35, pt2.Y - (float)v.Y / (float)2.35);
            /*g.DrawLine(SystemPens.MenuText, mid, shift);*/
            /*mid = v.Add(shift).ToPointF();*/


            if (selected)
            {
                g.DrawBezier(LinkSelectedPen, from, pt1, pt2, to);
            }
            else
            {
                g.DrawBezier(LinkPen, from, pt1, pt2, to);
            }
            g.DrawLineCenteredString(Label, weightFont, weightBrush, 18f, shift);
        }

        /// <summary>
        /// Рисование окружности заданного радиуса в начале координат
        /// </summary>
        public static void DrawCircle(this Graphics g, float radius, Pen pen)
        {
            g.DrawEllipse(pen, -radius, -radius, 2 * radius, 2 * radius);
        }
        /// <summary>
        /// Рисование строки с выравниванием по центру по вертикали и по горизонтали.
        /// </summary>
        public static void DrawCenteredString(this Graphics g, string text, Font font, Brush brush, float radius)
        {
            var rect = new RectangleF(-radius, -radius, 2 * radius, 2 * radius);
            rect.Inflate(-2, -4);
            g.DrawString(text, font, brush, rect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }
        /// <summary>
        /// Рисование строки с выравниванием по центру линии - по вертикали и по горизонтали.
        /// </summary>
        public static void DrawLineCenteredString(this Graphics g, string text, Font font, Brush brush, float radius, PointF center)
        {
            var bgBrush = new SolidBrush(Color.FromArgb(230, Color.DarkGray));
            var rect = new RectangleF(center.X - radius, center.Y - radius, 2 * radius, 2 * radius);
            rect.Inflate(2, -4);

            g.FillRectangle(bgBrush, rect);
            g.DrawString(text, font, new SolidBrush(Color.Black), new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }
        /// <summary>
        /// Преобразование вектора в точку
        /// </summary>
        private static PointF ToPointF(this Vector vector)
        {
            return new PointF((float)vector.X, (float)vector.Y);
        }
        /// <summary>
        /// Координаты отрезка между окружностями на прямой, проходящей через их центры.
        /// </summary>
        /// <param name="center1">Центр первой окружности</param>
        /// <param name="r1">Радиус первой окружности</param>
        /// <param name="center2">Центр второй окружности</param>
        /// <param name="r2">Радиус второй окружности</param>
        private static Tuple<PointF, PointF> LineBetweenCircles(PointF center1, float r1, PointF center2, float r2)
        {
            var v = new Vector(center2.X - center1.X, center2.Y - center1.Y);
            v.Normalize();
            var start = Vector.Add(new Vector(center1.X, center1.Y), v * r1);
            var end = Vector.Add(new Vector(center2.X, center2.Y), -v * r2);
            return new Tuple<PointF, PointF>(new PointF((float)start.X, (float)start.Y), new PointF((float)end.X, (float)end.Y));
        }

        private static Vector Rotate(this Vector vector, float angle)
        {
            angle *= (float)Math.PI / 180;
            return new Vector(vector.X * Math.Cos(angle) - vector.Y * Math.Sin(angle), vector.X * Math.Sin(angle) + vector.Y * Math.Cos(angle));
        }

        private static Vector Add(this Vector vector, PointF point)
        {
            return new Vector(vector.X + point.X, vector.Y + point.Y);
        }
    }
}
