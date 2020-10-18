using System;
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

            // Verificam daca numarul este cu virgula
            int virgula = input.IndexOf('.');

            string afterPoint, beforePoint;
            beforePoint = input.Substring(0, virgula);
            afterPoint = input.Substring(virgula + 1);

            input = beforePoint;

            Console.Write("In ce baza este numarul tau? ");
            int startingBase = Int32.Parse(Console.ReadLine());

            Console.Write("In ce baza doresti sa convertesti numarul dat? ");
            int endingBase = Int32.Parse(Console.ReadLine());

            // Convertim numarul initial in baza 10
            int base10 = 0, power = 1, cifra = 0;
            int i, j;

            // Luam valorile ASCII din input
            byte[] asciiBytes = Encoding.ASCII.GetBytes(input);
            for (i = asciiBytes.Length - 1; i >= 0; i--)
            {
                if (asciiBytes[i] >= 48 && asciiBytes[i] <= 57)
                {
                    // este numar
                    cifra = (asciiBytes[i] - 48) * power;
                } else if (asciiBytes[i] >= 65 && asciiBytes[i] <= 70)
                {
                    cifra = (asciiBytes[i] - 55) * power;
                    // este litera mare
                } else
                {
                    // handle exception
                }
                base10 = base10 + cifra;
                power = power * startingBase;
            }
            string HEX = "0123456789ABCDEF";
            Stack<string> myStack = new Stack<string>();
            int rest;
            while (base10 != 0)
            {
                rest = base10 % endingBase;
                myStack.Push(HEX[rest].ToString());
                base10 = base10 / endingBase;
            }
            int index;
            Console.Write("Numarul in baza finala: ");
            while (myStack.Count > 0)
            {

                Console.Write(myStack.Peek());
                myStack.Pop();
            }
        }

    }
}
