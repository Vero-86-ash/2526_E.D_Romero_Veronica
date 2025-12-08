
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



Console.WriteLine("=== DEMOSTRACIÓN DE LA CLASE CÍRCULO ===\n");

// Crear un círculo con radio válido
Circulo miCirculo = new Circulo(5.0);
Console.WriteLine("Círculo 1 (radio = 5.0):");
miCirculo.MostrarInformacion();
Console.WriteLine();

// Crear un círculo con radio inválido
Console.WriteLine("Intentando crear círculo con radio negativo:");
Circulo circuloInvalido = new Circulo(-3.0);
circuloInvalido.MostrarInformacion();
Console.WriteLine();

// Probar cambiar el radio después de crear el objeto
Console.WriteLine("Cambiando el radio del primer círculo a 7.5:");
miCirculo.Radio = 7.5;
miCirculo.MostrarInformacion();
Console.WriteLine();

// Crear otro círculo con datos diferentes
Circulo circulo2 = new Circulo(3.0);
Console.WriteLine("Círculo 2 (radio = 3.0):");
Console.WriteLine($"Radio: {circulo2.Radio}");
Console.WriteLine($"Área calculada: {circulo2.CalcularArea():F4}");
Console.WriteLine($"Perímetro calculado: {circulo2.CalcularPerimetro():F4}");
Console.WriteLine();

// Demostración con valores decimales
Console.WriteLine("Círculo con radio decimal (2.5):");
Circulo circulo3 = new Circulo(2.5);
Console.WriteLine($"Área: {circulo3.CalcularArea()}");
Console.WriteLine($"Perímetro: {circulo3.CalcularPerimetro()}");
Console.WriteLine();

Console.WriteLine("Programa finalizado. Presiona cualquier tecla para salir...");
