using System;
using System.Runtime.InteropServices.ComTypes;

namespace Reuniune
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int n, m;
            n = 8; m = 8;
            int[] A = new int[n];
            int[] B = new int[m];

            A[0] = rnd.Next(5);
            B[0] = rnd.Next(5);

            Console.Write(A[0] + " ");

            for (int i = 1; i < n; i++)
            {
                A[i] = rnd.Next(5) + A[i - 1] + 1;
                Console.Write(A[i] + " ");
            }
            Console.WriteLine();

            Console.Write(B[0] + " ");
            for (int i = 1; i < m; i++)
            {
                B[i] = rnd.Next(5) + B[i - 1] + 1;
                Console.Write(B[i] + " ");
            }

            Console.WriteLine();

            /// Intersectia
            int[] C = new int[n + m];
            int idx = 0;

            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if (A[i] == B[j])
                    {
                        C[idx] = A[i];
                        idx++;
                    }
                }
            }

            for (int i = 0; i < idx; i++)
            {
                Console.Write(C[i] + " ");
            }
            /// Reuniunea
            idx = 0;
            for(int i = 0; i < n; i++)
            {
                C[idx] = A[i];
                idx++;
            }
            for (int i = 0; i < m; i++)
            {
                bool okay = true;
                for (int j = 0; j < idx; j++)
                {
                    if (B[i] == C[j])
                    {
                        okay = false;
                        break;
                    }
                }
                if (okay)
                {
                    C[idx] = B[i];
                    idx++;
                }
            }
            Console.WriteLine();

            for (int i = 0; i < idx; i++)
            {
                Console.Write(C[i] + " ");
            }

            /// Concatenare
            idx = 0;
            for (int i = 0; i < n; i++)
            {
                C[idx] = A[i];
                idx++;
            }
            for (int i = 0; i < m; i++)
            {
                C[idx] = B[i];
                idx++;
            }

            Console.WriteLine();

            for (int i = 0; i < idx; i++)
            {
                Console.Write(C[i] + " ");
            }

            /// A / B
            idx = 0;
            for (int i = 0; i < n; i++)
            {
                bool okay = true;
                for (int j = 0; j < m; j++)
                {
                    if (A[i] == B[j])
                    {
                        okay = false;
                    }
                }
                if (okay)
                {
                    C[idx] = A[i];
                    idx++;
                }
            }

            Console.WriteLine();

            for (int i = 0; i < idx; i++)
            {
                Console.Write(C[i] + " ");
            }

            /// B / A
            idx = 0;
            for (int i = 0; i < m; i++)
            {
                bool okay = true;
                for (int j = 0; j < n; j++)
                {
                    if (A[j] == B[i])
                    {
                        okay = false;
                    }
                }
                if (okay)
                {
                    C[idx] = B[i];
                    idx++;
                }
            }

            Console.WriteLine();

            for (int i = 0; i < idx; i++)
            {
                Console.Write(C[i] + " ");
            }

            /// Interclasare
            int k1, k2;
            idx = 0;
            k1 = 0;
            k2 = 0;

            while (k1 < n && k2 < m)
            {
                if (A[k1] < B[k2])
                {
                    C[idx] = A[k1];
                    idx++;
                    k1++;
                } else
                {
                    C[idx] = B[k2];
                    idx++;
                    k2++;
                }
            }

            while (k1 < n)
            {
                C[idx] = A[k1];
                idx++;
                k1++;
            }

            while (k2 < m)
            {
                C[idx] = B[k2];
                idx++;
                k2++;
            }

            Console.WriteLine();

            for (int i = 0; i < idx; i++)
            {
                Console.Write(C[i] + " ");
            }


            Console.ReadKey();

        }
    }
}
