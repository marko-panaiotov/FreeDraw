using FreeDraw.GUI;
using FreeDraw.Model;
using FreeDraw.Processors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FreeDraw
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
        /// </summary>
        private DialogProcessor dialogProcessor = new DialogProcessor();
        private Point startPoint;
        private Point endPoint;
        private bool isDoubleClicking;
        private const int DoubleClickInterval = 300; // Интервал на двойно натискане в милисекунди
        private DateTime lastClickTime = DateTime.MinValue;
        private bool singleClickPending = false;

        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            dialogProcessor.UpdateUdnoList();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        #region Variable


        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private ColorDialog colorDialog = new ColorDialog();
        private List<PointF> polyPoints = new List<PointF>();
        private int dragHandle = 0;
        private PointF dragPoint;

        #endregion Variable

        #region Key Events
        void Key_Down(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            #region Control Key

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
                        Copy.PerformClick();
                        break;
                    case Keys.X:
                        Cut.PerformClick();
                        break;
                    case Keys.V:
                        Paste.PerformClick();
                        break;
                    case Keys.A:
                        SelectAll.PerformClick();
                        viewPort.Invalidate();
                        break;
                    case Keys.G:
                        if (e.Alt)
                        {
                            // Break.PerformClick();
                            break;
                        }
                        else
                        {
                            // GroupSelection.PerformClick();
                            break;
                        }
                    case Keys.N:
                        New.PerformClick();
                        break;
                    case Keys.S:
                        Save.PerformClick();
                        break;
                    case Keys.O:
                        Open.PerformClick();
                        break;
                    case Keys.Z:
                        Undo.PerformClick();
                        break;

                    default:
                        dialogProcessor.ControlKey = true;
                        break;
                }
                viewPort.Invalidate();
            }

            #endregion Control Key

            #region Shift Key

            if (e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.F:
                        // bringToFrontToolStripMenuItem.PerformClick();
                        break;
                    case Keys.B:
                        //sendToBackToolStripMenuItem.PerformClick();
                        break;
                    case Keys.R:
                        // ChangeName.PerformClick();
                        break;
                    default:
                        if (dialogProcessor.IsDrawing)
                        {
                            statusBar.Items[1].Text = "Чертаене на правилна фигура";
                            dialogProcessor.ShiftKey = true;
                        }
                        break;
                }
                viewPort.Invalidate();
            }

            #endregion Shift Key

            #region Delete Key
            if (e.KeyCode == Keys.Delete)
            {
                Delete.PerformClick();
            }
            #endregion Delete Key

            #region Esc Key
            if (e.KeyCode == Keys.Escape)
            {
                /*if (DrawPolygon.Checked && polyPoints.Count > 0)
                {
                    polyPoints.Clear();
                }
                else
                {
                    DrawEllipse.Checked = false;
                    DrawRectangle.Checked = false;
                    DrawLine.Checked = false;
                    DrawPolygon.Checked = false;
                    DrawTriangle.Checked = false;
                    DrawPentagon.Checked = false;
                    dialogProcessor.IsDrawing = false;
                    pickUpSpeedButton.Checked = true;
                }
                dialogProcessor.GroupSelection.Clear();*/
                viewPort.Invalidate();
            }
            #endregion Esc Key

            #region Just Keys

            /* if (e.KeyCode == Keys.Oemplus)
             {
                 Expand.PerformClick();
             }

             if (e.KeyCode == Keys.OemMinus)
             {
                 Shrink.PerformClick();
             }

             if (e.Alt && e.KeyCode == Keys.F4)
             {
                 Exit.PerformClick();
             }*/

            #endregion Just Keys
        }

        void Key_Up(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (dialogProcessor.ControlKey)
            {
                dialogProcessor.ControlKey = false;
            }
            if (dialogProcessor.ShiftKey)
            {
                dialogProcessor.ShiftKey = false;
                statusBar.Items[1].Text = "Чертаене на неправилна фигура";
            }
        }

        #endregion Key Events



        private void MainForm_Exit(object sender, FormClosingEventArgs e)
        {
            if (dialogProcessor.ShapeList.Count > 0)
            {
                if (statusBar.Items[0].Text != "Запазване във " + saveFileDialog.FileName
                    && statusBar.Items[0].Text != "Запазване във " + openFileDialog.FileName)
                {
                    SaveForm decisiondialog = new SaveForm("Не запазихте работата си. \n Наистина ли желаете да излезете?");

                    if (decisiondialog.ShowDialog() == DialogResult.OK)
                    {
                        e.Cancel = false;
                    }
                    else
                        e.Cancel = true;
                }

            }
        }

        /// <summary>
        /// Изход от програмата. Затваря главната форма, а с това и програмата.
        /// </summary>
        void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
        /// </summary>
        void ViewPortPaint(object sender, PaintEventArgs e)
        {
            dialogProcessor.ReDraw(sender, e);
        }

        /// <summary>
        /// Бутон, който поставя на произволно място правоъгълник със зададените размери.
        /// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
        /// </summary>
        /// 

        private void DrawDotSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomDot();

            shapeBox.Items.Add(dialogProcessor.ShapeList.Last().Name);
            statusBar.Items[0].Text = "Последно действие: Рисуване на точка";

            viewPort.Invalidate();
        }

        private void DrawCirclesSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomCircle();

            shapeBox.Items.Add(dialogProcessor.ShapeList.Last().Name);
            statusBar.Items[0].Text = "Последно действие: Рисуване на кръг";

            viewPort.Invalidate();
        }
        private void DrawEllipseButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomEllipse();

            shapeBox.Items.Add(dialogProcessor.ShapeList.Last().Name);
            statusBar.Items[0].Text = "Последно действие: Рисуване на елипса";

            viewPort.Invalidate();
        }

        private void DrawRectangleSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomRectangle();

            shapeBox.Items.Add(dialogProcessor.ShapeList.Last().Name);
            statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";

            viewPort.Invalidate();
        }

        private void DrawRoundedRectangleSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomRoundedRectangle();

            shapeBox.Items.Add(dialogProcessor.ShapeList.Last().Name);
            statusBar.Items[0].Text = "Последно действие: Рисуване на заоблен правоъгълник";

            viewPort.Invalidate();
        }

        private void DrawSquareSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomSquare();

            shapeBox.Items.Add(dialogProcessor.ShapeList.Last().Name);
            statusBar.Items[0].Text = "Последно действие: Рисуване на квадрат";

            viewPort.Invalidate();
        }

        private void DrawTriangleSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomTriangle();

            shapeBox.Items.Add(dialogProcessor.ShapeList.Last().Name);
            statusBar.Items[0].Text = "Последно действие: Рисуване на триъгълник";

            viewPort.Invalidate();
        }

        private void DrawLineSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomLine();

            shapeBox.Items.Add(dialogProcessor.ShapeList.Last().Name);
            statusBar.Items[0].Text = "Последно действие: Рисуване на права";

            viewPort.Invalidate();
        }

        /// <summary>
        /// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
        /// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
        /// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
        /// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
        /// </summary>
        void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (pickUpSpeedButton.Checked)
            {
                Shape sel = dialogProcessor.ContainsPoint(e.Location);
                if (sel != null)
                {
                    if (dialogProcessor.SelectionList.Contains(sel))
                    {

                        dialogProcessor.SelectionList.Remove(sel);
                        statusBar.Items[0].Text = "Последно действие: Премахване на примитив";
                        dialogProcessor.IsDragging = true;
                        dialogProcessor.LastLocation = e.Location;
                    }
                    else
                    {
                        dialogProcessor.SelectionList.Add(sel);
                        statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
                        dialogProcessor.IsDragging = true;
                        dialogProcessor.LastLocation = e.Location;
                    }
                    viewPort.Invalidate();
                }


            }
        }

        /// <summary>
        /// Прихващане на преместването на мишката.
        /// Ако сме в режм на "влачене", то избрания елемент се транслира.
        /// </summary>
        void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (dialogProcessor.IsDragging)
            {
                if (dialogProcessor.SelectionList != null) statusBar.Items[0].Text = "Последно действие: Влачене";
                dialogProcessor.TranslateTo(e.Location);
                viewPort.Invalidate();
            }
        }
        /// <summary>
        /// Прихващане на отпускането на бутона на мишката.
        /// Излизаме от режим "влачене".
        /// </summary>
        void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dialogProcessor.IsDragging = false;
        }

        void ViewPortMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            #region Expand and Shrink

            if (dialogProcessor.SelectionList != null)
            {
                if (e.Delta > 0)
                {
                    dialogProcessor.Expand();
                }
                else
                    dialogProcessor.Shrink();
                viewPort.Invalidate();
            }

            #endregion Expand and Shrink
        }

        private void FillColorPickerButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorPickerDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (Shape item in dialogProcessor.SelectionList)
                {
                    item.FillColor = colorPickerDialog.Color;
                    viewPort.Invalidate();
                }
            }
        }

        private void BorderColorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorPickerDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (Shape item in dialogProcessor.SelectionList)
                {
                    item.BorderColor = colorPickerDialog.Color;
                    viewPort.Invalidate();
                }
            }
        }

        private void pickUpSpeedButton_Click(object sender, EventArgs e)
        {
            pickUpSpeedButton.Checked = true;
            dialogProcessor.IsDrawing = false;
            // polyPoints.Clear();
            viewPort.Invalidate();
        }

        #region File Menu

        private void New_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.ShapeList.Count > 0)
            {
                if (statusBar.Items[0].Text != "Запазване във " + saveFileDialog.FileName
                    && statusBar.Items[0].Text != "Запазване във " + openFileDialog.FileName)
                {
                    SaveForm decisiondialog = new SaveForm("Вие не запазихте промените. \n Желаете ли да продължите?");
                    if (decisiondialog.ShowDialog() == DialogResult.OK)
                    {
                        dialogProcessor.New();
                        openFileDialog.FileName = null;
                        saveFileDialog.FileName = null;
                        //dialogProcessor.ComboboxUpdate(comboBox1);

                        viewPort.Invalidate();
                    }
                    else
                        return;
                }
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Отваряне на... ";

            dialogProcessor.FileDialogFilters(openFileDialog, "Open");
            New.PerformClick();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.Open(openFileDialog.FileName);

                dialogProcessor.ControlKey = false;

                //dialogProcessor.ComboboxUpdate(comboBox1);
                //comboBox1.SelectedItem = dialogProcessor.ShapeList.Last();
            }

            statusBar.Items[0].Text = "Отваряне на " + openFileDialog.FileName;
            pickUpSpeedButton.Checked = true;
            viewPort.Invalidate();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            dialogProcessor.FileDialogFilters(saveFileDialog, "Save");

            if (openFileDialog.FileName.Length != 0)
            {
                dialogProcessor.Save(openFileDialog.FileName);
                statusBar.Items[1].Text = "Запазване във " + openFileDialog.FileName;
            }
            else if (saveFileDialog.FileName.Length != 0)
            {
                dialogProcessor.Save(saveFileDialog.FileName);
                statusBar.Items[1].Text = "Запазване във " + saveFileDialog.FileName;
            }
            else
                SaveAs.PerformClick();

            pickUpSpeedButton.Checked = true;
            viewPort.Invalidate();
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Запазване във... ";

            dialogProcessor.FileDialogFilters(saveFileDialog, "Save");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.SaveAs(saveFileDialog.FileName);
            }
            pickUpSpeedButton.Checked = true;
            statusBar.Items[0].Text = "Запазване във " + saveFileDialog.FileName;
            viewPort.Invalidate();
        }
        #endregion File Menu

        private void groupButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.Group();
            statusBar.Items[0].Text = "Групиране.";
            viewPort.Invalidate();
        }

        private void unGroupButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.Ungroup();
            statusBar.Items[0].Text = "Разгрупиране.";
            viewPort.Invalidate();
        }

        private void fillingColorPickerButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorPickerDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (Shape item in dialogProcessor.SelectionList)
                {
                    item.FillColor = colorPickerDialog.Color;
                    viewPort.Invalidate();
                }
            }
        }

        private void stroke1pt_Click(object sender, EventArgs e)
        {
            foreach (Shape item in dialogProcessor.SelectionList)
            {
                item.BorderWidth = 1;
                statusBar.Items[0].Text = "Дебелина на рамката 1 pt.";
                dialogProcessor.LastBorderWith = 1;
                viewPort.Invalidate();
            }

        }

        private void stroke3pt_Click(object sender, EventArgs e)
        {
            foreach (Shape item in dialogProcessor.SelectionList)
            {
                item.BorderWidth = 3;
                statusBar.Items[0].Text = "Дебелина на рамката 3 pt.";
                dialogProcessor.LastBorderWith = 3;
                viewPort.Invalidate();
            }
        }

        private void stroke5pt_Click(object sender, EventArgs e)
        {
            foreach (Shape item in dialogProcessor.SelectionList)
            {
                item.BorderWidth = 5;
                statusBar.Items[0].Text = "Дебелина на рамката 5 pt.";
                dialogProcessor.LastBorderWith = 5;
                viewPort.Invalidate();
            }
        }

        private void stroke10pt_Click(object sender, EventArgs e)
        {
            foreach (Shape item in dialogProcessor.SelectionList)
            {
                item.BorderWidth = 10;
                statusBar.Items[0].Text = "Дебелина на рамката 10 pt.";
                dialogProcessor.LastBorderWith = 10;
                viewPort.Invalidate();
            }
        }

        private void transperancyTrackBar_Scroll(object sender, EventArgs e)
        {

            foreach (Shape item in dialogProcessor.SelectionList)
            {

                item.FillColor = Color.FromArgb(transperancyTrackBar.Value, item.FillColor);
                statusBar.Items[0].Text = "Промяна на прозрачността...";
                item.Transperancy = transperancyTrackBar.Value;
                viewPort.Invalidate();

            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CutButton_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Изрязване...";
            dialogProcessor.Copy();
            dialogProcessor.Delete();
            dialogProcessor.SelectionList.Clear();

            viewPort.Invalidate();
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Изрязване...";
            dialogProcessor.Copy();
            dialogProcessor.Delete();
            dialogProcessor.SelectionList.Clear();

            viewPort.Invalidate();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Копиране на селекция";
            dialogProcessor.Copy();
            //viewPort.Invalidate();
        }
        private void Copy_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Копиране на селекция";
            dialogProcessor.Copy();
        }

        private void PasteButton_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Draw: Поставяне...";
            dialogProcessor.Paste();

            viewPort.Invalidate();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Draw: Поставяне...";
            dialogProcessor.Paste();

            viewPort.Invalidate();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Изтриване...";
            dialogProcessor.Delete();
            viewPort.Invalidate();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Изтриване...";
            dialogProcessor.Delete();
            viewPort.Invalidate();
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Масова селекция";
            dialogProcessor.SelectAll();
            viewPort.Invalidate();
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            dialogProcessor.Undo();
            //dialogProcessor.ComboboxUpdate(comboBox1);
            viewPort.Invalidate();
            if (dialogProcessor.UndoRedoList.Count < 1)

                // Redo.Enabled = true;

                viewPort.Invalidate();
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            dialogProcessor.Redo();
            viewPort.Invalidate();
            // dialogProcessor.ComboboxUpdate(comboBox1);
            if (dialogProcessor.CurrentIndex > 9)

                viewPort.Invalidate();
        }

        void currentStatusLabel_textChange(object sender, EventArgs e)
        {
            foreach (string str in IgnoreString())
            {
                if (statusBar.Items[0].Text == str)
                {
                    if (dialogProcessor.UndoRedoList.Count > dialogProcessor.CurrentIndex)
                    {
                        dialogProcessor.UndoRedoList.RemoveRange(dialogProcessor.CurrentIndex,
                            dialogProcessor.UndoRedoList.Count - dialogProcessor.CurrentIndex);

                    }

                    dialogProcessor.UpdateUdnoList();
                    viewPort.Invalidate();
                }
            }
        }

        private List<string> IgnoreString()
        {
            List<string> ignore = new List<string>();

            //Цялата тази дивотия е с цел да определяме при кои събития можем да изпълняваме Undu/Redo.

            ignore.Add("Последно действие: Рисуване на правоъгълник");
            ignore.Add("Изчертана елипса");
            ignore.Add("Изчертана линия");
            ignore.Add("Изчертан пентагон");
            ignore.Add("Изчертан триъгълник");
            ignore.Add("Изчетан полигон");
            ignore.Add("Създаване на група.");
            ignore.Add("Разгрупиране.");
            ignore.Add("Поставяне на селекция");
            ignore.Add("Оразмеряването приключено");
            ignore.Add("Влачене приключено");
            ignore.Add("Ротацията приключена");
            ignore.Add("Избран цвят: " + colorDialog.Color.Name);
            ignore.Add("Изрязване на селекция");
            ignore.Add("Изтриване на фигура.");
            ignore.Add("Преместване на фигурата една позиция напред.");
            ignore.Add("Дебелина на рамката 1 pt.");
            ignore.Add("Дебелина на рамката 3 pt.");
            ignore.Add("Дебелина на рамката 5 pt.");
            ignore.Add("Дебелина на рамката 10 pt.");
            ignore.Add("Завъртане на дясно 90 градуса.");
            ignore.Add("Завъртане на ляво 270 градуса.");
            ignore.Add("Завъртане 180 градуса.");
            ignore.Add("Завъртане на дясно 45 градуса.");
            ignore.Add("Завъртане на дясно 225 градуса.");
            ignore.Add("Обектът е разширен");
            ignore.Add("Обектът е свит");
            ignore.Add("Фигурата е завъртяна");
            ignore.Add("Промяна на прозрачността...");
            ignore.Add("Прозрачността променена");

            return ignore;
        }

        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogProcessor.BringToFront(dialogProcessor.Selection);
            statusBar.Items[0].Text = "Преместване на фигурата една позиция напред.";
            viewPort.Invalidate();
        }

        private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogProcessor.SendToBack(dialogProcessor.Selection);
            statusBar.Items[0].Text = "Преместване на фигурата една позиция назад.";
            viewPort.Invalidate();
        }

        private void rotateRight45_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Завъртане...";
            dialogProcessor.Rotate(45);
            statusBar.Items[0].Text = "Завъртане на дясно 45 градуса.";
            viewPort.Invalidate();
        }

        private void rotateRight90_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Завъртане...";
            dialogProcessor.Rotate(90);
            statusBar.Items[0].Text = "Завъртане на дясно 90 градуса.";
            viewPort.Invalidate();
        }

        private void rotateLeft45_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Завъртане...";
            dialogProcessor.Rotate(-45);
            statusBar.Items[0].Text = "Завъртане на ляво 45 градуса.";
            viewPort.Invalidate();
        }

        private void rotateLeft90_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Завъртане...";
            dialogProcessor.Rotate(-90);
            statusBar.Items[0].Text = "Завъртане на ляво 90 градуса.";
            viewPort.Invalidate();
        }

        private void rotate180_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Завъртане...";
            dialogProcessor.Rotate(180);
            statusBar.Items[0].Text = "Завъртане на 180 градуса.";
            viewPort.Invalidate();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsImage_Click(object sender, EventArgs e)
        {
            /*statusBar.Items[0].Text = "Запазване във... ";

            dialogProcessor.FileDialogFilters(saveFileDialog, "Save");
            //.SaveAsImage();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.SaveAsImage();
            }
            pickUpSpeedButton.Checked = true;
            statusBar.Items[0].Text = "Запазване във " + saveFileDialog.FileName;
            viewPort.Invalidate();*/
        }
        #region Scaling
        private void ExpandButton_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Разширяване...";
            dialogProcessor.Expand();
            statusBar.Items[0].Text = "Обектът е разширен";
            viewPort.Invalidate();
        }

        private void ShrinkButton_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Свиване...";
            dialogProcessor.Shrink();
            statusBar.Items[0].Text = "Обектът е свит";
            viewPort.Invalidate();
        }
        #endregion Scaling

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void shapeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((System.String)shapeBox.SelectedValue))
            {
                var str = shapeBox.SelectedValue;

                var res = from s in dialogProcessor.ShapeList
                          where s.Name == (System.String)str
                          select s;

                if (res.Count() > 0)
                {
                    dialogProcessor.Selection = res.First();
                    viewPort.Invalidate();
                }
            }
            statusBar.Items[0].Text = "Draw: Селектиране на " + shapeBox.SelectedValue;
        }

        private void viewPort_Load(object sender, EventArgs e)
        {

        }
    }
}

