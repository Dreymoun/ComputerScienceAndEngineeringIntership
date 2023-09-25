using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNamespace
{
    public partial class Car
    {
        private string model;
        private string color;
        private int year;
        private double engineVolume;
        private bool isStarted;

        public static int TotalCarsCreated;
        public static string FactoryLocation = "Германия";

        static Car()
        {
            TotalCarsCreated = 0;
            Console.WriteLine("Статичный конструктор вызван.");
        }

        public Car()
        {
            model = "Стандартная модель";
            color = "Белый";
            year = 2000;
            engineVolume = 1.6;
            TotalCarsCreated++;
        }

        public Car(string model, string color) : this()
        {
            this.model = model;
            this.color = color;
            TotalCarsCreated++;
        }

        public Car(string model, string color, int year, double engineVolume) : this(model, color)
        {
            this.year = year;
            this.engineVolume = engineVolume;
            TotalCarsCreated++;
        }

        public void StartEngine()
        {
            isStarted = true;
            Console.WriteLine($"{model} поехала");
        }

        public void StopEngine()
        {
            isStarted = false;
            Console.WriteLine($"{model} остановилась");
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public void UpdateModel(ref string newModel)
        {
            model = newModel;
            return;
        }
    }
}
