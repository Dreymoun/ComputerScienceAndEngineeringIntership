using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ex1();
            //Ex2();
            //Ex3();
            //Ex4();
            //Ex5();
            //Ex6();
            //Ex7();
            //Ex8();
            //Ex9();
            //Ex10();
            //Ex11();
            //Ex12();
            //Ex13();
            //Ex14();
            //Ex15();
        }
        static void Ex1()
        {
            int spaceCount = 0;
            char input;

            Console.WriteLine("Введите символы. Введите '.' чтобы завершить.");

            do
            {
                input = Console.ReadKey().KeyChar;
                if (input == ' ')
                {
                    spaceCount++;
                }
            } while (input != '.');

            Console.WriteLine($"\nКоличество пробелов: {spaceCount}");
        }
        static void Ex2()
        {
            Console.WriteLine("Введите 6-значный номер билета:");
            string ticket = Console.ReadLine();

            if (ticket.Length != 6)
            {
                Console.WriteLine("Неверный номер билета!");
                return;
            }

            int firstHalf = int.Parse(ticket.Substring(0, 3));
            int secondHalf = int.Parse(ticket.Substring(3, 3));

            int sum1 = firstHalf / 100 + (firstHalf / 10) % 10 + firstHalf % 10;
            int sum2 = secondHalf / 100 + (secondHalf / 10) % 10 + secondHalf % 10;

            Console.WriteLine(sum1 == sum2 ? "Счастливый билет!" : "Обычный билет.");
        }
        static void Ex3()
        {
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsUpper(chars[i]))
                {
                    chars[i] = char.ToLower(chars[i]);
                }
                else if (char.IsLower(chars[i]))
                {
                    chars[i] = char.ToUpper(chars[i]);
                }
            }

            Console.WriteLine("Конвертированная строка: " + new string(chars));
        }
        static void Ex4()
        {
            Console.WriteLine("Введите целое число N:");
            string input = Console.ReadLine();
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            Console.WriteLine("Обратное число: " + new string(chars));
        }
        static void Ex5()
        {
            double[] A = new double[5];
            double[,] B = new double[3, 4];
            Random rnd = new Random();

            // Заполнение массива A
            Console.WriteLine("Введите 5 чисел для массива A:");
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = double.Parse(Console.ReadLine());
            }

            // Заполнение массива B
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = rnd.Next(-100, 101);  // Случайные числа от -100 до 100
                }
            }

            // Вывод массива A
            Console.WriteLine("\nМассив A:");
            foreach (var item in A)
            {
                Console.Write(item + " ");
            }

            // Вывод массива B
            Console.WriteLine("\n\nМассив B:");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Расчет статистических данных
            double maxElement = double.MinValue;
            double minElement = double.MaxValue;
            double totalSum = 0;
            double totalProduct = 1;  // начнем с 1, так как это нейтральный элемент для умножения
            double sumEvenA = 0;
            double sumOddColumnsB = 0;

            foreach (var item in A)
            {
                maxElement = Math.Max(maxElement, item);
                minElement = Math.Min(minElement, item);
                totalSum += item;
                totalProduct *= item;

                if (item % 2 == 0) sumEvenA += item;
            }

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    maxElement = Math.Max(maxElement, B[i, j]);
                    minElement = Math.Min(minElement, B[i, j]);
                    totalSum += B[i, j];
                    totalProduct *= B[i, j];

                    if (j % 2 != 0) sumOddColumnsB += B[i, j];
                }
            }

            Console.WriteLine("\nМаксимальный элемент: " + maxElement);
            Console.WriteLine("Минимальный элемент: " + minElement);
            Console.WriteLine("Общая сумма всех элементов: " + totalSum);
            Console.WriteLine("Общее произведение всех элементов: " + totalProduct);
            Console.WriteLine("Сумма четных элементов массива A: " + sumEvenA);
            Console.WriteLine("Сумма нечетных столбцов массива B: " + sumOddColumnsB);
        }
        static void Ex6()
        {
            int[,] matrix = new int[5, 5];
            Random rnd = new Random();

            // Заполнение массива случайными числами от -100 до 100
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = rnd.Next(-100, 101);
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int minElementIndexI = 0, minElementIndexJ = 0;
            int maxElementIndexI = 0, maxElementIndexJ = 0;

            // Поиск минимального и максимального элемента
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] < matrix[minElementIndexI, minElementIndexJ])
                    {
                        minElementIndexI = i;
                        minElementIndexJ = j;
                    }
                    if (matrix[i, j] > matrix[maxElementIndexI, maxElementIndexJ])
                    {
                        maxElementIndexI = i;
                        maxElementIndexJ = j;
                    }
                }
            }

            // Вычисление суммы между минимальным и максимальным элементами
            int sum = 0;
            bool startSumming = false;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if ((i == minElementIndexI && j == minElementIndexJ) ||
                        (i == maxElementIndexI && j == maxElementIndexJ))
                    {
                        if (startSumming)
                        {
                            startSumming = false;
                            continue;
                        }
                        else
                        {
                            startSumming = true;
                            continue;
                        }
                    }

                    if (startSumming)
                    {
                        sum += matrix[i, j];
                    }
                }
            }

            Console.WriteLine($"Сумма элементов между минимальным и максимальным элементами: {sum}");
        }
        static void Ex7()
        {
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();
            string result = input.Replace("/", "").Replace("\\", "");
            Console.WriteLine("Результат: " + result);
        }
        static void Ex8()
        {
            string word = "класс";
            int count = 0;
            foreach (var ch in word)
            {
                if (ch == 'с') count++;
            }
            if (count == 2) word = word.Replace("сс", "1");
            Console.WriteLine(word);
        }
        static void Ex9()
        {
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();
            int count = 0;
            foreach (char c in input)
            {
                if (char.IsDigit(c)) count++;
            }
            Console.WriteLine("Количество цифр в строке: " + count);
        }
        static void Ex10()
        {
            string text = Console.ReadLine();
            if (text.Contains("one"))
            {
                Console.WriteLine("Текст содержит слово 'one'.");
            }
            else
            {
                Console.WriteLine("Текст не содержит слово 'one'.");
            }
        }
        static void Ex11()
        {
            string text = Console.ReadLine();
            if (text.Any(c => !char.IsLetterOrDigit(c)))
            {
                Console.WriteLine("Текст содержит символы, отличные от букв и цифр.");
            }
            else
            {
                Console.WriteLine("Текст содержит только буквы и цифры.");
            }
        }
        static void Ex12()
        {
            string text = Console.ReadLine();
            var words = text.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            var firstLetter = words.GroupBy(w => w[0]).OrderByDescending(g => g.Count()).First().Key;
            Console.WriteLine($"Больше всего слов начинается на букву: {firstLetter}");
        }
        static void Ex13()
        {
            string text = Console.ReadLine();
            int pCount = text.Count(c => c == 'P' || c == 'p');
            Console.WriteLine($"Количество вхождений буквы P: {pCount}");

        }
        static void Ex14()
        {
            string text = Console.ReadLine();
            var wordsList = text.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Количество слов: {wordsList.Length}");
            foreach (var word in wordsList)
            {
                Console.WriteLine(word);
            }

        }
        static void Ex15()
        {
            string text = Console.ReadLine();
            var wordsList = text.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            int matchingCount = wordsList.Count(word => word.First() == word.Last());
            Console.WriteLine($"Количество слов, где первый и последний символы совпадают: {matchingCount}");
        }
    }
}
