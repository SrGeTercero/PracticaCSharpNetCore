using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("Bienvenidos a la escuela");
            //Printer.Pitar(hz:10000,cantidad:2);
            ImprimirCursosEscuela(engine.Escuela);

            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Pruebas de Polimorfismo");
            
            var alumnoTest = new Alumno(){Nombre = "Claire Underwood"};
            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");

            ObjetoEscuelaBase ob = alumnoTest;
            Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.GetType()}");

            var objetoDummy = new ObjetoEscuelaBase(){Nombre="Frank Underwood"};
            Printer.WriteTitle("ObjetoEscuelaBase");
            WriteLine($"Alumno: {objetoDummy.Nombre}");
            WriteLine($"Alumno: {objetoDummy.UniqueId}");
            WriteLine($"Alumno: {objetoDummy.GetType()}");

            /*
            alumnoTest = (Alumno) ob;
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");
            */

            var evaluacion = new Evaluación(){Nombre="Evaluacion de mate", Nota=4.5f};
            Printer.WriteTitle("Evaluación");
            WriteLine($"Evaluación: {evaluacion.Nombre}");
            WriteLine($"Evaluación: {evaluacion.UniqueId}");
            WriteLine($"Evaluación: {evaluacion.Nota}");
            WriteLine($"Evaluación: {evaluacion.GetType()}");

            //ob = evaluacion;
            /*Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"Evaluación: {ob.Nombre}");
            WriteLine($"Evaluación: {ob.UniqueId}");
            WriteLine($"Evaluación: {ob.GetType()}");*/

            //alumnoTest = (Alumno) (ObjetoEscuelaBase) evaluacion;

            if (ob is Alumno)
            {
                Alumno alumnoRecuperado = (Alumno) ob;
            }

            Alumno alumnoRecuperado2 = ob as Alumno;

            if(alumnoRecuperado2 != null)
            {
                
            }

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
