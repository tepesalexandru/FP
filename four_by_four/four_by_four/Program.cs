using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace four_by_four
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            // declar matricea
            int[,] m = new int[4, 4];
            bool[] taken = new bool[16];
            bool okay;
            int i, j;
            do
            { 
                okay = true;
                
                // resetam numerele
                for (i = 0; i < 16; i++)
                {
                    taken[i] = false;
                }
                // generam o noua matrice
                for (i = 0; i < 4; i++)
                {
                    for (j = 0; j < 4; j++)
                    {
                        int p;
                        do
                        {
                            p = rnd.Next(16);
                        } while (taken[p]);
                        m[i, j] = p + 1;
                        taken[p] = true;
                    }
                }

                int sumaD = 0, sumaD2 = 0;
                

                // verificam matricea

                // suma de pe diagonale
                for (i = 0; i < 4; i++)
                {
                    sumaD = sumaD + m[i, i];
                    sumaD2 = sumaD2 + m[i, 3 - i];
                }


                // comparam fiecare suma de pe linie/coloana cu suma diagonalei
                int suma;
                // linii
                for (i = 0; i < 4; i++)
                {
                    suma = 0;
                    for (j = 0; j < 4; j++)
                    {
                        suma = suma + m[i, j];
                    }
                    if (suma != sumaD) okay = false;
                }
                // coloane
                for (i = 0; i < 4; i++)
                {
                    suma = 0;
                    for (j = 0; j < 4; j++)
                    {
                        suma = suma + m[j, i];
                    }
                    if (suma != sumaD) okay = false;
                }

                if (sumaD != sumaD2) okay = false;

                // daca matricea respecta toate conditiile, iesim din while

               
                /*for ( i = 0; i < 4; i++)
                {
                    for ( j = 0; j < 4; j++)
                    {
                        Console.Write(m[i, j] + " ");
                    }
                    Console.WriteLine();
                }*/
               
                

            } while (!okay);

            // in final, afisam matricea
            for ( i = 0; i < 4; i++)
            {
                for ( j = 0; j < 4; j++)
                {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
