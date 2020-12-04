using System;
using System.Collections.Generic;
using System.Text;

namespace Module13
{
    public class ModuleItems
    {
        public void Item_13_1(string userName, int userAge)
        {
            const byte CycleCount = 3;
            int t = 0;

            (string name, string[] favcolors) = ("", new string[CycleCount]);

            for (int i = 0; i < CycleCount; i++)
            {
                Console.WriteLine(t);
                favcolors[t] = ShowColor(userName, userAge);
            }
        }

        public string ShowColor(string userName, int userAge)
        {
            Console.WriteLine($"{userName}! Вам {userAge} лет.\nНапишите свой любимый цвет с маленькой буквы");
            string color = Console.ReadLine();

            switch (color)
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

            return color;
        }

        public  void Item_13_2()
        {
            var (name, age) = ("Dmitry", 29);

            Console.WriteLine($"My name is {name}");
            Console.WriteLine($"I am {age} years old");

            Console.Write("Enter your name: ");
            name = Console.ReadLine();

            Console.Write("Enter your age: ");
            age = Convert.ToByte(Console.ReadLine());

            Console.WriteLine($"Your name is {name} and age is {age}");

            Item_13_1(name, age);
        }
    }
}
