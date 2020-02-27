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
    public partial class About : Form
    {
        /// <summary>
        /// Constructor básico de la clase
        /// </summary>
        public About()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método que se ejecuta cuando carga el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_Load(object sender, EventArgs e)
        {
            lblHechoPor.Text = "Hecho por Rafael Barranco Antúnez" + Environment.NewLine +
                            "para Desarrollo de Interfaces." + Environment.NewLine +
                            "Colegio San José.";
        }

        /// <summary>
        /// Evento que se ejecuta al pulsar en el botón de cerrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
