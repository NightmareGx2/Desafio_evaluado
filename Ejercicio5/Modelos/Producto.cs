namespace Ejercicio5_POO.Modelos
{
    public class Producto
    {
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }

        public Producto(string nombre, decimal precioUnitario, int stock)
        {
            Nombre = nombre;
            PrecioUnitario = precioUnitario;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"{Nombre} - ${PrecioUnitario:N2} - Stock: {Stock}";
        }
    }
}
