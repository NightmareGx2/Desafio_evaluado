using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EJERCICIO_4
{
    public partial class Menu : Form
    {
        // Instancia principal del gestor que almacenará los datos en memoria
        private GestorBiblioteca gestor = new GestorBiblioteca();

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // Mostrar la fecha actual en la esquina superior
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Cargar contadores iniciales
            ActualizarResumenInventario();
        }

        // Método para actualizar los contadores en los labels
        public void ActualizarResumenInventario()
        {
            lblCantLibros.Text = gestor.ContarLibros().ToString();
            lblCantRevistas.Text = gestor.ContarRevistas().ToString();
            lblCantDVDs.Text = gestor.ContarDVDs().ToString();
            lblCantTotal.Text = gestor.ContarTotal().ToString();
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            // Pasamos la instancia actual del gestor para compartir la lista
            GESTION_DE_MATERIALES formGestion = new GESTION_DE_MATERIALES(gestor);

            // Ocultamos temporalmente el menú
            this.Hide();

            // Mostramos la ventana de gestión de forma modal
            formGestion.ShowDialog();

            // Al cerrar la ventana de gestión, volvemos a mostrar el menú y actualizamos los conteos
            this.Show();
            ActualizarResumenInventario();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea salir del sistema?",
                                                     "Confirmar Salida",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }
    }
}
