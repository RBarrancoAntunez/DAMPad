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
    public partial class FontSizeCombo : System.Windows.Forms.ComboBox
    {
        public FontSizeCombo()
        {
            InitializeComponent();
            //Load();

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected void Load()
        {
            for (int i = 2; i <= 40; i += 2)
            {
                this.Items.Add(i);
            }
        }
    }
}
