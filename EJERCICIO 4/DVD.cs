using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIO_4
{
    public class DVD : MaterialBibliotecario
    {
        public int Duracion { get; set; } // En minutos

        public DVD(string titulo, string codigo, int año, int duracion)
            : base(titulo, codigo, año)
        {
            Duracion = duracion;
        }

        public override string MostrarInfo()
        {
            return $"--- TIPO: DVD ---\r\n" +
                   $"Título: {Titulo}\r\n" +
                   $"Código: {Codigo}\r\n" +
                   $"Año de Emisión: {Año}\r\n" +
                   $"Duración: {Duracion} minutos";
        }
    }
}
