using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Ejercicio5_POO.Modelos;

namespace Ejercicio5_POO.Formularios
{
    public class FormPrincipal : Form
    {
        private readonly List<Cliente> clientes = new List<Cliente>();
        private readonly List<Producto> productos = new List<Producto>();

        private TextBox txtNombreCliente;
        private TextBox txtCorreoCliente;
        private TextBox txtTelefonoCliente;
        private TextBox txtNombreProducto;
        private TextBox txtPrecioProducto;
        private TextBox txtStockProducto;
        private ListBox lstClientes;
        private ListBox lstProductos;

        public FormPrincipal()
        {
            Text = "Gestión de Clientes y Productos";
            Size = new Size(900, 600);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            CrearInterfaz();
        }

        private void CrearInterfaz()
        {
            Label titulo = new Label
            {
                Text = "Gestión de Clientes y Productos",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(270, 20)
            };
            Controls.Add(titulo);

            GroupBox grupoCliente = new GroupBox
            {
                Text = "Registrar cliente",
                Location = new Point(30, 70),
                Size = new Size(400, 220)
            };

            txtNombreCliente = CrearTextBox(grupoCliente, "Nombre:", 30, 35);
            txtCorreoCliente = CrearTextBox(grupoCliente, "Correo:", 30, 85);
            txtTelefonoCliente = CrearTextBox(grupoCliente, "Teléfono:", 30, 135);

            Button btnCliente = new Button
            {
                Text = "Registrar cliente",
                Location = new Point(230, 170),
                Size = new Size(140, 30)
            };
            btnCliente.Click += RegistrarCliente;
            grupoCliente.Controls.Add(btnCliente);
            Controls.Add(grupoCliente);

            GroupBox grupoProducto = new GroupBox
            {
                Text = "Agregar producto",
                Location = new Point(470, 70),
                Size = new Size(400, 220)
            };

            txtNombreProducto = CrearTextBox(grupoProducto, "Nombre:", 30, 35);
            txtPrecioProducto = CrearTextBox(grupoProducto, "Precio unitario:", 30, 85);
            txtStockProducto = CrearTextBox(grupoProducto, "Stock:", 30, 135);

            Button btnProducto = new Button
            {
                Text = "Agregar producto",
                Location = new Point(230, 170),
                Size = new Size(140, 30)
            };
            btnProducto.Click += AgregarProducto;
            grupoProducto.Controls.Add(btnProducto);
            Controls.Add(grupoProducto);

            Label lblClientes = new Label
            {
                Text = "Clientes registrados",
                AutoSize = true,
                Location = new Point(30, 315),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            Controls.Add(lblClientes);

            lstClientes = new ListBox
            {
                Location = new Point(30, 345),
                Size = new Size(400, 150)
            };
            Controls.Add(lstClientes);

            Label lblProductos = new Label
            {
                Text = "Productos registrados",
                AutoSize = true,
                Location = new Point(470, 315),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            Controls.Add(lblProductos);

            lstProductos = new ListBox
            {
                Location = new Point(470, 345),
                Size = new Size(400, 150)
            };
            Controls.Add(lstProductos);

            Button btnFactura = new Button
            {
                Text = "Crear factura",
                Location = new Point(350, 515),
                Size = new Size(200, 35)
            };
            btnFactura.Click += AbrirFactura;
            Controls.Add(btnFactura);
        }

        private TextBox CrearTextBox(Control padre, string texto, int x, int y)
        {
            Label label = new Label
            {
                Text = texto,
                Location = new Point(x, y + 3),
                AutoSize = true
            };
            padre.Controls.Add(label);

            TextBox textBox = new TextBox
            {
                Location = new Point(x + 100, y),
                Width = 240
            };
            padre.Controls.Add(textBox);

            return textBox;
        }

        private void RegistrarCliente(object sender, EventArgs e)
        {
            string nombre = txtNombreCliente.Text.Trim();
            string correo = txtCorreoCliente.Text.Trim();
            string telefono = txtTelefonoCliente.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("Todos los datos del cliente son obligatorios.");
                return;
            }

            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingrese un correo válido.");
                return;
            }

            if (!Regex.IsMatch(telefono, @"^\d{8}$"))
            {
                MessageBox.Show("El teléfono debe contener 8 dígitos.");
                return;
            }

            Cliente cliente = new Cliente(nombre, correo, telefono);
            clientes.Add(cliente);
            lstClientes.Items.Add(cliente);
            LimpiarCliente();
        }

        private void AgregarProducto(object sender, EventArgs e)
        {
            string nombre = txtNombreProducto.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) ||
                !decimal.TryParse(txtPrecioProducto.Text, out decimal precio) ||
                !int.TryParse(txtStockProducto.Text, out int stock))
            {
                MessageBox.Show("Ingrese correctamente los datos del producto.");
                return;
            }

            if (precio <= 0 || stock < 0)
            {
                MessageBox.Show("El precio debe ser mayor que cero y el stock no puede ser negativo.");
                return;
            }

            Producto producto = new Producto(nombre, precio, stock);
            productos.Add(producto);
            lstProductos.Items.Add(producto);
            LimpiarProducto();
        }

        private void AbrirFactura(object sender, EventArgs e)
        {
            if (clientes.Count == 0)
            {
                MessageBox.Show("Debe registrar al menos un cliente.");
                return;
            }

            if (productos.Count == 0)
            {
                MessageBox.Show("Debe registrar al menos un producto.");
                return;
            }

            using (FormFactura formulario = new FormFactura(clientes, productos))
            {
                formulario.ShowDialog();
                ActualizarProductos();
            }
        }

        private void ActualizarProductos()
        {
            lstProductos.Items.Clear();

            foreach (Producto producto in productos)
                lstProductos.Items.Add(producto);
        }

        private void LimpiarCliente()
        {
            txtNombreCliente.Clear();
            txtCorreoCliente.Clear();
            txtTelefonoCliente.Clear();
        }

        private void LimpiarProducto()
        {
            txtNombreProducto.Clear();
            txtPrecioProducto.Clear();
            txtStockProducto.Clear();
        }
    }
}
