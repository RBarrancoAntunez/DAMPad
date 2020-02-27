/*
* PRÁCTICA.............: Práctica 9.
* NOMBRE Y APELLIDOS...: Rafael Barranco Antúnez
* CURSO Y GRUPO........: 2º Desarrollo de Interfaces
* TÍTULO DE LA PRÁCTICA: Editor de Textos.
* FECHA DE ENTREGA.....: 06 de marzo de 2020
*/

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FontFamily = System.Drawing.FontFamily;

namespace Practica9
{
    public partial class Notepad : Form
    {
        #region Propiedades

        // Propiedad que indica si el archivo ha sido modificado desde la última vez que se guardó
        private bool modified;
        // Propiedad que almacena el nombre del archivo
        private string fileName;
        // Propiedad que almacena la ruta completa del archivo ya guardado
        private string fullPath;

        #endregion Propiedades

        #region Constructor

        /// <summary>
        /// Constructor básico de la clase.
        /// </summary>
        public Notepad()
        {
            InitializeComponent();

            setNewFile();
            FillFontComboBox(cbFonts);
            cbFontSize.SelectedIndex = cbFontSize.FindStringExact("14");
        }

        #endregion Constructor

        #region Eventos

        #region Formulario
        /// <summary>
        /// Evento que se ejecuta antes de que se cierre el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Evento que se ejecuta al modificar el tamaño del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notepad_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                trayIcon.Visible = true;
                trayIcon.Text = "Modificando: " + fileName;
                this.ShowInTaskbar = false;
            }
        }
        
        /// <summary>
        /// Evento que se ejecuta cuando el formulario adquiere el foco.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notepad_Activated(object sender, EventArgs e)
        {
            rtbPad.Select();
        }

        #endregion Formulario

        #region ComboBoxes
        
        /// <summary>
        /// Evento que se ejecuta cuando se va a añadir un elemento a un combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFonts_DrawItem(object sender, DrawItemEventArgs e)
        {

            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.Items[e.Index];
            var font = new Font(fontFamily, comboBox.Font.SizeInPoints);
            System.Drawing.Brush brush = System.Drawing.Brushes.Black;

            e.DrawBackground();
            e.Graphics.DrawString(font.Name, font, brush, e.Bounds.X, e.Bounds.Y);

        }

        /// <summary>
        /// Evento que se ejecuta cuando cambia el índice de selección del combo de fuentes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cambiar la fuente del texto seleccionado
            FontFamily f = (FontFamily)cbFonts.SelectedItem;
            ChangeFontStyle(rtbPad, f.Name, null, null);
            //changeSelectedFont(cbFonts, cbFontSize);
            rtbPad.Select();
        }

        /// <summary>
        /// Evento que se ejecuta cuando cambia el índice de selección del combo de tamaños de fuente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Evento que se ejecuta cuando se escribe en el combo de tamaños de fuente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFontSize_TextChanged(object sender, EventArgs e)
        {
            // Cambiar el tamaño de la fuente seleccionada
            bool rightSize = float.TryParse(cbFontSize.Text, out float fontSize);
            if (rightSize)
            {
                ChangeFontStyle(rtbPad, null, fontSize, null);
            }

        }

        #endregion ComboBoxes

        #region Toolbox

        /// <summary>
        /// Evento que se ejecuta antes de que cambie la pestaña seleccionada en el toolbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabToolBox_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Name.Equals("tabAbout"))
            {
                About acerca = new About
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                acerca.ShowDialog(this);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Evento que se ejecuta después de que cambie la pestaña seleccionada en el toolbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabToolBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbPad.Select();
        }

        #endregion Toolbox

        #region RichTextBox

        /// <summary>
        /// Evento que se ejecuta cuando se modifica el texto del RTB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbPad_TextChanged(object sender, EventArgs e)
        {
            if (!modified)
            {
                modified = true;
                fileName += " *";
                this.Text = fileName;
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se modifica la selección (o posición) del RTB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        #endregion RichTextBox

        #region Botones

        /// <summary>
        /// Evento que se ejecuta cuando se pulsa en el botón Nuevo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Evento que se ejecuta cuando se pulsa en el botón Negrita.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBold_Click(object sender, EventArgs e)
        {
            ChangeFontStyle(rtbPad, null, null, FontStyle.Bold);
            rtbPad.Select();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se pulsa en el botón Cursiva.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItalic_Click(object sender, EventArgs e)
        {

            ChangeFontStyle(rtbPad, null, null, FontStyle.Italic);

            rtbPad.Select();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se pulsa en el botón Subrayado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnderlined_Click(object sender, EventArgs e)
        {
            ChangeFontStyle(rtbPad, null, null, FontStyle.Underline);

            rtbPad.Select();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se pulsa en el botón Salir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se pulsa en el botón Alinear a la izquierda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeftAlign_Click(object sender, EventArgs e)
        {
            rtbPad.SelectionAlignment = HorizontalAlignment.Left;
            rtbPad.Select();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se pulsa en el botón Alinear a la derecha.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRightAlign_Click(object sender, EventArgs e)
        {
            rtbPad.SelectionAlignment = HorizontalAlignment.Right;
            rtbPad.Select();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se pulsa en el botón Alinear en el centro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCenterAlign_Click(object sender, EventArgs e)
        {
            rtbPad.SelectionAlignment = HorizontalAlignment.Center;
            rtbPad.Select();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se pulsa en el botón Copiar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (rtbPad.SelectedText.Length > 0)
            {
                rtbPad.Copy();
            }
            rtbPad.Select();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se pulsa en el botón Cortar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCut_Click(object sender, EventArgs e)
        {
            if (rtbPad.SelectedText.Length > 0)
            {
                rtbPad.Cut();
            }
            rtbPad.Select();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se pulsa en el botón Pegar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPaste_Click(object sender, EventArgs e)
        {
            rtbPad.Paste();
            rtbPad.Select();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se pulsa en el botón Guardar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se pulsa en el botón Abrir archivo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #endregion Botones

        #region NotificationIcon

        /// <summary>
        /// Evento que se ejecuta cuando se hace doble click en el icono de la barra de tareas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            trayIcon.Visible = false;
        }

        #endregion NotificationIcon

        #endregion Eventos

        #region Métodos privados

        /// <summary>
        /// Método para rellenar un combobox con todos los tipos de fuente presentes en el sistema.
        /// </summary>
        /// <param name="comboBoxFonts">Combobox a rellenar con las fuentes del sistema</param>
        private void FillFontComboBox(ComboBox comboBoxFonts)
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

        /// <summary>
        /// Método para la creación de un diálogo Sí/No para la grabación del archivo.
        /// </summary>
        /// <returns>Diálogo con respuesta de tipo Sí/No</returns>
        private DialogResult ExitWithoutSaving()
        {
            string body = "¿Desea salir sin guardar?";
            string title = "Confirmación";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            return MessageBox.Show(body, title, buttons);
        }

        /// <summary>
        /// Método para la creación de un diálogo Sí/No para la grabación del archivo.
        /// </summary>
        /// <returns>Diálogo con respuesta de tipo Sí/No</returns>
        private DialogResult NewWithoutSaving()
        {
            string body = "¿Desea guardar antes de crear un nuevo archivo?";
            string title = "Confirmación";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            return MessageBox.Show(body, title, buttons);
        }

        /// <summary>
        /// Método que inicializa un nuevo documento en la aplicación.
        /// </summary>
        private void setNewFile()
        {
            rtbPad.Clear();
            modified = false;
            fileName = "Nuevo documento.rtf";
            fullPath = "";
            this.Text = fileName;
        }

        /// <summary>
        /// Método que devuelve la Fuente en un combo según su nombre si es encontrada.
        /// </summary>
        /// <param name="fontsCombo">Combo en el que buscar la posición</param>
        /// <param name="fontName">Nombre de la fuente a buscar</param>
        /// <returns>Objeto Fuente que está en el combobox, o nulo si no se ha encontrado.</returns>
        private FontFamily searchFontPosition(ComboBox fontsCombo, string fontName)
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

        /// <summary>
        /// Método para cambiar el estilo del texto según el cambio que se le pida desde la botonera.
        /// </summary>
        /// <param name="rtb">RichTextBox en el que producir los cambios</param>
        /// <param name="family">Fuente a la que cambiar el texto</param>
        /// <param name="size">Tamaño al que cambiar el texto</param>
        /// <param name="style">Estilo a modificar en el texto</param>
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

        /// <summary>
        /// Método para guardar el texto del RichTextBox en un archivo en disco duro.
        /// </summary>
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

        #endregion Métodos privados
    }
}
