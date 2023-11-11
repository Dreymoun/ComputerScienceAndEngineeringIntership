using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8.Practice
{
    public class SquaredArray
    {
        private int[] _array;

        public SquaredArray(int size)
        {
            _array = new int[size];
        }

        public int this[int index]
        {
            get => _array[index];
            set => _array[index] = value * value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var squaredArray = new SquaredArray(3);
            squaredArray[0] = 2;
            squaredArray[1] = 3;
            squaredArray[2] = 4;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"squaredArray[{i}] = {squaredArray[i]}");
            }
        }
    }

}
