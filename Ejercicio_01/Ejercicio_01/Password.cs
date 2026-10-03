using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_01
{
    // Creamos la clase Password y sus atributos y métodos
    public class Password
    {
        // atributos de la clase
        private int longitud;
        private string contraseña;
        
        // Constructor de la clase
        public Password()
        {
            // le damos una longitud por defecto de 8
            longitud = 8;

            // le damos una contraseña inicial
            contraseña = "12345678";
        }

        // GET de contraseña este nos permite obtener la contraseña almacenada
        public string GetContraseña()
        {
            return contraseña;
        }

        // GET de longitud igual nos permite obtener la longitud de la contraseña
        public int GetLongitud()
        {
            return longitud;
        }

        // SET de longitud permite cambiar la longitud de la contraseña
        public void SetLongitud(int longitud)
        {
            
            this.longitud = longitud; // usamos this para referirnos al atributo de la clase
        }

        // SET de contraseña permite cambiar la contraseña almacenada
        public void SetContraseña(string contraseña)
        {
            this.contraseña = contraseña;
        }

        // Método que verifica si la contraseña es fuerte
        public bool esFuerte()
        {
         
            int mayusculas = 0;
            int minusculas = 0;
            int numeros = 0;

            // Verificamos uno a uno los caracteres de la contraseña
            foreach (char caracter in contraseña)
            {
                // Verificamos si el carácter es una mayúscula
                if (char.IsUpper(caracter))
                {
                    mayusculas++;
                }

                // Si no es mayúscula, verificamos si es minúscula
                else if (char.IsLower(caracter))
                {
                    minusculas++;
                }

                // Si tampoco es minúscula, verificamos si es un número
                else if (char.IsDigit(caracter))
                {
                    numeros++;
                }
            }

            // La contraseña será fuerte si tiene:
            // Más de 1 mayúscula = mínimo 2
            // Más de 0 minúsculas = mínimo 1
            // Más de 4 números = mínimo 5
            // Esto para cumplir con los requisitos de longitud y seguridad
            return mayusculas > 1 &&
                   minusculas > 0 &&
                   numeros > 4;
        }

        // Método encargado de generar una contraseña
        public void generarPassword()
        {
            // Si ingresamos una longitud menor a 8, la ajustamos para que si o si sea de 8
            if (longitud < 8)
            {
                longitud = 8;
            }

            // Ponemos los caracteres en conjuntos de mayúsculas, minúsculas y números
            string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string minusculas = "abcdefghijklmnopqrstuvwxyz";
            string numeros = "0123456789";

            // Creamos un objeto Random para seleccionar los caracteres aleatoriamente
            Random random = new Random();

            //antes de generar la contraseña, la inicializamos como una cadena vacía
            contraseña = "";


            //Esto nos sirve para asegurarnos de que la contraseña generada cumpla con los requisitos de longitud y seguridad
            
            // Generamos 2 letras mayúsculas.
            for (int i = 0; i < 2; i++)
            {
                contraseña += mayusculas[random.Next(mayusculas.Length)];
            }

            // Generamos 1 letra minúscula.
            for (int i = 0; i < 1; i++)
            {
                contraseña += minusculas[random.Next(minusculas.Length)];
            }

            // Generamos 5 números.
            for (int i = 0; i < 5; i++)
            {
                contraseña += numeros[random.Next(numeros.Length)];
            }
        }
    }
}
