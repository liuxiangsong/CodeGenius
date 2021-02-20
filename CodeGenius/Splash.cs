using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace CodeGenius
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            lblVersion.Text = String.Format("Version {0}\n", Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }
    }
}
