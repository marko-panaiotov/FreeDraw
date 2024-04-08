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

        protected int lastBorderWidth;
        /// <summary>
        /// Запазва се последната зададена дебелина на рамката на дадена фигура.
        /// </summary>
        public int LastBorderWith
        {
            get { return lastBorderWidth; }
            set { lastBorderWidth = value; }
        }

        protected int currentIndex;
        /// <summary>
        /// Отчитаме индекса на актуалния елемент в списъка за Undu.
        /// В процеса на изпълнение тази променлива приема стоиности от 1 до 10.
        /// Защо: Избрал съм потребителя да има право само на 10 връщания.
        /// </summary>
        public int CurrentIndex
        {
            get { return currentIndex; }
            set { currentIndex = value; }
        }

        /// <summary>
        /// Броя на фигурите.
        /// Цел: уникално име.
        /// </summary>
        private int rectCount = 0;
        private int ellipCount = 0;
        private int lineCount = 0;
        private int groupCount = 0;
        private int pentaCount = 0;
        private int polyCount = 0;
        private int triCount = 0;

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

            TriangleShape triangle = new TriangleShape(new RectangleF(x, y, 100, 200));
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

        #region Group and UnGroup
        internal void Group()
        {
            if (selectionList.Count > 0)
            {
                GroupShape group = new GroupShape();
                RectangleF kontur = selectionList[0].Rectangle;
                float minX = kontur.Left;
                float minY = kontur.Top;
                float maxRight = kontur.Right;
                float maxBottom = kontur.Bottom;

                foreach (Shape sh in selectionList)
                {
                    minX = Math.Min(minX, sh.Rectangle.Left);
                    minY = Math.Min(minY, sh.Rectangle.Top); ;
                    maxRight = Math.Max(maxRight, sh.Rectangle.Right); ;
                    maxBottom = Math.Max(maxBottom, sh.Rectangle.Bottom); ;

                    group.SubShape.Add(sh);
                    ShapeList.Remove(sh);
                }

                PointF location = new PointF(minX, minY);
                kontur.Location = location;
                kontur.Width = maxRight - minX;
                kontur.Height = maxBottom - minY;

                group.Rectangle = kontur;
                ShapeList.Add(group);
                selectionList.Clear();
                selectionList.Add(group);

            }
        }

        internal void Ungroup()
        {
            if (selectionList.Count > 0)
            {
                foreach (Shape sh in selectionList)
                {
                    if (sh.GetType() == typeof(GroupShape))
                    {
                        foreach (Shape gsh in ((GroupShape)sh).SubShape) 
                        {
                            ShapeList.Add(gsh);
                        }

                        ((GroupShape)sh).SubShape.Clear();
                        ShapeList.Remove(sh);

                    }
                }

                selectionList.Clear();
            }
        }
        #endregion

        #region Shape Options


        /* /// <summary>
         /// Задаване на прозрачност на запълващия цвят.
         /// </summary>
         public void SetTransperancy(Int32 transperancy)
         {
             if (IsSelectionNotNull())
             {
                 if (GroupSelectionContains(selection))
                 {
                     foreach (Shape sh in GroupSelection)
                     {
                         sh.Transperancy = transperancy;
                     }
                 }
                 else
                     selection.Transperancy = transperancy;
             }
         }

         /// <summary>
         /// Задаване на запълващ цвят.
         /// </summary>
         public void SetFillColor(Color color)
         {
             if (IsSelectionNotNull())
             {
                 if (GroupSelectionContains(selection))
                 {
                     foreach (Shape sh in GroupSelection)
                     {
                         sh.FillColor = color;
                         if (sh.Transperancy == 0)
                             sh.Transperancy = 255;
                     }
                 }
                 else
                 {
                     selection.FillColor = color;
                     if (selection.Transperancy == 0)
                         selection.Transperancy = 255;
                 }
             }
         }

         /// <summary>
         /// Задаване на цвят на линията
         /// </summary>
         public void SetBorderColor(Color color)
         {
             if (IsSelectionNotNull())
             {
                 if (GroupSelectionContains(selection))
                 {
                     foreach (Shape sh in GroupSelection)
                     {
                         sh.BorderColor = color;
                     }
                 }
                 else
                     selection.BorderColor = color;
             }
         }*/

        #endregion Shape Options      

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
                   // ShapeList[i].FillColor = Color.Red;

                    return ShapeList[i];
                }
            }
            return null;
        }

        public override void Draw(Graphics grfx)
        {
            base.Draw(grfx);

            if (selectionList.Count > 0)
            {
                foreach (Shape sh in selectionList)
                {
                    RectangleF counture = sh.Rectangle;
                    PointF location = new PointF(counture.Location.X - 4, counture.Location.Y - 4);
                    counture.Location = location;
                    counture.Width += 8;
                    counture.Height += 8;

                    Pen pen = new Pen(Color.Black, 1);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                    grfx.Transform = sh.Transform;
                    grfx.DrawRectangle(pen, counture.Location.X, counture.Location.Y, counture.Width, counture.Height);
                }
            }


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

        /// <summary>
        /// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
        /// </summary>
        /// <param name="p">Вектор на транслация.</param>
        public void TranslateTo(PointF p)
        {
            if (selectionList.Count>0)
            {
                foreach (Shape item in SelectionList)
                {
                    //item.Location = new PointF(item.Location.X + p.X - lastLocation.X, item.Location.Y + p.Y - lastLocation.Y);
                    PointF offset = new PointF(p.X - lastLocation.X, p.Y - lastLocation.Y);
                    item.Translate(offset);

                }
                lastLocation = p;
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
        /*public void Paste()
        {
            if (Clipboard.ContainsData("FreeDraw"))
            {
                SelectionList.Clear();
                using (MemoryStream memoryStream = Clipboard.GetData("FreeDraw") as MemoryStream)
                {
                    List<Shape> copyList = new List<Shape>();
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    copyList = (List<Shape>)binaryFormatter.Deserialize(memoryStream);

                    if (copyList.Count > 1)
                    {
                        foreach (Shape sh in copyList)
                        {
                           sh.Translate(Offset, Offset);
                           // sh.Name = sh.Name + Convert.ToInt32(Offset);
                            SelectionList.Add(sh);
                            ShapeList.Add(sh);
                            Offset += 10;
                        }
                    }
                    else
                    {
                        copyList.First().Translate(Offset, Offset);
                        //copyList.First().Name = copyList.First().Name + Convert.ToInt32(Offset);
                        ShapeList.Add(copyList.First());
                        Offset += 10;
                    }
                }
            }
        }*/

        /// <summary>
        /// Копиране на избрани примитиви.
        /// </summary>
        public void Copy()
        {
            CopyList.Clear();
            Offset = 10;
            foreach (Shape item in SelectionList)
                CopyList.Add(item);
        }

        public void Paste()
        {
            if (CopyList.Count > 0)
            {
                SelectionList.Clear();
                foreach (Shape item in CopyList)
                {
                    ShapeList.Add(item.Clone(Offset));
                }
                Offset += 10;
            }

        }

        public void Delete()
        {
            if (SelectionList.Count > 0)
                foreach (Shape sh in SelectionList)
                    ShapeList.Remove(sh);
            SelectionList.Clear();
        }



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

        #region Undo/Redo

        /// <summary>
        /// С това ние пълним списъка за Undu/Redo.
        /// </summary>
        public void UpdateUdnoList()
        {
            //UnduRedoList.Insert(CurrentIndex, Clone(ShapeList));
            UndoRedoList.Add(Clone(ShapeList));

            if (UndoRedoList.Count > 10) UndoRedoList.Remove(UndoRedoList.First());

            CurrentIndex = UndoRedoList.Count;
        }

        /// <summary>
        /// Името си казва: Функция за връщане на последното действие.
        /// </summary>
        public void Undo()
        {
            if (UndoRedoList.Count > 0)
            {
                if (CurrentIndex > 1) CurrentIndex--;

                ShapeList.Clear();
                ShapeList.AddRange(UndoRedoList[CurrentIndex - 1]);

                Selection = null;
            }
        }

        /// <summary>
        /// Точно противоположно на Undu.
        /// </summary>
        public void Redo()
        {
            if (CurrentIndex < UndoRedoList.Count)
            {
                ShapeList.Clear();
                ShapeList.AddRange(UndoRedoList[CurrentIndex]);

                if (CurrentIndex < 9) CurrentIndex++;

                Selection = null;
            }
        }

        #endregion Undo/Redo

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

        /* private int CountShapes(Shape item)
         {
             int count = 0;
             Type typeOfShape = item.GetType();
             foreach (Shape rsg in ShapeList)
             {
                 if (ItemTypeGroupShape(rsg))
                 {
                     foreach (Shape sh in ((GroupShape)rsg).subShape)
                     {
                         if (sh.GetType() == typeOfShape)
                             count++;
                     }
                 }
                 if (rsg.GetType() == typeOfShape)
                 {
                     count++;
                 }
             }
             return count;
         }*/

        public bool IsSelectionNotNull()
        {
            if (selection != null)
                return true;
            else
                return false;
        }

        public bool GroupSelectionContains(Shape item)
        {
            if (SelectionList.Contains(item))
                return true;
            else
                return false;
        }

    }


}
