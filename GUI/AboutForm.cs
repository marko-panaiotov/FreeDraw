using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Windows.Forms;

namespace FreeDraw.GUI
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            //this.Text = String.Format("About {0}", Assembly.GetExecutingAssembly().GetName().Version);
            this.labelProductName.Text = String.Format("Product: {0}", "FreeDraw for personal use");
            this.labelVersion.Text = String.Format("Version: {0}", "2.045.476");
            this.labelCopyright.Text = String.Format("Copyright: {0}", "(c) 2024 Marko Panaiotov");

        }
    }
}
