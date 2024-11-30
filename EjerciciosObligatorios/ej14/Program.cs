using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Perecedero> productsPereced = new List<Perecedero>();
            List<NoPerecedero> productsNoPereced = new List<NoPerecedero>();

            int cant = 5;

            for (int i = 0; i <= cant; i++)
            {
                productsPereced.Add(new Perecedero("Arbejas", 1000, 3));
                productsNoPereced.Add(new NoPerecedero("Ferrari", 5000, "Juguetes"));
            }

            foreach (var Pereced in productsPereced)
            {
                Pereced.CalcularP(cant);

                Console.WriteLine(Pereced.Precio);
            }

            foreach (var noPereced in productsNoPereced)
            {
                noPereced.CalcularNoP(cant);

                Console.WriteLine(noPereced.Precio);
            }

            Console.ReadKey();
        }
    }
}
