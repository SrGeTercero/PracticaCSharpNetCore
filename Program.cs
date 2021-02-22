﻿using System;
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
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Pitar(2000, 1000, 1);
            AppDomain.CurrentDomain.ProcessExit -= AccionDelEvento;
            
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
