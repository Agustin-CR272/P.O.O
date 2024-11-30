using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Espectador> espectadores = new List<Espectador>();
            List<Asiento> asientos = new List<Asiento>();
            List<Cine> cines = new List<Cine>();
            List<Peliculas> peliculas = new List<Peliculas>();
                        
            cines.Add(new Cine("Batman"));
            cines.Add(new Cine("Tron"));

            peliculas.Add(new Peliculas("Batman", "2:20 hs", 16, "Christopher Nolan", 5000));
            peliculas.Add(new Peliculas("Tron", "1:30 hs", 16, "Steven Lisberger", 7000));

            for (int letra = 'A'; letra <= 'I'; letra++)
            {
                for (int numero = 1; numero <= 8; numero++)
                {
                    asientos.Add(new Asiento(false, letra + "" + numero));
                }
            }
             
            Random random = new Random();
            int r = random.Next(1, 72);
            asientos[r].Ocupado = true;

            espectadores.Add(new Espectador("Joaco", 18, 5000, false, asientos[r]));
            espectadores.Add(new Espectador("Jatniel", 18, 15000, false, asientos[r]));
            espectadores.Add(new Espectador("Lautaro", 17, 10000, false, asientos[r]));
            espectadores.Add(new Espectador("Agustin", 17, 7000, false, asientos[r]));

            
            foreach (Peliculas p in peliculas) 
            {
                if(p.Titulo == "Batman")
                {
                    Console.WriteLine("Estan viendo Batman");
                    foreach (Espectador e in espectadores)
                    {
                        if (e.Dinero >= p.Precio && e.Edad >= p.EdadMin)
                        {
                            e.Sentado = true;
                            Console.WriteLine(e.Nombre + " esta sentado " + r);
                        }
                    }
                }
                break;
            }          


            Console.ReadKey();

        }
    }
}
