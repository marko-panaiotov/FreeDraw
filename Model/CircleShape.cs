using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeDraw.Model
{
    [Serializable]
    public class CircleShape : Shape
    {
        #region Constructor

        public CircleShape(RectangleF rect) : base(rect)
        {
        }

        public CircleShape(CircleShape circle) : base(circle)
        {
        }

        public override Shape Clone(int offset)
        {
            CircleShape newCircle = new CircleShape(this);
            newCircle.Location = new PointF(newCircle.Location.X + offset, newCircle.Location.Y + offset);
            newCircle.FillColor = this.FillColor;
            newCircle.BorderColor = this.BorderColor;
            newCircle.BorderWidth = this.BorderWidth;
            newCircle.Name = this.Name+" Copy";
            return newCircle;
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

            grfx.FillEllipse(new SolidBrush(base.FillColor), Rectangle.X, Rectangle.Y, 200, 200);
            grfx.DrawEllipse(new Pen(base.BorderColor, BorderWidth), Rectangle.X, Rectangle.Y, 200, 200);

        }

    }
}
