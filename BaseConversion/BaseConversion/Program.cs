﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BaseConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Acesta este un algoritm pentru conversia unui numar in alta, ambele fiind cuprinse intre 1 si 16.\n");
            Console.Write("Incepe introducand numarul tau: ");
            string input = Console.ReadLine();

            string[] numbers = input.Split(".");

            Console.Write("In ce baza este numarul tau? ");
            int startingBase = Int32.Parse(Console.ReadLine());

            Console.Write("In ce baza doresti sa convertesti numarul dat? ");
            int endingBase = Int32.Parse(Console.ReadLine());

            int base10 = ToBase10(numbers[0], startingBase);

            PrintIntegerConversion(base10, endingBase);
        
            float decimalBase10 = FractionToBase10(numbers[1], startingBase);

            PrintDecimalConversion(decimalBase10, endingBase);
            
        }

        static int ToBase10(string s, int b)
        {
            int i, power = 1, cifra = 0, base10 = 0;
            byte[] asciiBytes = Encoding.ASCII.GetBytes(s);
            for (i = asciiBytes.Length - 1; i >= 0; i--)
            {
                if (asciiBytes[i] >= 48 && asciiBytes[i] <= 57)
                {
                    // este numar
                    cifra = (asciiBytes[i] - 48) * power;
                }
                else if (asciiBytes[i] >= 65 && asciiBytes[i] <= 70)
                {
                    cifra = (asciiBytes[i] - 55) * power;
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

        static float FractionToBase10(string s, int b)
        {
            int i, power = b;
            float cifra = 0, base10 = 0;
            byte[] asciiBytes = Encoding.ASCII.GetBytes(s);
            for (i = 0; i < s.Length; i++)
            {
                if (asciiBytes[i] >= 48 && asciiBytes[i] <= 57)
                {
                    // este numar
                    cifra = (asciiBytes[i] - 48) * (1f / power);
                }
                else if (asciiBytes[i] >= 65 && asciiBytes[i] <= 70)
                {
                    cifra = (asciiBytes[i] - 55) * (1f / power);
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

        static void PrintIntegerConversion(int n, int b)
        {
            string HEX = "0123456789ABCDEF";
            Stack<string> myStack = new Stack<string>();
            int rest;
            while (n != 0)
            {
                rest = n % b;
                myStack.Push(HEX[rest].ToString());
                n = n / b;
            }
            Console.Write("Numarul in baza finala: ");
            while (myStack.Count > 0)
            {

                Console.Write(myStack.Peek());
                myStack.Pop();
            }
        }

        static float FractionalPart(float n)
        {
            return n - (int)n;
        }

        static int IntegerPart(float n)
        {
            return (int)n;
        }

        static void PrintDecimalConversion(float n, int b)
        {
            if (FractionalPart(n) > 0) Console.Write(".");
            string HEX = "0123456789ABCDEF";
            while (FractionalPart(n) != 0)
            {
                n = n * b;
                Console.Write(HEX[IntegerPart(n)]);
                n = n - IntegerPart(n);
            }
        }

    }
}
