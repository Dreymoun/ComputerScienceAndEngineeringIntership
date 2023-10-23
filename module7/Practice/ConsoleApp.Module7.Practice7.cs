using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp.Module8.Practice
{
    public struct Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static implicit operator Complex(double real)
        {
            return new Complex(real, 0);
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }

        public override bool Equals(object obj)
        {
            if (obj is Complex)
            {
                Complex other = (Complex)obj;
                return this.Real == other.Real && this.Imaginary == other.Imaginary;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Real.GetHashCode() ^ Imaginary.GetHashCode();
        }

        public static bool operator ==(Complex left, Complex right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Complex left, Complex right)
        {
            return !(left == right);
        }
    }

    public class ComplexClass
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexClass(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static implicit operator ComplexClass(double real)
        {
            return new ComplexClass(real, 0);
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }

        public override bool Equals(object obj)
        {
            if (obj is ComplexClass)
            {
                ComplexClass other = (ComplexClass)obj;
                return this.Real == other.Real && this.Imaginary == other.Imaginary;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Real.GetHashCode() ^ Imaginary.GetHashCode();
        }

        public static bool operator ==(ComplexClass left, ComplexClass right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ComplexClass left, ComplexClass right)
        {
            return !(left == right);
        }
    }


    class Program
    {
        static void Main()
        {
            const int size = 1000000;
            Complex[] structArray = new Complex[size];
            ComplexClass[] classArray = new ComplexClass[size];

            // Заполняем массивы
            for (int i = 0; i < size; i++)
            {
                structArray[i] = new Complex(i, i);
                classArray[i] = new ComplexClass(i, i);
            }

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            // Операция над structArray
            foreach (var item in structArray)
            {
                var temp = item; // Просто какое-то действие, чтобы произвести измерение
            }
            stopwatch.Stop();
            Console.WriteLine($"Time for structure: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();

            stopwatch.Start();
            // Операция над classArray
            foreach (var item in classArray)
            {
                var temp = item;
            }
            stopwatch.Stop();
            Console.WriteLine($"Time for class: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
