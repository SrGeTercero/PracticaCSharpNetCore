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
        public static EscuelaEngine engine = new EscuelaEngine();
        static void Main(string[] args)
        {
            //AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            //AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Pitar(2000, 1000, 1);
            //AppDomain.CurrentDomain.ProcessExit -= AccionDelEvento;
            
            Printer.WriteTitle("Bienvenidos a la escuela");
            engine.Inicializar();

            ImprimirMenuDeReportes(out int reporteElegido, out int cantidadOpcionMenu);
            MostrarReporte(reporteElegido, cantidadOpcionMenu);

            // var evalList = reporteador.GetListaEvaluaciones();

            // var asigList = reporteador.GetListAsignaturas();

            // var listaEvalXAsig = reporteador.GetDiccionarioEvaluacionesXAsignatura();

            // var listaPromXAsig = reporteador.GetPromedioAlumnoXAsignatura();

            // var listaPromXAsig_Cantidad = reporteador.GetPromedioAlumnoXAsignatura(5);

            #region codigo Ejemplo para trabajar con try, catch, finally

            // Printer.WriteTitle("Captura de una evaluación por consola");
            // var newEval = new Evaluación();
            // string nombre, notaString;
            // float nota;

            // WriteLine("Ingrese el nombre de la evaluación");
            // Printer.PresioneENTER();
            // nombre = Console.ReadLine();

            // if(string.IsNullOrWhiteSpace(nombre))
            // {
            //     Printer.WriteTitle("El valor del nombre no puede ser vacio");
            //     WriteLine("Saliendo del programa");
            // }
            // else
            // {
            //     newEval.Nombre = nombre.ToLower();
            //     WriteLine("El nombre de la evaluación ha sido ingresado correctamente.");
            // }

            // WriteLine("Ingrese la nota de la evaluación");
            // Printer.PresioneENTER();
            // notaString = Console.ReadLine();

            // if(string.IsNullOrWhiteSpace(notaString))
            // {
            //     Printer.WriteTitle("El valor de nota no puede ser vacio");
            //     WriteLine("Saliendo del programa");
            // }
            // else
            // {
                // try
                // {
                //     newEval.Nota = float.Parse(notaString);
                //     if (newEval.Nota < 0 || newEval.Nota > 5)
                //     {
                //         throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                //     }
                //     WriteLine("La nota de la evaluación ha sido ingresado correctamente.");
                //     return;
                // }
                // catch(ArgumentOutOfRangeException argE)
                // {
                //     Printer.WriteTitle(argE.Message);
                //     WriteLine("Saliendo del programa");
                // }
                // catch (Exception)
                // {
                //     Printer.WriteTitle("El valor de nota no es un número valido");
                //     WriteLine("Saliendo del programa");
                // }
                // finally
                // {
                //     Printer.WriteTitle("FINALLY");
                //     Printer.Pitar(2500, 500, 3);
                // }
            //}

#endregion
        
        
        }
        
        private static void ImprimirMenuDeReportes(out int reporteElegido, out int cantidadOpcionMenu){
            Printer.WriteTitle("Menu de reportes");

            var cantidadReportes = Enum.GetNames(typeof(TiposReporte)).Count();
            reporteElegido = 0;
            cantidadOpcionMenu = 1;

            foreach (var reporte in Enum.GetValues(typeof(TiposReporte)))
            {
                WriteLine($"Presione {cantidadOpcionMenu} para ver el reporte: {reporte}");
                if(cantidadOpcionMenu < cantidadReportes) cantidadOpcionMenu++;
            }

            try
            {
                int teclaPresionada = Console.ReadKey().KeyChar;
                reporteElegido = Convert.ToInt32((System.Convert.ToChar(teclaPresionada)).ToString());
            }catch(Exception e){
                WriteLine();
                WriteLine($"Unicamente se permite elegir opciones con valor numerico {e.Message}");
            }
        }

        public static void MostrarReporte(int reporteElegido, int cantidadOpciones){
            //WriteLine(reporteElegido);
            //WriteLine(cantidadOpciones);
            try
            {
                if(reporteElegido > cantidadOpciones || reporteElegido < (cantidadOpciones - (cantidadOpciones-1)))
                {
                    throw new RankException();
                }
                else
                {
                    var tipoReporte = Enum.GetName(typeof(TiposReporte),reporteElegido-1);
                    //WriteLine(tipoReporte);
                    var reporteador = new Reporteador(engine.GetDiccionarioDeObjetos());
                    switch (tipoReporte)
                    {
                        case "GetListaEvaluaciones":
                            WriteLine();
                            var evalList = reporteador.GetListaEvaluaciones();
                            foreach (var eval in evalList)
                            {
                                WriteLine($"Nombre: {eval.Nombre}, Id: {eval.UniqueId}, Alumno: {eval.Alumno.Nombre}, Asignatura: {eval.Asignatura.Nombre}, Nota: {eval.Nota}");
                            }
                        break;
                        case "GetListAsignaturas":
                            WriteLine();
                            var asigList = reporteador.GetListAsignaturas();
                            foreach (var asig in asigList)
                            {
                                WriteLine($"Asignatura: {asig}");
                            }
                        break;
                        case "GetDiccionarioEvaluacionesXAsignatura":
                            WriteLine();
                            var listaEvalXAsig = reporteador.GetDiccionarioEvaluacionesXAsignatura();
                            foreach (var EvalXAsig in listaEvalXAsig)
                            {
                                Printer.WriteTitle($"{EvalXAsig.Key}");
                                foreach (var eval in EvalXAsig.Value)
                                {
                                    WriteLine($"Nombre: {eval.Nombre}, Id: {eval.UniqueId}, Alumno: {eval.Alumno.Nombre}, Asignatura: {eval.Asignatura.Nombre}, Nota: {eval.Nota}");
                                }
                            }
                        break;
                        case "GetPromedioAlumnoXAsignatura":
                            WriteLine();
                            var listaPromXAsig = reporteador.GetPromedioAlumnoXAsignatura();
                            foreach (var PromXAsig in listaPromXAsig)
                            {
                                Printer.WriteTitle($"{PromXAsig.Key}");
                                foreach (var eval in PromXAsig.Value)
                                {
                                    WriteLine($"IdAlumno: {eval.alumnoId}, NombreAlumno: {eval.alumnoNombre}, Promedio: {eval.promedio}");
                                }
                            }
                        break;
                        case "GetPromedioAlumnoXAsignatura_Cantidad":
                            WriteLine();
                            WriteLine("Ingrese la cantidad de alumnos que desea ver:");
                            try
                            {
                                int teclaPresionada = Console.ReadKey().KeyChar;
                                int cantidadAlumnos = Convert.ToInt32((System.Convert.ToChar(teclaPresionada)).ToString());
                                WriteLine();
                                var listaPromXAsig_Cantidad = reporteador.GetPromedioAlumnoXAsignatura(cantidadAlumnos);
                                foreach (var PromXAsig in listaPromXAsig_Cantidad)
                                {
                                    Printer.WriteTitle($"{PromXAsig.Key}");
                                    foreach (var eval in PromXAsig.Value)
                                    {
                                        WriteLine($"IdAlumno: {eval.alumnoId}, NombreAlumno: {eval.alumnoNombre}, Promedio: {eval.promedio}");
                                    }
                                }
                            }catch(Exception e){
                                WriteLine();
                                WriteLine($"Unicamente se permite elegir opciones con valor numerico {e.Message}");
                            }
                        break;
                        default:
                        break;
                    }                    
                }
            }
            catch(RankException ex)
            {
                WriteLine($"ERROR: Ha elegido una opción que no existe! -> {ex.Message}");
            }
            catch(Exception ex){
                WriteLine($"ERROR:  -> {ex.Message}");
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
