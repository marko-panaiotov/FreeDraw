using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeDraw.GUI
{
    public partial class ChangeNameForm : Form
    {
        public ChangeNameForm(string str)
        {
            InitializeComponent();
            this.warningLabel.Text = str;
        }

        private string newName;
        public string NewName
        {
            get { return newName; }
            set { newName = value; }
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            NewName = maskedTextBox.Text.ToString();
        }

        private void CancelRenameButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChangeNameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
