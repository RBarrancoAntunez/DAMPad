namespace Practica9
{
    partial class Notepad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notepad));
            this.rtbPad = new System.Windows.Forms.RichTextBox();
            this.ttTexts = new System.Windows.Forms.ToolTip(this.components);
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBold = new System.Windows.Forms.Button();
            this.btnItalic = new System.Windows.Forms.Button();
            this.btnUnderlined = new System.Windows.Forms.Button();
            this.btnLeftAlign = new System.Windows.Forms.Button();
            this.btnCenterAlign = new System.Windows.Forms.Button();
            this.btnRightAlign = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnCut = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.cbFonts = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabToolBox = new System.Windows.Forms.TabControl();
            this.tabFile = new System.Windows.Forms.TabPage();
            this.tabFunctions = new System.Windows.Forms.TabPage();
            this.tabFont = new System.Windows.Forms.TabPage();
            this.tabStyle = new System.Windows.Forms.TabPage();
            this.tabAlign = new System.Windows.Forms.TabPage();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.cbFontSize = new Practica9.FontSizeCombo();
            this.tabToolBox.SuspendLayout();
            this.tabFile.SuspendLayout();
            this.tabFunctions.SuspendLayout();
            this.tabFont.SuspendLayout();
            this.tabStyle.SuspendLayout();
            this.tabAlign.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbPad
            // 
            this.rtbPad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPad.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbPad.Location = new System.Drawing.Point(4, 83);
            this.rtbPad.Name = "rtbPad";
            this.rtbPad.Size = new System.Drawing.Size(789, 463);
            this.rtbPad.TabIndex = 1;
            this.rtbPad.Text = "";
            this.rtbPad.SelectionChanged += new System.EventHandler(this.rtbPad_SelectionChanged);
            this.rtbPad.TextChanged += new System.EventHandler(this.rtbPad_TextChanged);
            // 
            // btnNew
            // 
            this.btnNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNew.BackgroundImage")));
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNew.Location = new System.Drawing.Point(6, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(32, 40);
            this.btnNew.TabIndex = 1;
            this.ttTexts.SetToolTip(this.btnNew, "Nuevo");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Location = new System.Drawing.Point(44, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(32, 40);
            this.btnSave.TabIndex = 2;
            this.ttTexts.SetToolTip(this.btnSave, "Guardar");
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnBold
            // 
            this.btnBold.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBold.BackgroundImage")));
            this.btnBold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBold.Location = new System.Drawing.Point(6, 6);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(32, 40);
            this.btnBold.TabIndex = 2;
            this.ttTexts.SetToolTip(this.btnBold, "Negrita");
            this.btnBold.UseVisualStyleBackColor = true;
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnItalic.BackgroundImage")));
            this.btnItalic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnItalic.Location = new System.Drawing.Point(44, 6);
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(32, 40);
            this.btnItalic.TabIndex = 3;
            this.ttTexts.SetToolTip(this.btnItalic, "Cursiva");
            this.btnItalic.UseVisualStyleBackColor = true;
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnUnderlined
            // 
            this.btnUnderlined.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUnderlined.BackgroundImage")));
            this.btnUnderlined.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUnderlined.Location = new System.Drawing.Point(82, 6);
            this.btnUnderlined.Name = "btnUnderlined";
            this.btnUnderlined.Size = new System.Drawing.Size(32, 40);
            this.btnUnderlined.TabIndex = 4;
            this.ttTexts.SetToolTip(this.btnUnderlined, "Subrayado");
            this.btnUnderlined.UseVisualStyleBackColor = true;
            this.btnUnderlined.Click += new System.EventHandler(this.btnUnderlined_Click);
            // 
            // btnLeftAlign
            // 
            this.btnLeftAlign.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLeftAlign.BackgroundImage")));
            this.btnLeftAlign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLeftAlign.Location = new System.Drawing.Point(6, 6);
            this.btnLeftAlign.Name = "btnLeftAlign";
            this.btnLeftAlign.Size = new System.Drawing.Size(32, 40);
            this.btnLeftAlign.TabIndex = 3;
            this.ttTexts.SetToolTip(this.btnLeftAlign, "Alineado izquierda");
            this.btnLeftAlign.UseVisualStyleBackColor = true;
            this.btnLeftAlign.Click += new System.EventHandler(this.btnLeftAlign_Click);
            // 
            // btnCenterAlign
            // 
            this.btnCenterAlign.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCenterAlign.BackgroundImage")));
            this.btnCenterAlign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCenterAlign.Location = new System.Drawing.Point(44, 6);
            this.btnCenterAlign.Name = "btnCenterAlign";
            this.btnCenterAlign.Size = new System.Drawing.Size(32, 40);
            this.btnCenterAlign.TabIndex = 4;
            this.ttTexts.SetToolTip(this.btnCenterAlign, "Centrado");
            this.btnCenterAlign.UseVisualStyleBackColor = true;
            this.btnCenterAlign.Click += new System.EventHandler(this.btnCenterAlign_Click);
            // 
            // btnRightAlign
            // 
            this.btnRightAlign.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRightAlign.BackgroundImage")));
            this.btnRightAlign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRightAlign.Location = new System.Drawing.Point(82, 6);
            this.btnRightAlign.Name = "btnRightAlign";
            this.btnRightAlign.Size = new System.Drawing.Size(32, 40);
            this.btnRightAlign.TabIndex = 5;
            this.ttTexts.SetToolTip(this.btnRightAlign, "Alineado derecha");
            this.btnRightAlign.UseVisualStyleBackColor = true;
            this.btnRightAlign.Click += new System.EventHandler(this.btnRightAlign_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopy.BackgroundImage")));
            this.btnCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCopy.Location = new System.Drawing.Point(6, 6);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(32, 40);
            this.btnCopy.TabIndex = 2;
            this.ttTexts.SetToolTip(this.btnCopy, "Copiar");
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnCut
            // 
            this.btnCut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCut.BackgroundImage")));
            this.btnCut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCut.Location = new System.Drawing.Point(44, 6);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(32, 40);
            this.btnCut.TabIndex = 3;
            this.ttTexts.SetToolTip(this.btnCut, "Cortar");
            this.btnCut.UseVisualStyleBackColor = true;
            // 
            // btnPaste
            // 
            this.btnPaste.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPaste.BackgroundImage")));
            this.btnPaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPaste.Location = new System.Drawing.Point(82, 6);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(32, 40);
            this.btnPaste.TabIndex = 4;
            this.ttTexts.SetToolTip(this.btnPaste, "Pegar");
            this.btnPaste.UseVisualStyleBackColor = true;
            // 
            // cbFonts
            // 
            this.cbFonts.DropDownHeight = 140;
            this.cbFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFonts.FormattingEnabled = true;
            this.cbFonts.IntegralHeight = false;
            this.cbFonts.Location = new System.Drawing.Point(6, 6);
            this.cbFonts.Name = "cbFonts";
            this.cbFonts.Size = new System.Drawing.Size(350, 39);
            this.cbFonts.TabIndex = 0;
            this.ttTexts.SetToolTip(this.cbFonts, "Fuente");
            this.cbFonts.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbFonts_DrawItem);
            this.cbFonts.SelectedIndexChanged += new System.EventHandler(this.cbFonts_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Location = new System.Drawing.Point(751, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 40);
            this.btnExit.TabIndex = 3;
            this.ttTexts.SetToolTip(this.btnExit, "Salir");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tabToolBox
            // 
            this.tabToolBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabToolBox.Controls.Add(this.tabFile);
            this.tabToolBox.Controls.Add(this.tabFunctions);
            this.tabToolBox.Controls.Add(this.tabFont);
            this.tabToolBox.Controls.Add(this.tabStyle);
            this.tabToolBox.Controls.Add(this.tabAlign);
            this.tabToolBox.Controls.Add(this.tabAbout);
            this.tabToolBox.Location = new System.Drawing.Point(0, 0);
            this.tabToolBox.Name = "tabToolBox";
            this.tabToolBox.SelectedIndex = 0;
            this.tabToolBox.Size = new System.Drawing.Size(797, 81);
            this.tabToolBox.TabIndex = 2;
            this.tabToolBox.SelectedIndexChanged += new System.EventHandler(this.tabToolBox_SelectedIndexChanged);
            this.tabToolBox.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabToolBox_Selecting);
            // 
            // tabFile
            // 
            this.tabFile.Controls.Add(this.btnExit);
            this.tabFile.Controls.Add(this.btnSave);
            this.tabFile.Controls.Add(this.btnNew);
            this.tabFile.Location = new System.Drawing.Point(4, 22);
            this.tabFile.Name = "tabFile";
            this.tabFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabFile.Size = new System.Drawing.Size(789, 55);
            this.tabFile.TabIndex = 0;
            this.tabFile.Text = "Archivo";
            this.tabFile.UseVisualStyleBackColor = true;
            // 
            // tabFunctions
            // 
            this.tabFunctions.Controls.Add(this.btnPaste);
            this.tabFunctions.Controls.Add(this.btnCut);
            this.tabFunctions.Controls.Add(this.btnCopy);
            this.tabFunctions.Location = new System.Drawing.Point(4, 22);
            this.tabFunctions.Name = "tabFunctions";
            this.tabFunctions.Size = new System.Drawing.Size(789, 55);
            this.tabFunctions.TabIndex = 4;
            this.tabFunctions.Text = "Funciones";
            this.tabFunctions.UseVisualStyleBackColor = true;
            // 
            // tabFont
            // 
            this.tabFont.Controls.Add(this.cbFontSize);
            this.tabFont.Controls.Add(this.cbFonts);
            this.tabFont.Location = new System.Drawing.Point(4, 22);
            this.tabFont.Name = "tabFont";
            this.tabFont.Padding = new System.Windows.Forms.Padding(3);
            this.tabFont.Size = new System.Drawing.Size(789, 55);
            this.tabFont.TabIndex = 1;
            this.tabFont.Text = "Fuente";
            this.tabFont.UseVisualStyleBackColor = true;
            // 
            // tabStyle
            // 
            this.tabStyle.Controls.Add(this.btnUnderlined);
            this.tabStyle.Controls.Add(this.btnItalic);
            this.tabStyle.Controls.Add(this.btnBold);
            this.tabStyle.Location = new System.Drawing.Point(4, 22);
            this.tabStyle.Name = "tabStyle";
            this.tabStyle.Size = new System.Drawing.Size(789, 55);
            this.tabStyle.TabIndex = 2;
            this.tabStyle.Text = "Estilo";
            this.tabStyle.UseVisualStyleBackColor = true;
            // 
            // tabAlign
            // 
            this.tabAlign.Controls.Add(this.btnRightAlign);
            this.tabAlign.Controls.Add(this.btnCenterAlign);
            this.tabAlign.Controls.Add(this.btnLeftAlign);
            this.tabAlign.Location = new System.Drawing.Point(4, 22);
            this.tabAlign.Name = "tabAlign";
            this.tabAlign.Size = new System.Drawing.Size(789, 55);
            this.tabAlign.TabIndex = 3;
            this.tabAlign.Text = "Alineado";
            this.tabAlign.UseVisualStyleBackColor = true;
            // 
            // tabAbout
            // 
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Size = new System.Drawing.Size(789, 55);
            this.tabAbout.TabIndex = 5;
            this.tabAbout.Text = "Acerca de";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // cbFontSize
            // 
            this.cbFontSize.DropDownHeight = 140;
            this.cbFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFontSize.FormattingEnabled = true;
            this.cbFontSize.IntegralHeight = false;
            this.cbFontSize.ItemHeight = 31;
            this.cbFontSize.Items.AddRange(new object[] {
            2,
            4,
            6,
            8,
            10,
            12,
            14,
            16,
            18,
            20,
            22,
            24,
            26,
            28,
            30,
            32,
            34,
            36,
            38,
            40});
            this.cbFontSize.Location = new System.Drawing.Point(362, 6);
            this.cbFontSize.Name = "cbFontSize";
            this.cbFontSize.Size = new System.Drawing.Size(85, 39);
            this.cbFontSize.TabIndex = 3;
            this.cbFontSize.SelectedIndexChanged += new System.EventHandler(this.cbFontSize_SelectedIndexChanged);
            this.cbFontSize.TextChanged += new System.EventHandler(this.cbFontSize_TextChanged);
            // 
            // Notepad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.tabToolBox);
            this.Controls.Add(this.rtbPad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Notepad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo documento";
            this.Activated += new System.EventHandler(this.Notepad_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Notepad_FormClosing);
            this.tabToolBox.ResumeLayout(false);
            this.tabFile.ResumeLayout(false);
            this.tabFunctions.ResumeLayout(false);
            this.tabFont.ResumeLayout(false);
            this.tabStyle.ResumeLayout(false);
            this.tabAlign.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtbPad;
        private System.Windows.Forms.ToolTip ttTexts;
        private System.Windows.Forms.TabControl tabToolBox;
        private System.Windows.Forms.TabPage tabFile;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TabPage tabFont;
        private System.Windows.Forms.TabPage tabStyle;
        private System.Windows.Forms.TabPage tabAlign;
        private System.Windows.Forms.Button btnUnderlined;
        private System.Windows.Forms.Button btnItalic;
        private System.Windows.Forms.Button btnBold;
        private System.Windows.Forms.TabPage tabFunctions;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnCut;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnRightAlign;
        private System.Windows.Forms.Button btnCenterAlign;
        private System.Windows.Forms.Button btnLeftAlign;
        private System.Windows.Forms.ComboBox cbFonts;
        private System.Windows.Forms.TabPage tabAbout;
        private FontSizeCombo cbFontSize;
        private System.Windows.Forms.Button btnExit;
    }
}