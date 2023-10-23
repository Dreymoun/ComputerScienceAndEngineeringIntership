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

        // Оператор доступа по индексу
        public int this[int index]
        {
            get => values[index];
            set => values[index] = value;
        }

        // Оператор объединения массивов
        public static ArrayWrapper operator +(ArrayWrapper left, ArrayWrapper right)
        {
            int[] result = new int[left.values.Length + right.values.Length];
            left.values.CopyTo(result, 0);
            right.values.CopyTo(result, left.values.Length);
            return new ArrayWrapper(result);
        }

        // Операторы сравнения
        public static bool operator ==(ArrayWrapper left, ArrayWrapper right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArrayWrapper left, ArrayWrapper right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is ArrayWrapper other)
            {
                return values.SequenceEqual(other.values);
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

            var concatenated = array1 + array2; // Concatenate arrays
            Console.WriteLine($"Concatenated: {concatenated}");

            bool areEqual = array1 == array2; // Check equality
            Console.WriteLine($"Array1 == Array2: {areEqual}");

            bool areNotEqual = array1 != array2; // Check inequality
            Console.WriteLine($"Array1 != Array2: {areNotEqual}");
        }
    }
}
