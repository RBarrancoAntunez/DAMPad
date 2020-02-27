/*
* PRÁCTICA.............: Práctica 9.
* NOMBRE Y APELLIDOS...: Rafael Barranco Antúnez
* CURSO Y GRUPO........: 2º Desarrollo de Interfaces
* TÍTULO DE LA PRÁCTICA: Editor de Textos.
* FECHA DE ENTREGA.....: 06 de marzo de 2020
*/

using System;
using System.Windows.Forms;

namespace Practica9
{
    public partial class FontSizeCombo : System.Windows.Forms.ComboBox
    {
        public FontSizeCombo()
        {
            InitializeComponent();
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
