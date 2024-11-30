using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Libro> libros = new List<Libro>();

            for (int i = 0; i < 1; i++)
            {
                libros.Add(new Libro(1234567890, "El principito", "Antoine de Saint-Exupéry", 96));
                libros.Add(new Libro(9876543211, "1984", "George Orwell", 328));
            }

            foreach (Libro l in libros)
            {
              l.mostrarInfo();

            }
            Libro libroMasPaginas = libros[0].NumPaginas > libros[1].NumPaginas ? libros[0] : libros[1];
            Console.WriteLine("El libro con más páginas es"+ libroMasPaginas.Titulo + " con " + libroMasPaginas.NumPaginas +" páginas.");

            Console.ReadKey();
        }
    }
}
