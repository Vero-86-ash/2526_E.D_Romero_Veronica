using System;
using System.Collections.Generic;

class TraductorCompleto
{
    static Dictionary<string, string> diccionario = new Dictionary<string, string>();
    static int palabrasTraducidas = 0;

    static void Main()
    {
        InicializarDiccionario();
        int opcion = -1;

        do
        {
            Console.Clear();
            MostrarCabecera();

            Console.WriteLine("==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase (Español → Inglés)");
            Console.WriteLine("2. Agregar palabra al diccionario");
            Console.WriteLine("3. Mostrar diccionario");
            Console.WriteLine("4. Buscar una palabra");
            Console.WriteLine("5. Contar palabras traducidas");
            Console.WriteLine("6. Ayuda al usuario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string? entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out opcion))
            {
                Console.WriteLine("Opción inválida.");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase();
                    break;
                case 2:
                    AgregarPalabra();
                    break;
                case 3:
                    MostrarDiccionario();
                    break;
                case 4:
                    BuscarPalabra();
                    break;
                case 5:
                    MostrarConteo();
                    break;
                case 6:
                    AyudaUsuario();
                    break;
                case 0:
                    Console.WriteLine("Gracias por usar el traductor. ¡Hasta pronto!");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

        } while (opcion != 0);
    }

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

    static void InicializarDiccionario()
    {
        diccionario.Add("día", "day");
        diccionario.Add("ojo", "eye");
        diccionario.Add("amor", "love");
        diccionario.Add("familia", "family");
        diccionario.Add("amigo", "friend");
        diccionario.Add("casa", "house");
        diccionario.Add("escuela", "school");
        diccionario.Add("libro", "book");
        diccionario.Add("agua", "water");
        diccionario.Add("sol", "sun");
        diccionario.Add("mundo", "world");
        diccionario.Add("vida", "life");
        diccionario.Add("niño", "child");
        diccionario.Add("mujer", "woman");
        diccionario.Add("hombre", "man");
        diccionario.Add("trabajo", "work");
        diccionario.Add("tiempo", "time");

        diccionario.Add("feliz", "happy");
        diccionario.Add("triste", "sad");
        diccionario.Add("hermoso", "beautiful");
        diccionario.Add("grande", "big");
        diccionario.Add("pequeño", "small");
        diccionario.Add("bueno", "good");
        diccionario.Add("malo", "bad");

        diccionario.Add("es", "is");
        diccionario.Add("soy", "am");
        diccionario.Add("eres", "are");
        diccionario.Add("somos", "are");
        diccionario.Add("tiene", "has");
        diccionario.Add("tengo", "have");
        diccionario.Add("ver", "see");
        diccionario.Add("ve", "sees");
        diccionario.Add("ir", "go");
        diccionario.Add("vamos", "go");
        diccionario.Add("comer", "eat");
        diccionario.Add("beber", "drink");
        diccionario.Add("vivir", "live");
        diccionario.Add("amar", "love");

        diccionario.Add("el", "the");
        diccionario.Add("la", "the");
        diccionario.Add("los", "the");
        diccionario.Add("las", "the");
        diccionario.Add("un", "a");
        diccionario.Add("una", "a");

        diccionario.Add("y", "and");
        diccionario.Add("o", "or");
        diccionario.Add("pero", "but");
        diccionario.Add("porque", "because");
        diccionario.Add("que", "that");
        diccionario.Add("con", "with");
        diccionario.Add("sin", "without");
        diccionario.Add("en", "in");
        diccionario.Add("de", "of");
        diccionario.Add("para", "for");
        diccionario.Add("por", "by");
        diccionario.Add("este", "this");
        diccionario.Add("esa", "that");
        diccionario.Add("mi", "my");
        diccionario.Add("tu", "your");
    }

    static void TraducirFrase()
    {
        Console.Write("\nIngrese una frase: ");
        string? frase = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(frase))
        {
            Console.WriteLine("No ingresó ninguna frase.");
            return;
        }

        string[] palabras = frase.Split(' ');
        string traduccion = "";
        palabrasTraducidas = 0;

        foreach (string palabra in palabras)
        {
            string limpia = palabra.ToLower().Trim(',', '.', ';', ':', '¿', '?', '¡', '!');

            if (diccionario.ContainsKey(limpia))
            {
                traduccion += diccionario[limpia] + " ";
                palabrasTraducidas++;
            }
            else
            {
                traduccion += palabra + " ";
            }
        }

        Console.WriteLine("\nTraducción:");
        Console.WriteLine(traduccion);
    }

    static void AgregarPalabra()
    {
        Console.Write("\nIngrese palabra en español: ");
        string? esp = Console.ReadLine();

        Console.Write("Ingrese traducción en inglés: ");
        string? ing = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(esp) || string.IsNullOrWhiteSpace(ing))
        {
            Console.WriteLine("Datos inválidos.");
            return;
        }

        esp = esp.ToLower();
        ing = ing.ToLower();

        if (!diccionario.ContainsKey(esp))
        {
            diccionario.Add(esp, ing);
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }

    static void MostrarDiccionario()
    {
        Console.WriteLine("\nDiccionario completo:\n");
        foreach (var item in diccionario)
        {
            Console.WriteLine(item.Key + " -> " + item.Value);
        }
    }

    static void BuscarPalabra()
    {
        Console.Write("\nIngrese la palabra a buscar: ");
        string? palabra = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(palabra))
        {
            Console.WriteLine("Entrada inválida.");
            return;
        }

        palabra = palabra.ToLower();

        if (diccionario.ContainsKey(palabra))
        {
            Console.WriteLine("Traducción: " + diccionario[palabra]);
        }
        else
        {
            Console.WriteLine("La palabra no existe en el diccionario.");
        }
    }

    static void MostrarConteo()
    {
        Console.WriteLine("\nCantidad de palabras traducidas en la última frase: " + palabrasTraducidas);
    }

    static void AyudaUsuario()
    {
        Console.WriteLine("\n=== AYUDA DEL SISTEMA ===");
        Console.WriteLine("1. Traduce una frase al inglés.");
        Console.WriteLine("2. Permite agregar nuevas palabras.");
        Console.WriteLine("3. Muestra todas las palabras del diccionario.");
        Console.WriteLine("4. Busca una palabra específica.");
        Console.WriteLine("5. Cuenta cuántas palabras fueron traducidas.");
        Console.WriteLine("0. Sale del programa.");
        Console.WriteLine("Solo se traducen las palabras que existen en el diccionario.");
    }
}
