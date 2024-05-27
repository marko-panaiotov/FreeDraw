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
        #region Construct
        public GroupShape()
        {

        }

        public GroupShape(RectangleF rect)
            : base(rect)
        {

        }

        public GroupShape(Shape shape)
            : base(shape)
        {

        }
        #endregion

        public override Shape Clone(int offset)
        {
            GroupShape newGroup = new GroupShape(this);

            foreach (Shape sh in SubShape)
                newGroup.SubShape.Add(sh.Clone(offset));

            newGroup.Location = new PointF(newGroup.Location.X + offset, newGroup.Location.Y + offset);
            newGroup.FillColor = this.FillColor;
            newGroup.BorderColor = this.BorderColor;
            newGroup.BorderWidth = this.BorderWidth;
            newGroup.Name = this.Name + " Copy";
            return newGroup;
        }

        #region Properties
        private List<Shape> subShape = new List<Shape>();
        public List<Shape> SubShape
        {
            get { return subShape; }
            set { subShape = value; }
        }

        private Color fillColor;
        public override Color FillColor
        {
            get { return fillColor; }
            set
            {
                fillColor = value;
                foreach (Shape subsh in subShape)
                    subsh.FillColor = value;
            }
        }

        private Color borderColor;
        public override Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                foreach (Shape subsh in subShape)
                    subsh.BorderColor = value;
            }
        }

        private float borderWidth;
        public override float BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
                foreach (Shape subsh in subShape)
                    subsh.BorderWidth = value;
            }
        }

        #endregion

        public override bool Contains(PointF point)
        {
            foreach (Shape sh in subShape)
            {
                if (sh.Contains(point)) return true;
            }
            return false;
        }

        public override void Translate(PointF vector)
        {
            base.Translate(vector);

            foreach (Shape sh in subShape)
            {
                sh.Translate(vector);
            }
        }

        public override void Translate(float offsetX, float offsetY)
        {
            base.Translate(offsetX, offsetY);

            foreach (Shape sh in subShape)
                sh.Translate(offsetX, offsetY);
        }

        public override void Rotate(int gradus)
        {
            base.Rotate(gradus);

            foreach (Shape sh in subShape)
            {
                sh.Rotate(gradus);
            }
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

            grfx.Transform = this.Transform;

            foreach (Shape sh in subShape)
            {
                sh.DrawSelf(grfx);
            }
        }

        
    }
}
