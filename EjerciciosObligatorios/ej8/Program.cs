using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Profesores> profesores = new List<Profesores>();
            List<Estudiantes> estudiantes = new List<Estudiantes>();
            List<Aula> aula = new List<Aula>();

            int contador = 0, contH = 0, contM = 0;

            profesores.Add(new Profesores("Ana", 35, "Mujer", "filosofia", true));
            profesores.Add(new Profesores("Carlos", 50, "Hombre", "matematica", true));
            profesores.Add(new Profesores("Ruben", 50, "Hombre", "fisica", true));

            estudiantes.Add(new Estudiantes("Luis", 18, "Hombre", 6, true, 3));
            estudiantes.Add(new Estudiantes("Sofía", 17, "Mujer", 8, false, 6));

            aula.Add(new Aula(3, 25, "matematica", "Carlos", true));
            aula.Add(new Aula(4, 35, "filosofia", "Ana", true));
            aula.Add(new Aula(5, 45, "fisica", "Ruben", true));

            foreach (Estudiantes e in estudiantes)
            {
                if (e.Presente)
                {
                    contador++;
                }
            }

            foreach (Profesores p in profesores)
            {
                if (p.Nombre == "Carlos")
                {
                    if (p.Disponibilidad)
                    {
                        foreach (Estudiantes e in estudiantes)
                        {
                            if (contador <= estudiantes.Count / 2)
                            {
                                foreach (Aula a in aula)
                                {
                                    if (a.Materia == "Quimica")
                                    {
                                        a.ClaseE = true;

                                        if (e.Sexo == "Hombre" && e.Calificacion >= 6)
                                        {
                                            contH++;
                                        }
                                        else if (e.Sexo == "Mujer" && e.Calificacion >= 6)
                                        {
                                            contM++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                break;
            }

            Console.WriteLine("La cantidad de alumnos aprobados es " + contH);
            Console.WriteLine("La cantidad de alumnas aprobados es " + contM);
            Console.ReadKey();
            




        }
    }
}
