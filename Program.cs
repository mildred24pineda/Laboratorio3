using System;
using System.Collections.Generic;
using System.Linq;

class Programa
{
    //Lista Global
    static List<Estudiante> estudiantes = new List<Estudiante>();

    static void Main()
    {
        Console.WriteLine("Bienvenido al Sistema de gestión de estudiantes.");
        Console.WriteLine("\nEscriba '6' para mostrar opciones en cualquier momento.");

        while (true)
        {
            Console.Write("\nSeleccione una opción o escriba '6' para ver el menú: ");
            string entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out int opcion))
            {
                Console.WriteLine("Error: Ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    AgregarvariosEstudiantes();
                    break;
                case 2:
                    MostrarEstudiantes();
                    break;
                case 3:
                    CalcularPromedio();
                    break;
                case 4:
                    EstudianteConMaxCalificacion();
                    break;
                case 5:
                    Console.WriteLine("Saliendo del sistema...");
                    return;
                case 6:
                    MostrarMenu();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\nOpciones disponibles:");
        Console.WriteLine("1. Agregar estudiantes");
        Console.WriteLine("2. Mostrar lista de estudiantes");
        Console.WriteLine("3. Calcular promedio de calificaciones");
        Console.WriteLine("4. Mostrar estudiante con la calificación más alta");
        Console.WriteLine("5. Salir");
        Console.WriteLine("6. Mostrar opciones");
    }

    static void AgregarvariosEstudiantes()
    {
        Console.WriteLine("\nModo de ingreso múltiple: Escriba 'fin' cuando termine.");

        while (true)
        {
            Console.Write("\nIngrese el nombre del estudiante (o 'fin' para terminar): ");
            string nombre = Console.ReadLine();

            if (nombre.ToLower() == "fin")
            {
                Console.WriteLine("Finalizando ingreso de estudiantes.");
                return;
            }

            double calificacion;
            while (true)
            {
                Console.Write($"Ingrese la calificación de {nombre} (0 - 100): ");
                string entrada = Console.ReadLine();

                if (double.TryParse(entrada, out calificacion) && calificacion >= 0 && calificacion <= 100)
                {
                    break;
                }
                Console.WriteLine("Error: Ingrese una calificación válida entre 0 y 100.");
            }

            estudiantes.Add(new Estudiante(nombre, calificacion));
            Console.WriteLine($"Estudiante {nombre} agregado correctamente.");
        }
    }

    static void MostrarEstudiantes()
    {
        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
            return;
        }

        Console.WriteLine("\nLista de estudiantes:");
        foreach (var estudiante in estudiantes)
        {
            Console.WriteLine($"Nombre: {estudiante.Nombre}, Calificación: {estudiante.Calificacion}");
        }
    }

    static void CalcularPromedio()
    {
        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
            return;
        }

        double promedio = estudiantes.Average(e => e.Calificacion);
        Console.WriteLine($"El promedio de calificaciones es: {promedio:F2}");
    }

    static void EstudianteConMaxCalificacion()
    {
        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
            return;
        }

        Estudiante mejorEstudiante = estudiantes.OrderByDescending(e => e.Calificacion).First();
        Console.WriteLine($"El estudiante con la calificación más alta es {mejorEstudiante.Nombre} con {mejorEstudiante.Calificacion:F2}");
    }
}

// Clase para representar a un estudiante
class Estudiante
{
    public string Nombre { get; set; }
    public double Calificacion { get; set; }

    public Estudiante(string nombre, double calificacion)
    {
        Nombre = nombre;
        Calificacion = calificacion;
    }
}