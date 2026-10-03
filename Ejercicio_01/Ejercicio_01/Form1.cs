using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_01
{
  
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        // Este metodo se genera cuando hacemos clic en el botón "Generar Contraseña"
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            // Validamos que el campo de longitud no esté vacío
            if (string.IsNullOrWhiteSpace(txtLongitud.Text))
            {
                MessageBox.Show("Debe ingresar una longitud");
                return;
            }
            // Validamos que el valor ingresado sea un número entero
            if (!int.TryParse(txtLongitud.Text, out int longitud))
            {
                MessageBox.Show("La longitud debe ser un número");
                return;
            }
            // Validamos que la longitud sea al menos 8
            if (longitud < 8)
            {
                MessageBox.Show("La longitud debe ser como mínimo 8");
                return;
            }

            // Creamos un objeto de la clase Password
            Password password = new Password();
            // Le damos al objeto la longitud que el usuario ingreso
            password.SetLongitud(longitud);
            // Generamos la contraseña usando el método generarPassword()
            password.generarPassword();
            // Mostramos la contraseña generada en el TextBox correspondiente
            txtContraseña.Text = password.GetContraseña();
        }

        // Este metodo se genera cuando hacemos clic en el botón "Verificar Contraseña"
        private void btnVerificar_Click(object sender, EventArgs e)
        {
            // Creamos un objeto de la clase Password
            Password password = new Password();

            // Le damos al objeto  la contraseña que el usuario ingreso 
            password.SetContraseña(txtContraseña.Text);

            // Comprobamos si la contraseña es fuerte o débil usando el método esFuerte()
            if (password.esFuerte())
            {
                // Si la contraseña es fuerte, mostramos el siguiente mensaje
                lblResultado.Text = "La contraseña es FUERTE";
            }
            else
            {
                // Si no cumple las condiciones, mostramos el siguiente mensaje
                lblResultado.Text = "La contraseña es DÉBIL";
            }
        }

        // Este método se ejecuta cuando se carga el formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            // Creamos un objeto de la clase Password para poder acceder a sus métodos y propiedades
            Password password = new Password();

            // Obtenemos la longitud predeterminada de la contraseña
            txtLongitud.Text = password.GetLongitud().ToString();

        }
    }
}