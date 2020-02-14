using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica9
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void tmrSplash_Tick(object sender, EventArgs e)
        {
            Notepad ntp = new Notepad();
            ntp.Show();
            this.Hide();
            tmrSplash.Enabled = false;
        }
    }
}
