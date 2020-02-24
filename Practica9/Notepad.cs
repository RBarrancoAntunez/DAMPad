using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontFamily = System.Drawing.FontFamily;

namespace Practica9
{
    public partial class Notepad : Form
    {
        private bool modified;
        private string fileName;
        private string fullPath;

        public Notepad()
        {
            InitializeComponent();

            setNewFile();
            FillFontComboBox(cbFonts);
            cbFontSize.SelectedIndex = cbFontSize.FindStringExact("14");
        }

        private void Notepad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modified)
            {
                if (ExitWithoutSaving() == DialogResult.Yes)
                {
                    modified = false;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            } 
            else
            {
                Application.Exit();
            }
        }


        public void FillFontComboBox(ComboBox comboBoxFonts)
        {
            comboBoxFonts.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxFonts.DrawItem += new DrawItemEventHandler(cbFonts_DrawItem);

            comboBoxFonts.DataSource = System.Drawing.FontFamily.Families.ToList();

            comboBoxFonts.SelectedIndex = 0;

            FontFamily f = searchFontPosition(comboBoxFonts, "Arial");
            if (f != null)
            {
                comboBoxFonts.SelectedItem = f;
            } 
            else
            {
                comboBoxFonts.SelectedIndex = 0;
            }
            
        }

        public DialogResult ExitWithoutSaving()
        {
            string body = "¿Desea salir sin guardar?";
            string title = "Confirmación";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            return MessageBox.Show(body, title, buttons);
        }

        private void cbFonts_DrawItem(object sender, DrawItemEventArgs e)
        {

            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.Items[e.Index];
            var font = new Font(fontFamily, comboBox.Font.SizeInPoints);
            System.Drawing.Brush brush = System.Drawing.Brushes.Black;

            e.DrawBackground();
            e.Graphics.DrawString(font.Name, font, brush, e.Bounds.X, e.Bounds.Y);


        }

