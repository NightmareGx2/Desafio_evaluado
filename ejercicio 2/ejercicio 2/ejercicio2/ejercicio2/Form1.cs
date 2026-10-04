using Ejercicio2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicio2
{
    public partial class Form1 : Form
    {
        List<Libro> libros = new List<Libro>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            
            if (txtisbn.Text == "" ||
                txttitulo.Text == "" ||
                txtautor.Text == "" ||
                txtpaginas.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos");
                return;
            }

            
            int paginas;

            if (!int.TryParse(txtpaginas.Text, out paginas) || paginas <= 0)
            {
                MessageBox.Show("Ingrese un número de páginas válido");
                return;
            }

            Libro nuevoLibro = new Libro(
                txtisbn.Text,
                txttitulo.Text,
                txtautor.Text,
                paginas
            );

           
            libros.Add(nuevoLibro);

            
            listlibros.Items.Clear();

            foreach (Libro libro in libros)
            {
                listlibros.Items.Add(libro.ToString());
            }

            MessageBox.Show("Libro registrado correctamente");

         
            txtisbn.Clear();
            txttitulo.Clear();
            txtautor.Clear();
            txtpaginas.Clear();

            txtisbn.Focus();
        }
    }



}
