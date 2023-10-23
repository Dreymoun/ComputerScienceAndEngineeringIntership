using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Module8.Practice
{
    public class MyClass
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is MyClass other)
            {
                return Property1 == other.Property1 && Property2 == other.Property2;
            }
            return false;
        }

        public static bool operator ==(MyClass left, MyClass right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);

            return left.Equals(right);
        }

        public static bool operator !=(MyClass left, MyClass right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Property1.GetHashCode();
                hash = hash * 23 + (Property2?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public override string ToString()
        {
            return $"Property1: {Property1}, Property2: {Property2}";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            MyClass obj1 = new MyClass { Property1 = 5, Property2 = "Hello" };
            MyClass obj2 = new MyClass { Property1 = 5, Property2 = "Hello" };
            MyClass obj3 = new MyClass { Property1 = 10, Property2 = "World" };

            Console.WriteLine($"obj1: {obj1}");
            Console.WriteLine($"obj2: {obj2}");
            Console.WriteLine($"obj3: {obj3}");

            Console.WriteLine($"obj1 == obj2: {obj1 == obj2}");
            Console.WriteLine($"obj1 != obj2: {obj1 != obj2}");
            Console.WriteLine($"obj1 == obj3: {obj1 == obj3}");
        }
    }
}
