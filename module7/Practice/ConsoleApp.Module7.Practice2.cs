using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Module8.Practice
{
    public class ArrayClass
    {
        private int[] values;

        public ArrayClass(int[] values)
        {
            this.values = values ?? throw new ArgumentNullException(nameof(values));
        }

        public static bool operator <(ArrayClass left, ArrayClass right)
        {
            return left.values.Sum() < right.values.Sum();
        }

        public static bool operator >(ArrayClass left, ArrayClass right)
        {
            return left.values.Sum() > right.values.Sum();
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
            ArrayClass array1 = new ArrayClass(new int[] { 1, 2, 3 });
            ArrayClass array2 = new ArrayClass(new int[] { 4, 5, 6 });

            Console.WriteLine($"Array 1: {array1}");
            Console.WriteLine($"Array 2: {array2}");
            Console.WriteLine($"Array1 > Array2: {array1 > array2}");
            Console.WriteLine($"Array1 < Array2: {array1 < array2}");
        }
    }
}
