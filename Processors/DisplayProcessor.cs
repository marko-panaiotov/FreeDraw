using FreeDraw.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeDraw.Processors
{
    public class DisplayProcessor
    {
        #region Constructor

        public DisplayProcessor()
        {
        }

        #endregion

        #region Properties

        private List<List<Shape>> undoRedoList = new List<List<Shape>>();
        /// <summary>
        /// Този налудничев списък представлява списък състоящ се от списъци на всички елементи.
        /// Идеята му е да се използва за Undu/ Redo функции...
        /// </summary>	
        public List<List<Shape>> UndoRedoList
        {
            get { return undoRedoList; }
            set { undoRedoList = value; }
        }

        /// <summary>
        /// Списък с всички елементи формиращи изображението.
        /// </summary>
        private List<Shape> shapeList = new List<Shape>();
        public List<Shape> ShapeList
        {
            get { return shapeList; }
            set { shapeList = value; }
        }

        private int offset;
        public int Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        private List<Shape> copyList = new List<Shape>();
        public List<Shape> CopyList
        {
            get { return copyList; }
            set { copyList = value; }
        }

        #endregion

        #region Drawing

        /// <summary>
        /// Прерисува всички елементи в shapeList върху e.Graphics
        /// </summary>
        public void ReDraw(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Draw(e.Graphics);

        }

        /// <summary>
        /// Визуализация.
        /// Обхождане на всички елементи в списъка и извикване на визуализиращия им метод.
        /// </summary>
        /// <param name="grfx">Къде да се извърши визуализацията.</param>
        public virtual void Draw(Graphics grfx)
        {
            foreach (Shape item in ShapeList)
            {
                DrawShape(grfx, item);
            }
        }

        public virtual void Draw(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (Shape item in ShapeList)
            {
                e.Graphics.Transform = item.Transform;
                item.DrawSelf(e.Graphics);

            }
        }

        /// <summary>
        /// Визуализира даден елемент от изображението.
        /// </summary>
        /// <param name="grfx">Къде да се извърши визуализацията.</param>
        /// <param name="item">Елемент за визуализиране.</param>
        public virtual void DrawShape(Graphics grfx, Shape item)
        {
            item.DrawSelf(grfx);
        }



        #endregion

        public static List<Shape> Clone(List<Shape> source)
        {
            if (!typeof(List<Shape>).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(List<Shape>);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (List<Shape>)formatter.Deserialize(stream);
            }
        }

    }
}
