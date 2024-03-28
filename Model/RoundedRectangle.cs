using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeDraw.Model
{
    [Serializable] // za zapisvane na fail
    public class RoundedRectangleShape : Shape
    {
        #region Constructor

        public RoundedRectangleShape(RectangleF rect) : base(rect)
        {
        }

        public RoundedRectangleShape(RoundedRectangleShape roundedRectangle) : base(roundedRectangle)
        {
        }

        #endregion

        /// <summary>
        /// Проверка за принадлежност на точка point към правоъгълника.
        /// В случая на правоъгълник този метод може да не бъде пренаписван, защото
        /// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
        /// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
        /// елемента в този случай).
        /// </summary>
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
                // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
                // В случая на правоъгълник - директно връщаме true
                return true;
            else
                // Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
                return false;
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            GraphicsPath path = new GraphicsPath();

            int diameter = CornerRadius * 2;
            Size size = new Size(diameter, diameter);
            RectangleF arc = new RectangleF(Rectangle.Location, size);

            path.AddArc(arc, 180, 90);
            arc.X = Rectangle.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = Rectangle.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = Rectangle.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();

            grfx.FillPath(new SolidBrush(FillColor), path);
            grfx.DrawPath(new Pen(BorderColor,BorderWidth), path);

            //grfx.FillRectangle(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            //grfx.DrawRectangle(new Pen(BorderColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

        }
    }
}
