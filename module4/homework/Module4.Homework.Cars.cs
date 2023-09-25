using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using CarNamespace;

namespace ConsoleApp2
{
    /* 
        1.	Разработать один из классов на ваше усмотрение (примеры описаны ниже).
2.	Реализовать не менее пяти закрытых полей (различных типов), представляющих основные характеристики рассматриваемого класса.
3.	Создать не менее трех методов управления классом и методы доступа к его закрытым полям. 
4.	Создать метод, в который передаются аргументы по ссылке. 
5.	Создать не менее двух статических полей (различных типов), представляющих общие характеристики объектов данного класса. 
6.	Обязательным требованием является реализация нескольких перегруженных конструкторов, аргументы которых определяются студентом, исходя из специфики реализуемого класса, а также реализация конструктора по умолчанию.
7.	Создать статический конструктор.
8.	Создать массив (не менее 5 элементов) объектов созданного класса.
9.	Создать дополнительный метод для данного класса в другом файла, используя ключевое слово partial. 

    */
    class Program
    {

        static void Main()
        {
            Console.WriteLine($"Всего машин: {Car.TotalCarsCreated}");
            Console.WriteLine($"Местоположение завода: {Car.FactoryLocation}");

            Car[] cars = new Car[5]
            {
            new Car(),
            new Car("Tesla", "Красный"),
            new Car("Ford", "Синий", 2020, 2.0),
            new Car("BMW", "Черный", 2021, 3.0),
            new Car("Audi", "Серый", 2019, 1.8)
            };

            foreach (var car in cars)
            {
                car.StartEngine();
                car.Honk();
                car.StopEngine();
                Console.WriteLine("-------------------");
            }

            string modelName = "Nissan";
            cars[0].UpdateModel(ref modelName);
            Console.WriteLine($"Имя модели после изменения: {modelName}");
        }
    }
}
