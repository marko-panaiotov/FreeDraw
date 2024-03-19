﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeDraw.Model
{
    public abstract class Shape
    {
        #region Constructors

        public Shape()
        {
        }

        public Shape(RectangleF rect)
        {
            rectangle = rect;
        }

        public Shape(Shape shape)
        {
            this.Height = shape.Height;
            this.Width = shape.Width;
            this.Location = shape.Location;
            this.Size = shape.Size;
            this.rectangle = shape.rectangle;

            this.FillColor = shape.FillColor;
            this.BorderColor = shape.BorderColor;
            this.CornerRadius = shape.cornerRadius;
            this.Transperancy = shape.Transperancy;
            this.Transform = shape.Transform.Clone();
        }
        #endregion

        #region Properties

        private SizeF size;
        public virtual SizeF Size
        {
            get { return size; }
            set { size = value; }
        }

        /// <summary>
        /// Обхващащ правоъгълник на елемента.
        /// </summary>
        private RectangleF rectangle;
        public virtual RectangleF Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        /// <summary>
        /// Широчина на елемента.
        /// </summary>
        public virtual float Width
        {
            get { return Rectangle.Width; }
            set { rectangle.Width = value; }
        }

        /// <summary>
        /// Височина на елемента.
        /// </summary>
        public virtual float Height
        {
            get { return Rectangle.Height; }
            set { rectangle.Height = value; }
        }

        /// <summary>
        /// Горен ляв ъгъл на елемента.
        /// </summary>
        public virtual PointF Location
        {
            get { return Rectangle.Location; }
            set { rectangle.Location = value; }
        }

        /// <summary>
        /// Цвят на елемента.
        /// </summary>
        private Color fillColor;
        public virtual Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }

        private Color borderColor = Color.Black;
        public virtual Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        private int cornerRadius = 20;

        public virtual int CornerRadius 
        {
            get { return cornerRadius; }
            set { cornerRadius = value; }
        }

        private float borderWidth;
        /// <summary>
        /// Дебелина на рамката на елемента.
        /// </summary>
        public virtual float BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; }
        }

        private int transperancy;
        /// <summary>
        /// Прозрачност на цвета на елемента.
        /// </summary>
        public virtual int Transperancy
        {
            get { return transperancy; }
            set { transperancy = value; }
        }

        private string name;
        /// <summary>
        /// Име на елемента.
        /// </summary>
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        private AppMatrix transform = new AppMatrix();
        /// <summary>
        /// Трансформираща матрица.
        /// </summary>
        public Matrix Transform
        {
            get { return transform.matrix; }
            set { transform.matrix = value; }
        }

        private AppGraphicPath gpath = new AppGraphicPath();
        public virtual GraphicsPath Gpath
        {
            get { return gpath.path; }
            set { gpath.path = value; }
        }

        #endregion


        /// <summary>
        /// Проверка дали точка point принадлежи на елемента.
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Връща true, ако точката принадлежи на елемента и
        /// false, ако не пренадлежи</returns>
        public virtual bool Contains(PointF point)
        {
            /*if (Transperancy == 0)
            {
                return Gpath.IsOutlineVisible(point, new Pen(BorderColor, BorderWidth));
            }
            else
            {
                return Gpath.IsVisible(point);
            }*/

            return Rectangle.Contains(point.X, point.Y);



        }

        /// <summary>
        /// Визуализира елемента.
        /// </summary>
        /// <param name="grfx">Къде да бъде визуализиран елемента.</param>
        public virtual void DrawSelf(Graphics grfx)
        {
            // shape.Rectangle.Inflate(shape.BorderWidth, shape.BorderWidth);
        }

        public virtual void Translate(float offsetX, float offsetY)
        {
            this.Transform.Translate(offsetX, offsetY, MatrixOrder.Append);
        }

        public virtual void Rotate(float angle, PointF center)
        {
            this.Transform.RotateAt(angle, center, MatrixOrder.Append);
        }

        public virtual void Scale(float offsetX, float offsetY, PointF center)
        {
            this.Transform.Translate(center.X, center.Y);
            this.Transform.Scale(offsetX, offsetY);
            this.Transform.Translate(-center.X, -center.Y);
        }

    }
}
