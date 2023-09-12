using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lesson2.Practice1
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
            Console.WriteLine("Введите четырехзначное число:");
            int number = int.Parse(Console.ReadLine());

            // a. Сумма цифр
            int sum = 0;
            int tempNumber = number;
            while (tempNumber != 0)
            {
                int digit = tempNumber % 10;
                sum += digit;
                tempNumber /= 10;
            }

            // b. Произведение цифр
            int product = 1;
            tempNumber = number;
            while (tempNumber != 0)
            {
                int digit = tempNumber % 10;
                product *= digit;
                tempNumber /= 10;
            }

            Console.WriteLine($"Сумма цифр: {sum}");
            Console.WriteLine($"Произведение цифр: {product}");
        }

        static void Ex2()
        {
            for (int x = 100; x <= 999; x++)
            {
                int firstDigit = x / 100;
                int lastTwoDigits = x % 100;
                int reconstructedNumber = lastTwoDigits * 10 + firstDigit;

                if (reconstructedNumber == 456)
                {
                    Console.WriteLine($"Число x: {x}");
                    break;
                }
            }
        }
        static void Ex3()
        {
            bool[] values = { true, false };

            Console.WriteLine("Таблица истинности логических выражений:");

            foreach (bool X in values)
            {
                foreach (bool Y in values)
                {
                    // a. не X и не Y;
                    bool resultA = !X && !Y;

                    // b. X или (не X и Y);
                    bool resultB = X || (!X && Y);

                    // c. (не X и Y) или Y;
                    bool resultC = (!X && Y) || Y;

                    Console.WriteLine($"X = {X}, Y = {Y}:");
                    Console.WriteLine($"a. не X и не Y = {resultA}");
                    Console.WriteLine($"b. X или (не X и Y) = {resultB}");
                    Console.WriteLine($"c. (не X и Y) или Y = {resultC}");
                    Console.WriteLine();
                }
            }
        }
        static void Ex4()
        {
            int num1 = 5;
            int num2 = 10;

            Console.WriteLine($"До изменений: num1 = {num1}, num2 = {num2}");

            // Меняем значения num1 и num2 с помощью временной переменной
            int temp = num1;
            num1 = num2;
            num2 = temp;

            Console.WriteLine($"После изменений: num1 = {num1}, num2 = {num2}");
        }
        static int f1(ref int a, ref int b, int x, int y)
        {
            if (y == 0)
            {
                return -1; // Деление на ноль
            }

            a = x * y;
            b = x / y;

            return 0;
        }
        static void Ex5()
        {
            int num1 = 0;
            int num2 = 0;
            int x = 5;
            int y = 2;

            int result = f1(ref num1, ref num2, x, y);

            if (result == 0)
            {
                Console.WriteLine($"a = {num1}, b = {num2}");
            }
            else
            {
                Console.WriteLine("Ошибка: деление на ноль.");
            }
        }
        static int f2(int x, int y)
        {
            if (x == 0 && y == 0)
            {
                return 0;
            }
            else if (y == 0)
            {
                return 12 / x;
            }
            else if (x == 0)
            {
                return 12 / y;
            }
            else
            {
                return 144 / (x * y);
            }
        }
        static void Ex6()
        {
            int x1 = 0, y1 = 0;
            int x2 = 5, y2 = 0;
            int x3 = 0, y3 = 3;
            int x4 = 4, y4 = 6;

            int result1 = f2(x1, y1);
            int result2 = f2(x2, y2);
            int result3 = f2(x3, y3);
            int result4 = f2(x4, y4);

            Console.WriteLine($"Значение 1: {result1}");
            Console.WriteLine($"Значение 2: {result2}");
            Console.WriteLine($"Значение 3: {result3}");
            Console.WriteLine($"Значение 4: {result4}");
        }
        static int CalculateSeconds(int h, int m, int s)
        {
            if (h < 0 || h > 23 || m < 0 || m > 59 || s < 0 || s > 59)
            {
                throw new ArgumentException("Некорректное время");
            }

            return h * 3600 + m * 60 + s;
        }
        static void Ex7()
        {
            int hours = 12;
            int minutes = 30;
            int seconds = 45;

            int totalSeconds = CalculateSeconds(hours, minutes, seconds);

            Console.WriteLine($"Секунд с начала дня: {totalSeconds}");
        }
        static int CalculateDays1(int m, int d)
        {
            if (m < 1 || m > 12 || d < 1 || d > 30)
            {
                throw new ArgumentException("Некорректная дата");
            }

            int daysInPreviousMonths = (m - 1) * 30;
            return daysInPreviousMonths + d;
        }
        static void Ex8()
        {
            int month = 5;
            int day = 15;

            int totalDays = CalculateDays1(month, day);

            Console.WriteLine($"Дней с начала года: {totalDays}");
        }
        static int CalculateDays2(int m, int d)
        {
            if (m < 1 || m > 12 || d < 1 || d > 31)
            {
                throw new ArgumentException("Некорректная дата");
            }

            int[] daysInMonth = { 31, 30, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int totalDays = 0;

            for (int i = 0; i < m - 1; i++)
            {
                totalDays += daysInMonth[i];
            }

            return totalDays + d;
        }
        static void Ex9()
        {
            int month = 9;
            int day = 12;
            
            int totalDays = CalculateDays2(month, day);

            Console.WriteLine($"Дней с начала года: {totalDays}");
        }
        static int FindMinimum(int m1 = 999, int m2 = 999, int m3 = 999)
        {
            int min = m1;

            if (m2 < min)
            {
                min = m2;
            }

            if (m3 < min)
            {
                min = m3;
            }

            return min;
        }
        static void Ex10()
        {
            int result1 = FindMinimum(5);
            int result2 = FindMinimum(7, 3);
            int result3 = FindMinimum(9, 2, 4);

            Console.WriteLine($"Минимальное число 1: {result1}");
            Console.WriteLine($"Минимальное число 2: {result2}");
            Console.WriteLine($"Минимальное число 3: {result3}");
        }
        static void Ex11()
        {
            int number1 = 7;
            int number2 = 12;

            bool isEven1 = number1 % 2 == 0;
            bool isEven2 = number2 % 2 == 0;

            Console.WriteLine($"{number1} четное: {isEven1}");
            Console.WriteLine($"{number2} четное: {isEven2}");
        }
        static void Ex12()
        {
            int num1 = 15;
            int num2 = 8;
            int num3 = 22;

            int minimum = num1;

            if (num2 < minimum)
            {
                minimum = num2;
            }

            if (num3 < minimum)
            {
                minimum = num3;
            }

            Console.WriteLine($"Минимальное число : {minimum}");
        }
        static void Ex13()
        {
            Random random = new Random();
            int grade = random.Next(2, 6);

            string result;

            switch (grade)
            {
                case 2:
                    result = "Неуд";
                    break;
                case 3:
                    result = "Удовл";
                    break;
                case 4:
                    result = "Хорошо";
                    break;
                case 5:
                    result = "Отлично";
                    break;
                default:
                    result = "Неизвестная оценка";
                    break;
            }

            // Запись результата в файл протокола
            File.WriteAllText("protokol.txt", result);

            Console.WriteLine($"Оценка: {result}");
        }
        
        static void Ex14()
        {
            int start = 1;
            int end = 10;
            int sum = 0;

            for (int i = start; i <= end; i++)
            {
                if (i % 2 != 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine($"Сумма нечетных чисел от {start} до {end}: {sum}");
        }
        static void Ex15()
        {
            int N = 15;
            int n = 7;
            int multiple = N;

            while (multiple % n != 0)
            {
                multiple++;
            }

            Console.WriteLine($"Наименьшее число, большее или равное {N}, делится нацело на {n}: {multiple}");
        }
    }
}
