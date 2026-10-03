namespace Ejercicio5_POO.Modelos
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public Cliente(string nombre, string correo, string telefono)
        {
            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
        }

        public override string ToString()
        {
            return $"{Nombre} - {Correo} - {Telefono}";
        }
    }
}
