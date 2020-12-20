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

            Item_12_1_16();

            //(string Name, string Type, float Age) Pet;

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

            for (int i = 5; i > 1; i--)
            {
                Console.WriteLine($"Iteration {i}");

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

        static void Item_12_2_11()
        {
            Console.WriteLine("Цикл do");
            int t = 0;

            do
            {
                Console.WriteLine(t);
                Console.WriteLine("Напишите свой любимый цвет с маленькой буквы");

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

                t++;

            } while (t < 3);
        }

        static void Item_12_4_3()
        {
            var (name, age) = ("Dmitry", 29);

            Console.WriteLine($"My name is {name}");
            Console.WriteLine($"I am {age} years old");

            Console.Write("Enter your name: ");
            name = Console.ReadLine();

            Console.Write("Enter your age: ");
            age = Convert.ToByte(Console.ReadLine());

            Console.WriteLine($"Your name is {name} and age is {age}");
        }

        static void Item_12_5()
        {
            (string Name, string LastName, string Login, int LoginLength, bool HasPet, string[] favcolors, double Age) User;

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter your name: ");
                User.Name = Console.ReadLine();

                Console.Write("Enter your surname: ");
                User.LastName = Console.ReadLine();

                Console.Write("Enter your login: ");
                User.Login = Console.ReadLine();
                User.LoginLength = User.Login.Length;

                Console.WriteLine("Do you have a pet? Да or Нет");
                User.HasPet = Console.ReadLine() == "Да";

                Console.WriteLine("Enter user age: ");
                User.Age = Convert.ToDouble(Console.ReadLine());

                User.favcolors = new string[3];
                for (int j = 0; j < User.favcolors.Length; j++)
                {
                    Console.WriteLine($"Enter your {j} favourite color: ");
                    User.favcolors[j] = Console.ReadLine();
                }
            }
        }

    }
}
