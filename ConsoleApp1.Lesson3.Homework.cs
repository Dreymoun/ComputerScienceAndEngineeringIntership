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
            //ArrEx1();
            //ArrEx2();
            //ArrEx3();
            //ArrEx4();
            //ArrEx5();
            //ArrEx6();
            //ArrEx7();
            //ArrEx8();
            //ArrEx9();
            //ArrEx10();
            //StrEx1();
            //StrEx2();
            //StrEx3();
            //StrEx4();
            //StrEx5();
            //StrEx6();
            //StrEx7();
            //StrEx8();
            //StrEx9();
            StrEx10();
            //StrEx11();
            //StrEx12();
            //StrEx13();
        }
        static void ArrEx1()
        {
            // Задача 1
            double[] A = new double[5];
            double[,] B = new double[3, 4];
            Random rand = new Random();

            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"Введите значение для элемента A[{i}]: ");
                A[i] = double.Parse(Console.ReadLine());
            }

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = rand.NextDouble() * 100; // случайные числа от 0 до 100
                }
            }

            Console.WriteLine("Массив A:");
            Console.WriteLine(string.Join(" ", A));

            Console.WriteLine("Массив B:");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write($"{B[i, j]} ");
                }
                Console.WriteLine();
            }

            double globalMax = Math.Max(A.Max(), B.Cast<double>().Max());
            double globalMin = Math.Min(A.Min(), B.Cast<double>().Min());
            double globalSum = A.Sum() + B.Cast<double>().Sum();
            double globalProduct = A.Aggregate(1.0, (acc, val) => acc * val) * B.Cast<double>().Aggregate(1.0, (acc, val) => acc * val);
            double sumEvenA = A.Where(val => val % 2 == 0).Sum();
            double sumOddColumnsB = 0;
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (j % 2 == 1)
                {
                    for (int i = 0; i < B.GetLength(0); i++)
                    {
                        sumOddColumnsB += B[i, j];
                    }
                }
            }

            Console.WriteLine($"Максимальный элемент: {globalMax}");
            Console.WriteLine($"Минимальный элемент: {globalMin}");
            Console.WriteLine($"Общая сумма: {globalSum}");
            Console.WriteLine($"Общее произведение: {globalProduct}");
            Console.WriteLine($"Сумма четных элементов массива A: {sumEvenA}");
            Console.WriteLine($"Сумма нечетных столбцов массива B: {sumOddColumnsB}");
        }
        static void ArrEx2()
        {
            int[] M = { 1, 2, 3, 4, 5 };
            int[] N = { 4, 5, 6, 7, 8 };
            int[] common = M.Intersect(N).ToArray();
            //Intersect - удобный метод, который решает задачу в одну строку :)

            Console.WriteLine("Общие элементы:");
            Console.WriteLine(string.Join(", ", common));
        }
        static void ArrEx3()
        {
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            bool isPalindrome = input == new string(input.Reverse().ToArray());
            Console.WriteLine(isPalindrome ? "Строка является палиндромом" : "Строка не является палиндромом");
        }
        static void ArrEx4()
        {
            Console.WriteLine("Введите предложение:");
            string sentence = Console.ReadLine();

            int wordCount = sentence.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine($"Количество слов: {wordCount}");
        }
        static void ArrEx5()
        {
            int[,] arr = new int[5, 5];
            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr[i, j] = rand.Next(-100, 101);
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int minVal = int.MaxValue;
            int maxVal = int.MinValue;
            Tuple<int, int> minIndex = null;
            Tuple<int, int> maxIndex = null;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (arr[i, j] < minVal)
                    {
                        minVal = arr[i, j];
                        minIndex = Tuple.Create(i, j);
                    }
                    if (arr[i, j] > maxVal)
                    {
                        maxVal = arr[i, j];
                        maxIndex = Tuple.Create(i, j);
                    }
                }
            }

            int sum = 0;
            if (minIndex.Item1 == maxIndex.Item1)  // Одна строка
            {
                for (int j = minIndex.Item2 + 1; j < maxIndex.Item2; j++)
                {
                    sum += arr[minIndex.Item1, j];
                }
            }
            else if (minIndex.Item1 < maxIndex.Item1)
            {
                for (int j = minIndex.Item2 + 1; j < 5; j++)
                {
                    sum += arr[minIndex.Item1, j];
                }

                for (int i = minIndex.Item1 + 1; i < maxIndex.Item1; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        sum += arr[i, j];
                    }
                }

                for (int j = 0; j < maxIndex.Item2; j++)
                {
                    sum += arr[maxIndex.Item1, j];
                }
            }
            else  // minIndex.Item1 > maxIndex.Item1
            {
                for (int j = maxIndex.Item2 + 1; j < 5; j++)
                {
                    sum += arr[maxIndex.Item1, j];
                }

                for (int i = maxIndex.Item1 + 1; i < minIndex.Item1; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        sum += arr[i, j];
                    }
                }

                for (int j = 0; j < minIndex.Item2; j++)
                {
                    sum += arr[minIndex.Item1, j];
                }
            }

            Console.WriteLine(minVal + " " + maxVal);
            Console.WriteLine($"Сумма элементов между минимальным и максимальным элементами: {sum}");
        }
        static void ArrEx6()
        {
            Console.WriteLine("Введите текст:");
            string input = Console.ReadLine();

            char currentChar = input[0];
            int currentStreak = 1;
            int maxStreak = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == currentChar)
                {
                    currentStreak++;
                    maxStreak = Math.Max(maxStreak, currentStreak);
                }
                else
                {
                    currentChar = input[i];
                    currentStreak = 1;
                }
            }

            Console.WriteLine($"Максимальное количество подряд идущих одинаковых символов: {maxStreak}");
        }
        static void ArrEx7()
        {
            Console.WriteLine("Введите строку длиной 20 символов:");
            string input = Console.ReadLine();

            int digitCount = 0;
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    digitCount++;
                }
            }

            Console.WriteLine($"Количество цифр: {digitCount}");
        }
        static void ArrEx8()
        {
            Console.WriteLine("Введите текст, состоящий из 20 букв:");
            string input = Console.ReadLine();

            Console.WriteLine("Введите Ваше имя: ");
            string name = Console.ReadLine();

            bool canFormName = name.All(input.Contains);
            Console.WriteLine(canFormName ?"Ваше имя " + name + "содержится в строке" : "Нет имени");
        }
        static void ArrEx9()
        {
            Console.WriteLine("Введите строку длиной не более 255 символов:");
            string input = Console.ReadLine();

            string[] words = input.Split(' ');

            int count = 0;
            foreach (string word in words)
            {
                if (word[0] == word[word.Length - 1])
                {
                    count++;
                }
            }

            Console.WriteLine($"Количество слов с одинаковыми первым и последним символами: {count}");
        }
        static void ArrEx10()
        {
            Console.WriteLine("Введите маленькую русскую букву:");
            char input = Console.ReadLine()[0];

            char upper = char.ToUpper(input, System.Globalization.CultureInfo.GetCultureInfo("ru-RU"));
            Console.WriteLine($"Большая буква: {upper}");
        }
        static void StrEx1()
        {
            string word = "abcdefghiklmn";
            string a = word.Substring(0, 4);  // Первая треть
            string b = word.Substring(4, 4);  // Вторая треть
            string c = word.Substring(8, 4);  // Третья треть

            string result1 = b + c + a;
            string result2 = c + a + b;
            Console.WriteLine(word);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }
        static void StrEx2()
        {
            Console.WriteLine("Введите строку: ");
            string text = Console.ReadLine();  // Ваш текст
            int count = text.Count(ch => ch == '+' || ch == '-');
            Console.WriteLine(count);
        }
        static void StrEx3()
        {
            Console.WriteLine("Введите строку: ");
            string text = Console.ReadLine();  // Ваш текст
            int sentencesCount = text.Count(ch => ch == '.' || ch == '!' || ch == '?');
            Console.WriteLine(sentencesCount);
        }
        static void StrEx4()
        {
            Console.WriteLine("Введите строку: ");
            string text = Console.ReadLine();  // Ваш текст
            int mCount = text.Count(ch => ch == 'м');
            int nCount = text.Count(ch => ch == 'н');
            string result = mCount > nCount ? "м больше" : "н больше";
            Console.WriteLine(result);
        }
        static void StrEx5()
        {
            Console.WriteLine("Введите строку: ");
            string text = Console.ReadLine();  // Ваш текст
            int lastIndexS = text.LastIndexOf('с');
            int lastIndexT = text.LastIndexOf('Т');
            string laterLetter = lastIndexS > lastIndexT ? "с" : "Т";
            Console.WriteLine(laterLetter);
        }
        static void StrEx6()
        {
            Console.WriteLine("Введите строку: ");
            string text = Console.ReadLine();  // Ваш текст
            int indexA = text.IndexOf('а');
            bool containsA = indexA != -1;
            Console.WriteLine(containsA);
        }
        static void StrEx7()
        {
            Console.WriteLine("Введите строку: ");
            string text = Console.ReadLine();  // Ваш текст
            Console.WriteLine(text);
            text = text.Replace('е', 'и');
            Console.WriteLine(text);
        }
        static void StrEx8()
        {
            Console.WriteLine("Введите строку: ");
            string text = Console.ReadLine();  // Ваш текст
            char[] chars = text.ToCharArray();
            for (int i = 2; i < chars.Length; i += 3)
            {
                chars[i] = 'а';
            }
            text = new string(chars);
            Console.WriteLine(text);
        }
        static void StrEx9()
        {
            Console.WriteLine("Введите слово: ");
            string word = Console.ReadLine();  // Ваш текст
            char[] wordChars = word.ToCharArray();
            char temp = wordChars[1];
            wordChars[1] = wordChars[4];
            wordChars[4] = temp;
            word = new string(wordChars);
            Console.WriteLine(word);
        }
        static void StrEx10()
        {
            Console.WriteLine("Введите строку: ");
            string word = Console.ReadLine();  // Ваш текст
            int k = Convert.ToInt32(Console.ReadLine());  // Ваше значение k
            word = word.Remove(2, 1);  // а)
            Console.WriteLine("A) " + word);
            word = word.Remove(k - 1, 1);  // б)
            Console.WriteLine("B) " + word);
        }
        static void StrEx11()
        {
            Console.WriteLine("Введите строку: ");
            string text = Console.ReadLine();  // Ваш текст
            int digitsCount = text.Count(char.IsDigit);
        }
        static void StrEx12()
        {
            Console.WriteLine("Введите строку: ");
            string text = Console.ReadLine();  // Ваш текст
            string[] words = text.Split(' ');
            int sum = 0;
            foreach (string w in words)
            {
                if (int.TryParse(w, out int number))
                {
                    sum += number;
                }
            }
        }
        static void StrEx13()
        {
            Console.WriteLine("Введите предложение из 10 слов:");
            string sentence = Console.ReadLine();

            string[] wordsArray = new string[10];
            string[] splitWords = sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (splitWords.Length != 10)
            {
                Console.WriteLine("Предложение должно содержать ровно 10 слов!");
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                wordsArray[i] = splitWords[i];
            }

            Console.WriteLine("Ваш массив слов:");
            foreach (string word in wordsArray)
            {
                Console.WriteLine(word);
            }
        }
    }
}
