using System;
using System.Windows.Forms;
using Ejercicio5_POO.Formularios;

namespace Ejercicio5_POO
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormPrincipal());
        }
    }
}
