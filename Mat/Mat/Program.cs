using System;
using System.Globalization;

namespace Mat
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = new int[] { 1, 6, 3, 1, 1, 2, 5, 1, 1, 4, 2, 1, 3, 6, 7, 1, 8, 2 };
            int n = v.Length;
            int apa = 0;
            int max = v[0];
            for (int i = 1; i < n; i++)
            {
                if (v[i] > max) max = v[i];
            }
            int[,] m = new int[max, n];
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < v[j]; i++)
                {
                    m[i, j] = 1;
                }
            }

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(m[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}
