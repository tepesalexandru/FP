using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Rand
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            // incercam o metoda aleatoare
            int[] v = new int[] { 1, 6, 3, 1, 1, 2, 5, 1, 1, 4, 2 };
            int apa = 0;
            for (int j = 0; j < v.Length; j++)
            {
                bool ok = false;
                do
                {
                    ok = false;
                    int p = j;
                    bool isLeft = false;
                    bool isRight = false;
                    for (int i = p - 1; i >= 0; i--)
                    {
                        if (v[i] > v[p])
                        {
                            isLeft = true;
                            break;
                        }
                    }
                    for (int i = p + 1; i < v.Length; i++)
                    {
                        if (v[i] > v[p])
                        {
                            isRight = true;
                            break;
                        }
                    }
                    if (isLeft && isRight)
                    {
                        apa++;
                        v[p]++;
                        ok = true;
                    }
                } while (ok);
                
            }
            Console.WriteLine(apa);
            Console.ReadKey();
        }
    }
}
