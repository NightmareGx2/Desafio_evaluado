using System;

namespace Ejercicio2
{
    public class Libro
    {
       
        private string ISBN;
        private string Titulo;
        private string Autor;
        private int NumeroPaginas;

        
        public Libro(string isbn, string titulo, string autor, int paginas)
        {
            ISBN = isbn;
            Titulo = titulo;
            Autor = autor;
            NumeroPaginas = paginas;
        }

        
        public string GetISBN()
        {
            return ISBN;
        }

        public void SetISBN(string isbn)
        {
            ISBN = isbn;
        }

        
        public string GetTitulo()
        {
            return Titulo;
        }

        public void SetTitulo(string titulo)
        {
            Titulo = titulo;
        }

     
        public string GetAutor()
        {
            return Autor;
        }

        public void SetAutor(string autor)
        {
            Autor = autor;
        }

        
        public int GetNumeroPaginas()
        {
            return NumeroPaginas;
        }

        public void SetNumeroPaginas(int paginas)
        {
            NumeroPaginas = paginas;
        }

       
        public override string ToString()
        {
            return "El libro con ISBN " + ISBN +
                   " creado por el autor " + Autor +
                   " tiene " + NumeroPaginas + " páginas";
        }
    }
}