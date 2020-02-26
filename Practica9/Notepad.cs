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

        public DialogResult NewWithoutSaving()
        {
            string body = "¿Desea guardar antes de crear un nuevo archivo?";
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
                setNewFile();
            } 
            else
            {
                if (NewWithoutSaving() == DialogResult.Yes)
                {
                    saveFile();
                    setNewFile();
                }
                else
                {
                    setNewFile();
                }
            }
            rtbPad.Select();
        }

        private void setNewFile()
        {
            rtbPad.Clear();
            modified = false;
            fileName = "Nuevo documento.rtf";
            fullPath = "";
            this.Text = fileName;
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            ChangeFontStyle(rtbPad, null, null, FontStyle.Bold);
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

            ChangeFontStyle(rtbPad, null, null, FontStyle.Italic);
            
            rtbPad.Select();
        }

        private void btnUnderlined_Click(object sender, EventArgs e)
        {
            ChangeFontStyle(rtbPad, null, null, FontStyle.Underline);
           
            rtbPad.Select();
        }

        private void rtbPad_SelectionChanged(object sender, EventArgs e)
        {
            // Poner en el combo la fuente adecuada y el tamaño adecuado
            Font seleccionado = rtbPad.SelectionFont;
            if (seleccionado != null)
            { 
                FontFamily f = searchFontPosition(cbFonts, rtbPad.SelectionFont.FontFamily.Name);
                if (f != null)
                {
                    cbFonts.SelectedItem = f;
                    cbFontSize.SelectedIndex = cbFontSize.FindStringExact(rtbPad.SelectionFont.Size.ToString());
                }
            }
        }

        private void cbFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cambiar la fuente del texto seleccionado
            FontFamily f = (FontFamily)cbFonts.SelectedItem;
            ChangeFontStyle(rtbPad, f.Name, null, null);
            //changeSelectedFont(cbFonts, cbFontSize);
            rtbPad.Select();
        }

        private void cbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cambiar el tamaño de la fuente seleccionada
            bool rightSize = float.TryParse(cbFontSize.Text, out float fontSize);
            if (rightSize)
            {
                ChangeFontStyle(rtbPad, null, fontSize, null);
            }
            
            rtbPad.Select();
        }

        private void cbFontSize_TextChanged(object sender, EventArgs e)
        {
            // Cambiar el tamaño de la fuente seleccionada
            bool rightSize = float.TryParse(cbFontSize.Text, out float fontSize);
            if (rightSize)
            {
                ChangeFontStyle(rtbPad, null, fontSize, null);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ChangeFontStyle(RichTextBox rtb, string family, float? size, FontStyle? style)
        {
            int selectedStart = rtb.SelectionStart;
            int selectedLength = rtb.SelectionLength;
            if (selectedLength > 0)
            {
                using (RichTextBox rtbTemp = new RichTextBox())
                {
                    rtbTemp.Rtf = rtb.SelectedRtf;
                    for (int i = 0; i < selectedLength; ++i)
                    {
                        rtbTemp.Select(i, 1);
                        FontFamily newfamily;
                        float newsize;
                        if (string.IsNullOrEmpty(family))
                        {
                            newfamily = rtbTemp.SelectionFont.FontFamily;
                        }
                        else
                        {
                            newfamily = new FontFamily(family);
                        }

                        newsize = size ?? rtbTemp.SelectionFont.Size;

                        FontStyle newstyle = rtbTemp.SelectionFont.Style;
                        if (style != null)
                        {
                            rtbTemp.SelectionFont = new Font(newfamily, newsize, newstyle ^ (FontStyle)style);
                        }
                        else
                        {
                            rtbTemp.SelectionFont = new Font(newfamily, newsize, newstyle);
                        }



                    }

                    rtbTemp.Select(0, selectedLength);
                    rtb.SelectedRtf = rtbTemp.SelectedRtf;
                    rtb.Select(selectedStart, selectedLength);
                }
            }
            else
            {
                string newfamily = family ?? rtb.SelectionFont.FontFamily.Name;
                float newsize = size ?? rtb.SelectionFont.Size;
                FontStyle newstyle = rtb.SelectionFont.Style;
                if (style != null)
                {
                    rtb.SelectionFont = new Font(newfamily, newsize, newstyle ^ (FontStyle)style);
                }
                else
                {
                    rtb.SelectionFont = new Font(newfamily, newsize, newstyle);
                }
            }
        }

        private void btnLeftAlign_Click(object sender, EventArgs e)
        {
            rtbPad.SelectionAlignment = HorizontalAlignment.Left;
            rtbPad.Select();
        }

        private void btnRightAlign_Click(object sender, EventArgs e)
        {
            rtbPad.SelectionAlignment = HorizontalAlignment.Right;
            rtbPad.Select();
        }

        private void btnCenterAlign_Click(object sender, EventArgs e)
        {
            rtbPad.SelectionAlignment = HorizontalAlignment.Center;
            rtbPad.Select();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (rtbPad.SelectedText.Length > 0)
            {
                rtbPad.Copy();
            }
            rtbPad.Select();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            if (rtbPad.SelectedText.Length > 0)
            {
                rtbPad.Cut();
            }
            rtbPad.Select();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            rtbPad.Paste();
            rtbPad.Select();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveFile()
        {
            if (string.IsNullOrEmpty(fullPath))
            {

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Documento de texto|*.rtf";
                saveDialog.Title = "Guarde el documento";
                saveDialog.FilterIndex = 1;
                saveDialog.RestoreDirectory = true;


                if (saveDialog.ShowDialog() == DialogResult.OK && saveDialog.FileName != "")
                {
                    fullPath = saveDialog.FileName;
                }
            }

            // Se repite la comprobación porque en el paso anterior puede no haberse rellenado el path del archivo
            if (!string.IsNullOrEmpty(fullPath))
            {
                rtbPad.SaveFile(fullPath, RichTextBoxStreamType.RichNoOleObjs);
                modified = false;
                fileName = fullPath.Substring(fullPath.LastIndexOf("\\") + 1);
                this.Text = fileName;
            }
            rtbPad.Select();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.DefaultExt = "*.rtf";
            openDialog.Filter = "Documento de texto|*.rtf";

            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openDialog.FileName.Length > 0)
            {
                rtbPad.LoadFile(openDialog.FileName);
                fullPath = openDialog.FileName;
                modified = false;
                fileName = fullPath.Substring(fullPath.LastIndexOf("\\") + 1);
                this.Text = fileName;
            }
            rtbPad.Select();
        }

        private void Notepad_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                trayIcon.Visible = true;
                trayIcon.Text = "Modificando: " + fileName;
                this.ShowInTaskbar = false;
            }
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            trayIcon.Visible = false;
        }
    }
}
