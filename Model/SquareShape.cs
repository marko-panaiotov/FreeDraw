﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeDraw.Model
{
    [Serializable] // za zapisvane na fail
    public class SquareShape : Shape
    {
        #region Constructor

        public SquareShape(RectangleF rect) : base(rect)
        {
        }

        public SquareShape(SquareShape square) : base(square)
        {
        }

        public override Shape Clone(int offset)
        {
            SquareShape newRect = new SquareShape(this);
            newRect.Location = new PointF(newRect.Location.X + offset, newRect.Location.Y + offset);
            newRect.FillColor = this.FillColor;
            newRect.BorderColor = this.BorderColor;
            newRect.BorderWidth = this.BorderWidth;
            newRect.Name = this.Name+ " Copy";
            return newRect;
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
            grfx.FillRectangle(new SolidBrush(base.FillColor), Rectangle.X, Rectangle.Y, 100, 100);
            grfx.DrawRectangle(new Pen(base.BorderColor, BorderWidth), Rectangle.X, Rectangle.Y, 100, 100);


        }
    }
}
