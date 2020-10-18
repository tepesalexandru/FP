using System;
using System.Globalization;

namespace BT_4x4
{
    class Program
    {

        static void Main(string[] args)
        {
            int[,] m = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    m[i, j] = 0;
                }
            }
            bool[] taken = new bool[16];
            Backtrack(0, 0, m, taken);
        }
        static void Backtrack(int x, int y, int[,] m, bool[] t)
        {
            int i, j;
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("===============");
            if (x == 4 && y == 0)
            {
                int sumaD = 0, sumaD2 = 0;
                for (i = 0; i < 3; i++)
                {
                    sumaD = sumaD + m[i, i];
                    sumaD2 = sumaD2 + m[i, 3 - i];
                }
                if (sumaD != sumaD2) return;
                int suma = 0;
                for (i = 0; i < 4; i++)
                {
                    suma = 0;
                    for (j = 0; j < 4; j++)
                    {
                        suma = suma + m[i, j];
                    }
                    if (suma != sumaD) return;
                }
                for (i = 0; i < 4; i++)
                {
                    suma = 0;
                    for (j = 0; j < 4; j++)
                    {
                        suma = suma + m[j, i];
                    }
                    if (suma != sumaD) return;
                }
                
               

                
                for (i = 0; i < 4; i++)
                {
                    for (j = 0; j < 4; j++)
                    {
                        Console.Write(m[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("===============");

                return;
            }

            
            for (i = 0; i < 16; i++)
            {
                
                if (!t[i])
                {
                    m[x, y] = i + 1;
                    if (!CheckM(m)) continue;
                    t[i] = true;
                    if (y == 3)
                    {
                        Backtrack(x + 1, 0, m, t);
                    }
                    else
                    {
                        Backtrack(x, y + 1, m, t);
                    }
                    
                   
                    t[i] = false;
                }
            }
        }
        static bool CheckM(int[,] m)
        {
            int i, j;
            int sumaD = 0, suma = 0;
            for (i = 0; i < 4; i++)
            {
                sumaD = sumaD + m[i, i];
                if (sumaD > 34) return false;
            }
            for (i = 0; i < 4; i++)
            {
                suma = 0;
                for (j = 0; j < 4; j++)
                {
                    suma = suma + m[i, j];
                }
                if (suma > 34) return false;
            }
            for (i = 0; i < 4; i++)
            {
                suma = 0;
                for (j = 0; j < 4; j++)
                {
                    suma = suma + m[j, i];
                }
                if (suma > 34) return false;
            }
            suma = 0;
            for (i = 0; i < 4; i++)
            {
                suma = suma + m[i, 3 - i];
                if (suma > 34) return false;
            }
            return true;
        }
    }
}
