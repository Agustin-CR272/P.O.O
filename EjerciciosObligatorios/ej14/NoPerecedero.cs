using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej14
{
    internal class NoPerecedero : Productos
    {
        string tipo;

        public string Tipos { get { return tipo; } set { tipo = value; } }

        public NoPerecedero(string nombre, double precio, string tipos) : base (nombre, precio) 
        {
            this.tipo = tipos;
        }

        public double CalcularNoP(int cantP)
        {
            Precio = cantP * Precio;

            return Precio;
        }
    }
}
