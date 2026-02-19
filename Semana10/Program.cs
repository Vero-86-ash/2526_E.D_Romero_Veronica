using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Random rnd = new Random();
    static HashSet<Ciudadano> conjuntoU;
    static HashSet<Ciudadano> conjuntoA;
    static HashSet<Ciudadano> conjuntoB;

    static void Main()
    {
        // ===============================
        // Mostrar cabecera
        // ===============================
        MostrarCabecera();

        // ===============================
        // Crear ciudadanos y vacunación inicial
        // ===============================
        conjuntoU = CrearUniverso(500);
        conjuntoA = GenerarVacunados(conjuntoU, 75, "Pfizer");
        conjuntoB = GenerarVacunados(conjuntoU, 75, "AstraZeneca", conjuntoA);

        // ===============================
        // Menú interactivo
        // ===============================
        bool salir = false;
        while (!salir)
        {
            MostrarMenu();
            string opcion = Console.ReadLine()?.Trim();

            switch (opcion)
            {
                case "1":
                    MostrarCiudadanos(conjuntoU);
                    break;
                case "2":
                    MostrarCiudadanos(conjuntoA, "Vacunados con Pfizer");
                    break;
                case "3":
                    MostrarCiudadanos(conjuntoB, "Vacunados con AstraZeneca");
                    break;
                case "4":
                    MostrarCiudadanos(conjuntoA.Intersect(conjuntoB).ToHashSet(), "Ambas dosis (Pfizer ∩ AstraZeneca)");
                    break;
                case "5":
                    MostrarCiudadanos(conjuntoA.Except(conjuntoB).ToHashSet(), "Solo Pfizer (Pfizer − AstraZeneca)");
                    break;
                case "6":
                    MostrarCiudadanos(conjuntoB.Except(conjuntoA).ToHashSet(), "Solo AstraZeneca (AstraZeneca − Pfizer)");
                    break;
                case "7":
                    MostrarCiudadanos(conjuntoU.Except(conjuntoA.Union(conjuntoB)).ToHashSet(), "No vacunados (U − (Pfizer ∪ AstraZeneca))");
                    break;
                case "8":
                    BuscarCiudadano();
                    break;
                case "9":
                    MostrarTotales();
                    break;
                case "10":
                    ModificarVacunacion();
                    break;
                case "0":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }
        }

        Console.WriteLine("\nFin del programa. Presione cualquier tecla para salir...");
        Console.ReadKey();
    }

    // ===============================
    // Cabecera
    // ===============================
    static void MostrarCabecera()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("====================================================");
        Console.WriteLine("Estudiante : Veronica Romero");
        Console.WriteLine("Carrera    : Tecnología de la Información");
        Console.WriteLine("Docente    : Ing. Santiago Israel Nogales Guerrero");
        Console.WriteLine("Año        : 2026");
        Console.WriteLine("====================================================");
        Console.ResetColor();
    }

    // ===============================
    // Mostrar menú
    // ===============================
    static void MostrarMenu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n============== MENÚ ==============");
        Console.WriteLine("1. Mostrar Universo (500 ciudadanos)");
        Console.WriteLine("2. Pfizer");
        Console.WriteLine("3. AstraZeneca");
        Console.WriteLine("4. Ambas dosis (Pfizer ∩ AstraZeneca)");
        Console.WriteLine("5. Solo Pfizer (Pfizer − AstraZeneca)");
        Console.WriteLine("6. Solo AstraZeneca (AstraZeneca − Pfizer)");
        Console.WriteLine("7. No vacunados (U − (Pfizer ∪ AstraZeneca))");
        Console.WriteLine("8. Buscar ciudadano por ID");
        Console.WriteLine("9. Mostrar totales");
        Console.WriteLine("10. Modificar vacunación de un ciudadano");
        Console.WriteLine("0. Salir");
        Console.WriteLine("=================================");
        Console.ResetColor();
        Console.Write("Seleccione opción: ");
    }

    // ===============================
    // Crear ciudadanos
    // ===============================
    static HashSet<Ciudadano> CrearUniverso(int total)
    {
        string[] nombres = { "Ana", "Luis", "Carlos", "Maria", "Pedro", "Lucia", "Sofia", "Miguel", "Juan", "Elena" };
        string[] apellidos = { "Perez", "Gomez", "Ruiz", "Torres", "Vera", "Castro", "Lopez", "Diaz", "Romero", "Mendoza" };

        HashSet<Ciudadano> ciudadanos = new HashSet<Ciudadano>();
        for (int i = 1; i <= total; i++)
        {
            ciudadanos.Add(new Ciudadano
            {
                Id = i,
                Nombre = nombres[rnd.Next(nombres.Length)],
                Apellido = apellidos[rnd.Next(apellidos.Length)]
            });
        }
        return ciudadanos;
    }

    // ===============================
    // Generar vacunados
    // ===============================
    static HashSet<Ciudadano> GenerarVacunados(HashSet<Ciudadano> universo, int cantidad, string vacuna, HashSet<Ciudadano> excluir = null)
    {
        var lista = universo.ToList();
        if (excluir != null)
            lista = lista.Except(excluir).ToList();

        HashSet<Ciudadano> vacunados = new HashSet<Ciudadano>();
        while (vacunados.Count < cantidad)
        {
            var c = lista[rnd.Next(lista.Count)];
            if (!c.Vacunas.Contains(vacuna))
            {
                c.Vacunas.Add(vacuna);
                vacunados.Add(c);
            }
        }
        return vacunados;
    }

    // ===============================
    // Mostrar ciudadanos
    // ===============================
    static void MostrarCiudadanos(HashSet<Ciudadano> conjunto, string titulo = "Ciudadanos")
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n=== {titulo} ===");
        Console.ResetColor();
        foreach (var c in conjunto.OrderBy(c => c.Id))
        {
            string vacunas = c.Vacunas.Count > 0 ? string.Join(", ", c.Vacunas) : "No vacunado";
            Console.WriteLine($"ID: {c.Id,3} | {c.Nombre} {c.Apellido} | Vacunas: {vacunas}");
        }
    }

    // ===============================
    // Mostrar totales
    // ===============================
    static void MostrarTotales()
    {
        var ambasDosis = conjuntoA.Intersect(conjuntoB).ToHashSet();
        var soloPfizer = conjuntoA.Except(conjuntoB).ToHashSet();
        var soloAstra = conjuntoB.Except(conjuntoA).ToHashSet();
        var noVacunados = conjuntoU.Except(conjuntoA.Union(conjuntoB)).ToHashSet();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n=== Totales ===");
        Console.ResetColor();
        Console.WriteLine($"Vacunados con Pfizer: {conjuntoA.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca: {conjuntoB.Count}");
        Console.WriteLine($"Ambas dosis: {ambasDosis.Count}");
        Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Solo AstraZeneca: {soloAstra.Count}");
        Console.WriteLine($"No vacunados: {noVacunados.Count}");
    }

    // ===============================
    // Buscar ciudadano por ID
    // ===============================
    static void BuscarCiudadano()
    {
        Console.Write("Ingrese ID del ciudadano a buscar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var ciudadano = conjuntoU.FirstOrDefault(c => c.Id == id);
        if (ciudadano != null)
        {
            string vacunas = ciudadano.Vacunas.Count > 0 ? string.Join(", ", ciudadano.Vacunas) : "No vacunado";
            Console.WriteLine($"ID: {ciudadano.Id} | {ciudadano.Nombre} {ciudadano.Apellido} | Vacunas: {vacunas}");
        }
        else
        {
            Console.WriteLine("Ciudadano no encontrado.");
        }
    }

    // ===============================
    // Modificar vacunación
    // ===============================
    static void ModificarVacunacion()
    {
        Console.Write("Ingrese ID del ciudadano a modificar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var ciudadano = conjuntoU.FirstOrDefault(c => c.Id == id);
        if (ciudadano == null)
        {
            Console.WriteLine("Ciudadano no encontrado.");
            return;
        }

        if (ciudadano.Vacunas.Count == 0)
        {
            ciudadano.Vacunas.Add("Pfizer");
            Console.WriteLine("El ciudadano estaba no vacunado → ahora tiene 1 dosis (Pfizer).");
        }
        else if (ciudadano.Vacunas.Count == 1)
        {
            string segunda = ciudadano.Vacunas.Contains("Pfizer") ? "AstraZeneca" : "Pfizer";
            ciudadano.Vacunas.Add(segunda);
            Console.WriteLine($"El ciudadano tenía 1 dosis → ahora tiene ambas dosis ({string.Join(", ", ciudadano.Vacunas)}).");
        }
        else
        {
            Console.WriteLine("El ciudadano ya tiene ambas dosis → no se hicieron cambios.");
        }

        // Actualizar conjuntos
        conjuntoA = conjuntoU.Where(c => c.Vacunas.Contains("Pfizer")).ToHashSet();
        conjuntoB = conjuntoU.Where(c => c.Vacunas.Contains("AstraZeneca")).ToHashSet();
    }
}

// ===============================
// Clase Ciudadano
// ===============================
class Ciudadano
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public HashSet<string> Vacunas { get; set; } = new HashSet<string>();

    public override bool Equals(object obj) => obj is Ciudadano c && Id == c.Id;
    public override int GetHashCode() => Id.GetHashCode();
}
