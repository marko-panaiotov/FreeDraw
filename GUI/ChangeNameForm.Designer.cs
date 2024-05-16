namespace FreeDraw.GUI
{
    partial class ChangeNameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeNameForm));
            RenameButton = new Button();
            CancelRenameButton = new Button();
            warningLabel = new Label();
            maskedTextBox = new MaskedTextBox();
            SuspendLayout();
            // 
            // RenameButton
            // 
            RenameButton.DialogResult = DialogResult.OK;
            RenameButton.Location = new Point(12, 65);
            RenameButton.Name = "RenameButton";
            RenameButton.Size = new Size(67, 22);
            RenameButton.TabIndex = 1;
            RenameButton.Text = "Rename";
            RenameButton.UseVisualStyleBackColor = true;
            RenameButton.Click += RenameButton_Click;
            // 
            // CancelRenameButton
            // 
            CancelRenameButton.Location = new Point(85, 64);
            CancelRenameButton.Name = "CancelRenameButton";
            CancelRenameButton.Size = new Size(67, 23);
            CancelRenameButton.TabIndex = 2;
            CancelRenameButton.Text = "Cancel";
            CancelRenameButton.UseVisualStyleBackColor = true;
            CancelRenameButton.Click += CancelRenameButton_Click;
            // 
            // warningLabel
            // 
            warningLabel.AutoSize = true;
            warningLabel.Location = new Point(12, 9);
            warningLabel.Name = "warningLabel";
            warningLabel.Size = new Size(0, 15);
            warningLabel.TabIndex = 3;
            // 
            // maskedTextBox
            // 
            maskedTextBox.Location = new Point(12, 34);
            maskedTextBox.Name = "maskedTextBox";
            maskedTextBox.Size = new Size(140, 23);
            maskedTextBox.TabIndex = 4;
            // 
            // ChangeNameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(164, 99);
            Controls.Add(maskedTextBox);
            Controls.Add(warningLabel);
            Controls.Add(CancelRenameButton);
            Controls.Add(RenameButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChangeNameForm";
            Load += ChangeNameForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button RenameButton;
        private Button CancelRenameButton;
        private Label warningLabel;
        private MaskedTextBox maskedTextBox;
    }
}