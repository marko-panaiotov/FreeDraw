﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace FreeDraw.Model
{
    [Serializable]
    public abstract class Shape
    {
        #region Construct
        public Shape()
        {
        }

        public Shape(RectangleF rect)
        { 
            this.Location = rect.Location;
            this.Size = rect.Size;  
            this.rectangle = rect;
        }

        public Shape(Shape shape)
        {
            this.Height = shape.Height;
            this.Width = shape.Width;
            this.Location = shape.Location;
            this.rectangle = shape.rectangle;
            this.Size = shape.Size;
            this.Location = shape.Location;

            this.Transperancy = shape.Transperancy;
            this.FillColor = shape.FillColor;
            this.BorderColor = shape.BorderColor;
            this.BorderWidth = shape.BorderWidth;

            this.Transform = shape.Transform.Clone();


        }
        #endregion

        #region Properties
        /// <summary>
        /// Обхващащ правоъгълник на елемента.
        /// </summary>
        private RectangleF rectangle;
        public virtual RectangleF Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        public virtual float Width
        {
            get { return Rectangle.Width; }
            set { rectangle.Width = value; }
        }

        public virtual float Height
        {
            get { return Rectangle.Height; }
            set { rectangle.Height = value; }
        }

        public virtual PointF Location
        {
            get { return Rectangle.Location; }
            set { rectangle.Location = value; }
        }

        public virtual PointF Center
        {
            get { return new PointF(this.Location.X + this.Width / 2, this.Location.Y + this.Height / 2); }
        }

        private Color fillColor;
        public virtual Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }

        private Color borderColor=Color.Black;
        public virtual Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
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

        private float borderWidth;
        public virtual float BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; }
        }

        private AppMatrix transform = new AppMatrix();
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


        private int rotation = 0;
        public int Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        private int cornerRadius = 20;

        public virtual int CornerRadius
        {
            get { return cornerRadius; }
            set { cornerRadius = value; }
        }

        private SizeF size;
        public virtual SizeF Size
        {
            get { return size; }
            set { size = value; }
        }

        #endregion

        public virtual bool Contains(PointF point)
        {
            Matrix reverse = this.Transform.Clone();
            return Rectangle.Contains(point.X, point.Y);
        }

        public virtual void Translate(PointF vector)
        {
            int backRotation = rotation;
            Rotate(-backRotation);
            rotation = backRotation;

            this.Location = new PointF(this.Location.X + vector.X, this.Location.Y + vector.Y);

            Rotate(backRotation);
            rotation = backRotation;
        }

        public virtual void Translate(float offsetX, float offsetY)
        {
            this.Transform.Translate(offsetX, offsetY, MatrixOrder.Append);
        }

        public virtual void Rotate(int gradus)
        {
            this.Transform.RotateAt(gradus, Center);
            rotation += gradus;
        }


        public virtual void DrawSelf(Graphics grfx){}

        public abstract Shape Clone(int offset);
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
