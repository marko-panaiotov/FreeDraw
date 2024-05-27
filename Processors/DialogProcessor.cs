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
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using FreeDraw.Entities;
using System.Drawing.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Forms;

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
        private int ellipseCount = 0;
        private int circleCount = 0;
        private int triCount = 0;
        private int dotCount = 0;
        private int roundedRectCount = 0;
        private int squareCount = 0;
        private int lineCount = 0;
        private int groupCount = 0;

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
            rect.FillColor = System.Drawing.Color.White;

            if (CountShapes(rect) <= rectCount)
            {
                rect.Name = "Rectangle " + (rectCount + 1);
                rectCount++;
            }
            else
            {
                rect.Name = "Rectangle " + CountShapes(rect);
                rectCount = CountShapes(rect);
            }

            ShapeList.Add(rect);
        }

        public void AddRandomEllipse()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            EllipseShape ellipse = new EllipseShape(new Rectangle(x, y, 100, 200));
            ellipse.FillColor = System.Drawing.Color.White;

            if (CountShapes(ellipse) <= ellipseCount)
            {
                ellipse.Name = "Ellipse " + (ellipseCount + 1);
                ellipseCount++;
            }
            else
            {
                ellipse.Name = "Ellipse " + CountShapes(ellipse);
                ellipseCount = CountShapes(ellipse);
            }

            ShapeList.Add(ellipse);
        }

        public void AddRandomCircle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            CircleShape circle = new CircleShape(new Rectangle(x, y, 100, 200));
            circle.FillColor = System.Drawing.Color.White;

            if (CountShapes(circle) <= circleCount)
            {
                circle.Name = "Circle " + (circleCount + 1);
                circleCount++;
            }
            else
            {
                circle.Name = "Circle " + CountShapes(circle);
                circleCount = CountShapes(circle);
            }

            ShapeList.Add(circle);
        }

        public void AddRandomTriangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            TriangleShape triangle = new TriangleShape(new RectangleF(x, y, 100, 200));
            triangle.FillColor = System.Drawing.Color.White;

            if (CountShapes(triangle) <= triCount)
            {
                triangle.Name = "Triangle " + (triCount + 1);
                triCount++;
            }
            else
            {
                triangle.Name = "Triangle " + CountShapes(triangle);
                triCount = CountShapes(triangle);
            }

            ShapeList.Add(triangle);



        }

        public void AddRandomDot()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            DotShape dot = new DotShape(new Rectangle(x, y, 100, 200));
           
            dot.FillColor = System.Drawing.Color.Black;

            if (CountShapes(dot) <= dotCount)
            {
                dot.Name = "Dot " + (dotCount + 1);
                dotCount++;
            }
            else
            {
                dot.Name = "Dot " + CountShapes(dot);
                dotCount = CountShapes(dot);
            }

            ShapeList.Add(dot);
        }

        public void AddRandomRoundedRectangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            RoundedRectangleShape roundedRectangle = new RoundedRectangleShape(new Rectangle(x, y, 100, 200));
            
            roundedRectangle.FillColor = System.Drawing.Color.White;

            if (CountShapes(roundedRectangle) <= roundedRectCount)
            {
                roundedRectangle.Name = "Rounded Rectangle " + (roundedRectCount + 1);
                roundedRectCount++;
            }
            else
            {
                roundedRectangle.Name = "Rounded Rectangle " + CountShapes(roundedRectangle);
                roundedRectCount = CountShapes(roundedRectangle);
            }

            ShapeList.Add(roundedRectangle);
        }

        public void AddRandomSquare()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            SquareShape square = new SquareShape(new Rectangle(x, y, 100, 200));

            square.FillColor = System.Drawing.Color.White;

            if (CountShapes(square) <= squareCount)
            {
                square.Name = "Square" + (squareCount + 1);
                squareCount++;
            }
            else
            {
                square.Name = "Square " + CountShapes(square);
                roundedRectCount = CountShapes(square);
            }

            ShapeList.Add(square);
        }

        public void AddRandomLine()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            LineShape line = new LineShape(new Rectangle(x, y, 100, 200));

            line.FillColor = System.Drawing.Color.White;

            if (CountShapes(line) <= lineCount)
            {
                line.Name = "Line " + (lineCount + 1);
                lineCount++;
            }
            else
            {
                line.Name = "Line " + CountShapes(line);
                lineCount = CountShapes(line);
            }

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
                if (CountShapes(group) <= groupCount)
                {
                    group.Name = "Group " + (groupCount + 1);
                    groupCount++;
                }
                else
                {
                    group.Name = "Group " + CountShapes(group);
                    groupCount = CountShapes(group);
                }


                ShapeList.Add(group);
                selectionList.Clear();
                selectionList.Add(group);

                Selection = group;

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
                foreach (Shape sh in SelectionList)
                {
                    RectangleF counture = sh.Rectangle;
                    PointF location = new PointF(counture.Location.X - 4, counture.Location.Y - 4);
                    counture.Location = location;
                    counture.Width += 8;
                    counture.Height += 8;

                    System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black, 1);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                    grfx.Transform = sh.Transform;
                    grfx.DrawRectangle(pen, counture.Location.X, counture.Location.Y, counture.Width, counture.Height);

                    sh.DrawSelf(grfx);

                }
            }
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
                for (int i = 0; i < SelectionList.Count; i++)
                {
                    if (SelectionList[i] == item)
                    {
                        SelectionList.RemoveAt(i);
                        if (i != 0) i--;
                        SelectionList.Insert(i, item);
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
            UndoRedoList.Add(Clone(SelectionList));

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
                ShapeList.AddRange(UndoRedoList[currentIndex - 1]);

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

        public void Rotate(int angle)
        {
            foreach (Shape sh in SelectionList)
            {
                PointF center = new PointF(sh.Location.X + sh.Width / 2, sh.Location.Y + sh.Height / 2);
                PointF[] points = { center };
                //Selection.Translate(center);
                sh.Rotate(angle, points[0]);
                TranslateTo(center);
               
            }

        }
        
        public void FileDialogFilters(FileDialog fileDialog, string titleName)
        {
            fileDialog.InitialDirectory = @"C:\";
            fileDialog.Title = titleName;
            fileDialog.RestoreDirectory = true;
            if (fileDialog.GetType() == typeof(OpenFileDialog))
            {
                fileDialog.CheckFileExists = true;
            }
            fileDialog.Filter = "FD (.fd)|*.fd";
            fileDialog.DefaultExt = "fd";
            fileDialog.CheckPathExists = true;

            /*ImageFormat format;
            switch (fileDialog.FilterIndex)
            {
                case 1:
                    format = ImageFormat.Png;
                    break;
                case 2:
                    format = ImageFormat.Jpeg;
                    break;
                default:
                    format = ImageFormat.Jpeg;
                    break;
            }
            DoubleBufferedPanel panel = new DoubleBufferedPanel();
            panel.GetImageFromPanel();
            panel.SaveImage(fileDialog, format);*/
        }
        /*public void SaveAsImage()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.ValidateNames = true;
            dlg.Filter = "Png Image (.png)|*.png|JPEG Image (.jpg)|*.jpg";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Зареждане на изображението, което искате да запазите (този код може да бъде заменен със зареждане на вашето изображение)
                //Bitmap bitmap = new Bitmap() ;
                DoubleBufferedPanel panel=new DoubleBufferedPanel();
                panel.GetImageFromPanel();
                // Създаване на кодера за запазване в зависимост от избрания тип на файл
                ImageFormat format;
                switch (dlg.FilterIndex)
                {
                    case 1:
                        format = ImageFormat.Png;
                        break;
                    case 2:
                        format = ImageFormat.Jpeg;
                        break;
                    default:
                        format = ImageFormat.Jpeg;
                        break;
                }

                // Запазване на изображението
               // panel.SaveImage(dlg.FileName, format);
                //tmap.Save(dlg.FileName, format);


            }
        }*/
        public void Expand()
        {
            
                if (SelectionList != null)
                {
                    foreach (Shape sh in SelectionList)
                    {
                        PointF center = new PointF(sh.Location.X + sh.Size.Width / 2, sh.Location.Y + sh.Size.Height / 2);
                        sh.Scale(1.1f, 1.1f, center);
                    }
                }
                else
                {
                    PointF center = new PointF(selection.Location.X + selection.Size.Width / 2, selection.Location.Y + selection.Size.Height / 2);
                    Selection.Scale(1.1f, 1.1f, center);
                }
            

        }
        public void Shrink()
        {
           
                if (SelectionList!=null)
                {
                    foreach (Shape sh in SelectionList)
                    {
                        PointF center = new PointF(sh.Location.X + sh.Size.Width / 2, sh.Location.Y + sh.Size.Height / 2);
                        sh.Scale(0.9f, 0.9f, center);
                    }
                }
                else
                {
                    PointF center = new PointF(selection.Location.X + selection.Size.Width / 2, selection.Location.Y + selection.Size.Height / 2);
                    Selection.Scale(0.9f, 0.9f, center);
                }
            
        }
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

        private int CountShapes(Shape item)
        {
            int count = 0;
            Type typeOfShape = item.GetType();
            foreach (Shape rsg in ShapeList)
            {
                if (ItemTypeGroupShape(rsg))
                {
                    foreach (Shape sh in ((GroupShape)rsg).SubShape)
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
        }

        public bool ItemTypeGroupShape(Shape item)
        {
            if (item.GetType() == typeof(GroupShape))
                return true;
            else
                return false;
        }

        public void ListBoxUpdate(System.Windows.Forms.ListBox listBox)
        {
            listBox.DataSource = null;
            listBox.DisplayMember = "Name";
            listBox.ValueMember = "Name";
            listBox.DataSource = ShapeList;
        }
    }


}
