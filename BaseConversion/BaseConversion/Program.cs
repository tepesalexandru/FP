using System;
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
            Console.WriteLine($"Numarul in baza 10: {base10}");
        }
    }
}
