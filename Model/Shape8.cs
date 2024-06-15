using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeDraw.Model
{
    [Serializable]
    public class Shape8 : Shape
    {
        #region Constructor

        public Shape8(RectangleF rect) : base(rect)
        {
        }

        public Shape8(Shape8 shape8) : base(shape8)
        {
        }

        public override Shape Clone(int offset)
        {
            Shape8 newShape8 = new Shape8(this);
            newShape8.Location = new PointF(newShape8.Location.X + offset, newShape8.Location.Y + offset);
            newShape8.FillColor = this.FillColor;
            newShape8.BorderColor = this.BorderColor;
            newShape8.BorderWidth = this.BorderWidth;
            newShape8.Name = this.Name + " Copy";
            return newShape8;
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

            grfx.Transform = this.Transform;
          
            grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, 200, 200);
            grfx.DrawEllipse(new Pen(base.BorderColor,BorderWidth), Rectangle.X, Rectangle.Y, 200, 200);

            PointF p1 = new PointF(Rectangle.X, Rectangle.Y + 200 / 2);
            PointF p2 = new PointF(Rectangle.X + 200, Rectangle.Y + 200 / 2);

            PointF p3 = new PointF(Rectangle.X + 200 / 2, Rectangle.Y);
            PointF p4 = new PointF(Rectangle.X + 200 / 2, Rectangle.Y + 200);


            grfx.DrawLine(new Pen(base.BorderColor, BorderWidth), p1, p2);
            grfx.DrawLine(new Pen(base.BorderColor, BorderWidth), p3, p4);


        }
    }
}
