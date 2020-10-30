using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BaseConversion
{
    class Program
    {
        static void Main(string[] args)
        {

            int startingBase = 0, endingBase = 0;
            string input = "";
            bool negativ = false;


            try
            {
                Console.WriteLine("Acesta este un algoritm pentru conversia unui numar in alta, ambele fiind cuprinse intre 1 si 16.\n");
                Console.Write("Incepe introducand numarul tau: ");
                input = Console.ReadLine();
                int len = input.Length;
                int nrPuncte = 0;
                if (input[0] == '-')
                {
                    negativ = true;
                }
                for (int i = 0; i < len; i++)
                {
                    if (input[i] == '-' && i == 0) continue;
                    if (input[i] == '.')
                    {
                        nrPuncte++;
                    }
                    else if (!(input[i] >= 'A' && input[i] <= 'F') && !(input[i] >= '0' && input[i] <= '9'))
                    {
                        throw new Exception();
                        
                    }
                }
                if (nrPuncte > 1) throw new Exception();
            } catch (Exception)
            {
                Console.WriteLine("Numarul introdus nu este in formatul corect. Te rog sa respecti formatul precizat.");
                Console.WriteLine("Exemplu de numere corecte: 16, 4A.F, -2, 10.01, -3C.DF");
                Environment.Exit(0);
            }
            if (negativ)
            {
                input = input.Substring(1);
            }
            string[] numbers = input.Split(".");

            try
            {
                Console.Write("In ce baza este numarul tau? ");
                startingBase = Int32.Parse(Console.ReadLine());
                if (startingBase < 2 || startingBase > 16)
                {
                    throw new Exception();
                }
            } catch(Exception)
            {
                Console.WriteLine("Baza initiala este intr-un format gresit, incercati din nou.");
                Environment.Exit(0);
            }

            try
            {
                Console.Write("In ce baza doresti sa convertesti numarul dat? ");
                endingBase = Int32.Parse(Console.ReadLine());
                if (endingBase < 2 || endingBase > 16)
                {
                    throw new Exception();
                }
            } catch (Exception)
            {
                Console.WriteLine("Baza finala este intr-un format gresit, incercati din nou.");
                Environment.Exit(0);
            }

            int base10 = ToBase10(numbers[0], startingBase);

            
            PrintIntegerConversion(base10, endingBase, negativ);
            
            if (numbers.Length > 1)
            {
                decimal decimalBase10 = FractionToBase10(numbers[1], startingBase);
                PrintDecimalConversion(decimalBase10, endingBase);
            }
            
            
        }

        static int ToBase10(string s, int b)
        {
            int i, power = 1, cifra = 0, base10 = 0;
            byte[] asciiBytes = Encoding.ASCII.GetBytes(s);
            for (i = asciiBytes.Length - 1; i >= 0; i--)
            {
                if (asciiBytes[i] >= (byte)'0' && asciiBytes[i] <= (byte)'9')
                {
                    // este numar
                    cifra = (asciiBytes[i] - '0') * power;
                }
                else if (asciiBytes[i] >= (byte)'A' && asciiBytes[i] <= (byte)'F')
                {
                    cifra = (asciiBytes[i] - 'A' + 10) * power;
                    // este litera mare
                }
                else
                {
                    // handle exception
                }
                base10 = base10 + cifra;
                power = power * b ;
            }
            return base10;
           
        }

        static decimal FractionToBase10(string s, int b)
        {
            int i, power = b;
            decimal cifra = 0.0M, base10 = 0.0M;
            byte[] asciiBytes = Encoding.ASCII.GetBytes(s);
            
            for (i = 0; i < s.Length; i++)
            {
                if (asciiBytes[i] >= 48 && asciiBytes[i] <= 57)
                {
                    // este numar
                    cifra = (asciiBytes[i] - 48) * ((decimal)1 / power);
                }
                else if (asciiBytes[i] >= 65 && asciiBytes[i] <= 70)
                {
                    cifra = (asciiBytes[i] - 55) * ((decimal)1 / power);
                    // este litera mare
                }
                else
                {
                    // handle exception
                }
                base10 = base10 + cifra;
                power = power * b;
            }
            return base10;
        }

        static void PrintIntegerConversion(int n, int b, bool negativ)
        {
            string HEX = "0123456789ABCDEF";
            Stack<string> myStack = new Stack<string>();
            int rest;
            int aux = n;
            
            while (n != 0)
            {
                rest = n % b;
                myStack.Push(HEX[rest].ToString());
                n = n / b;
            }
            Console.Write("Numarul in baza finala: ");
            if (negativ) Console.Write("-");
            if (aux == 0)
            {
                Console.Write("0");
            }
            while (myStack.Count > 0)
            {

                Console.Write(myStack.Peek());
                myStack.Pop();
            }
        }

        static decimal FractionalPart(decimal n)
        {
            return n - (int)n;
        }

        static int IntegerPart(decimal n)
        {
            return (int)n;
        }

        static void PrintDecimalConversion(decimal n, int b)
        {
            Dictionary<decimal, int> repeatingDecimals = new Dictionary<decimal, int>();
            List<char> decimals = new List<char>();
            bool infinite = false;
            int idx = 0;
            repeatingDecimals[n] = 1;
            if (FractionalPart(n) > 0) Console.Write(".");
            string HEX = "0123456789ABCDEF";
            while (FractionalPart(n) != 0.0M)
            {
                n = n * b;
                decimals.Add(HEX[IntegerPart(n)]);
                n = n - IntegerPart(n);
                
                try
                {
                    if (repeatingDecimals[n] != null)
                    {
                        infinite = true;
                        
                        decimals.Insert(repeatingDecimals[n] - 1, '(');
                        decimals.Add(')');
                        break;
                    }
                } catch (Exception)
                {
                    repeatingDecimals[n] = idx;
                    idx++;
                }
                
            }

            int i = 0;
            for (i = 0; i < decimals.Count; i++)
            {
                Console.Write(decimals[i]);
            }
        }

    }
}
