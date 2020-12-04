using System;

namespace Module13
{
    class Program
    {
        static void Main()
        {
            var info = GetUserInfo();
            ShowUserInfo(info);

            Console.ReadKey();
        }

        static (string Name, string LastName, int Age, bool HasPet, int PetCount, string[] PetNames, int ColorsCount, string[] Colors) 
            GetUserInfo()
        {
            (string Name, string LastName, int Age,
             bool HasPet, int PetCount, string[] PetNames,
             int ColorsCount, string[] Colors) info = ("", "", 0, false, 0, null, 0, null);

            Console.Write("Enter your name: ");
            info.Name = Console.ReadLine();

            Console.Write("\nEnter your surname: ");
            info.LastName = Console.ReadLine();

            bool validateResult;

            do
            {
                Console.Write("\nEnter your age: ");
                int.TryParse(Console.ReadLine(), out info.Age);

                Console.Write("\nHow much pets do you have? ");
                int.TryParse(Console.ReadLine(), out info.PetCount);

                info.HasPet = info.PetCount > 0;

                if (info.HasPet)
                    info.PetNames = GetPets(info.PetCount);

                Console.Write("\nEnter the number of your favourite colors: ");
                int.TryParse(Console.ReadLine(), out info.ColorsCount);

                info.Colors = GetColors(info.ColorsCount);

                validateResult = ValidateUserInput(info.Age, info.PetCount, info.ColorsCount);
                Console.WriteLine("\nРезультат проверки ввода: " + (validateResult ? "корректно" : "не корректно"));

                if (!validateResult)
                    Console.WriteLine("\nTry again!");

            } while (!validateResult);

            return info;
        }

        static string[] GetPets(int count)
        {
            var pets = new string[count];

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter nickname of your {i+1} pet: ");
                pets[i] = Console.ReadLine();
            }

            return pets;
        }

        static string[] GetColors(int count)
        {
            var colors = new string[count];

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter your {i+1} favourite color: ");
                colors[i] = Console.ReadLine();
            }

            return colors;
        }

        static bool ValidateUserInput(params int[] digits)
        {
            for (int i = 0; i < digits.Length; i++)
                if (digits[i] <= 0)
                    return false;

            return true;
        }

        static void ShowUserInfo((string Name, string LastName, int Age, bool HasPet, int PetCount, string[] PetNames, int ColorsCount, string[] Colors) info)
        {
            Console.WriteLine("\nUSER DATA INPUT");
            Console.WriteLine($"User name is {info.Name} {info.LastName}");

            Console.WriteLine($"He has {info.PetCount} pets:");
            for (int i = 0; i < info.PetCount; i++)
                Console.Write($"{info.PetNames[i]}{(i == info.PetCount - 1 ? ".\n" : ", ")}");

            Console.WriteLine("His favourite colors:");
            for (int i = 0; i < info.ColorsCount; i++)
                Console.Write($"{info.Colors[i]}{(i == info.ColorsCount - 1 ? ".\n" : ", ")}");
        }
    }
}
