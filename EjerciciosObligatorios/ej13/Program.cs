using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Repartidor> repartidor = new List<Repartidor>();
            List<Comercial> comercial = new List<Comercial>();

            repartidor.Add(new Repartidor("Joaco", 18, 1000, 300, "zona 3"));
            repartidor.Add(new Repartidor("Jatniel", 18 , 1000, 300, "zona 3"));
            comercial.Add(new Comercial("Lauti", 17, 1000, 300, 250));            
            comercial.Add(new Comercial("Agustín", 17, 1000, 300, 350));

            foreach (Repartidor r in repartidor)
            {
                r.PLUS();

                Console.WriteLine(r.Nombre + " tiene " + r.Edad + " cobra " + r.Salario + " euros");
            }

            foreach (Comercial c in comercial)
            {
                c.PLUS();

                Console.WriteLine(c.Nombre + " tiene " + c.Edad + " cobra " + c.Salario + " euros");
            }

            Console.ReadKey();
            
        }
    }
}
