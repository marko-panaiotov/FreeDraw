using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeDraw.Model
{
    [Serializable]
    public class DotShape : Shape
    {
     
        #region Constructor

        public DotShape(RectangleF rect) : base(rect)
        {
        }

        public DotShape(DotShape dot) : base(dot)
        {
        }

        public override Shape Clone(int offset)
        {
            DotShape newDot = new DotShape(this);
            newDot.Location = new PointF(newDot.Location.X + offset, newDot.Location.Y + offset);
            newDot.FillColor = this.FillColor;
            newDot.BorderColor = this.BorderColor;
            newDot.BorderWidth = this.BorderWidth;
            newDot.Name = this.Name+"Copy";
            return newDot;
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
            grfx.FillEllipse(new SolidBrush(base.FillColor), Rectangle.X - 3, Rectangle.Y - 3, 7, 7);
            grfx.DrawEllipse(new Pen(base.BorderColor,BorderWidth), Rectangle.X-3, Rectangle.Y-3, 7, 7);
        }


    }
}
