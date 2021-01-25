using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {
        public int AñoCreacion{get; set;}
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }
        public string Direccion { get; set; }

        //Nuevo constructor, basado en lenguajes funcional.
        public Escuela(string nombre, int añoCreacion) => (Nombre, AñoCreacion) = (nombre, añoCreacion);

        public Escuela(string nombre, int añoCreacion, TiposEscuela tiposEscuela, 
            string pais = "", 
            string ciudad = "")
        {
            //parametros opcionales o con valor por defecto
            (Nombre, AñoCreacion) = (nombre, añoCreacion);
            Pais = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine}Pais: {Pais}, Ciudad: {Ciudad}";
        }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela");
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }

            Printer.WriteTitle($"Escuela {Nombre} limpia.");
            Printer.Pitar(1000, cantidad:3);
        }
    }
}