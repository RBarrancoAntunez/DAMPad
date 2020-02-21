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
        }

        private void Notepad_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO: Bug. Pregunta dos veces si se quiere salir
            if (modified)
            {
                if (ExitWithoutSaving() == DialogResult.Yes)
                {
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
            changeSelectedStyle(FontStyle.Bold);
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

            changeSelectedStyle(FontStyle.Italic);
            
            rtbPad.Select();
        }

        private void btnUnderlined_Click(object sender, EventArgs e)
        {

            changeSelectedStyle(FontStyle.Underline);
           
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
            changeSelectedFont(cbFonts, cbFontSize);
            rtbPad.Select();
        }

        private void cbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cambiar el tamaño de la fuente seleccionada
            changeSelectedFont(cbFonts, cbFontSize);
            rtbPad.Select();
        }

        private void cbFontSize_TextChanged(object sender, EventArgs e)
        {
            // Cambiar el tamaño de la fuente seleccionada
            changeSelectedFont(cbFonts, cbFontSize);
        }

        private void changeSelectedFont(ComboBox familyCombo, ComboBox sizeCombo)
        {
            FontStyle style;
            if (rtbPad.SelectionFont == null)
            {
                style = new FontStyle();
            }
            else
            {
                style = rtbPad.SelectionFont.Style;
            }

            bool rightSize = float.TryParse(sizeCombo.Text, out float fontSize);
            if (rightSize)
            {
                int selstart = rtbPad.SelectionStart;
                int sellength = rtbPad.SelectionLength;

                rtbPad.SelectionFont = new Font((FontFamily)familyCombo.SelectedItem, fontSize, style);

                if (sellength > 0)
                {
                    rtbPad.SelectionStart = rtbPad.SelectionStart + rtbPad.SelectionLength;
                    rtbPad.SelectionLength = 0;

                    rtbPad.SelectionFont = rtbPad.Font;

                    rtbPad.Select(selstart, sellength);
                }
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

        private void ChangeFontStyle(RichTextBox rtb, FontFamily? family, Size? size, FontStyle? style)
        {

        }
    }
}
