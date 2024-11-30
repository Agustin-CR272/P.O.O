using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej12
{
    internal class Revolver
    {
        int posicionActual;
        int posicionBala;

        public int PosActual { get { return posicionActual; } set { posicionActual = value; } }
        public int PosBala { get { return posicionBala; } set { posicionBala = value; } }

        public Revolver(int posActual, int posBala) 
        {
            this.posicionActual = posActual;
            this.posicionBala = posBala;
        }

        public bool disparar()
        {
            if (posicionBala == posicionActual)
            {
                return true;
            }
            return false;
        }
       
        public void siguienteBala()
        {
            if (posicionBala == 7)
            {
                posicionBala = 1;
            }
            else
            {
                posicionBala++;
            }
        }
    }
}
