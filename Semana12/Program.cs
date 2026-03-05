using System;
using System.Collections.Generic;
using System.Linq;

namespace TorneoFutbol
{
    class Program
    {
        // ================= MAPAS =================
        static Dictionary<int, string> Equipos = new Dictionary<int, string>();
        static Dictionary<int, Jugador> Jugadores = new Dictionary<int, Jugador>();
        static Dictionary<int, EstadisticaEquipo> TablaEquipos = new Dictionary<int, EstadisticaEquipo>();

        // ================= CONJUNTOS =================
        static HashSet<int> UniversoJugadores = new HashSet<int>();
        static HashSet<string> Personas = new HashSet<string>();

        static int nextEquipoId = 1;
        static int nextJugadorId = 1;

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Generar50Jugadores();
            Menu();
        }

        // ================= GENERAR 50 PERSONAS =================
        static void Generar50Jugadores()
        {
            string[] nombres =
            {
                "Juan","Carlos","Luis","Pedro","Miguel","Andres","Jorge","Diego","Mario","Jose",
                "Fernando","Ricardo","Daniel","Sebastian","Adrian","Cristian","Pablo","Gabriel","Hector","Manuel",
                "Kevin","Brayan","Anthony","David","Samuel","Alexander","Esteban","Oscar","Edison","Julio",
                "Ronaldo","Alberto","Victor","Francisco","Roberto","Leonardo","Nicolas","Ivan","Santiago","Matias",
                "Emilio","Marco","Dario","Angel","Gonzalo","Joel","Felipe","Cesar","Edgar","Tomas"
            };

            string[] apellidos =
            {
                "Perez","Gomez","Lopez","Rodriguez","Martinez","Torres","Ramirez","Vargas","Castro","Morales",
                "Ortiz","Herrera","Rojas","Mendoza","Silva","Guerrero","Navarro","Jimenez","Ruiz","Flores",
                "Cruz","Acosta","Reyes","Delgado","Paredes","Sanchez","Valencia","Bravo","Cordero","Espinoza",
                "Chavez","Mora","Salazar","Benitez","Arroyo","Campos","Suarez","Zambrano","Ibarra","Peña",
                "Carrillo","Lara","Palacios","Nuñez","Correa","Medina","Aguilar","Bustos","Velasquez","Calderon"
            };

            for (int i = 0; i < 50; i++)
            {
                string nombreCompleto = nombres[i] + " " + apellidos[i];

                Jugadores.Add(nextJugadorId, new Jugador
                {
                    Id = nextJugadorId,
                    Nombre = nombreCompleto,
                    EquipoId = 0,
                    Goles = 0
                });

                UniversoJugadores.Add(nextJugadorId);
                Personas.Add(nombreCompleto);

                nextJugadorId++;
            }
        }

        // ================= FORMAR EQUIPOS =================
        static void FormarEquiposCon11Jugadores()
        {
            Equipos.Clear();
            TablaEquipos.Clear();

            nextEquipoId = 1;

            for (int i = 1; i <= 4; i++)
            {
                string nombre = "Equipo " + i;

                Equipos.Add(nextEquipoId, nombre);
                TablaEquipos.Add(nextEquipoId, new EstadisticaEquipo(nombre));

                nextEquipoId++;
            }

            foreach (var j in Jugadores.Values)
                j.EquipoId = 0;

            var jugadoresRandom = Jugadores.Keys.OrderBy(x => rnd.Next()).ToList();

            int jugadoresPorEquipo = 11;
            int indexJugador = 0;

            foreach (var equipoId in Equipos.Keys)
            {
                for (int i = 0; i < jugadoresPorEquipo; i++)
                {
                    Jugadores[jugadoresRandom[indexJugador]].EquipoId = equipoId;
                    indexJugador++;
                }
            }
        }

        // ================= MENU =================
        static void Menu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("===== TORNEO DE FUTBOL =====");
                Console.WriteLine("1. Ver conjunto universo de 50 personas");
                Console.WriteLine("2. Formar equipos aleatoriamente y ver equipos + sobrantes");
                Console.WriteLine("3. Simular partidos");
                Console.WriteLine("4. Tabla posiciones");
                Console.WriteLine("5. Tabla goleadores");
                Console.WriteLine("6. Reporte estructuras");
                Console.WriteLine("0. Salir");

