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
