using System;
using System.Collections.Generic;
using System.Linq;
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
            //ImprimirCursosEscuela(engine.Escuela);
            
            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10, "German");
            diccionario.Add(23, "Lorem Ipsum");
            
            Printer.WriteTitle("Acceso a Diccionario");
            foreach (var keyValPair in diccionario)
            {
                WriteLine($"key: {keyValPair.Key}, value: {keyValPair.Value}");
            }

            var dicTmp = engine.GetDiccionarioDeObjetos();

            engine.ImprimirDiccionario(dicTmp, true);
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
