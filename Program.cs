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
            var listaDeObjetos = engine.GetObjetoEscuela();
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
