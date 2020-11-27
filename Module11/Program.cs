using System;

namespace Module11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Item_11_3();
            //Item_11_7();
            //Item_12_FinalTask();

            

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

        static void Item_11_FinalTask()
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

        static void Item_12_1_4()
        {
            string A = default;
            string B = default;
            bool C = A != B;
        }

        static void Item_12_1_5()
        {
            int A = 4;
            int B = 10;
            double X = 5;
            double Y = 8;

            bool C = (A < B) | (X > Y);
        }

        static void Item_12_1_10()
        {
            var a = 6;
            var b = 6;

            if (a == b)
            {
                Console.WriteLine("Условие истинно");
            }
            else
            {
                Console.WriteLine("Условие ложно");
            }
        }

        static void Item_12_1_16()
        {
            Console.WriteLine("Напишите свой любимый цвет консоли с маленькой буквы: ");

            switch (Console.ReadLine())
            {
                case "red":
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is red!");
                    break;

                case "green":
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is green!");
                    break;

                case "cyan":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is cyan!");
                    break;

                default:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Your color is yellow!");
                    break;
            }
        }
    }
}
