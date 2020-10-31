using System;
using System.Collections.Generic;
using System.Linq;

namespace AdunareVectori
{
    class Program
    {
        static void Main(string[] args)
        {
            // cei doi vectori initiali
            List<int> v1 = new List<int> { 9, 6, 1, 0 };
            List<int> v2 = new List<int> { 8, 4, 4 };

            // vectorul rezultat
            List<int> v3 = new List<int>();

            // inversam ordinea celor doi vectori
            v1.Reverse();
            v2.Reverse();

            // initial, vectorul final va fi egal cu vectorul initial cel mai lung
            if (v1.Count > v2.Count) v3 = v1;
            else v3 = v2;

            // adunuam cei doi vectori si retinem restul
            int rest = 0, lmin = Math.Min(v1.Count, v2.Count), i;
            for (i = 0; i < lmin; i++)
            {
                int x = v1[i]; int y = v2[i];
                v3[i] = (x + y + rest) % 10;
                rest = (x + y) / 10;
            }

            // daca la final a mai ramas rest, il punem in rezultat
            if (rest > 0) v3.Add(0);
            while (rest > 0)
            {
                v3[i] = v3[i] + rest;
                int x = v3[i];
                rest = x / 10;
                v3[i] %= 10;
                i++;
            }

            // inversam rezultatul 
            v3.Reverse();

            // afisam rezultatul
            for (i = 0; i < v3.Count; i++)
            {
                Console.Write(v3[i]);
            }

            Console.ReadKey();
        }
    }
}
