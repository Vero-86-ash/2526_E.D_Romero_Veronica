using System;
using System.Collections.Generic;
using System.Linq;

namespace DeberSemana05
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Mostrar();
        }
    }

    public class MenuPrincipal
    {
        public void Mostrar()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("====================================================");
                Console.WriteLine("       DEBER SEMANA 05 - PROGRAMACIÓN EN C#         ");
                Console.WriteLine("====================================================");
                Console.WriteLine("1. Ejercicio 1: Asignaturas de un curso");
                Console.WriteLine("2. Ejercicio 2: Lotería Primitiva");
                Console.WriteLine("3. Ejercicio 3: Números 5-14 Inverso");
                Console.WriteLine("4. Ejercicio 4: Abecedario (Múltiplos de 5)");
                Console.WriteLine("5. Ejercicio 5: Verificador de Palíndromos");
                Console.WriteLine("0. Salir");
                Console.WriteLine("----------------------------------------------------");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": Ejercicio1(); break;
                    case "2": Ejercicio2(); break;
                    case "3": Ejercicio3(); break;
                    case "4": Ejercicio4(); break;
                    case "5": Ejercicio5(); break;
                    case "0": continuar = false; break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\n----------------------------------------------------");
                    Console.WriteLine("Presione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                }
            }
        }

        private void MostrarEnunciado(int num, string enunciado)
        {
            Console.Clear();
            Console.WriteLine($"EJERCICIO {num}");
            Console.WriteLine($"Pregunta: {enunciado}");
            Console.WriteLine(new string('-', 50) + "\n");
        }

        private void Ejercicio1()
        {
            MostrarEnunciado(1,
                "Almacenar las asignaturas de un curso en una lista y mostrarlas por pantalla.");

            List<string> asignaturas = new List<string>
            {
                "Administración",
                "Estructura de Datos",
                "Fundamento Sistema Digital",
                "Metodología de la Información",
                "Instalación Eléctrica"
            };

            Console.WriteLine("Las asignaturas son:");
            foreach (string materia in asignaturas)
            {
                Console.WriteLine("- " + materia);
            }
        }

        private void Ejercicio2()
        {
            MostrarEnunciado(2,
                "Pedir los 6 números ganadores de la lotería primitiva, ordenarlos y mostrarlos.");

            List<int> numeros = new List<int>();

            Console.WriteLine("Ingrese los 6 números ganadores:");

            for (int i = 0; i < 6; i++)
            {
                Console.Write($"[{i + 1}/6] Ingrese número: ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    numeros.Add(num);
                }
                else
                {
                    Console.WriteLine("Entrada inválida, intente nuevamente.");
                    i--;
                }
            }

            numeros.Sort();
            Console.WriteLine("\nNúmeros ordenados:");
            Console.WriteLine(string.Join(" - ", numeros));
        }

        private void Ejercicio3()
        {
            MostrarEnunciado(3,
                "Mostrar los números del 5 al 14 en orden inverso.");

            for (int i = 14; i >= 5; i--)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        private void Ejercicio4()
        {
            MostrarEnunciado(4,
                "Eliminar del abecedario las letras en posiciones múltiplos de 5.");

            List<char> abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();

            for (int i = abecedario.Count - 1; i >= 0; i--)
            {
                if ((i + 1) % 5 == 0)
                {
                    abecedario.RemoveAt(i);
                }
            }

            Console.WriteLine("Letras restantes:");
            Console.WriteLine(string.Join(" ", abecedario));
        }

        private void Ejercicio5()
        {
            MostrarEnunciado(5,
                "Pedir una palabra y verificar si es un palíndromo.");

            Console.Write("Ingrese la palabra: ");
            string original = Console.ReadLine() ?? "";

            string procesada = original.ToLower().Replace(" ", "");

            char[] letras = procesada.ToCharArray();
            Array.Reverse(letras);
            string invertida = new string(letras);

            if (procesada == invertida && procesada != "")
                Console.WriteLine("RESULTADO: SÍ es un palíndromo.");
            else
                Console.WriteLine("RESULTADO: NO es un palíndromo.");
        }
    }
}
