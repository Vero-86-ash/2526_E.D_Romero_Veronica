using System;

namespace FigurasGeometricas
{
    // Clase para representar un Círculo
    public class Circulo
    {
        // Atributo privado para almacenar el radio
        private double _radio;

        // Propiedad pública que encapsula el atributo '_radio'
        public double Radio
        {
            get { return _radio; }
            set
            {
                // Validación: el radio no puede ser negativo
                if (value > 0)
                {
                    _radio = value;
                }
                else
                {
                    // Si se intenta asignar un valor inválido
                    Console.WriteLine("El radio debe ser un valor positivo.");
                    _radio = 1.0; // Valor por defecto
                }
            }
        }

        // Constructor de la clase Círculo
        public Circulo(double radioInicial)
        {
            this.Radio = radioInicial; // Utiliza la propiedad 'Radio' para la asignación inicial
        }

        // Método para calcular el Área del círculo
        // Fórmula: Área = π * radio²
        public double CalcularArea()
        {
            return Math.PI * Math.Pow(Radio, 2);
        }

        // Método para calcular el Perímetro (Circunferencia) del círculo
        // Fórmula: Perímetro = 2 * π * radio
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * Radio;
        }

        // Método adicional para mostrar información del círculo
        public void MostrarInformacion()
        {
            Console.WriteLine($"Círculo con radio: {Radio}");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
        }
    }

    // Clase principal para ejecutar el programa
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DEMOSTRACIÓN DE LA CLASE CÍRCULO ===\n");

            // Crear un círculo con radio válido
            Circulo miCirculo = new Circulo(5.0);
            Console.WriteLine("Círculo 1 (radio = 5.0):");
            miCirculo.MostrarInformacion();
            Console.WriteLine();

            // Crear un círculo con radio inválido
            Console.WriteLine("Intentando crear círculo con radio negativo:");
            Circulo circuloInvalido = new Circulo(-3.0);
            circuloInvalido.MostrarInformacion();
            Console.WriteLine();

            // Probar cambiar el radio después de crear el objeto
            Console.WriteLine("Cambiando el radio del primer círculo a 7.5:");
            miCirculo.Radio = 7.5;
            miCirculo.MostrarInformacion();
            Console.WriteLine();

            // Crear otro círculo con datos diferentes
            Circulo circulo2 = new Circulo(3.0);
            Console.WriteLine("Círculo 2 (radio = 3.0):");
            Console.WriteLine($"Radio: {circulo2.Radio}");
            Console.WriteLine($"Área calculada: {circulo2.CalcularArea():F4}");
            Console.WriteLine($"Perímetro calculado: {circulo2.CalcularPerimetro():F4}");
            Console.WriteLine();

            // Demostración con valores decimales
            Console.WriteLine("Círculo con radio decimal (2.5):");
            Circulo circulo3 = new Circulo(2.5);
            Console.WriteLine($"Área: {circulo3.CalcularArea()}");
            Console.WriteLine($"Perímetro: {circulo3.CalcularPerimetro()}");
            Console.WriteLine();

            Console.WriteLine("Programa finalizado. Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
