using System;
using System.Collections.Generic;

namespace RegistroEstudiantes
{
    // Clase que representa a un estudiante
    public class Estudiante
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; }

        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            ID = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Telefonos = telefonos;
        }

        // Mostrar la información en un "cuadro"
        public void MostrarCuadro()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  {i + 1}. {Telefonos[i]}");
            }
            Console.WriteLine("=======================================\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            int id = 1; // ID inicial

            while (true)
            {
                // Mostrar menú
                Console.WriteLine("\n=== MENÚ DE ESTUDIANTES ===");
                Console.WriteLine("1. Registrar estudiante");
                Console.WriteLine("2. Ver estudiantes registrados");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine()!;

                if (opcion == "1")
                {
                    // Registrar estudiante
                    Console.Write("Nombres: ");
                    string nombres = Console.ReadLine()!;

                    Console.Write("Apellidos: ");
                    string apellidos = Console.ReadLine()!;

                    Console.Write("Dirección: ");
                    string direccion = Console.ReadLine()!;

                    string[] telefonos = new string[3];
                    Console.WriteLine("Ingrese 3 números de teléfono:");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write($"Teléfono {i + 1}: ");
                        telefonos[i] = Console.ReadLine()!;
                    }

                    Estudiante nuevo = new Estudiante(id, nombres, apellidos, direccion, telefonos);
                    estudiantes.Add(nuevo);
                    Console.WriteLine("\nEstudiante registrado exitosamente.");
                    id++; // Incrementa ID
                }
                else if (opcion == "2")
                {
                    // Mostrar todos los estudiantes
                    if (estudiantes.Count == 0)
                    {
                        Console.WriteLine("\nNo hay estudiantes registrados.");
                    }
                    else
                    {
                        Console.WriteLine("\n=== ESTUDIANTES REGISTRADOS ===");
                        foreach (var estudiante in estudiantes)
                        {
                            estudiante.MostrarCuadro();
                        }
                    }
                }
                else if (opcion == "3")
                {
                    Console.WriteLine("Saliendo del programa....");
                    break;
                }
                else
                {
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                }
            }
        }
    }
}


