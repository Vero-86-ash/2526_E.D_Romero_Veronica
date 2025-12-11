using System;

namespace FigurasGeometricas
{
    // Clase para representar un Cuadrado
    public class Cuadrado
    {
        // Atributo privado para almacenar el lado
        private double _lado;

        // Propiedad pública que encapsula el atributo '_lado'
        public double Lado
        {
            get { return _lado; }
            set
            {
                // Validación: el lado debe ser positivo
                if (value > 0)
                {
                    _lado = value;
                }
                else
                {
                    Console.WriteLine("El lado debe ser un valor positivo.");
                    _lado = 1.0; // Valor por defecto
                }
            }
        }

        // Constructor
        public Cuadrado(double ladoInicial)
        {
            this.Lado = ladoInicial; // Usa la propiedad para validar
        }

        // Método para calcular el área del cuadrado
        // Fórmula: Área = lado²
        public double CalcularArea()
        {
            return Math.Pow(Lado, 2);
        }

        // Método para calcular el perímetro del cuadrado
        // Fórmula: Perímetro = 4 * lado
        public double CalcularPerimetro()
        {
            return 4 * Lado;
        }

        // Método para mostrar información del cuadrado
        public void MostrarInformacion()
        {
            Console.WriteLine($"Cuadrado con lado: {Lado}");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
        }
    }

    // Clase principal para ejecutar el programa
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DEMOSTRACIÓN DE LA CLASE CUADRADO ===\n");

            // Crear un cuadrado con un lado válido
            Cuadrado cuadrado1 = new Cuadrado(4.0);
            Console.WriteLine("Cuadrado 1 (lado = 4.0):");
            cuadrado1.MostrarInformacion();
            Console.WriteLine();

            // Crear un cuadrado con lado inválido
            Console.WriteLine("Intentando crear un cuadrado con lado negativo:");
            Cuadrado cuadradoInvalido = new Cuadrado(-2.0);
            cuadradoInvalido.MostrarInformacion();
            Console.WriteLine();

            // Cambiar el lado después de crear el objeto
            Console.WriteLine("Cambiando el lado del cuadrado 1 a 6.5:");
            cuadrado1.Lado = 6.5;
            cuadrado1.MostrarInformacion();
            Console.WriteLine();

            // Crear otro cuadrado
            Cuadrado cuadrado2 = new Cuadrado(3.0);
            Console.WriteLine("Cuadrado 2 (lado = 3.0):");
            Console.WriteLine($"Lado: {cuadrado2.Lado}");
            Console.WriteLine($"Área calculada: {cuadrado2.CalcularArea():F4}");
            Console.WriteLine($"Perímetro calculado: {cuadrado2.CalcularPerimetro():F4}");
            Console.WriteLine();

            // Demostración con valores decimales
            Console.WriteLine("Cuadrado con lado decimal (2.5):");
            Cuadrado cuadrado3 = new Cuadrado(2.5);
            Console.WriteLine($"Área: {cuadrado3.CalcularArea()}");
            Console.WriteLine($"Perímetro: {cuadrado3.CalcularPerimetro()}");
            Console.WriteLine();

            Console.WriteLine("Programa finalizado. Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
