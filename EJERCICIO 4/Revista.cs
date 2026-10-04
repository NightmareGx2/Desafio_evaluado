using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIO_4
{
    public class Revista : MaterialBibliotecario
    {
        public int Numero { get; set; }

        public Revista(string titulo, string codigo, int año, int numero)
            : base(titulo, codigo, año)
        {
            Numero = numero;
        }

        public override string MostrarInfo()
        {
            return $"--- TIPO: REVISTA ---\r\n" +
                   $"Título: {Titulo}\r\n" +
                   $"Código: {Codigo}\r\n" +
                   $"Año de Publicación: {Año}\r\n" +
                   $"Número de Edición: N° {Numero}";
        }
    }
}
