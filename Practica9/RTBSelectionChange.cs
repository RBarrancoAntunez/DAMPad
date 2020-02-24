using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica9
{
    class RTBSelectionChange
    {
        private int selectionStart;
        private int selectionLength;
        private FontFamily family;
        private float fontsize;
        private FontStyle style;

        public RTBSelectionChange(int selectionStart, int selectionLength, FontFamily family, float fontsize, FontStyle style)
        {
            this.selectionStart = selectionStart;
            this.selectionLength = selectionLength;
            this.family = family;
            this.fontsize = fontsize;
            this.style = style;
        }

        public int SelectionStart { get => selectionStart; set => selectionStart = value; }
        public int SelectionLength { get => selectionLength; set => selectionLength = value; }
        public FontFamily Family { get => family; set => family = value; }
        public FontStyle Style { get => style; set => style = value; }
        public float Fontsize { get => fontsize; set => fontsize = value; }

        public void CompleteChange(RichTextBox rtb)
        {
            rtb.SelectionStart = this.selectionStart;
            rtb.SelectionLength = this.selectionLength;
            rtb.SelectionFont = new Font(this.family, this.fontsize, this.style);
        }

    }
}
