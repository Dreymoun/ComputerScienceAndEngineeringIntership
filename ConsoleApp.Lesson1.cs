using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HelloWorld();
            PrintSomeName();
            Summary();
        }

        static void HelloWorld()
        {
            Console.WriteLine("Hello World!!\n");
        }

        static void PrintSomeName()
        {
            Console.WriteLine("Введите имя :");
            string name = Console.ReadLine();
            Console.WriteLine("Приветствую тебя " + name + "\n");
        }

        static void Summary()
        {
            Console.WriteLine("Введите числа, разделяя их пробелами: ");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            int sum = 0;

            foreach (string numberString in numbers)
            {
                if (int.TryParse(numberString, out int number))
                {
                    sum += number;
                }
                else
                {
                    Console.WriteLine($"Ошибка: '{numberString}' не является числом и будет проигнорировано.");
                }
            }
            Console.WriteLine($"Сумма введенных чисел: {sum}\n");

        }

    }
}
