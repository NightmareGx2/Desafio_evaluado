using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIO_4
{
    public class Libro : MaterialBibliotecario
    {
        public string Autor { get; set; }

        public Libro(string titulo, string codigo, int año, string autor)
            : base(titulo, codigo, año)
        {
            Autor = autor;
        }

        // Sobrescribimos el método MostrarInfo usando 'override' ( para polimorfismo)
        public override string MostrarInfo()
        {
            return $"--- TIPO: LIBRO ---\r\n" +
                   $"Título: {Titulo}\r\n" +
                   $"Código: {Codigo}\r\n" +
                   $"Año de Publicación: {Año}\r\n" +
                   $"Autor: {Autor}";
        }
    }
}
