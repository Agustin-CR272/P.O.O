﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej14
{
    internal class Perecedero : Productos
    {
        int diasacaducar;

        public int DiasVencimiento { get { return diasacaducar; } set { diasacaducar = value; } }

        public Perecedero(string nombre, double precio, int diasVencimiento) : base (nombre, precio) 
        {
            this.diasacaducar = diasVencimiento;
        }

        public double CalcularP(int cantP)
        {
            Precio = cantP * Precio;

            if (DiasVencimiento == 1) 
            {
                Precio = Precio/4;
            }
            else if(DiasVencimiento == 2)
            {
                Precio = Precio / 3;
            }
            else if (DiasVencimiento == 3)
            {
                Precio = Precio / 2;
            }

            return Precio;
        }
    }
}