        private void tabToolBox_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Name.Equals("tabAbout")){
                About acerca = new About
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                acerca.ShowDialog(this);
                e.Cancel = true;
            }
        }

        private void rtbPad_TextChanged(object sender, EventArgs e)
        {
            if (!modified)
            {
                modified = true;
                fileName += " *";
                this.Text = fileName;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!modified)
            {

            } else
            {
                setNewFile();
            }
        }

        private void setNewFile()
        {
            modified = false;
            fileName = "Nuevo documento.rtf";
            fullPath = "";
            this.Text = fileName;
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            ChangeStyle(rtbPad, null, null, FontStyle.Bold);
            rtbPad.Select();
        }

        private void changeSelectedStyle(FontStyle estilo)
        {
            int selstart = rtbPad.SelectionStart;
            int sellength = rtbPad.SelectionLength;

            // Comprobar si ya tiene ese estilo para eliminarlo
            rtbPad.SelectionFont = new Font(rtbPad.Font, rtbPad.SelectionFont.Style ^ estilo);

            if (sellength > 0)
            {
                rtbPad.SelectionStart = rtbPad.SelectionStart + rtbPad.SelectionLength;
                rtbPad.SelectionLength = 0;

                rtbPad.SelectionFont = rtbPad.Font;

                rtbPad.Select(selstart, sellength);
            }
        }

        private void tabToolBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbPad.Select();
        }

        private void Notepad_Activated(object sender, EventArgs e)
        {
            rtbPad.Select();
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {

            ChangeStyle(rtbPad, null, null, FontStyle.Italic);
            
            rtbPad.Select();
        }

        private void btnUnderlined_Click(object sender, EventArgs e)
        {
            ChangeStyle(rtbPad, null, null, FontStyle.Underline);
           
            rtbPad.Select();
        }

        private void rtbPad_SelectionChanged(object sender, EventArgs e)
        {
            // Poner en el combo la fuente adecuada y el tamaño adecuado
            var seleccionado = rtbPad.SelectionFont;
            if (false)
            {
                MessageBox.Show("Hola", "sorpresa", MessageBoxButtons.OK);
            }
        }

        private void cbFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cambiar la fuente del texto seleccionado
            FontFamily f = (FontFamily)cbFonts.SelectedItem;
            ChangeStyle(rtbPad, f.Name, null, null);
            //changeSelectedFont(cbFonts, cbFontSize);
            rtbPad.Select();
        }

        private void cbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cambiar el tamaño de la fuente seleccionada
            bool rightSize = float.TryParse(cbFontSize.Text, out float fontSize);
            if (rightSize)
            {
                ChangeStyle(rtbPad, null, fontSize, null);
            }
            
            rtbPad.Select();
        }

        private void cbFontSize_TextChanged(object sender, EventArgs e)
        {
            // Cambiar el tamaño de la fuente seleccionada
            bool rightSize = float.TryParse(cbFontSize.Text, out float fontSize);
            if (rightSize)
            {
                ChangeStyle(rtbPad, null, fontSize, null);
            }

        }


        public FontFamily searchFontPosition(ComboBox fontsCombo, string fontName)
        {
            foreach (FontFamily f in fontsCombo.Items)
            {
                if (f.Name == fontName)
                {
                    return f;
                }
            }
            return null;
        }

        private void ChangeFontStyle(RichTextBox rtb, string family, float? size, FontStyle? style)
        {

            int selstart = rtb.SelectionStart;
            int sellength = rtb.SelectionLength;
            Font newFont = null;

            if (rtb.SelectionFont != null)
            {
                if (!string.IsNullOrEmpty(family))
                {
                    newFont = new Font(family, rtb.SelectionFont.Size);
                }
                else if (size != null)
                {
                    newFont = new Font(rtb.SelectionFont.FontFamily, size ?? 1);
                }
                else if (style != null)
                {
                    newFont = new Font(rtb.SelectionFont.FontFamily, rtb.SelectionFont.Size, rtb.SelectionFont.Style ^ style ?? FontStyle.Regular);
                }
                rtb.SelectionFont = newFont ?? rtb.SelectionFont;

                if (sellength > 0)
                {
                    rtb.SelectionStart = rtb.SelectionStart + rtb.SelectionLength;
                    rtb.SelectionLength = 0;

                    rtb.SelectionFont = rtb.Font;

                    rtb.Select(selstart, sellength);
                }
            } 
            else
            {
                int temporaryStart = selstart;
                int temporaryLength;

                do
                {
                    rtb.SelectionStart = temporaryStart;
                    temporaryLength = 0;
                    do
                    {
                        temporaryLength++;
                        rtb.SelectionLength = temporaryLength;
                        
                    } while ((temporaryStart + temporaryLength <= selstart + sellength) && rtb.SelectionFont != null);

                    temporaryLength--;
                    rtb.SelectionLength = temporaryLength;

                    if (!string.IsNullOrEmpty(family))
                    {
                        newFont = new Font(family, rtb.SelectionFont.Size);
                    }
                    else if (size != null)
                    {
                        newFont = new Font(rtb.SelectionFont.FontFamily, size ?? 1);
                    }
                    else if (style != null)
                    {
                        newFont = new Font(rtb.SelectionFont.FontFamily, rtb.SelectionFont.Size, rtb.SelectionFont.Style ^ style ?? FontStyle.Regular);
                    }
                    rtb.SelectionFont = newFont ?? rtb.SelectionFont;

                    temporaryStart += temporaryLength;

                } while (temporaryStart < selstart + sellength);

                rtb.SelectionStart = selstart + sellength;
                rtb.SelectionLength = 0;

                rtb.SelectionFont = rtb.Font;

                rtb.Select(selstart, sellength);
            }


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ChangeStyle(RichTextBox rtb, string family, float? size, FontStyle? style)
        {
            int selstart = rtb.SelectionStart;
            int sellength = rtb.SelectionLength;
            int temporaryStart = selstart;
            List<RTBSelectionChange> rtbList = new List<RTBSelectionChange>();

            do
            {
                rtb.SelectionStart = temporaryStart;
                int temporaryPosition = temporaryStart;
                rtb.SelectionLength = 0;
                RTBSelectionChange sc = new RTBSelectionChange(temporaryStart, 0, rtb.SelectionFont.FontFamily, rtb.SelectionFont.Size, rtb.SelectionFont.Style);
                while (rtb.SelectionFont.FontFamily.Name == sc.Family.Name && rtb.SelectionFont.Size == sc.Fontsize && rtb.SelectionFont.Style == sc.Style && (temporaryPosition < selstart + sellength))
                {
                    temporaryPosition++;
                    rtb.SelectionStart = temporaryPosition;
                }
                
                sc.SelectionLength = (temporaryPosition - temporaryStart - 1) >= 0 ? (temporaryPosition - temporaryStart - 1) : 0;
                rtb.SelectionStart = sc.SelectionStart;
                rtb.SelectionLength = sc.SelectionLength;
                if (!string.IsNullOrEmpty(family))
                {
                    sc.Family = new FontFamily(family);
                }
                sc.Fontsize = size ?? rtb.SelectionFont.Size;
                sc.Style = style ?? rtb.SelectionFont.Style;
                rtbList.Add(sc);

                temporaryStart = temporaryPosition;

            } while (temporaryStart < (selstart + sellength));

            foreach (RTBSelectionChange r in rtbList)
            {
                r.CompleteChange(rtb);
            }

            rtb.SelectionStart = selstart + sellength;
            rtb.SelectionLength = 0;

            //rtb.SelectionFont = rtb.Font;

            rtb.Select(selstart, sellength);
        }

    }
}
