using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module9.Homework
{
    class Employee
    {
        public string Name { get; }
        public int Age { get; }
        public decimal Salary { get; }

        public Employee(string name, int age, decimal salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public string GetInfo()
        {
            return $"Name: {Name}, Age: {Age}, Salary: {Salary}";
        }

        public virtual decimal CalculateAnnualSalary()
        {
            return Salary * 12;
        }
    }

    class Manager : Employee
    {
        public decimal Bonus { get; }

        public Manager(string name, int age, decimal salary, decimal bonus)
            : base(name, age, salary)
        {
            Bonus = bonus;
        }

        public override decimal CalculateAnnualSalary()
        {
            return base.CalculateAnnualSalary() + Bonus;
        }
    }

    class Developer : Employee
    {
        public int LinesOfCodePerDay { get; }

        public Developer(string name, int age, decimal salary, int linesOfCodePerDay)
            : base(name, age, salary)
        {
            LinesOfCodePerDay = linesOfCodePerDay;
        }

        public override decimal CalculateAnnualSalary()
        {
            decimal codePay = LinesOfCodePerDay * 365 * 0.5m; // предположим, что стоимость за строку кода - 0.5
            return base.CalculateAnnualSalary() + codePay;
        }
    }

    class Program
    {
        static void Main()
        {
            var manager = new Manager("Alice", 35, 5000, 10000);
            var developer = new Developer("Bob", 28, 4000, 100);

            Console.WriteLine(manager.GetInfo());
            Console.WriteLine("Manager Annual Salary: " + manager.CalculateAnnualSalary());

            Console.WriteLine(developer.GetInfo());
            Console.WriteLine("Developer Annual Salary: " + developer.CalculateAnnualSalary());
        }
    }
}
