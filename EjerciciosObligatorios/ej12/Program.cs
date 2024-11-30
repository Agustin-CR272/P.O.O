using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Jugador> jugadores = new List<Jugador>();

            for (int i = 0; i < 6; i++)
            {
                jugadores.Add(new Jugador(i));
            }

            Random r1 = new Random();
            Random r2= new Random();
            Revolver revolver = new Revolver(r1.Next(1,6), r2.Next(1,6));

            Juego juego = new Juego(jugadores, revolver);

            juego.ronda();
            Console.ReadKey();
        }
    }
}
