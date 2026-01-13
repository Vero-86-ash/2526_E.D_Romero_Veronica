using System;

namespace ProyectoListas
{
    // ===================== NODO =====================
    class Nodo
    {
        public int Dato;
        public Nodo Siguiente;

        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // ===================== LISTA ENLAZADA =====================
    class Lista
    {
        private Nodo cabeza;

        // Agregar al final
        public void AgregarFinal(int dato)
        {
            Nodo nuevo = new Nodo(dato);

            if (cabeza == null)
                cabeza = nuevo;
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                    actual = actual.Siguiente;

                actual.Siguiente = nuevo;
            }
        }

        // Agregar al inicio
        public void AgregarInicio(int dato)
        {
            Nodo nuevo = new Nodo(dato);
            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
        }

        // Mostrar lista
        public void Mostrar()
        {
            Nodo actual = cabeza;

            if (actual == null)
            {
                Console.WriteLine("Lista vacía.");
                return;
            }

            while (actual != null)
            {
                Console.Write(actual.Dato + " -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null");
        }

        // Contar nodos
        public int Contar()
        {
            int contador = 0;
            Nodo actual = cabeza;

            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

        // ===== ELIMINAR FUERA DE RANGO Y GUARDAR ELIMINADOS =====
        public void EliminarFueraDeRango(int min, int max, Lista eliminados)
        {
            // Eliminar desde el inicio
            while (cabeza != null && (cabeza.Dato < min || cabeza.Dato > max))
            {
                eliminados.AgregarFinal(cabeza.Dato);
                cabeza = cabeza.Siguiente;
            }

            Nodo actual = cabeza;

            while (actual != null && actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato < min || actual.Siguiente.Dato > max)
                {
                    eliminados.AgregarFinal(actual.Siguiente.Dato);
                    actual.Siguiente = actual.Siguiente.Siguiente;
                }
                else
                {
                    actual = actual.Siguiente;
                }
            }
        }
    }

    // ===================== PROGRAMA PRINCIPAL =====================
    class Program
    {
        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("====================================================");
                Console.WriteLine("        TAREA SEMANA 06 - PROGRAMACIÓN EN C#        ");
                Console.WriteLine("====================================================");
                Console.WriteLine("Estudiante : Veronica Romero");
                Console.WriteLine("Carrera    : Tecnología de la Información");
                Console.WriteLine("Paralelo   : B");
                Console.WriteLine("Docente    : Ing. Santiago Israel Nogales Guerrero");
                Console.WriteLine("Año        : 2026");
                Console.WriteLine("====================================================\n");

                Console.WriteLine("1. Ejercicio 1: Listas con rango");
                Console.WriteLine("2. Ejercicio 2: Lista de primos y Armstrong");
                Console.WriteLine("3. Salir\n");
                Console.Write("Elige una opción: ");

                opcion = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        Ejercicio1();
                        break;
                    case 2:
                        Ejercicio2();
                        break;
                    case 3:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (opcion != 3)
                {
                    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                }

            } while (opcion != 3);
        }

        // ===================== EJERCICIO 1 =====================
        static void Ejercicio1()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("EJERCICIO 1: LISTAS CON RANGO");
            Console.WriteLine("====================================================");
            Console.WriteLine("Se generan 50 números aleatorios entre 1 y 999");
            Console.WriteLine("Luego se eliminan los números fuera de un rango");
            Console.WriteLine("====================================================\n");

            Lista lista = new Lista();
            Lista eliminados = new Lista();
            Random rnd = new Random();

            for (int i = 0; i < 50; i++)
                lista.AgregarFinal(rnd.Next(1, 1000));

            Console.WriteLine("Lista original:");
            lista.Mostrar();

            Console.Write("\nIngrese el valor mínimo del rango: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el valor máximo del rango: ");
            int max = int.Parse(Console.ReadLine());

            lista.EliminarFueraDeRango(min, max, eliminados);

            Console.WriteLine("\nLista después de eliminar valores fuera del rango:");
            lista.Mostrar();

            Console.WriteLine("\nValores eliminados:");
            eliminados.Mostrar();
        }

        // ===================== EJERCICIO 2 =====================
        static void Ejercicio2()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("EJERCICIO 2: LISTA DE PRIMOS Y ARMSTRONG");
            Console.WriteLine("====================================================");
            Console.WriteLine("• Primos → se agregan al final");
            Console.WriteLine("• Armstrong → se agregan al inicio");
            Console.WriteLine("====================================================\n");

            Lista primos = new Lista();
            Lista armstrong = new Lista();

            Console.Write("Ingrese la cantidad de números: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Ingrese un número: ");
                int num = int.Parse(Console.ReadLine());

                if (EsPrimo(num))
                    primos.AgregarFinal(num);

                if (EsArmstrong(num))
                    armstrong.AgregarInicio(num);
            }

            Console.WriteLine("\nCantidad de números primos: " + primos.Contar());
            Console.WriteLine("Cantidad de números Armstrong: " + armstrong.Contar());

            if (primos.Contar() > armstrong.Contar())
                Console.WriteLine("La lista de primos tiene más elementos.");
            else if (armstrong.Contar() > primos.Contar())
                Console.WriteLine("La lista de Armstrong tiene más elementos.");
            else
                Console.WriteLine("Ambas listas tienen la misma cantidad de elementos.");

            Console.WriteLine("\nLista de números primos:");
            primos.Mostrar();

            Console.WriteLine("\nLista de números Armstrong:");
            armstrong.Mostrar();
        }

        // ===================== MÉTODOS AUXILIARES =====================
        static bool EsPrimo(int n)
        {
            if (n <= 1) return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        static bool EsArmstrong(int n)
        {
            int original = n, suma = 0;
            int digitos = n.ToString().Length;

            while (n > 0)
            {
                int d = n % 10;
                suma += (int)Math.Pow(d, digitos);
                n /= 10;
            }

            return suma == original;
        }
    }
}

