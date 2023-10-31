using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8.Practice
{
    public class RangeOfArray<T>
    {
        private T[] _internalArray;
        private int _start;
        private int _end;

        public RangeOfArray(int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentException("Start index must be less than or equal to end index.");
            }

            _start = start;
            _end = end;
            _internalArray = new T[_end - _start + 1];
        }

        public T this[int index]
        {
            get
            {
                if (index < _start || index > _end)
                {
                    throw new IndexOutOfRangeException();
                }
                return _internalArray[index - _start];
            }
            set
            {
                if (index < _start || index > _end)
                {
                    throw new IndexOutOfRangeException();
                }
                _internalArray[index - _start] = value;
            }
        }

        public int Length => _end - _start + 1;
    }
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class Supermarket
    {
        public Dictionary<string, Product> _products = new Dictionary<string, Product>();

        public Product this[string name]
        {
            get
            {
                if (!_products.ContainsKey(name))
                {
                    throw new KeyNotFoundException($"Такого продукта '{name}' нет.");
                }

                return _products[name];
            }
            set { _products[name] = value; }
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (var product in _products.Values)
            {
                total += product.Price;
            }

            // Проверяем текущее время и предоставляем скидку, если это утро
            DateTime now = DateTime.Now;
            if (now.Hour >= 8 && now.Hour < 12)
            {
                Console.WriteLine("Вы получили скидку 5%");
                total *= 0.95; // скидка 5%
            }

            return total;
        }
    }

    class Program
    {
        static void Main()
        {
            int index1, index2 = 0;
            Console.WriteLine("Введите нижнюю границу: ");
            index1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите верхнюю границу: ");
            index2 = int.Parse(Console.ReadLine());
            RangeOfArray<int> array = new RangeOfArray<int>(index1, index2);
            Random random = new Random();

            for (int i = index1; i <= index2; i++)
            {
                array[i] = random.Next(1, 20);
                Console.WriteLine($"array[{i}] = {array[i]}");
            }

            array[5] = 228;
            for (int i = index1; i <= index2; ++i)
            {
                Console.WriteLine(array[i]);
            }

            Console.WriteLine("------------------------");

            Supermarket basket = new Supermarket();
            basket["Apple"] = new Product { Name = "Яблоко", Price = 600.99 };
            basket["Banana"] = new Product { Name = "Banana", Price = 800.01 };

            double total = basket.CalculateTotal();
            Console.WriteLine($"Total cost: {total}");
        }
    }

}
