using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeDraw.Model
{
    [Serializable]
    public class GroupShape : Shape
    {
        #region Constructor

        public GroupShape(List<Shape> SubFigures)
        {
            subShape.AddRange(SubFigures);

            float minX = subShape[0].Gpath.GetBounds().Left;
            float minY = subShape[0].Gpath.GetBounds().Top;
            float maxX = subShape[0].Gpath.GetBounds().Right;
            float maxY = subShape[0].Gpath.GetBounds().Bottom;

            foreach (Shape sh in subShape)
            {
                minX = Math.Min(minX, sh.Gpath.GetBounds().Left);
                minY = Math.Min(minY, sh.Gpath.GetBounds().Top);
                maxX = Math.Max(maxX, sh.Gpath.GetBounds().Right);
                maxY = Math.Max(maxY, sh.Gpath.GetBounds().Bottom);
            }
            PointF pinch = new PointF(minX, minY);
            this.Location = pinch;
            SizeF size = new SizeF(maxX - minX, maxY - minY);
            this.Size = size;

            this.Gpath.AddRectangle(new RectangleF(pinch, size));
        }

        public GroupShape(RectangleF rect)
            : base(rect)
        {
            this.Location = rect.Location;
            this.Size = rect.Size;
        }

        public GroupShape(GroupShape rectangle)
            : base(rectangle) { }

        #endregion

        #region Properties

        public List<Shape> subShape = new List<Shape>();

        private Color fillColor;
        public override Color FillColor
        {
            get { return fillColor; }
            set
            {
                fillColor = value;
                foreach (Shape sh in subShape)
                    sh.FillColor = fillColor;
            }
        }

        private float borderWidth;
        public override float BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
                foreach (Shape sh in subShape)
                    sh.BorderWidth = borderWidth;
            }
        }

        private Color borderColor;
        public override Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                foreach (Shape sh in subShape)
                    sh.BorderColor = borderColor;
            }
        }

        private int transperancy;
        public override int Transperancy
        {
            get { return transperancy; }
            set
            {
                transperancy = value;
                foreach (Shape s in subShape)
                    s.Transperancy = transperancy;
            }
        }

        #endregion Properties

        #region Operations

        public override bool Contains(PointF point)
        {
            foreach (Shape sh in subShape)
            {
                if (sh.Contains(point)) return true;
            }
            return false;
        }

        public override void Translate(float offsetX, float offsetY)
        {
            base.Translate(offsetX, offsetY);

            foreach (Shape sh in subShape)
                sh.Translate(offsetX, offsetY);
        }

        public override void Rotate(float angle, PointF center)
        {
            base.Rotate(angle, center);

            foreach (Shape sh in subShape)
                sh.Rotate(angle, center);
        }

        public override void Scale(float offsetX, float offsetY, PointF center)
        {
            base.Scale(offsetX, offsetY, center);

            foreach (Shape sh in subShape)
            {
                sh.Scale(offsetX, offsetY, center);
            }
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            Gpath.Reset();
            Gpath.AddRectangle(new RectangleF(this.Location, this.Size));
            Gpath.Transform(this.Transform);

            foreach (Shape sh in subShape)
            {
                sh.DrawSelf(grfx);
            }
        }

        #endregion Operations
    }
}
