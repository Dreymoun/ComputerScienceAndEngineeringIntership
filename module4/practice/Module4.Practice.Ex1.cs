using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp2
{
    public class Student
    {
        public string SurnameAndInitials { get; set; }
        public int GroupNumber { get; set; }
        public int[] Grades { get; set; }

        public double AverageGrade => Grades.Average();

        // Проверка на то, что все оценки студента равны 4 или 5
        public bool HasOnlyGoodGrades => Grades.All(grade => grade == 4 || grade == 5);
    }

    public class Program
    {
        public static void Main()
        {
            Student[] students = new Student[10];

            // Пример заполнения массива студентов (в реальности вы можете получить эти данные откуда-то еще)
            for (int i = 0; i < 10; i++)
            {
                students[i] = new Student
                {
                    SurnameAndInitials = $"Student{i}",
                    GroupNumber = i,
                    Grades = new[] { 5, 4, 4, 5, 4 }  // Просто пример оценок для демонстрации
                };
            }

            // Упорядочивание записей по возрастанию среднего балла
            students = students.OrderBy(s => s.AverageGrade).ToArray();

            // Вывод фамилий и номеров групп студентов, имеющих оценки 4 и 5
            foreach (var student in students)
            {
                if (student.HasOnlyGoodGrades)
                {
                    Console.WriteLine($"Surname: {student.SurnameAndInitials}, Group Number: {student.GroupNumber}");
                }
            }
        }
    }
}
