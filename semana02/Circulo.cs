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
