﻿using System;
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
    public partial class SaveForm : Form
    {
        public SaveForm(String str)
        {
            InitializeComponent();
            this.strLabel.Text = str;
        }

        private void SaveForm_Load(object sender, EventArgs e)
        {

        }
    }
}
