/*
====================================================
Descripción:
Uso de la estructura de datos Pila (Stack) para:
1) Verificar paréntesis, llaves y corchetes balanceados
   en una expresión matemática.
2) Problema de las Torres de Hanoi mostrando
   paso a paso los movimientos de los discos.
====================================================
*/

using System;
using System.Collections.Generic;

class Program
{
    static int contadorMovimientos = 0;

    static void Main()
    {
        int opcion;

        do
        {
            MostrarEncabezado();
            Console.WriteLine("\n===== MENÚ PRINCIPAL =====");
            Console.WriteLine("1. Verificar paréntesis balanceados");
            Console.WriteLine("2. Resolver Torres de Hanoi con pilas");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            while (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.Write("Ingrese una opción válida: ");
            }

            switch (opcion)
            {
                case 1:
                    VerificarParentesis();
                    break;

                case 2:
                    TorresDeHanoi();
                    break;

                case 0:
                    Console.WriteLine("\nPrograma finalizado.");
                    break;

                default:
                    Console.WriteLine("\nOpción no válida.");
                    break;
            }

            if (opcion != 0)
            {
                Console.WriteLine("\nPresione una tecla para volver al menú...");
                Console.ReadKey();
            }

        } while (opcion != 0);
    }

    // ===============================
    // ENCABEZADO EN CONSOLA
    // ===============================
    static void MostrarEncabezado()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("====================================================");
        Console.WriteLine("TAREA SEMANA 07 - PROGRAMACIÓN EN C#");
        Console.WriteLine("====================================================");
        Console.WriteLine("Estudiante : Veronica Romero");
        Console.WriteLine("Carrera    : Tecnología de la Información");
        Console.WriteLine("Paralelo   : B");
        Console.WriteLine("Docente    : Ing. Santiago Israel Nogales Guerrero");
        Console.WriteLine("Año        : 2026");
        Console.WriteLine("====================================================");
        Console.ResetColor();
    }

    // ===============================
    // EJERCICIO 1: VERIFICACIÓN DE PARÉNTESIS
    // ===============================
    static void VerificarParentesis()
    {
        MostrarEncabezado();
        Console.WriteLine("\n=== VERIFICACIÓN DE PARÉNTESIS ===");

        Console.WriteLine("\nEl programa verifica los siguientes símbolos:");
        Console.WriteLine("Paréntesis  : ( )");
        Console.WriteLine("Llaves      : { }");
        Console.WriteLine("Corchetes   : [ ]");

        Console.WriteLine("\nNota:");
        Console.WriteLine("• Los números, letras y operadores se ignoran.");
        Console.WriteLine("• Solo se valida el cierre correcto de los símbolos.");

        Console.WriteLine("\nEjemplo:");
        Console.WriteLine("(5 + 3) * [2 + (4 - 1)]");

        Console.Write("\nIngrese una expresión: ");
        string expresion = Console.ReadLine();

        Stack<char> pila = new Stack<char>();
        bool balanceado = true;

        foreach (char c in  expresion)
        {
            if ("({[".Contains(c))
            {
                pila.Push(c);
            }
            else if (")}]".Contains(c))
            {
                if (pila.Count == 0)
                {
                    balanceado = false;
                    break;
                }

                char ultimo = pila.Pop();

                if ((c == ')' && ultimo != '(') ||
                    (c == '}' && ultimo != '{') ||
                    (c == ']' && ultimo != '['))
                {
                    balanceado = false;
                    break;
                }
            }
        }

        Console.ForegroundColor = (balanceado && pila.Count == 0)
            ? ConsoleColor.Green
            : ConsoleColor.Red;

        Console.WriteLine(balanceado && pila.Count == 0
            ? "\n✔ Fórmula balanceada"
            : "\n✖ Fórmula NO balanceada");

        Console.ResetColor();
    }

    // ===============================
    // EJERCICIO 2: TORRES DE HANOI
    // ===============================
    static void TorresDeHanoi()
    {
        MostrarEncabezado();
        Console.WriteLine("\n=== TORRES DE HANOI ===");
        Console.Write("Ingrese el número de discos: ");

        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Ingrese un número válido mayor a 0: ");
        }

        Stack<string> origen = new Stack<string>();
        Stack<string> destino = new Stack<string>();
        Stack<string> auxiliar = new Stack<string>();

        for (int i = n; i >= 1; i--)
            origen.Push("Disco " + i);

        contadorMovimientos = 0;

        ResolverHanoi(n, origen, destino, auxiliar,
                      "Origen", "Destino", "Auxiliar");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nTotal de movimientos realizados: {contadorMovimientos}");
        Console.ResetColor();
    }

    static void ResolverHanoi(int n, Stack<string> origen,
                              Stack<string> destino, Stack<string> auxiliar,
                              string nomOrigen, string nomDestino,
                              string nomAuxiliar)
    {
        if (n == 0) return;

        ResolverHanoi(n - 1, origen, auxiliar, destino,
                      nomOrigen, nomAuxiliar, nomDestino);

        string disco = origen.Pop();
        destino.Push(disco);
        contadorMovimientos++;

        Console.WriteLine($"Movimiento {contadorMovimientos}: {disco} de {nomOrigen} a {nomDestino}");
        MostrarTorres(origen, destino, auxiliar);

        ResolverHanoi(n - 1, auxiliar, destino, origen,
                      nomAuxiliar, nomDestino, nomOrigen);
    }

    static void MostrarTorres(Stack<string> o, Stack<string> d, Stack<string> a)
    {
        Console.WriteLine("Origen   : " + string.Join(", ", o));
        Console.WriteLine("Destino  : " + string.Join(", ", d));
        Console.WriteLine("Auxiliar : " + string.Join(", ", a));
        Console.WriteLine("-----------------------------------");
    }
}


