using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp2
{
    /* 1.	2.	Построить три класса (базовый и 3 потомка), описывающих некоторых хищных животных
     * (один из потомков), всеядных(второй потомок) и травоядных (третий потомок).
     * Описать в базовом классе абстрактный метод для расчета количества и типа пищи, необходимого для пропитания животного в зоопарке.
a.	Упорядочить всю последовательность животных по убыванию количества пищи.
    При совпадении значений – упорядочивать данные по алфавиту по имени.
    Вывести идентификатор животного, имя, тип и количество потребляемой пищи для всех элементов списка.
b.	Вывести первые 5 имен животных из полученного в пункте а) списка.
c.	Вывести последние 3 идентификатора животных из полученного в пункте а) списка.
d.	Организовать запись и чтение коллекции в/из файл.
e.	Организовать обработку некорректного формата входного файла.
 */

    abstract class Animal
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public abstract string FoodType { get; }
        public virtual int FoodQuantity { get; set; }

        // Рассчитываем необходимое количество пищи для животного
        public abstract void CalculateFoodQuantity();
    }

    class Carnivore : Animal
    {
        public override string FoodType => "Carnivore";

        public override void CalculateFoodQuantity()
        {
            // Пример: львы потребляют примерно 5-7 кг мяса в день.
            if (Name == "Lion") FoodQuantity = 6;
            
        }
    }

    class Omnivore : Animal
    {
        public override string FoodType => "Omnivore";

        public override void CalculateFoodQuantity()
        {
            // Пример: медведи могут потреблять до 20 кг еды в день в зависимости от типа пищи.
            if (Name == "Bear") FoodQuantity = 20;
            
        }
    }

    class Herbivore : Animal
    {
        public override string FoodType => "Herbivore";

        public override void CalculateFoodQuantity()
        {
            // Пример: слоны потребляют примерно 150-170 кг растительной пищи в день.
            if (Name == "Elephant") FoodQuantity = 160;
            
        }
    }

    class Program
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>
        {
            new Carnivore { ID = "1", Name = "Lion" },
            new Omnivore { ID = "2", Name = "Bear" },
            new Herbivore { ID = "3", Name = "Elephant" }
            
        };

            foreach (var animal in animals)
            {
                animal.CalculateFoodQuantity();
                Console.WriteLine($"ID: {animal.ID}, Name: {animal.Name}, Type: {animal.FoodType}, Food Quantity: {animal.FoodQuantity}kg");
            }
        }
    }
}
