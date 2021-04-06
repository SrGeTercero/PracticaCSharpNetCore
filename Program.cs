using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Pitar(2000, 1000, 1);
            AppDomain.CurrentDomain.ProcessExit -= AccionDelEvento;
            
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("Bienvenidos a la escuela");
            
            var reporteador = new Reporteador(engine.GetDiccionarioDeObjetos());

            var evalList = reporteador.GetListaEvaluaciones();

            var asigList = reporteador.GetListAsignaturas();

            var listaEvalXAsig = reporteador.GetDiccionarioEvaluacionesXAsignatura();

            var listaPromXAsig = reporteador.GetPromedioAlumnoXAsignatura();

            var listaPromXAsig_Cantidad = reporteador.GetPromedioAlumnoXAsignatura(5);

            Printer.WriteTitle("Captura de una evaluación por consola");
            var newEval = new Evaluación();
            string nombre, notaString;
            float nota;

            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PresioneENTER();
            nombre = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(nombre))
            {
                Printer.WriteTitle("El valor del nombre no puede ser vacio");
                WriteLine("Saliendo del programa");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre de la evaluación ha sido ingresado correctamente.");
            }

            WriteLine("Ingrese la nota de la evaluación");
            Printer.PresioneENTER();
            notaString = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(notaString))
            {
                Printer.WriteTitle("El valor de nota no puede ser vacio");
                WriteLine("Saliendo del programa");
            }
            else
            {
                try
                {
                    newEval.Nota = float.Parse(notaString);
                    if (newEval.Nota < 0 || newEval.Nota > 5)
                    {
                        throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                    }
                    WriteLine("La nota de la evaluación ha sido ingresado correctamente.");
                }
                catch(ArgumentOutOfRangeException argE)
                {
                    Printer.WriteTitle(argE.Message);
                    WriteLine("Saliendo del programa");
                }
                catch (Exception)
                {
                    Printer.WriteTitle("El valor de nota no es un número valido");
                    WriteLine("Saliendo del programa");
                }
            }
        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
            Printer.Pitar(2000,1000,3);
            Printer.WriteTitle("SALIÓ");
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la Escuela");
            
            if(escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}, Jornada: {curso.Jornada}");
                }       
            }
        } 

           
    }
}
