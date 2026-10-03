using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ejercicio5_POO.Modelos;

namespace Ejercicio5_POO.Formularios
{
    public class FormFactura : Form
    {
        private readonly List<Cliente> clientes;
        private readonly List<Producto> productos;
        private Factura factura;

        private ComboBox cmbClientes;
        private ComboBox cmbProductos;
        private NumericUpDown nudCantidad;
        private ListBox lstFactura;
        private Label lblTotal;

        public FormFactura(List<Cliente> clientes, List<Producto> productos)
        {
            this.clientes = clientes;
            this.productos = productos;

            Text = "Crear Factura";
            Size = new Size(750, 550);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            CrearInterfaz();
            CargarDatos();
        }

        private void CrearInterfaz()
        {
            Label titulo = new Label
            {
                Text = "Nueva Factura",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(285, 20)
            };
            Controls.Add(titulo);

            Label lblCliente = new Label
            {
                Text = "Cliente:",
                AutoSize = true,
                Location = new Point(40, 80)
            };
            Controls.Add(lblCliente);

            cmbClientes = new ComboBox
            {
                Location = new Point(110, 76),
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbClientes.SelectedIndexChanged += SeleccionarCliente;
            Controls.Add(cmbClientes);

            Label lblProducto = new Label
            {
                Text = "Producto:",
                AutoSize = true,
                Location = new Point(40, 125)
            };
            Controls.Add(lblProducto);

            cmbProductos = new ComboBox
            {
                Location = new Point(110, 121),
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            Controls.Add(cmbProductos);

            Label lblCantidad = new Label
            {
                Text = "Cantidad:",
                AutoSize = true,
                Location = new Point(400, 125)
            };
            Controls.Add(lblCantidad);

            nudCantidad = new NumericUpDown
            {
                Location = new Point(470, 121),
                Width = 100,
                Minimum = 1,
                Maximum = 100000
            };
            Controls.Add(nudCantidad);

            Button btnAgregar = new Button
            {
                Text = "Agregar producto",
                Location = new Point(250, 170),
                Size = new Size(220, 35)
            };
            btnAgregar.Click += AgregarProducto;
            Controls.Add(btnAgregar);

            lstFactura = new ListBox
            {
                Location = new Point(40, 230),
                Size = new Size(650, 160)
            };
            Controls.Add(lstFactura);

            lblTotal = new Label
            {
                Text = "Total: $0.00",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(40, 410)
            };
            Controls.Add(lblTotal);

            Button btnCrear = new Button
            {
                Text = "Generar factura",
                Location = new Point(500, 405),
                Size = new Size(190, 40)
            };
            btnCrear.Click += GenerarFactura;
            Controls.Add(btnCrear);
        }

        private void CargarDatos()
        {
            foreach (Cliente cliente in clientes)
                cmbClientes.Items.Add(cliente);

            foreach (Producto producto in productos)
                cmbProductos.Items.Add(producto);

            if (cmbClientes.Items.Count > 0)
                cmbClientes.SelectedIndex = 0;
        }

        private void SeleccionarCliente(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedItem is Cliente cliente)
                factura = new Factura(cliente);
        }

        private void AgregarProducto(object sender, EventArgs e)
        {
            if (factura == null)
            {
                MessageBox.Show("Seleccione un cliente.");
                return;
            }

            if (!(cmbProductos.SelectedItem is Producto producto))
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            int cantidad = (int)nudCantidad.Value;

            try
            {
                factura.AgregarProducto(producto, cantidad);
                lstFactura.Items.Add($"{producto.Nombre} x {cantidad} = ${producto.PrecioUnitario * cantidad:N2}");
                lblTotal.Text = $"Total: ${factura.CalcularTotal():N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GenerarFactura(object sender, EventArgs e)
        {
            if (factura == null)
            {
                MessageBox.Show("Seleccione un cliente.");
                return;
            }

            if (factura.Productos.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto.");
                return;
            }

            factura.ActualizarStock();

            MessageBox.Show(
                $"Factura generada correctamente.\nCliente: {factura.Cliente.Nombre}\nTotal: ${factura.CalcularTotal():N2}",
                "Factura");

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
