using System;

namespace FP
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int a, b, c, d, e;
            a = rnd.Next(2, 13);
            b = rnd.Next(2, 13);
            c = rnd.Next(2, 13);
            d = rnd.Next(2, 13);
            e = rnd.Next(2, 13);

            Console.WriteLine($"{a} {b} {c} {d} {e}");

            // vector de frecventa
            int[] v = new int[13];
            for (int i = 0; i < 13; i++)
            {
                v[i] = 0;
            }

            v[a]++;
            v[b]++;
            v[c]++;
            v[d]++;
            v[e]++;

            for (int i = 0; i < 13; i++)
            {
                Console.Write($"{v[i]} ");
            }

            Console.ReadKey();

        }
    }
}
