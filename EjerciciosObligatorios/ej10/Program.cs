using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej10
{

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Carta> cartasMazo = new List<Carta>();
            List<Carta> monton = new List<Carta>();
            for (int i = 1; i <= 4; i++)
            {
                for (int k = 1; k <= 12; k++)
                {
                    if (k != 8 && k != 9)
                    {
                        if (i == 0)
                            cartasMazo.Add(new Carta(k, "oro"));
                        else if (i == 1)
                            cartasMazo.Add(new Carta(k, "copa"));
                        else if (i == 2)
                            cartasMazo.Add(new Carta(k, "espada"));
                        else
                            cartasMazo.Add(new Carta(k, "basto"));
                    }
                }
            }

            Baraja mazo = new Baraja(new List<Carta>(cartasMazo));
            mazo.Barajar();
            Console.WriteLine("Baraja mezclada: ");
            mazo.MostrarBaraja();
            Console.WriteLine("----------------------------");

            bool infinidad = true;
            while (infinidad)
            {
                Console.WriteLine("1: Siguiente");
                Console.WriteLine("2: Pedir");
                Console.WriteLine("3: Cartas disponibles");
                Console.WriteLine("4: Tus cartas");
                Console.WriteLine("5: Mostrar mazo");
                Console.WriteLine("6: Terminar");
              
                string opciones = Console.ReadLine();
                if (opciones == "1" || opciones == "2" || opciones == "3" || opciones == "4" || opciones == "5" || opciones == "6") 
                {
                    switch (opciones) 
                    {
                        case "1":
                            if (mazo.Mazo[0] == null)
                            {
                                Console.WriteLine("Se acabaron las cartas.");
                                break;
                            }
                            mazo.SiguienteCarta(monton);
                            break;
                        case "2":
                            Console.WriteLine("¿Cuantas cartas queres?: ");
                            int cantidad = Convert.ToInt32(Console.ReadLine());
                            if (cantidad <= mazo.Mazo.Count)
                            {
                                mazo.DarCartas(monton, cantidad);
                                break;
                            }
                            else 
                            {
                                Console.WriteLine("Pides más de lo que hay.");
                                break; 
                            }
                        case "3": mazo.CartasDisponibles(); break;
                        case "4": mazo.CartasMonton(monton); break;
                        case "5": mazo.MostrarBaraja(); break;
                        case "6": infinidad = false; break;
                    }
                }
            }
        }
    }
}   
