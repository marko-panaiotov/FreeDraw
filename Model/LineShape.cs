using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeDraw.Model
{
    [Serializable]
    public class LineShape : Shape
    {
        #region Constructor

        public LineShape(RectangleF rect) : base(rect)
        {
        }

        public LineShape(LineShape line) : base(line)
        {
        }

        public override Shape Clone(int offset)
        {
            LineShape newLine = new LineShape(this);
            newLine.Location = new PointF(newLine.Location.X + offset, newLine.Location.Y);
            newLine.Name = this.Name+" Copy";
            //newLine.EndLocation = new PointF(newLine.EndLocation.X + offset, newLine.EndLocation.Y);
            return newLine;
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
            
            Pen blackPen = new Pen(base.BorderColor, BorderWidth);

            PointF P1 = new PointF(Rectangle.X, Rectangle.Y);
            PointF P2 = new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Width);

            grfx.Transform = this.Transform;
            grfx.DrawLine(blackPen, P1, P2);
            grfx.ResetTransform();

        }
    }
}
