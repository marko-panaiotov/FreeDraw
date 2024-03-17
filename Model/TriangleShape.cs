﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeDraw.Model
{
    public class TriangleShape : Shape
    {
        #region Constructor

        public TriangleShape(RectangleF rect) : base(rect)
        {
        }

        public TriangleShape(TriangleShape triangle) : base(triangle)
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

            PointF point1 = new PointF(150, 100);
            PointF point2 = new PointF(100, 200);
            PointF point3 = new PointF(200, 200);

            PointF[] trianglePoints = { point1, point2, point3 };

            // Draw the triangle
            grfx.FillPolygon(new SolidBrush(FillColor), trianglePoints);
            grfx.DrawPolygon(new Pen(BorderColor), trianglePoints);

            //grfx.FillPolygon(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            //grfx.DrawEllipse(Pens.Black, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
        }
    }
}
