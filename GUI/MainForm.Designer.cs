namespace FreeDraw
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mainMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            New = new ToolStripMenuItem();
            Open = new ToolStripMenuItem();
            Save = new ToolStripMenuItem();
            SaveAs = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            Undo = new ToolStripMenuItem();
            Redo = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            Cut = new ToolStripMenuItem();
            Paste = new ToolStripMenuItem();
            Copy = new ToolStripMenuItem();
            Delete = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            SelectAll = new ToolStripMenuItem();
            imageToolStripMenuItem = new ToolStripMenuItem();
            bringToFrontToolStripMenuItem = new ToolStripMenuItem();
            sendToBackToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            statusBar = new StatusStrip();
            currentStatusLabel = new ToolStripStatusLabel();
            speedMenu = new ToolStrip();
            pickUpSpeedButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            drawDotSpeedButton = new ToolStripButton();
            drawLineSpeedButton = new ToolStripDropDownButton();
            toolStripMenuItem4 = new ToolStripMenuItem();
            drawCircleSpeedButton = new ToolStripSplitButton();
            drawEllipseButton = new ToolStripMenuItem();
            drawRectangleSpeedButton = new ToolStripSplitButton();
            drawRoundedRectangleSpeedButton = new ToolStripMenuItem();
            drawSquareSpeedButton = new ToolStripMenuItem();
            drawTriangleSpeedButton = new ToolStripButton();
            pickColorButton = new ToolStripSplitButton();
            fillingColorPickerButtonToolStripMenuItem = new ToolStripMenuItem();
            BorderColorPickerButton = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            groupButton = new ToolStripButton();
            unGroupButton = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            Stroke = new ToolStripDropDownButton();
            stroke1pt = new ToolStripMenuItem();
            stroke3pt = new ToolStripMenuItem();
            stroke5pt = new ToolStripMenuItem();
            stroke10pt = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            CutButton = new ToolStripButton();
            CopyButton = new ToolStripButton();
            PasteButton = new ToolStripButton();
            DeleteButton = new ToolStripButton();
            Rotation = new ToolStripDropDownButton();
            rotateRight45 = new ToolStripMenuItem();
            rotateRight90 = new ToolStripMenuItem();
            rotateLeft45 = new ToolStripMenuItem();
            rotateLeft90 = new ToolStripMenuItem();
            rotate180 = new ToolStripMenuItem();
            viewPort = new GUI.DoubleBufferedPanel();
            colorPickerDialog = new ColorDialog();
            transperancyTrackBar = new TrackBar();
            label1 = new Label();
            saveAsImage = new ToolStripMenuItem();
            mainMenu.SuspendLayout();
            statusBar.SuspendLayout();
            speedMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)transperancyTrackBar).BeginInit();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, imageToolStripMenuItem, helpToolStripMenuItem });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Padding = new Padding(7, 2, 0, 2);
            mainMenu.Size = new Size(808, 24);
            mainMenu.TabIndex = 1;
            mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { New, Open, Save, SaveAs, saveAsImage, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            fileToolStripMenuItem.Click += fileToolStripMenuItem_Click;
            // 
            // New
            // 
            New.Name = "New";
            New.ShortcutKeyDisplayString = "Ctrl+N";
            New.Size = new Size(180, 22);
            New.Text = "New";
            New.Click += New_Click;
            // 
            // Open
            // 
            Open.Name = "Open";
            Open.ShortcutKeyDisplayString = "Ctrl+O";
            Open.Size = new Size(180, 22);
            Open.Text = "Open...";
            Open.Click += Open_Click;
            // 
            // Save
            // 
            Save.Name = "Save";
            Save.ShortcutKeyDisplayString = "Ctrl+S";
            Save.Size = new Size(180, 22);
            Save.Text = "Save";
            Save.Click += Save_Click;
            // 
            // SaveAs
            // 
            SaveAs.Name = "SaveAs";
            SaveAs.Size = new Size(180, 22);
            SaveAs.Text = "Save As...";
            SaveAs.Click += SaveAs_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItemClick;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Undo, Redo, toolStripSeparator3, Cut, Paste, Copy, Delete, toolStripSeparator4, SelectAll });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // Undo
            // 
            Undo.Name = "Undo";
            Undo.ShortcutKeyDisplayString = "Ctrl+Z";
            Undo.Size = new Size(164, 22);
            Undo.Text = "Undo";
            Undo.Click += Undo_Click;
            // 
            // Redo
            // 
            Redo.Name = "Redo";
            Redo.ShortcutKeyDisplayString = "Ctrl+Y";
            Redo.Size = new Size(164, 22);
            Redo.Text = "Redo";
            Redo.Click += Redo_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(161, 6);
            // 
            // Cut
            // 
            Cut.Name = "Cut";
            Cut.ShortcutKeyDisplayString = "Ctrl+X";
            Cut.Size = new Size(164, 22);
            Cut.Text = "Cut";
            Cut.Click += Cut_Click;
            // 
            // Paste
            // 
            Paste.Name = "Paste";
            Paste.ShortcutKeyDisplayString = "Ctrl+V";
            Paste.Size = new Size(164, 22);
            Paste.Text = "Paste";
            Paste.Click += Paste_Click;
            // 
            // Copy
            // 
            Copy.Name = "Copy";
            Copy.ShortcutKeyDisplayString = "Ctrl+C";
            Copy.Size = new Size(164, 22);
            Copy.Text = "Copy";
            Copy.Click += Copy_Click;
            // 
            // Delete
            // 
            Delete.Name = "Delete";
            Delete.ShortcutKeyDisplayString = "Del";
            Delete.Size = new Size(164, 22);
            Delete.Text = "Delete";
            Delete.Click += Delete_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(161, 6);
            // 
            // SelectAll
            // 
            SelectAll.Name = "SelectAll";
            SelectAll.ShortcutKeyDisplayString = "Ctrl+A";
            SelectAll.Size = new Size(164, 22);
            SelectAll.Text = "Select All";
            SelectAll.Click += SelectAll_Click;
            // 
            // imageToolStripMenuItem
            // 
            imageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { bringToFrontToolStripMenuItem, sendToBackToolStripMenuItem });
            imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            imageToolStripMenuItem.Size = new Size(52, 20);
            imageToolStripMenuItem.Text = "Image";
            // 
            // bringToFrontToolStripMenuItem
            // 
            bringToFrontToolStripMenuItem.Name = "bringToFrontToolStripMenuItem";
            bringToFrontToolStripMenuItem.ShortcutKeyDisplayString = "Shift+F";
            bringToFrontToolStripMenuItem.Size = new Size(193, 22);
            bringToFrontToolStripMenuItem.Text = "Bring To Front";
            bringToFrontToolStripMenuItem.Click += bringToFrontToolStripMenuItem_Click;
            // 
            // sendToBackToolStripMenuItem
            // 
            sendToBackToolStripMenuItem.Name = "sendToBackToolStripMenuItem";
            sendToBackToolStripMenuItem.ShortcutKeyDisplayString = "Shift+B";
            sendToBackToolStripMenuItem.Size = new Size(193, 22);
            sendToBackToolStripMenuItem.Text = "Send To Back";
            sendToBackToolStripMenuItem.Click += sendToBackToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(116, 22);
            aboutToolStripMenuItem.Text = "About...";
            // 
            // statusBar
            // 
            statusBar.Items.AddRange(new ToolStripItem[] { currentStatusLabel });
            statusBar.Location = new Point(0, 466);
            statusBar.Name = "statusBar";
            statusBar.Padding = new Padding(1, 0, 16, 0);
            statusBar.Size = new Size(808, 22);
            statusBar.TabIndex = 2;
            statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            currentStatusLabel.Name = "currentStatusLabel";
            currentStatusLabel.Size = new Size(0, 17);
            currentStatusLabel.TextChanged += currentStatusLabel_textChange;
            // 
            // speedMenu
            // 
            speedMenu.AutoSize = false;
            speedMenu.Items.AddRange(new ToolStripItem[] { pickUpSpeedButton, toolStripSeparator1, drawDotSpeedButton, drawLineSpeedButton, drawCircleSpeedButton, drawRectangleSpeedButton, drawTriangleSpeedButton, pickColorButton, toolStripSeparator5, groupButton, unGroupButton, toolStripSeparator7, Stroke, toolStripSeparator6, CutButton, CopyButton, PasteButton, DeleteButton, Rotation });
            speedMenu.Location = new Point(0, 24);
            speedMenu.Name = "speedMenu";
            speedMenu.Size = new Size(808, 45);
            speedMenu.Stretch = true;
            speedMenu.TabIndex = 3;
            speedMenu.Text = "toolStrip1";
            // 
            // pickUpSpeedButton
            // 
            pickUpSpeedButton.CheckOnClick = true;
            pickUpSpeedButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            pickUpSpeedButton.Image = (Image)resources.GetObject("pickUpSpeedButton.Image");
            pickUpSpeedButton.ImageTransparentColor = Color.Magenta;
            pickUpSpeedButton.Name = "pickUpSpeedButton";
            pickUpSpeedButton.Size = new Size(23, 42);
            pickUpSpeedButton.Text = "toolStripButton1";
            pickUpSpeedButton.Click += pickUpSpeedButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 45);
            // 
            // drawDotSpeedButton
            // 
            drawDotSpeedButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            drawDotSpeedButton.Image = (Image)resources.GetObject("drawDotSpeedButton.Image");
            drawDotSpeedButton.ImageTransparentColor = Color.Magenta;
            drawDotSpeedButton.Name = "drawDotSpeedButton";
            drawDotSpeedButton.Size = new Size(23, 42);
            drawDotSpeedButton.Text = "DrawDotButton";
            drawDotSpeedButton.Click += DrawDotSpeedButton_Click;
            // 
            // drawLineSpeedButton
            // 
            drawLineSpeedButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            drawLineSpeedButton.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem4 });
            drawLineSpeedButton.Image = (Image)resources.GetObject("drawLineSpeedButton.Image");
            drawLineSpeedButton.ImageTransparentColor = Color.Magenta;
            drawLineSpeedButton.Name = "drawLineSpeedButton";
            drawLineSpeedButton.Size = new Size(29, 42);
            drawLineSpeedButton.Text = "DrawLineButton";
            drawLineSpeedButton.Click += DrawLineSpeedButton_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(180, 22);
            toolStripMenuItem4.Text = "toolStripMenuItem4";
            // 
            // drawCircleSpeedButton
            // 
            drawCircleSpeedButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            drawCircleSpeedButton.DropDownItems.AddRange(new ToolStripItem[] { drawEllipseButton });
            drawCircleSpeedButton.Image = (Image)resources.GetObject("drawCircleSpeedButton.Image");
            drawCircleSpeedButton.ImageTransparentColor = Color.Magenta;
            drawCircleSpeedButton.Name = "drawCircleSpeedButton";
            drawCircleSpeedButton.Size = new Size(32, 42);
            drawCircleSpeedButton.Text = "DrawCircleButton";
            drawCircleSpeedButton.ButtonClick += DrawCirclesSpeedButton_Click;
            // 
            // drawEllipseButton
            // 
            drawEllipseButton.Image = (Image)resources.GetObject("drawEllipseButton.Image");
            drawEllipseButton.Name = "drawEllipseButton";
            drawEllipseButton.Size = new Size(134, 22);
            drawEllipseButton.Text = "DrawEllipse";
            drawEllipseButton.Click += DrawEllipseButton_Click;
            // 
            // drawRectangleSpeedButton
            // 
            drawRectangleSpeedButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            drawRectangleSpeedButton.DropDownItems.AddRange(new ToolStripItem[] { drawRoundedRectangleSpeedButton, drawSquareSpeedButton });
            drawRectangleSpeedButton.Image = (Image)resources.GetObject("drawRectangleSpeedButton.Image");
            drawRectangleSpeedButton.ImageTransparentColor = Color.Magenta;
            drawRectangleSpeedButton.Name = "drawRectangleSpeedButton";
            drawRectangleSpeedButton.Size = new Size(32, 42);
            drawRectangleSpeedButton.Text = "DrawRectangleButton";
            drawRectangleSpeedButton.ButtonClick += DrawRectangleSpeedButton_Click;
            // 
            // drawRoundedRectangleSpeedButton
            // 
            drawRoundedRectangleSpeedButton.Image = (Image)resources.GetObject("drawRoundedRectangleSpeedButton.Image");
            drawRoundedRectangleSpeedButton.Name = "drawRoundedRectangleSpeedButton";
            drawRoundedRectangleSpeedButton.Size = new Size(201, 22);
            drawRoundedRectangleSpeedButton.Text = "DrawRoundedRectangle";
            drawRoundedRectangleSpeedButton.Click += DrawRoundedRectangleSpeedButton_Click;
            // 
            // drawSquareSpeedButton
            // 
            drawSquareSpeedButton.Image = (Image)resources.GetObject("drawSquareSpeedButton.Image");
            drawSquareSpeedButton.Name = "drawSquareSpeedButton";
            drawSquareSpeedButton.Size = new Size(201, 22);
            drawSquareSpeedButton.Text = "DrawSquare";
            drawSquareSpeedButton.ToolTipText = "DrawSquare";
            drawSquareSpeedButton.Click += DrawSquareSpeedButton_Click;
            // 
            // drawTriangleSpeedButton
            // 
            drawTriangleSpeedButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            drawTriangleSpeedButton.Image = (Image)resources.GetObject("drawTriangleSpeedButton.Image");
            drawTriangleSpeedButton.ImageTransparentColor = Color.Magenta;
            drawTriangleSpeedButton.Name = "drawTriangleSpeedButton";
            drawTriangleSpeedButton.Size = new Size(23, 42);
            drawTriangleSpeedButton.Text = "DrawTriangleButton";
            drawTriangleSpeedButton.TextAlign = ContentAlignment.MiddleRight;
            drawTriangleSpeedButton.Click += DrawTriangleSpeedButton_Click;
            // 
            // pickColorButton
            // 
            pickColorButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            pickColorButton.DoubleClickEnabled = true;
            pickColorButton.DropDownItems.AddRange(new ToolStripItem[] { fillingColorPickerButtonToolStripMenuItem, BorderColorPickerButton });
            pickColorButton.Image = (Image)resources.GetObject("pickColorButton.Image");
            pickColorButton.ImageTransparentColor = Color.Magenta;
            pickColorButton.Name = "pickColorButton";
            pickColorButton.RightToLeft = RightToLeft.No;
            pickColorButton.Size = new Size(32, 42);
            pickColorButton.Text = "ColorPickerButton";
            // 
            // fillingColorPickerButtonToolStripMenuItem
            // 
            fillingColorPickerButtonToolStripMenuItem.Image = (Image)resources.GetObject("fillingColorPickerButtonToolStripMenuItem.Image");
            fillingColorPickerButtonToolStripMenuItem.Name = "fillingColorPickerButtonToolStripMenuItem";
            fillingColorPickerButtonToolStripMenuItem.Size = new Size(138, 22);
            fillingColorPickerButtonToolStripMenuItem.Text = "FillColor";
            fillingColorPickerButtonToolStripMenuItem.Click += FillColorPickerButtonToolStripMenuItem_Click;
            // 
            // BorderColorPickerButton
            // 
            BorderColorPickerButton.Image = (Image)resources.GetObject("BorderColorPickerButton.Image");
            BorderColorPickerButton.Name = "BorderColorPickerButton";
            BorderColorPickerButton.Size = new Size(138, 22);
            BorderColorPickerButton.Text = "BorderColor";
            BorderColorPickerButton.TextDirection = ToolStripTextDirection.Horizontal;
            BorderColorPickerButton.Click += BorderColorPickerButton_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 45);
            // 
            // groupButton
            // 
            groupButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            groupButton.Image = (Image)resources.GetObject("groupButton.Image");
            groupButton.ImageTransparentColor = Color.Magenta;
            groupButton.Name = "groupButton";
            groupButton.Size = new Size(23, 42);
            groupButton.Text = "GroupButton";
            groupButton.Click += groupButton_Click;
            // 
            // unGroupButton
            // 
            unGroupButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            unGroupButton.Image = (Image)resources.GetObject("unGroupButton.Image");
            unGroupButton.ImageTransparentColor = Color.Magenta;
            unGroupButton.Name = "unGroupButton";
            unGroupButton.Size = new Size(23, 42);
            unGroupButton.Text = "UnGroupButton";
            unGroupButton.TextDirection = ToolStripTextDirection.Horizontal;
            unGroupButton.Click += unGroupButton_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 45);
            // 
            // Stroke
            // 
            Stroke.DisplayStyle = ToolStripItemDisplayStyle.Image;
            Stroke.DropDownItems.AddRange(new ToolStripItem[] { stroke1pt, stroke3pt, stroke5pt, stroke10pt });
            Stroke.Image = (Image)resources.GetObject("Stroke.Image");
            Stroke.ImageTransparentColor = Color.Magenta;
            Stroke.Name = "Stroke";
            Stroke.Size = new Size(29, 42);
            Stroke.Text = "Stroke";
            // 
            // stroke1pt
            // 
            stroke1pt.Image = (Image)resources.GetObject("stroke1pt.Image");
            stroke1pt.Name = "stroke1pt";
            stroke1pt.Size = new Size(135, 22);
            stroke1pt.Text = "Width 1 pt";
            stroke1pt.Click += stroke1pt_Click;
            // 
            // stroke3pt
            // 
            stroke3pt.Image = (Image)resources.GetObject("stroke3pt.Image");
            stroke3pt.Name = "stroke3pt";
            stroke3pt.Size = new Size(135, 22);
            stroke3pt.Text = "Width 3 pt";
            stroke3pt.Click += stroke3pt_Click;
            // 
            // stroke5pt
            // 
            stroke5pt.Image = (Image)resources.GetObject("stroke5pt.Image");
            stroke5pt.Name = "stroke5pt";
            stroke5pt.Size = new Size(135, 22);
            stroke5pt.Text = "Width 5 pt";
            stroke5pt.Click += stroke5pt_Click;
            // 
            // stroke10pt
            // 
            stroke10pt.Image = (Image)resources.GetObject("stroke10pt.Image");
            stroke10pt.Name = "stroke10pt";
            stroke10pt.Size = new Size(135, 22);
            stroke10pt.Text = "Width 10 pt";
            stroke10pt.Click += stroke10pt_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 45);
            // 
            // CutButton
            // 
            CutButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            CutButton.Image = (Image)resources.GetObject("CutButton.Image");
            CutButton.ImageTransparentColor = Color.Magenta;
            CutButton.Name = "CutButton";
            CutButton.Size = new Size(23, 42);
            CutButton.Text = "Cut";
            CutButton.TextDirection = ToolStripTextDirection.Horizontal;
            CutButton.Click += CutButton_Click;
            // 
            // CopyButton
            // 
            CopyButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            CopyButton.Image = (Image)resources.GetObject("CopyButton.Image");
            CopyButton.ImageTransparentColor = Color.Magenta;
            CopyButton.Name = "CopyButton";
            CopyButton.Size = new Size(23, 42);
            CopyButton.Text = "Copy";
            CopyButton.Click += CopyButton_Click;
            // 
            // PasteButton
            // 
            PasteButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            PasteButton.Image = (Image)resources.GetObject("PasteButton.Image");
            PasteButton.ImageTransparentColor = Color.Magenta;
            PasteButton.Name = "PasteButton";
            PasteButton.Size = new Size(23, 42);
            PasteButton.Text = "Paste";
            PasteButton.ToolTipText = "Paste";
            PasteButton.Click += PasteButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            DeleteButton.Image = (Image)resources.GetObject("DeleteButton.Image");
            DeleteButton.ImageTransparentColor = Color.Magenta;
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(23, 42);
            DeleteButton.Text = "Delete";
            DeleteButton.Click += DeleteButton_Click;
            // 
            // Rotation
            // 
            Rotation.DisplayStyle = ToolStripItemDisplayStyle.Image;
            Rotation.DropDownItems.AddRange(new ToolStripItem[] { rotateRight45, rotateRight90, rotateLeft45, rotateLeft90, rotate180 });
            Rotation.Image = (Image)resources.GetObject("Rotation.Image");
            Rotation.ImageTransparentColor = Color.Magenta;
            Rotation.Name = "Rotation";
            Rotation.Size = new Size(29, 42);
            Rotation.Text = "Rotation";
            // 
            // rotateRight45
            // 
            rotateRight45.Name = "rotateRight45";
            rotateRight45.Size = new Size(156, 22);
            rotateRight45.Text = "Rotate right 45°";
            rotateRight45.Click += rotateRight45_Click;
            // 
            // rotateRight90
            // 
            rotateRight90.Name = "rotateRight90";
            rotateRight90.Size = new Size(156, 22);
            rotateRight90.Text = "Rotate right 90°";
            // 
            // rotateLeft45
            // 
            rotateLeft45.Name = "rotateLeft45";
            rotateLeft45.Size = new Size(156, 22);
            rotateLeft45.Text = "Rotate left 45°";
            // 
            // rotateLeft90
            // 
            rotateLeft90.Name = "rotateLeft90";
            rotateLeft90.Size = new Size(156, 22);
            rotateLeft90.Text = "Rotate left 90°";
            // 
            // rotate180
            // 
            rotate180.Name = "rotate180";
            rotate180.Size = new Size(156, 22);
            rotate180.Text = "Rotate 180°";
            // 
            // viewPort
            // 
            viewPort.Dock = DockStyle.Fill;
            viewPort.Location = new Point(0, 69);
            viewPort.Margin = new Padding(5, 3, 5, 3);
            viewPort.Name = "viewPort";
            viewPort.Size = new Size(808, 397);
            viewPort.TabIndex = 4;
            viewPort.Paint += ViewPortPaint;
            viewPort.KeyDown += Key_Down;
            viewPort.KeyUp += Key_Up;
            viewPort.MouseDown += ViewPortMouseDown;
            viewPort.MouseMove += ViewPortMouseMove;
            viewPort.MouseUp += ViewPortMouseUp;
            // 
            // colorPickerDialog
            // 
            colorPickerDialog.FullOpen = true;
            // 
            // transperancyTrackBar
            // 
            transperancyTrackBar.AutoSize = false;
            transperancyTrackBar.Location = new Point(645, 42);
            transperancyTrackBar.Maximum = 255;
            transperancyTrackBar.Name = "transperancyTrackBar";
            transperancyTrackBar.Size = new Size(98, 27);
            transperancyTrackBar.TabIndex = 5;
            transperancyTrackBar.Value = 255;
            transperancyTrackBar.Scroll += transperancyTrackBar_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(657, 24);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 6;
            label1.Text = "Transperancy";
            // 
            // saveAsImage
            // 
            saveAsImage.Name = "saveAsImage";
            saveAsImage.Size = new Size(180, 22);
            saveAsImage.Text = "Save As Image";
            saveAsImage.Click += saveAsImage_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 488);
            Controls.Add(transperancyTrackBar);
            Controls.Add(label1);
            Controls.Add(viewPort);
            Controls.Add(speedMenu);
            Controls.Add(statusBar);
            Controls.Add(mainMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mainMenu;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "FreeDraw";
            WindowState = FormWindowState.Maximized;
            FormClosing += MainForm_Exit;
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            speedMenu.ResumeLayout(false);
            speedMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)transperancyTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
        private FreeDraw.GUI.DoubleBufferedPanel viewPort;
        private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip speedMenu;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.MenuStrip mainMenu;
        private ToolStripButton drawEllipseSpeedButton;
        private ColorDialog colorDialog1;
        private ColorDialog colorPickerDialog;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripButton drawTriangleSpeedButton;
        private ToolStripSplitButton toolStripSplitButton2;
        private ToolStripMenuItem toolStripMenuItem2;
        private BindingSource ellipseShapeBindingSource;
        private ToolStripButton drawDotSpeedButton;
        private ToolStripSplitButton drawRectangleSpeedButton;
        private ToolStripMenuItem drawRoundedRectangleSpeedButton;
        private ToolStripDropDownButton drawLineSpeedButton;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripSplitButton drawCircleSpeedButton;
        private ToolStripMenuItem drawEllipseButton;
        private ToolStripMenuItem drawSquareSpeedButton;
        private ToolStripMenuItem New;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem Open;
        private ToolStripMenuItem Save;
        private ToolStripMenuItem SaveAs;
        private ToolStripMenuItem Undo;
        private ToolStripMenuItem Redo;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem Cut;
        private ToolStripMenuItem Paste;
        private ToolStripMenuItem Copy;
        private ToolStripMenuItem Delete;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem SelectAll;
        private ToolStripButton groupButton;
        private ToolStripButton unGroupButton;
        private ToolStripSplitButton pickColorButton;
        private ToolStripMenuItem BorderColorPickerButton;
        private ToolStripMenuItem fillingColorPickerButtonToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripDropDownButton Stroke;
        private ToolStripMenuItem stroke1pt;
        private ToolStripMenuItem stroke3pt;
        private ToolStripMenuItem stroke5pt;
        private ToolStripMenuItem stroke10pt;
        private TrackBar transperancyTrackBar;
        private Label label1;
        private ToolStripButton CutButton;
        private ToolStripButton CopyButton;
        private ToolStripButton PasteButton;
        private ToolStripButton DeleteButton;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem bringToFrontToolStripMenuItem;
        private ToolStripMenuItem sendToBackToolStripMenuItem;
        private ToolStripDropDownButton Rotation;
        private ToolStripMenuItem rotateRight45;
        private ToolStripMenuItem rotateRight90;
        private ToolStripMenuItem rotateLeft45;
        private ToolStripMenuItem rotateLeft90;
        private ToolStripMenuItem rotate180;
        private ToolStripMenuItem saveAsImage;
    }
}