using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit5
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowUserData(EnterUserData());
            Console.ReadKey();
        }

        static void ShowUserData((string Name, string LastName, int Age, bool HasPet, int PetsCount, string[] Nicknames, int ColorsCount, string[] Colors) user)
        {
            Console.WriteLine("Имя пользователя: {0} {1}", user.Name, user.LastName);
            Console.WriteLine("Возраст пользователя: {0} лет", user.Age);
            if (user.HasPet)
            {
                Console.WriteLine("Количество питомцев: {0}", user.PetsCount);
                foreach (string nick in user.Nicknames)
                {
                    Console.Write("- {0} ", nick);
                }
            }
            else
            {
                Console.Write("Нет питомцев");
            }

            Console.WriteLine();
            Console.WriteLine("Количество любимых цветов: {0}", user.ColorsCount);
            foreach (string color in user.Colors)
            {
                Console.Write("- {0} ", color);
            }
        }

        private static (string Name, string LastName, int Age, bool HasPet, int PetsCount, string[] Nicknames, int ColorsCount, string[] Colors) EnterUserData()
        {
            (string Name, string LastName, int Age, bool HasPet, int PetsCount, string[] Nicknames, int ColorsCount, string[] Colors) User;

            Console.WriteLine("Введите имя ");
            User.Name = Console.ReadLine();

            Console.WriteLine("Введите фамилию ");
            User.LastName = Console.ReadLine();

            User.Age = GetNumberFromConsole("Введите возраст ");

            ConsoleKey response;
            do
            {
                Console.Write("У вас есть питомец? y/n ");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                    Console.WriteLine();
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);
            User.HasPet = response == ConsoleKey.Y;

            User.PetsCount = 0;
            User.Nicknames = new string[0];
            if (User.HasPet)
            {
                User.PetsCount = GetNumberFromConsole("Введите количество питомцев ");
                User.Nicknames = EnterArray(User.PetsCount, "Введите клички питомцев: ");
            }

            User.ColorsCount = GetNumberFromConsole("Введите количество любимых цветов ");
            User.Colors = EnterArray(User.ColorsCount, "Введите названия любимых цветов: ");

            return User;
        }

        private static int GetNumberFromConsole(string title)
        {
            string inputString;
            int validNumber;
            do
            {
                Console.WriteLine(title);
                inputString = Console.ReadLine();
            } while (!CheckNum(inputString, out validNumber));
            return validNumber;
        }

        private static string[] EnterArray(int count, string title)
        {
            var result = new string[count];
            Console.WriteLine(title);

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write("№{0}: ", i+1);
                result[i] = Console.ReadLine();
            }

            return result;
        }

        private static bool CheckNum(string num, out int validNum)
        {
            if (int.TryParse(num, out int numToCheck))
            {
                if (numToCheck > 0)
                {
                    validNum = numToCheck;
                    return true;
                }
                else
                {
                    validNum = 0;
                    return false;
                }
            }
            else
            {
                validNum = 0;
                return false;
            }
        }
    }
}
