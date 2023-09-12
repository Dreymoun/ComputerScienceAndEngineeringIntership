using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Lesson2.Homework
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
            //Ex16();
            //Ex17();
            //Ex18();
            //Ex19();
            //Ex20();
        }

        static void Ex1()
        {
            Console.WriteLine("Введите текст (для завершения введите точку):");

            char dot = '.';
            int spaceCounter = 0;

            while (true)
            {
                char inputChar = Console.ReadKey().KeyChar;

                if (inputChar == dot)
                {
                    break;
                }
                else if (inputChar == ' ')
                {
                    spaceCounter++;
                }
            }

            Console.WriteLine();

            Console.WriteLine($"Количество введенных пробелов: {spaceCounter}");
        }
        static void Ex2()
        {
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();
            char[] characters = input.ToCharArray();

            for (int i = 0; i < characters.Length; i++)
            {
                if (char.IsLetter(characters[i]))
                {
                    if (char.IsLower(characters[i]))
                    {
                        characters[i] = (char)(characters[i] - 32);
                    }
                    else if (char.IsUpper(characters[i]))
                    {
                        characters[i] = (char)(characters[i] + 32);
                    }
                }
            }

            string result = new string(characters);
            Console.WriteLine("Результат: " + result);

        }
        static void Ex3()
        {
            Console.WriteLine("Введите целое число:");
            int number = int.Parse(Console.ReadLine());

            int reversedNumber = 0;

            while (number != 0)
            {
                int digit = number % 10;
                reversedNumber = reversedNumber * 10 + digit;
                number /= 10;
            }

            Console.WriteLine($"Инвертированное число: {reversedNumber}");
            Console.ReadLine();
        }
        static void Ex4()
        {
            int number1 = 2;
            int number2 = 7;
            int number3 = 3;

            Console.WriteLine($"{number1}  {number2}  {number3}");
        }

        static void Ex5()
        {
            Console.WriteLine("5");
            Console.WriteLine("10");
            Console.WriteLine("21");
        }

        static void Ex6()
        {
            Console.WriteLine("Введите расстояние в сантиметрах:");
            int Cm = int.Parse(Console.ReadLine());

            int m = Cm / 100;

            Console.WriteLine($"Число полных метров: {m}");
        }
        static void Ex7()
        {
            int days = 234;
            int Week = 7;

            int Weeks = days / Week;

            Console.WriteLine($"Полных недель прошло: {Weeks}");
        }
        static void Ex8()
        {
            Console.WriteLine("Введите двузначное число:");
            int number = int.Parse(Console.ReadLine());

            int tens = number / 10;
            int units = number % 10;
            int sum = tens + units;
            int product = tens * units;

            Console.WriteLine($"Число десятков: {tens}");
            Console.WriteLine($"Число единиц: {units}");
            Console.WriteLine($"Сумма цифр: {sum}");
            Console.WriteLine($"Произведение цифр: {product}");
        }
        static void Ex9()
        {
            bool A = true;
            bool B = false;
            bool C = false;
           
            bool resultA = A || B;
            Console.WriteLine($"A или B: {resultA}");

            bool resultB = A && B;
            Console.WriteLine($"A и B: {resultB}");

            bool resultC = B || C;
            Console.WriteLine($"B или C: {resultC}");
        }
        static void Ex10()
        {
            Console.WriteLine("Введите радиус круга:");
            double radius = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите сторону квадрата:");
            double side = double.Parse(Console.ReadLine());

            double areaCircle = Math.PI * Math.Pow(radius, 2); // Площадь круга
            double areaSquare = Math.Pow(side, 2); // Площадь квадрата

            if (areaCircle > areaSquare)
            {
                Console.WriteLine("Площадь круга больше.");
            }
            else if (areaCircle < areaSquare)
            {
                Console.WriteLine("Площадь квадрата больше.");
            }
            else
            {
                Console.WriteLine("Площади равны.");
            }
        }
        static void Ex11()
        {
            for (int i = 20; i <= 35; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Введите значение b (b > 10):");
            int b1 = int.Parse(Console.ReadLine());

            if (b1 <= 10)
            {
                Console.WriteLine("Значение b должно быть больше 10.");
            }
            else
            {
                for (int i = 10; i <= b1; i++)
                {
                    int square = i * i;
                    Console.WriteLine($"Квадрат числа {i}: {square}");
                }
            }
            Console.WriteLine("Введите значение a (a < 50):");
            int a1 = int.Parse(Console.ReadLine());

            if (a1 >= 50)
            {
                Console.WriteLine("Значение a должно быть меньше 50.");
            }
            else
            {
                for (int i = a1; i <= 50; i++)
                {
                    int cube = i * i * i;
                    Console.WriteLine($"Третья степень числа {i}: {cube}");
                }
            }
            Console.WriteLine("Введите значение a:");
            int a2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите значение b:");
            int b2 = int.Parse(Console.ReadLine());

            if (b2 < a2)
            {
                Console.WriteLine("Значение b должно быть больше значения a.");
            }
            else
            {
                for (int i = a2; i <= b2; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void Ex12()
        {
            Console.WriteLine("Введите значение x:");
            double x = double.Parse(Console.ReadLine());

            double y = 7 * Math.Pow(x, 2) - 3 * x + 6;

            Console.WriteLine($"Значение функции y = 7x^2 - 3x + 6 при x = {x} равно {y}");
        }
        static void Ex13()
        {
            Console.WriteLine("Введите значение a:");
            double a = double.Parse(Console.ReadLine());

            double x = 12 * Math.Pow(a, 2) + 7 * a - 16;

            Console.WriteLine($"Значение функции x = 12a^2 + 7a - 16 при a = {a} равно {x}");
        }
        static void Ex14()
        {
            Console.WriteLine("Введите длину стороны квадрата:");
            double sideLength = double.Parse(Console.ReadLine());

            double perimeter = 4 * sideLength;

            Console.WriteLine($"Периметр квадрата: {perimeter}");
        }
        static void Ex15()
        {
            Console.WriteLine("Введите радиус окружности:");
            double radius = double.Parse(Console.ReadLine());

            double diameter = 2 * radius;

            Console.WriteLine($"Диаметр окружности: {diameter}");
        }
        static void Ex16()
        {
            double earthRadius = 6350; // Радиус Земли в км

            Console.WriteLine("Введите высоту над Землей (в км):");
            double height = double.Parse(Console.ReadLine());

            double horizonDistance = Math.Sqrt(Math.Pow(earthRadius + height, 2) - Math.Pow(earthRadius, 2));

            Console.WriteLine($"Расстояние до линии горизонта: {horizonDistance} км");
        }
        static void Ex17()
        {
            Console.WriteLine("Введите значение x:");
            double x = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите значение y:");
            double y = double.Parse(Console.ReadLine());

            double z = Math.Pow(x, 3) - 2.5 * x * y + 1.78 * Math.Pow(x, 2) - 2.5 * y + 1;

            Console.WriteLine($"Значение функции z = x^3 - 2.5xy + 1.78x^2 - 2.5y + 1 при x = {x} и y = {y} равно {z}");
        }
        static void Ex18()
        {
            Console.WriteLine("Введите первое целое число:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите второе целое число:");
            int num2 = int.Parse(Console.ReadLine());

            // Среднее арифметическое
            double avA = (num1 + num2) / 2.0;

            // Среднее геометрическое
            double avG = Math.Sqrt(num1 * num2);

            Console.WriteLine($"Среднее арифметическое: {avA}");
            Console.WriteLine($"Среднее геометрическое: {avG}");
        }
        static void Ex19()
        {
            Console.WriteLine("Введите натуральное число:");
            int number = int.Parse(Console.ReadLine());

            int sumOfDigits = 0;
            int originalNumber = number; // Сохраняем оригинальное число для последнего пункта (g)

            while (number > 0)
            {
                int digit = number % 10;
                sumOfDigits += digit;
                number /= 10;
            }

            bool isSumGreaterThan10 = sumOfDigits > 10;
            Console.WriteLine($"Сумма цифр больше 10: {isSumGreaterThan10}");

            // b. Верно ли, что произведение его цифр меньше 50?
            int productOfDigits = 1;
            number = originalNumber; // Восстанавливаем оригинальное число

            while (number > 0)
            {
                int digit = number % 10;
                productOfDigits *= digit;
                number /= 10;
            }

            bool isProductLessThan50 = productOfDigits < 50;
            Console.WriteLine($"Произведение цифр меньше 50: {isProductLessThan50}");

            // c. Верно ли, что количество его цифр есть четное число?
            bool isNumberOfDigitsEven = originalNumber.ToString().Length % 2 == 0;
            Console.WriteLine($"Количество цифр четное: {isNumberOfDigitsEven}");

            // d. Верно ли, что это число четырехзначное?
            bool isFourDigitNumber = originalNumber >= 1000 && originalNumber <= 9999;
            Console.WriteLine($"Четырехзначное число: {isFourDigitNumber}");

            // e. Верно ли, что его первая цифра не превышает 6?
            int firstDigit = int.Parse(originalNumber.ToString()[0].ToString());
            bool isFirstDigitNotGreaterThan6 = firstDigit <= 6;
            Console.WriteLine($"Первая цифра не превышает 6: {isFirstDigitNotGreaterThan6}");

            // f. Верно ли, что оно начинается и заканчивается одной и той же цифрой?
            int lastDigit = int.Parse(originalNumber.ToString()[originalNumber.ToString().Length - 1].ToString());
            bool startsAndEndsWithSameDigit = firstDigit == lastDigit;
            Console.WriteLine($"Начинается и заканчивается одной и той же цифрой: {startsAndEndsWithSameDigit}");

            // g. Определить, какая из его цифр больше: первая или последняя.
            bool isFirstDigitGreaterThanLastDigit = firstDigit > lastDigit;
            Console.WriteLine($"Первая цифра больше последней: {isFirstDigitGreaterThanLastDigit}");
        }
        static void Ex20()
        {
            Console.WriteLine("Таблица умножения на 9:");

            for (int i = 1; i <= 9; i++)
            {
                int result = 9 * i;
                Console.WriteLine($"9 x {i} = {result}");
            }
        }
    }
}
