using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Module8.Practice
{
    public class DecimalNumber
    {
        private const int SIZE = 100;
        private char[] values = new char[SIZE];

        private static bool IsGreaterOrEqual(DecimalNumber left, DecimalNumber right)
        {
            for (int i = 0; i < SIZE; i++)
            {
                if (left.values[i] > right.values[i])
                    return true;
                else if (left.values[i] < right.values[i])
                    return false;
            }
            return true; // они равны
        }

        public DecimalNumber(string number)
        {
            if (number.Length > SIZE)
                throw new ArgumentOutOfRangeException("Number is too large for the DecimalNumber class");

            // Fill with zeros
            for (int i = 0; i < SIZE; i++)
                values[i] = '0';

            // Copy number
            for (int i = 0; i < number.Length; i++)
                values[SIZE - number.Length + i] = number[i];
        }

        // Helper method for addition
        private static int CharToInt(char c) => c - '0';

        public static DecimalNumber operator +(DecimalNumber left, DecimalNumber right)
        {
            int carry = 0;
            char[] result = new char[SIZE];

            for (int i = SIZE - 1; i >= 0; i--)
            {
                int sum = CharToInt(left.values[i]) + CharToInt(right.values[i]) + carry;
                result[i] = (char)((sum % 10) + '0');
                carry = sum / 10;
            }

            if (carry > 0)
                throw new OverflowException("Addition resulted in an overflow");

            return new DecimalNumber(new string(result));
        }

        public static DecimalNumber operator -(DecimalNumber left, DecimalNumber right)
        {
            int borrow = 0;
            char[] result = new char[SIZE];

            for (int i = SIZE - 1; i >= 0; i--)
            {
                int diff = CharToInt(left.values[i]) - CharToInt(right.values[i]) - borrow;
                if (diff < 0)
                {
                    diff += 10;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }
                result[i] = (char)(diff + '0');
            }

            if (borrow > 0)
                throw new InvalidOperationException("Subtraction resulted in a negative number");

            return new DecimalNumber(new string(result));
        }

        public static DecimalNumber operator *(DecimalNumber left, DecimalNumber right)
        {
            char[] result = new char[SIZE * 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = '0';
            }

            for (int i = SIZE - 1; i >= 0; i--)
            {
                int carry = 0;
                for (int j = SIZE - 1; j >= 0; j--)
                {
                    int product = CharToInt(left.values[j]) * CharToInt(right.values[i]) + CharToInt(result[i + j + 1]) + carry;

                    result[i + j + 1] = (char)((product % 10) + '0');
                    carry = product / 10;
                }
                result[i] += (char)carry;
            }

            // Удаляем лидирующие нули и преобразуем в DecimalNumber
            string strResult = new string(result).TrimStart('0');
            if (strResult.Length > SIZE)
                throw new OverflowException("Multiplication resulted in an overflow");

            return new DecimalNumber(strResult.Length > 0 ? strResult : "0");
        }

        public static DecimalNumber operator /(DecimalNumber left, DecimalNumber right)
        {
            if (right.values.All(c => c == '0'))
                throw new DivideByZeroException();

            DecimalNumber quotient = new DecimalNumber("0");
            DecimalNumber temp = new DecimalNumber("0");

            for (int i = 0; i < SIZE; i++)
            {
                temp = temp * new DecimalNumber("10") + new DecimalNumber(left.values[i].ToString());

                int count = 0;
                while (IsGreaterOrEqual(temp, right))
                {
                    temp -= right;
                    count++;
                }

                quotient = quotient * new DecimalNumber("10") + new DecimalNumber(count.ToString());
            }

            return quotient;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            bool leadingZero = true;

            foreach (var val in values)
            {
                if (val != '0' || !leadingZero)
                {
                    sb.Append(val);
                    leadingZero = false;
                }
            }

            if (sb.Length == 0)
                return "0";

            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DecimalNumber num1 = new DecimalNumber("123");
            DecimalNumber num2 = new DecimalNumber("456");

            var result1 = num1 + num2;
            Console.WriteLine($"Result: {result1}");
            var result2 = num2 - num1;
            Console.WriteLine($"Result: {result2}");
            var result3 = num1 * num2;
            Console.WriteLine($"Result: {result3}");
            var result4 = num2 / num1;
            Console.WriteLine($"Result: {result4}");

        }
    }
}
