using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RockAndRoll
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            Version version =
            System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime dt = new DateTime(2000, 1, 1);
            string buildTime = dt.AddDays(version.Build).ToShortDateString();
        }
    }
}
