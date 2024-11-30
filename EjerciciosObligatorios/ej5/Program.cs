using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Serie> listaSeries = new List<Serie>();
            List<Videojuego> listaVideojuego = new List<Videojuego>();

            listaSeries.Add(new Serie("A", 5, "b", "c"));
            listaSeries.Add(new Serie("d", 6, "e", "f"));
            listaSeries.Add(new Serie("g", 5, "h", "i"));
            listaVideojuego.Add(new Videojuego("j", 5, "k", "l"));
            listaVideojuego.Add(new Videojuego("m", 4, "n", "ñ"));
            listaVideojuego.Add(new Videojuego("o", 5, "p", "q"));
                    


            foreach (Serie serie in listaSeries)
            {
                serie.entregar();
            }

            foreach (Videojuego juego in listaVideojuego)
            {
                juego.entregar();
            }
            
            int cantJuego = 0;
            foreach (Videojuego a in listaVideojuego)
            {
                cantJuego++;
                if (a.isEntregado() == true)
                {
                    a.devolver();
                }
            }

            int cantSerie = 0;
            foreach (Serie b in listaSeries)
            {
                cantSerie++;
                if (b.isEntregado() == true)
                {
                    b.devolver();
                }
            }

            int num = listaVideojuego[0].GetHorasEstimadas();

            foreach (Videojuego juego in listaVideojuego)
            {
                if(num >= juego.GetHorasEstimadas())
                {
                    Console.WriteLine($"{num}");
                }
                else
                {
                    Console.WriteLine("nt");
                }
            }
            
            Console.ReadKey();
        }
    }
}
