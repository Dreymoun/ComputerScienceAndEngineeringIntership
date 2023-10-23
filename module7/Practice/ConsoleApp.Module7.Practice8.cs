using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp.Module8.Practice
{
    public class FracClass
    {
        private int numerator;
        private int denominator;

        public FracClass(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");

            this.numerator = numerator;
            this.denominator = denominator;
        }

        public static FracClass operator +(FracClass a, FracClass b)
        {
            int num = a.numerator * b.denominator + b.numerator * a.denominator;
            int den = a.denominator * b.denominator;
            return new FracClass(num, den);
        }

        // Implement other operators: -, *, / similarly...

        public static implicit operator double(FracClass f)
        {
            return (double)f.numerator / f.denominator;
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        public override bool Equals(object obj)
        {
            if (obj is FracClass)
            {
                FracClass other = (FracClass)obj;
                return this.numerator * other.denominator == other.numerator * this.denominator;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(FracClass left, FracClass right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FracClass left, FracClass right)
        {
            return !(left == right);
        }
        public static FracClass TestOperation(FracClass a, FracClass b)
        {
            return a + b;
        }
    }

    public struct FracStruct
    {
        private int numerator;
        private int denominator;

        public FracStruct(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");

            this.numerator = numerator;
            this.denominator = denominator;
        }

        public static FracStruct operator +(FracStruct a, FracStruct b)
        {
            int num = a.numerator * b.denominator + b.numerator * a.denominator;
            int den = a.denominator * b.denominator;
            return new FracStruct(num, den);
        }

        // Implement other operators: -, *, / similarly...

        public static implicit operator double(FracStruct f)
        {
            return (double)f.numerator / f.denominator;
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        public override bool Equals(object obj)
        {
            if (obj is FracStruct)
            {
                FracStruct other = (FracStruct)obj;
                return this.numerator * other.denominator == other.numerator * this.denominator;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(FracStruct left, FracStruct right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FracStruct left, FracStruct right)
        {
            return !(left == right);
        }
        public static FracStruct TestOperation(FracStruct a, FracStruct b)
        {
            return a + b;
        }
    }

    public class Program
    {
        public static void Main()
        {
            FracClass a = new FracClass(1, 2);
            FracClass b = new FracClass(3, 4);

            FracStruct x = new FracStruct(1, 2);
            FracStruct y = new FracStruct(3, 4);

            const int iterations = 1000000;

            Stopwatch stopwatch = new Stopwatch();

            // Тест класса
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                FracClass.TestOperation(a, b);
            }
            stopwatch.Stop();
            Console.WriteLine($"Class took {stopwatch.ElapsedMilliseconds}ms for {iterations} iterations.");

            // Тест структуры
            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                FracStruct.TestOperation(x, y);
            }
            stopwatch.Stop();
            Console.WriteLine($"Struct took {stopwatch.ElapsedMilliseconds}ms for {iterations} iterations.");
        }
    }
}
