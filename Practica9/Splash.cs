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
    public partial class Splash : Form
    {
        /// <summary>
        /// Constructor básico de la clase
        /// </summary>
        public Splash()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método que se ejecuta cuando el temporizador cumple el tiempo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrSplash_Tick(object sender, EventArgs e)
        {
            Notepad ntp = new Notepad();
            ntp.Show();
            this.Hide();
            tmrSplash.Enabled = false;
        }
    }
}
