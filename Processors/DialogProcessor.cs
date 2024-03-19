using FreeDraw.GUI;
using FreeDraw.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

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

        protected List<Shape> selectionList = new List<Shape>();
        /// <summary>
        /// Списък на Shape примитиви за мулти селекция.
        /// </summary>
        public List<Shape> SelectionList
        {
            get { return selectionList; }
            set { selectionList = value; }
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
            if (selectionList != null)
            {
                foreach (Shape item in SelectionList)
                {
                    item.Location = new PointF(item.Location.X + p.X - lastLocation.X, item.Location.Y + p.Y - lastLocation.Y);
                    lastLocation = p;
                }
            }
        }

        #region Basic Operations

        /// <summary>
        /// Изчиства екрана, списъка със фигури, селекцията и прочие!
        /// </summary>
        public void New()
        {
            Selection = null;
            ShapeList.Clear();
            SelectionList.Clear();
        }

        /// <summary>
        /// Операция за запазване във файл без диалог за избиране на директория.
        /// </summary>
        public void Save(string fileName)
        {
            using (FileStream filestream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter binaryFormater = new BinaryFormatter();
                binaryFormater.Serialize(filestream, ShapeList);
            }
        }
        /// <summary>
        /// Операция за запазване във файл чрез диалог за избиране на директория.
        /// </summary>
        public void SaveAs(string fileName)
        {
            using (FileStream filestream = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter binaryFormater = new BinaryFormatter();
                binaryFormater.Serialize(filestream, ShapeList);
            }
        }

        /// <summary>
        /// Операция за отваряне от файл.
        /// </summary>
        public void Open(string fileName)
        {
            using (FileStream filestream = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter binaryFormater = new BinaryFormatter();
                ShapeList = (List<Shape>)binaryFormater.Deserialize(filestream);
            }
        }

        /// <summary>
        /// Поставяне копирани или изрязани примитиви.
        /// </summary>
       /* public void Paste()
        {
            if (Clipboard.ContainsData("Draw"))
            {
                SelectionList.Clear();
                using (MemoryStream memoryStream = Clipboard.GetData("Draw") as MemoryStream)
                {
                    List<Shape> copyList = new List<Shape>();
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    copyList = (List<Shape>)binaryFormatter.Deserialize(memoryStream);

                    if (copyList.Count > 1)
                    {
                        foreach (Shape sh in copyList)
                        {
                            sh.Translate(Offset, Offset);
                            sh.Name = sh.Name + Convert.ToInt32(Offset);
                            SelectionList.Add(sh);
                            ShapeList.Add(sh);
                            Offset += 10;
                        }
                    }
                    else
                    {
                        copyList.First().Translate(Offset, Offset);
                        copyList.First().Name = copyList.First().Name + Convert.ToInt32(Offset);
                        ShapeList.Add(copyList.First());
                        Offset += 10;
                    }
                }
            }
        }

        /// <summary>
        /// Копиране на избрани примитиви.
        /// </summary>
        public void Copy()
        {
            if (selection != null)
            {
                Offset = 10;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    if (GroupSelectionContains(Selection))
                    {
                        binaryFormatter.Serialize(memoryStream, SelectionList);
                    }
                    else
                    {
                        GroupSelection.Add(Selection);
                        binaryFormatter.Serialize(memoryStream, GroupSelection);
                    }
                    Clipboard.SetData("Draw", memoryStream);
                }
            }
        }*/

        /// <summary>
        /// Преместване на избран примитив на една позиция напред в списъка с примитиви.
        /// </summary>
        public void BringToFront(Shape item)
        {
            if (selection!=null)
            {
                for (int i = 0; i < ShapeList.Count; i++)
                {
                    if (ShapeList[i] == item)
                    {
                        ShapeList.RemoveAt(i);
                        if (i != ShapeList.Count) i++;
                        ShapeList.Insert(i, item);
                    }
                }
                Selection = item;
            }
        }

        /// <summary>
        /// Преместване на избран примитив на една позиция назад в списъка с примитиви.
        /// </summary>
        public void SendToBack(Shape item)
        {
            if (selection!=null)
            {
                for (int i = 0; i < ShapeList.Count; i++)
                {
                    if (ShapeList[i] == item)
                    {
                        ShapeList.RemoveAt(i);
                        if (i != 0) i--;
                        ShapeList.Insert(i, item);
                    }
                }
                Selection = item;
            }
        }

        /// <summary>
        /// Изтриване на селектиран примитив.
        /// </summary>
   

        /// <summary>
        /// Мултиселекция на всички съществуващи примитиви.
        /// </summary>
        public void SelectAll()
        {
            if (ShapeList.Count > 0)
            {
                SelectionList.Clear();
                SelectionList.AddRange(ShapeList);
                Selection = SelectionList.Last();
            }
        }

        #endregion Basic Operations


        public void FileDialogFilters(FileDialog fileDialog, string titleName)
        {
            fileDialog.InitialDirectory = @"C:\";
            fileDialog.Title = titleName;
            fileDialog.RestoreDirectory = true;
            if (fileDialog.GetType() == typeof(OpenFileDialog))
            {
                fileDialog.CheckFileExists = true;
            }
            fileDialog.Filter = "CK (.ck)|*.ck";
            fileDialog.DefaultExt = "ck";
            fileDialog.CheckPathExists = true;
        }

    }


}
