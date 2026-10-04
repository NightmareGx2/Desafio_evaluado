using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIO_4
{
    public abstract class MaterialBibliotecario
    {
        // Propiedades requeridas
        public string Titulo { get; set; }
        public string Codigo { get; set; }
        public int Año { get; set; }

        // Constructor
        public MaterialBibliotecario(string titulo, string codigo, int año)
        {
            Titulo = titulo;
            Codigo = codigo;
            Año = año;
        }

        public override string ToString()
        {
            // Esto es lo que se verá en cada renglón del ListBox
            return $"[{this.GetType().Name}] - {Titulo} ({Año})";
        }
        // Método abstracto que aplicará Polimorfismo en las clases derivadas
        public abstract string MostrarInfo();
    }
}
