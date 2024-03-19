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
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            imageToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            statusBar = new StatusStrip();
            currentStatusLabel = new ToolStripStatusLabel();
            speedMenu = new ToolStrip();
            drawDotSpeedButton = new ToolStripButton();
            drawLineSpeedButton = new ToolStripDropDownButton();
            toolStripMenuItem4 = new ToolStripMenuItem();
            drawCircleSpeedButton = new ToolStripSplitButton();
            drawEllipseButton = new ToolStripMenuItem();
            drawRectangleSpeedButton = new ToolStripSplitButton();
            drawRoundedRectangleSpeedButton = new ToolStripMenuItem();
            drawSquareSpeedButton = new ToolStripMenuItem();
            drawTriangleSpeedButton = new ToolStripButton();
            pickColorButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            pickUpSpeedButton = new ToolStripButton();
            viewPort = new GUI.DoubleBufferedPanel();
            colorPickerDialog = new ColorDialog();
            mainMenu.SuspendLayout();
            statusBar.SuspendLayout();
            speedMenu.SuspendLayout();
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
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(93, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItemClick;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // imageToolStripMenuItem
            // 
            imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            imageToolStripMenuItem.Size = new Size(52, 20);
            imageToolStripMenuItem.Text = "Image";
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
            // 
            // speedMenu
            // 
            speedMenu.Items.AddRange(new ToolStripItem[] { drawDotSpeedButton, drawLineSpeedButton, drawCircleSpeedButton, drawRectangleSpeedButton, drawTriangleSpeedButton, pickColorButton, toolStripSeparator1, pickUpSpeedButton });
            speedMenu.Location = new Point(0, 24);
            speedMenu.Name = "speedMenu";
            speedMenu.Size = new Size(808, 25);
            speedMenu.Stretch = true;
            speedMenu.TabIndex = 3;
            speedMenu.Text = "toolStrip1";
            // 
            // drawDotSpeedButton
            // 
            drawDotSpeedButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            drawDotSpeedButton.Image = (Image)resources.GetObject("drawDotSpeedButton.Image");
            drawDotSpeedButton.ImageTransparentColor = Color.Magenta;
            drawDotSpeedButton.Name = "drawDotSpeedButton";
            drawDotSpeedButton.Size = new Size(23, 22);
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
            drawLineSpeedButton.Size = new Size(29, 22);
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
            drawCircleSpeedButton.Size = new Size(32, 22);
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
            drawRectangleSpeedButton.Size = new Size(32, 22);
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
            drawTriangleSpeedButton.Size = new Size(23, 22);
            drawTriangleSpeedButton.Text = "DrawTriangleButton";
            drawTriangleSpeedButton.TextAlign = ContentAlignment.MiddleRight;
            drawTriangleSpeedButton.Click += DrawTriangleSpeedButton_Click;
            // 
            // pickColorButton
            // 
            pickColorButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            pickColorButton.Image = (Image)resources.GetObject("pickColorButton.Image");
            pickColorButton.ImageTransparentColor = Color.Magenta;
            pickColorButton.Name = "pickColorButton";
            pickColorButton.RightToLeft = RightToLeft.No;
            pickColorButton.Size = new Size(23, 22);
            pickColorButton.Text = "ColorPickerButton";
            pickColorButton.Click += PickColorButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // pickUpSpeedButton
            // 
            pickUpSpeedButton.CheckOnClick = true;
            pickUpSpeedButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            pickUpSpeedButton.Image = (Image)resources.GetObject("pickUpSpeedButton.Image");
            pickUpSpeedButton.ImageTransparentColor = Color.Magenta;
            pickUpSpeedButton.Name = "pickUpSpeedButton";
            pickUpSpeedButton.Size = new Size(23, 22);
            pickUpSpeedButton.Text = "toolStripButton1";
            pickUpSpeedButton.Click += pickUpSpeedButton_Click;
            // 
            // viewPort
            // 
            viewPort.Dock = DockStyle.Fill;
            viewPort.Location = new Point(0, 49);
            viewPort.Margin = new Padding(5, 3, 5, 3);
            viewPort.Name = "viewPort";
            viewPort.Size = new Size(808, 417);
            viewPort.TabIndex = 4;
            viewPort.Paint += ViewPortPaint;
            viewPort.MouseDown += ViewPortMouseDown;
            viewPort.MouseMove += ViewPortMouseMove;
            viewPort.MouseUp += ViewPortMouseUp;
            // 
            // colorPickerDialog
            // 
            colorPickerDialog.FullOpen = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 488);
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
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            speedMenu.ResumeLayout(false);
            speedMenu.PerformLayout();
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
        private ToolStripButton pickColorButton;
        private ColorDialog colorDialog1;
        private ColorDialog colorPickerDialog;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripButton drawTriangleSpeedButton;
        private ToolStripMenuItem toolStripMenuItem1;
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
    }
}