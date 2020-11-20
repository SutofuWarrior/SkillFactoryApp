using System;

namespace Module11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Item_11_3();
            //Item_11_7();
            FinalTask();

            //Console.WriteLine("{0}\n{1}\n{2}", name, age, favcolor);
            //Console.WriteLine("{0}\n  {1}\n {2}", name, age, favcolor);
            // b -= k;

            Console.ReadKey();
        }

        static void Item_11_3()
        {
            string name = "Dmitry";
            byte age = 29;
            bool isPet = false;
            float shoeSize = 45;

            Console.WriteLine($"My name is {name}");
            Console.WriteLine($"I am {age} years old");
            Console.WriteLine($"I {(isPet ? "do have" : "don't have")} a pet");
            Console.WriteLine($"My foot size is {shoeSize}");
        }

        static void Item_11_7()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            byte age = Convert.ToByte(Console.ReadLine());

            Console.WriteLine($"Your name is {name} and age is {age}");

            Console.Write("What is your favourite day of week? ");
            DayOfWeek day = (DayOfWeek)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Your favourite day of week is {day}");
        }

        static void FinalTask()
        {
            Console.Write("Enter your name: ");
            var name = Console.ReadLine();

            Console.Write("Enter your age: ");
            var age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Your name is {name} and age is {age}");

            Console.Write("Enter your birthday: ");
            var birthdate = Console.ReadLine();
            Console.WriteLine($"Your birthday is {birthdate}");
        }
    }
}
