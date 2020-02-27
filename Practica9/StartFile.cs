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
    static class StartFile
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Splash());
        }
    }
}
