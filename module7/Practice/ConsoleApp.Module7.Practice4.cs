using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Module8.Practice
{
    public class ArrayWrapper
    {
        private int[] values;

        public ArrayWrapper(int[] values)
        {
            this.values = values ?? throw new ArgumentNullException(nameof(values));
        }

        // Оператор умножения массивов
        public static ArrayWrapper operator *(ArrayWrapper left, ArrayWrapper right)
        {
            if (left.values.Length != right.values.Length)
                throw new InvalidOperationException("Arrays must be of the same length for multiplication!");

            int[] result = new int[left.values.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = left.values[i] * right.values[i];
            }
            return new ArrayWrapper(result);
        }

        // Оператор доступа по индексу
        public int this[int index]
        {
            get => values[index];
            set => values[index] = value;
        }

        // Оператор преобразования к int (размер массива)
        public static explicit operator int(ArrayWrapper array)
        {
            return array.values.Length;
        }

        // Оператор сравнения на равенство
        public static bool operator ==(ArrayWrapper left, ArrayWrapper right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArrayWrapper left, ArrayWrapper right)
        {
            return !(left == right);
        }

        // Оператор сравнения
        public static bool operator <=(ArrayWrapper left, ArrayWrapper right)
        {
            if (left.values.Length != right.values.Length)
                return left.values.Length <= right.values.Length;

            for (int i = 0; i < left.values.Length; i++)
            {
                if (left.values[i] > right.values[i])
                    return false;
            }
            return true;
        }
        public static bool operator >=(ArrayWrapper left, ArrayWrapper right)
        {
            if (left.values.Length != right.values.Length)
                return left.values.Length >= right.values.Length;

            for (int i = 0; i < left.values.Length; i++)
            {
                if (left.values[i] < right.values[i])
                    return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj is ArrayWrapper other)
            {
                return (values.Length == other.values.Length) && values.SequenceEqual(other.values);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return values.GetHashCode();
        }

        public override string ToString()
        {
            return string.Join(", ", values);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayWrapper array1 = new ArrayWrapper(new int[] { 1, 2, 3 });
            ArrayWrapper array2 = new ArrayWrapper(new int[] { 4, 5, 6 });

            var result = array1 * array2; // Умножить
            Console.WriteLine($"Multiplication: {result}");

            int size = (int)array1; // Размеры array1
            Console.WriteLine($"Size of array1: {size}");

            bool areEqual = array1 == array2; // Проверить равны ли (по элементам)
            Console.WriteLine($"Array1 == Array2: {areEqual}");

            bool isLessOrEqual = array1 <= array2; // Меньше или равно (по длине)
            Console.WriteLine($"Array1 <= Array2: {isLessOrEqual}");

            bool isMoreOrEqual = array1 >= array2; // Больше или равно (по длине)
            Console.WriteLine($"Array1 >= Array2: {isLessOrEqual}");
        }
    }
}
