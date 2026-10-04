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
    public partial class GESTION_DE_MATERIALES : Form
    {
        // Variable del gestor de biblioteca
        private GestorBiblioteca gestor;

        // Constructor principal que recibe la instancia activa desde el Menú
        public GESTION_DE_MATERIALES(GestorBiblioteca gestorExistente)
        {
            InitializeComponent();
            this.gestor = gestorExistente ?? new GestorBiblioteca();
        }

        // Constructor sin parámetros necesario para el Diseñador de Visual Studio
        public GESTION_DE_MATERIALES()
        {
            InitializeComponent();
            this.gestor = new GestorBiblioteca();
        }

        private void GESTION_DE_MATERIALES_Load(object sender, EventArgs e)
        {
            // Seleccionar Libro por defecto en el ComboBox
            cmbTipo.SelectedIndex = 0;

            // Cargar los elementos existentes en la lista
            ActualizarListBox();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem == null) return;

            string seleccion = cmbTipo.SelectedItem.ToString();

            // Cambiar la etiqueta dinámicamente
            switch (seleccion)
            {
                case "Libro":
                    lblDatoEspecifico.Text = "Autor:";
                    break;
                case "Revista":
                    lblDatoEspecifico.Text = "Número de Revista:";
                    break;
                case "DVD":
                    lblDatoEspecifico.Text = "Duración (minutos):";
                    break;
            }

            txtDatoEspecifico.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. VALIDACIÓN: Campos vacíos
                if (string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                    string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                    string.IsNullOrWhiteSpace(txtDatoEspecifico.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos requeridos.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Captura de datos básicos
                string titulo = txtTitulo.Text.Trim();
                string codigo = txtCodigo.Text.Trim();
                int año = (int)numAño.Value;

                // 3. VALIDACIÓN y Creación según el tipo seleccionado
                string tipo = cmbTipo.SelectedItem.ToString();
                MaterialBibliotecario nuevoMaterial = null;

                if (tipo == "Libro")
                {
                    string autor = txtDatoEspecifico.Text.Trim();
                    nuevoMaterial = new Libro(titulo, codigo, año, autor);
                }
                else if (tipo == "Revista")
                {
                    if (!int.TryParse(txtDatoEspecifico.Text, out int numero) || numero <= 0)
                    {
                        MessageBox.Show("El número de edición de la revista debe ser un número entero positivo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    nuevoMaterial = new Revista(titulo, codigo, año, numero);
                }
                else if (tipo == "DVD")
                {
                    if (!int.TryParse(txtDatoEspecifico.Text, out int duracion) || duracion <= 0)
                    {
                        MessageBox.Show("La duración del DVD debe ser un número positivo en minutos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    nuevoMaterial = new DVD(titulo, codigo, año, duracion);
                }

                // 4. Agregar a la lógica y al ListBox
                gestor.AgregarMaterial(nuevoMaterial);

                // Actualizar el ListBox
                ActualizarListBox();

                // Limpiar campos
                LimpiarCampos();

                MessageBox.Show("¡Material agregado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Métodos auxiliares
        private void ActualizarListBox()
        {
            lstMateriales.Items.Clear();
            foreach (var mat in gestor.ObtenerTodos())
            {
                lstMateriales.Items.Add(mat);
            }
        }

        private void LimpiarCampos()
        {
            txtTitulo.Clear();
            txtCodigo.Clear();
            txtDatoEspecifico.Clear();
            numAño.Value = DateTime.Now.Year;
            txtTitulo.Focus();
        }

        // Corregido: Guion bajo en lugar de punto
        private void lstMateriales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMateriales.SelectedItem != null)
            {
                // Polimorfismo en acción: llamamos a MostrarInfo()
                MaterialBibliotecario seleccionado = (MaterialBibliotecario)lstMateriales.SelectedItem;
                txtDetalles.Text = seleccionado.MostrarInfo();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(busqueda))
            {
                MessageBox.Show("Escribe el título del material que deseas buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Buscamos con la clase Gestor
            MaterialBibliotecario encontrado = gestor.BuscarPorTitulo(busqueda);

            if (encontrado != null)
            {
                // Seleccionamos el elemento automáticamente en el ListBox
                lstMateriales.SelectedItem = encontrado;

                // Mostramos su información detallada con polimorfismo
                txtDetalles.Text = encontrado.MostrarInfo();

                MessageBox.Show($"¡Material '{encontrado.Titulo}' encontrado!", "Búsqueda Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No se encontró ningún material registrado con el título: '{busqueda}'.", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label16.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }

        private void GESTION_DE_MATERIALES_Activated(object sender, EventArgs e)
        {
            // Carga o actualiza los datos cada vez que la ventana se vuelve activa
            ActualizarListBox();
        }

        private void GESTION_DE_MATERIALES_Load_1(object sender, EventArgs e)
        {
            // Seleccionar Libro por defecto en el ComboBox
            cmbTipo.SelectedIndex = 0;

            // Mostrar Fecha y Hora actual
            if (label10 != null)
            {
                label10.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            }

            // Cargar los elementos de la lista
            ActualizarListBox();
        }
    }
}