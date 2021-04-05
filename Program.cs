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
