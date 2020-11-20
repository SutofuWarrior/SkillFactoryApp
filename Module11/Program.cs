using System;

namespace Module11
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Dmitry";
            byte age = 29;
            bool isPet = false;
            float shoeSize = 45;

            Console.WriteLine($"My name is {name}");
            Console.WriteLine($"I am {age} years old");
            Console.WriteLine($"I {(isPet ? "do have" : "don't have")} a pet");
            Console.WriteLine($"My foot size is {shoeSize}");

            Console.ReadKey();
        }
    }
}
