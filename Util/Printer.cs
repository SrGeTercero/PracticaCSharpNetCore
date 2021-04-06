using System.Threading;
using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        //las clases estaticas no permiten crear nuevas instacikas
        //ella misma es un objeto.
        public static void DrawLine(int tamaño = 10)
        {
            WriteLine("".PadLeft(tamaño, '='));
        }

        public static void PresioneENTER()
        {
            WriteLine("Presione ENTER para continuar...");
        }
        public static void WriteTitle(string titulo)
        {
            var tamaño = titulo.Length + 4;
            DrawLine(tamaño);
            WriteLine($"| {titulo} |");
            DrawLine(tamaño);
        }
        public static void Pitar(int hz = 2000, int tiempo = 1000, int cantidad = 1)
        {
            while(cantidad-- > 0) Beep(hz, tiempo);
        }
        public static void songWelcome()
        {
            var Solb = 185; var Lab = 207; var Sib = 233; var Reb = 277; var Mib =311 ; var Fa = 349; var La2 = 329;
            
            var negra = 250;
            var blanca = negra * 2;
            var corchea = negra /2;
            var dotblanca = blanca + negra;
            var dotnegra = negra + corchea;
            
            Beep(Solb,dotnegra);
            Beep(Fa,dotnegra);
            Beep(Mib,dotnegra);
            Beep(Mib,negra);
            Beep(Reb,corchea);
            Thread.Sleep(negra);
            Beep(Mib,dotnegra);
            Beep(Mib,negra);
            Beep(Fa,corchea);
            Beep(Mib,negra);
            Beep(Reb,corchea);
            Beep(Sib,negra);
            Beep(Lab,corchea);
            Thread.Sleep(negra);
            Beep(Sib,dotnegra);
            Beep(Fa,dotnegra);
            Beep(Mib,dotnegra);
            Beep(Mib,negra);
            Beep(Reb,corchea);
            Thread.Sleep(negra);
            Beep(Mib,dotnegra);
            Beep(Mib,negra);
            Beep(Fa,corchea);
            Beep(Mib,negra);
            Beep(Reb,corchea);
            Beep(Sib,negra);
            Beep(Lab,corchea);
            Thread.Sleep(negra);
            Beep(Sib,dotnegra);
            Beep(Reb,dotnegra);
            Beep(La2,dotblanca);
        }
    }
}