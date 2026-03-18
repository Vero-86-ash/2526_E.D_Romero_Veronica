using System;

class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

class ArbolBST
{
    public Nodo Raiz;

    public Nodo Insertar(Nodo nodo, int valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izquierdo = Insertar(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = Insertar(nodo.Derecho, valor);

        return nodo;
    }

    public bool Buscar(Nodo nodo, int valor)
    {
        if (nodo == null) return false;

        if (valor == nodo.Valor)
            return true;
        else if (valor < nodo.Valor)
            return Buscar(nodo.Izquierdo, valor);
        else
            return Buscar(nodo.Derecho, valor);
    }

    public int Minimo(Nodo nodo)
    {
        while (nodo.Izquierdo != null)
            nodo = nodo.Izquierdo;
        return nodo.Valor;
    }

    public int Maximo(Nodo nodo)
    {
        while (nodo.Derecho != null)
            nodo = nodo.Derecho;
        return nodo.Valor;
    }

    public Nodo Eliminar(Nodo nodo, int valor)
    {
        if (nodo == null) return nodo;

        if (valor < nodo.Valor)
            nodo.Izquierdo = Eliminar(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = Eliminar(nodo.Derecho, valor);
        else
        {
            if (nodo.Izquierdo == null && nodo.Derecho == null)
                return null;

            if (nodo.Izquierdo == null)
                return nodo.Derecho;

            if (nodo.Derecho == null)
                return nodo.Izquierdo;

            int minValor = Minimo(nodo.Derecho);
            nodo.Valor = minValor;
            nodo.Derecho = Eliminar(nodo.Derecho, minValor);
        }

        return nodo;
    }

    public void Inorden(Nodo nodo)
    {
        if (nodo != null)
        {
            Inorden(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            Inorden(nodo.Derecho);
        }
    }

    public void Preorden(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            Preorden(nodo.Izquierdo);
            Preorden(nodo.Derecho);
        }
    }

    public void Postorden(Nodo nodo)
    {
        if (nodo != null)
        {
            Postorden(nodo.Izquierdo);
            Postorden(nodo.Derecho);
            Console.Write(nodo.Valor + " ");
        }
    }

    public int Altura(Nodo nodo)
    {
        if (nodo == null) return -1;
        return Math.Max(Altura(nodo.Izquierdo), Altura(nodo.Derecho)) + 1;
    }

    public void Limpiar()
    {
        Raiz = null;
    }

    public void MostrarArbol(Nodo nodo, int espacio = 0, int incremento = 6)
    {
        if (nodo == null) return;

        espacio += incremento;

        MostrarArbol(nodo.Derecho, espacio);

        Console.WriteLine();
        Console.Write(new string(' ', espacio - incremento));
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(nodo.Valor);
        Console.ResetColor();

        MostrarArbol(nodo.Izquierdo, espacio);
    }
}

class Program
{
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

    static void Main()
    {
        ArbolBST arbol = new ArbolBST();
        int opcion = -1;

        do
        {
            Console.Clear();
            MostrarCabecera();

            Console.WriteLine("\n--- MENÚ BST ---");
            Console.WriteLine("1. Insertar valor");
            Console.WriteLine("2. Buscar valor");
            Console.WriteLine("3. Eliminar valor");
            Console.WriteLine("4. Mostrar recorridos");
            Console.WriteLine("5. Mostrar valor mínimo");
            Console.WriteLine("6. Mostrar valor máximo");
            Console.WriteLine("7. Mostrar altura del árbol");
            Console.WriteLine("8. Limpiar árbol");
            Console.WriteLine("9. Mostrar árbol gráfico");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Entrada inválida.");
                Console.ReadKey();
                continue;
            }

            int valor;

            switch (opcion)
            {
                case 1:
                    Console.Write("\nIngrese valor: ");
                    if (int.TryParse(Console.ReadLine(), out valor))
                    {
                        arbol.Raiz = arbol.Insertar(arbol.Raiz, valor);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("✔ Valor insertado");

                        Console.WriteLine("\nPOSTORDEN:");
                        arbol.Postorden(arbol.Raiz);

                        Console.WriteLine("\n\nÁRBOL:");
                        arbol.MostrarArbol(arbol.Raiz);

                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;

                case 2:
                    Console.Write("Ingrese valor a buscar: ");
                    if (int.TryParse(Console.ReadLine(), out valor))
                    {
                        Console.WriteLine(arbol.Buscar(arbol.Raiz, valor)
                            ? "✔ Encontrado"
                            : "✘ No encontrado");
                    }
                    break;

                case 3:
                    Console.Write("Ingrese valor a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out valor))
                    {
                        arbol.Raiz = arbol.Eliminar(arbol.Raiz, valor);
                        Console.WriteLine("✔ Eliminado");
                    }
                    break;

                case 4:
                    Console.WriteLine("\nINORDEN:");
                    arbol.Inorden(arbol.Raiz);

                    Console.WriteLine("\nPREORDEN:");
                    arbol.Preorden(arbol.Raiz);

                    Console.WriteLine("\nPOSTORDEN:");
                    arbol.Postorden(arbol.Raiz);
                    break;

                case 5:
                    if (arbol.Raiz != null)
                        Console.WriteLine($"✔ Mínimo: {arbol.Minimo(arbol.Raiz)}");
                    else
                        Console.WriteLine("Árbol vacío");
                    break;

                case 6:
                    if (arbol.Raiz != null)
                        Console.WriteLine($"✔ Máximo: {arbol.Maximo(arbol.Raiz)}");
                    else
                        Console.WriteLine("Árbol vacío");
                    break;

                case 7:
                    if (arbol.Raiz != null)
                        Console.WriteLine($"✔ Altura: {arbol.Altura(arbol.Raiz)}");
                    else
                        Console.WriteLine("Árbol vacío");
                    break;

                case 8:
                    arbol.Limpiar();
                    Console.WriteLine("✔ Árbol limpiado");
                    break;

                case 9:
                    Console.WriteLine("\nÁRBOL:");
                    arbol.MostrarArbol(arbol.Raiz);
                    break;

                case 0:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

            Console.WriteLine("\nPresione una tecla...");
            Console.ReadKey();

        } while (opcion != 0);
    }
}