namespace FreeDraw.GUI
{
    partial class SaveForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveForm));
            OK = new Button();
            Cancel = new Button();
            strLabel = new Label();
            SuspendLayout();
            // 
            // OK
            // 
            OK.DialogResult = DialogResult.OK;
            OK.Location = new Point(147, 63);
            OK.Name = "OK";
            OK.Size = new Size(75, 23);
            OK.TabIndex = 2;
            OK.Text = "Излез";
            OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            Cancel.DialogResult = DialogResult.Cancel;
            Cancel.Location = new Point(12, 63);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(75, 23);
            Cancel.TabIndex = 1;
            Cancel.Text = "Отказ";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // strLabel
            // 
            strLabel.Location = new Point(12, 9);
            strLabel.Name = "strLabel";
            strLabel.Size = new Size(210, 47);
            strLabel.TabIndex = 2;
            strLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SaveForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(234, 114);
            Controls.Add(strLabel);
            Controls.Add(Cancel);
            Controls.Add(OK);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SaveForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FreeDraw";
            Load += SaveForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button OK;
        private Button Cancel;
        private Label strLabel;
    }
}