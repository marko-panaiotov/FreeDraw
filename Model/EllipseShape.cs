﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeDraw.Model
{
    [Serializable]
    public class EllipseShape : Shape
    {
        #region Constructor

        public EllipseShape(RectangleF rect) : base(rect)
        {
        }

        public EllipseShape(EllipseShape ellipse) : base(ellipse)
        {
        }

        public override Shape Clone(int offset)
        {
            EllipseShape newEllipse = new EllipseShape(this);
            newEllipse.Location = new PointF(newEllipse.Location.X + offset, newEllipse.Location.Y + offset);
            newEllipse.FillColor = this.FillColor;
            newEllipse.BorderColor = this.BorderColor;
            newEllipse.BorderWidth = this.BorderWidth;
            newEllipse.Name = this.Name+" Copy";
            return newEllipse;
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
            grfx.FillEllipse(new SolidBrush(base.FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawEllipse(new Pen(base.BorderColor, BorderWidth), Rectangle.X, Rectangle.Y,Rectangle.Width, Rectangle.Height);

        }
    }
}