                switch (Console.ReadLine())
                {
                    case "1": MostrarUniverso(); break;
                    case "2": FormarEquiposYMostrar(); break;
                    case "3": SimularPartidos(); break;
                    case "4": MostrarTabla(); break;
                    case "5": TablaGoleadores(); break;
                    case "6": Reporte(); break;
                    case "0": return;
                    default: Pausa("Opcion invalida"); break;
                }
            }
        }

        // ================= UNIVERSO =================
        static void MostrarUniverso()
        {
            Console.Clear();

            Console.WriteLine("ID\tNombre");
            Console.WriteLine("-------------------------");

            foreach (var j in Jugadores.Values)
            {
                Console.WriteLine(j.Id + "\t" + j.Nombre);
            }

            Console.WriteLine("\nTotal personas: " + Personas.Count);

            Pausa();
        }

        // ================= OPCION 2 =================
        static void FormarEquiposYMostrar()
        {
            FormarEquiposCon11Jugadores();

            Console.Clear();

            foreach (var equipo in Equipos)
            {
                Console.WriteLine("\n=== " + equipo.Value + " ===");

                var jugadores = Jugadores.Values
                    .Where(j => j.EquipoId == equipo.Key);

                foreach (var j in jugadores)
                    Console.WriteLine("ID:" + j.Id + " - " + j.Nombre);
            }

            Console.WriteLine("\n===== JUGADORES SOBRANTES =====");

            var sobrantes = Jugadores.Values
                .Where(j => j.EquipoId == 0);

            foreach (var j in sobrantes)
                Console.WriteLine("ID:" + j.Id + " - " + j.Nombre);

            Console.WriteLine("\nTotal sobrantes: " + sobrantes.Count());

            Pausa();
        }

        // ================= SIMULAR PARTIDOS =================
        static void SimularPartidos()
        {
            Console.Clear();
            Console.WriteLine("===== RESULTADOS =====\n");

            var equipos = Equipos.Keys.ToList();

            for (int i = 0; i < equipos.Count; i += 2)
            {
                int e1 = equipos[i];
                int e2 = equipos[i + 1];

                int g1 = rnd.Next(0, 5);
                int g2 = rnd.Next(0, 5);

                Console.WriteLine(Equipos[e1] + " " + g1 + " - " + g2 + " " + Equipos[e2]);

                TablaEquipos[e1].GF += g1;
                TablaEquipos[e1].GC += g2;

                TablaEquipos[e2].GF += g2;
                TablaEquipos[e2].GC += g1;

                if (g1 > g2)
                    TablaEquipos[e1].Puntos += 3;
                else if (g2 > g1)
                    TablaEquipos[e2].Puntos += 3;
                else
                {
                    TablaEquipos[e1].Puntos++;
                    TablaEquipos[e2].Puntos++;
                }

                // goles a jugadores aleatorios
                for (int g = 0; g < g1; g++)
                {
                    var jugador = Jugadores.Values.Where(x => x.EquipoId == e1).OrderBy(x => rnd.Next()).First();
                    jugador.Goles++;
                }

                for (int g = 0; g < g2; g++)
                {
                    var jugador = Jugadores.Values.Where(x => x.EquipoId == e2).OrderBy(x => rnd.Next()).First();
                    jugador.Goles++;
                }
            }

            Pausa();
        }

        // ================= TABLA POSICIONES =================
        static void MostrarTabla()
        {
            Console.Clear();

            Console.WriteLine("Equipo\tPts\tGF\tGC\tDG");

            foreach (var e in TablaEquipos.Values
                .OrderByDescending(x => x.Puntos)
                .ThenByDescending(x => x.Diferencia))
            {
                Console.WriteLine(e.Nombre + "\t" + e.Puntos + "\t" + e.GF + "\t" + e.GC + "\t" + e.Diferencia);
            }

            Pausa();
        }

        // ================= TABLA GOLEADORES =================
        static void TablaGoleadores()
        {
            Console.Clear();

            Console.WriteLine("Jugador\t\tGoles");

            foreach (var j in Jugadores.Values
                .Where(x => x.Goles > 0)
                .OrderByDescending(x => x.Goles))
            {
                Console.WriteLine(j.Nombre + "\t" + j.Goles);
            }

            Pausa();
        }

        // ================= REPORTE =================
        static void Reporte()
        {
            Console.Clear();

            Console.WriteLine("Total Equipos: " + Equipos.Count);
            Console.WriteLine("Total Jugadores: " + Jugadores.Count);
            Console.WriteLine("Universo (HashSet): " + UniversoJugadores.Count);
            Console.WriteLine("Personas unicas: " + Personas.Count);

            Pausa();
        }

        static void Pausa(string msg = "")
        {
            if (msg != "")
                Console.WriteLine(msg);

            Console.WriteLine("\nEnter para continuar...");
            Console.ReadLine();
        }
    }

    class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EquipoId { get; set; }
        public int Goles { get; set; }
    }

    class EstadisticaEquipo
    {
        public string Nombre;
        public int Puntos;
        public int GF;
        public int GC;

        public int Diferencia
        {
            get { return GF - GC; }
        }

        public EstadisticaEquipo(string nombre)
        {
            Nombre = nombre;
        }
    }
}