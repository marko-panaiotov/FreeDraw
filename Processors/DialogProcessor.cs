using FreeDraw.GUI;
using FreeDraw.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;

namespace FreeDraw.Processors
{
    public class DialogProcessor : DisplayProcessor
    {
        #region Constructor

        public DialogProcessor()
        {
        }

        #endregion

        #region Properties

        /* private List<Shape> selection = new List<Shape>();
         public List<Shape> Selection
         {
             get { return selection; }
             set { selection = value; }
         }*/

        protected Shape selection;
        /// <summary>
        /// Shape елемент използвам при селекция.
        /// </summary>
        public Shape Selection
        {
            get { return selection; }
            set { selection = value; }
        }

        protected List<Shape> groupSelection = new List<Shape>();
        /// <summary>
        /// Списък на Shape примитиви за мулти селекция.
        /// </summary>
        public List<Shape> GroupSelection
        {
            get { return groupSelection; }
            set { groupSelection = value; }
        }

        /// <summary>
        /// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
        /// </summary>
        private bool isDragging;
        public bool IsDragging
        {
            get { return isDragging; }
            set { isDragging = value; }
        }

        protected bool isRotating;
        /// <summary>
        /// Дали в момента диалога е в режим на "ротация" на избрания елемент.
        /// </summary>
        public bool IsRotating
        {
            get { return isRotating; }
            set { isRotating = value; }
        }

        protected bool isdrawing;
        /// <summary>
        /// Дали в момента диалога е в режим на "рисуване".
        /// </summary>
        public bool IsDrawing
        {
            get { return isdrawing; }
            set { isdrawing = value; }
        }

        protected bool isResizing;
        /// <summary>
        /// Дали в момента диалога е в режим на "оразмеряване" на избрания елемент.
        /// </summary>
        public bool IsResizing
        {
            get { return isResizing; }
            set { isResizing = value; }
        }

        protected bool controlKey;
        /// <summary>
        /// Дали в момента диалога е в режим на натиснат CTRL-клавиш.
        /// </summary>
        public bool ControlKey
        {
            get { return controlKey; }
            set { controlKey = value; }
        }

        protected bool shiftKey;
        /// <summary>
        /// Дали в момента диалога е в режим на натиснат SHIFT-клавиш.
        /// </summary>
        public bool ShiftKey
        {
            get { return shiftKey; }
            set { shiftKey = value; }
        }

        /// <summary>
        /// Последна позиция на мишката при "влачене".
        /// Използва се за определяне на вектора на транслация.
        /// </summary>
        private PointF lastLocation;
        public PointF LastLocation
        {
            get { return lastLocation; }
            set { lastLocation = value; }
        }

        #endregion

        #region Creating Shapes

        /// <summary>
        /// Добавя примитив - правоъгълник на произволно място върху клиентската област.
        /// </summary>
        public void AddRandomRectangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            RectangleShape rect = new RectangleShape(new Rectangle(x, y, 100, 200));
            rect.FillColor = Color.White;

            ShapeList.Add(rect);
        }

        public void AddRandomEllipse()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            EllipseShape ellipse = new EllipseShape(new Rectangle(x, y, 100, 200));
            ellipse.FillColor = Color.White;

            ShapeList.Add(ellipse);
        }

        public void AddRandomCircle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            CircleShape circle = new CircleShape(new Rectangle(x, y, 100, 200));
            circle.FillColor = Color.White;

            ShapeList.Add(circle);
        }

        public void AddRandomTriangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            TriangleShape triangle = new TriangleShape(new Rectangle(x, y, 100, 200));
            triangle.FillColor = Color.White;

            ShapeList.Add(triangle);
        }

        public void AddRandomDot()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            DotShape dot = new DotShape(new Rectangle(x, y, 100, 200));
           
            dot.FillColor = Color.Black;

            ShapeList.Add(dot);
        }

        public void AddRandomRoundedRectangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            RoundedRectangleShape roundedRectangle = new RoundedRectangleShape(new Rectangle(x, y, 100, 200));
            
            roundedRectangle.FillColor = Color.White;

            ShapeList.Add(roundedRectangle);
        }

        public void AddRandomSquare()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            SquareShape square = new SquareShape(new Rectangle(x, y, 100, 200));

            square.FillColor = Color.White;

            ShapeList.Add(square);
        }

        public void AddRandomLine()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            LineShape line = new LineShape(new Rectangle(x, y, 100, 200));

            line.FillColor = Color.White;

            ShapeList.Add(line);
        }
        #endregion Creating Shapes

        #region Shape Properties
        #endregion Shape Properties  

    
        /// <summary>
        /// Проверява дали дадена точка е в елемента.
        /// Обхожда в ред обратен на визуализацията с цел намиране на
        /// "най-горния" елемент т.е. този който виждаме под мишката.
        /// </summary>
        /// <param name="point">Указана точка</param>
        /// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
        public Shape ContainsPoint(PointF point)
        {
            for (int i = ShapeList.Count - 1; i >= 0; i--)
            {
                if (ShapeList[i].Contains(point))
                {
                    ShapeList[i].FillColor = Color.Red;

                    return ShapeList[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
        /// </summary>
        /// <param name="p">Вектор на транслация.</param>
        public void TranslateTo(PointF p)
        {
            if (groupSelection != null)
            {
                foreach (Shape item in GroupSelection)
                {
                    item.Location = new PointF(item.Location.X + p.X - lastLocation.X, item.Location.Y + p.Y - lastLocation.Y);
                    lastLocation = p;
                }
            }
        }

        public bool ComparePoints(PointF old, PointF current)
        {
            var d = Math.Sqrt(Math.Pow(old.X - current.X, 2) + Math.Pow(old.Y - current.Y, 2));
            if (d < 15) return true;
            else
                return false;
        }

        public List<PointF> GetHandlePoint(RectangleF shape)
        {
            List<PointF> result = new List<PointF>();
            // Горня лява
            result.Add(new PointF(shape.Left, shape.Top));

            //Долна лява
            result.Add(new PointF(shape.Left,
                                shape.Top + shape.Height));

            //Дясна долна
            result.Add(new PointF(shape.Left + shape.Width,
                                shape.Top + shape.Height));

            //Дясна горна
            result.Add(new PointF(shape.Left + shape.Width,
                                shape.Top));


            return result;
        }

        public bool GroupSelectionContains(Shape item)
        {
            if (groupSelection.Contains(item))
                return true;
            else
                return false;
        }
    }
}
