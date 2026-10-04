using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIO_4
{
    public class GestorBiblioteca
    {
        // Lista genérica de Materiales Bibliotecarios
        private List<MaterialBibliotecario> listaMateriales;

        public GestorBiblioteca()
        {
            listaMateriales = new List<MaterialBibliotecario>();
        }

        // Método para agregar
        public void AgregarMaterial(MaterialBibliotecario material)
        {
            listaMateriales.Add(material);
        }

        // Obtener la lista completa
        public List<MaterialBibliotecario> ObtenerTodos()
        {
            return listaMateriales;
        }

        // Búsqueda por título (ignorando mayúsculas/minúsculas)
        public MaterialBibliotecario BuscarPorTitulo(string titulo)
        {
            return listaMateriales.FirstOrDefault(m => m.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
        }

        // Métodos para los indicadores del Dashboard
        public int ContarLibros()
        {
            return listaMateriales.OfType<Libro>().Count();
        }

        public int ContarRevistas()
        {
            return listaMateriales.OfType<Revista>().Count();
        }

        public int ContarDVDs()
        {
            return listaMateriales.OfType<DVD>().Count();
        }

        public int ContarTotal()
        {
            return listaMateriales.Count;
        }
    }
}

