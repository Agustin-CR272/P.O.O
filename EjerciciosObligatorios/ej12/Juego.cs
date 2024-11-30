using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej12
{
    internal class Juego
    {
        List<Jugador> playerList = new List<Jugador>();
        Revolver r;

        public Juego(List<Jugador> jugadorList, Revolver r)
        {
            this.playerList = jugadorList;
            this.r = r;
        }

        public bool finJuego()
        {
            foreach (var j in playerList) 
            {
                if (j.disparar(r) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public void ronda()
        {
            foreach (var j in playerList)
            {
                if (j.disparar(r) != true)
                {
                    r.siguienteBala();
                    Console.WriteLine("El " + j.Nombre + j.Id + " a logrado sobrevivir.");
                }
                else
                {
                    r.siguienteBala();
                    Console.WriteLine("El " + j.Nombre + j.Id + " no a logrado sobrevivir.");
                }
            }
        }
    }
}
