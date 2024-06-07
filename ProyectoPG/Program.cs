using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPG
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(IniciarSesion());
        }
        private static void ShowForm2()
        {
         MenuPrincipal() = new MenuPrincipal();
         Application.Run(MenyPrinciapl());
        }
    }
}
