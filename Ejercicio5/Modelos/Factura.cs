using System;
using System.Collections.Generic;

namespace Ejercicio5_POO.Modelos
{
    public class Factura
    {
        public Cliente Cliente { get; set; }
        public List<Producto> Productos { get; set; }
        public List<int> Cantidades { get; set; }

        public Factura(Cliente cliente)
        {
            Cliente = cliente;
            Productos = new List<Producto>();
            Cantidades = new List<int>();
        }

        public void AgregarProducto(Producto producto, int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");

            if (cantidad > producto.Stock)
                throw new InvalidOperationException("La cantidad supera el stock disponible.");

            Productos.Add(producto);
            Cantidades.Add(cantidad);
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;

            for (int i = 0; i < Productos.Count; i++)
                total += Productos[i].PrecioUnitario * Cantidades[i];

            return total;
        }

        public void ActualizarStock()
        {
            for (int i = 0; i < Productos.Count; i++)
                Productos[i].Stock -= Cantidades[i];
        }
    }
}
