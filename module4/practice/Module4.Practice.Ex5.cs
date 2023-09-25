using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp2
{
    /* 5.	Задача на взаимодействие между классами. Разработать систему «Железнодорожная касса». 
     * Пассажир делает заявку на станцию назначения, время и дату поездки. Система регистрирует Заявку и осуществляет поиск соответствующего Поезда. 
     * Пассажир делает выбор Поезда и получает Счет на оплату. Кассир вводит номера Поездов, промежуточные и конечные станции, цены.
 */

    public class Request
    {
        public string Destination { get; set; }
        public DateTime TravelDate { get; set; }
        public List<Train> AvailableTrains { get; set; } = new List<Train>();
    }

    public class Train
    {
        public int Number { get; set; }
        public string StartStation { get; set; }
        public string EndStation { get; set; }
        public decimal Price { get; set; }
    }

    public class System
    {
        private List<Train> trains = new List<Train>();

        public Request CreateRequest(string destination, DateTime date)
        {
            Request request = new Request
            {
                Destination = destination,
                TravelDate = date
            };

            request.AvailableTrains = trains.Where(t => t.EndStation == destination).ToList();

            return request;
        }

        public void AddTrain(Train train)
        {
            trains.Add(train);
        }

        public decimal GenerateBill(Train selectedTrain)
        {
            return selectedTrain.Price;
        }
    }

    public class Program
    {
        public static void Main()
        {
            System railwaySystem = new System();

            // Кассир вводит значения для поезда
            railwaySystem.AddTrain(new Train { Number = 101, StartStation = "A", EndStation = "B", Price = 100 });
            railwaySystem.AddTrain(new Train { Number = 102, StartStation = "A", EndStation = "C", Price = 150 });

            // Пример 1
            Request request1 = railwaySystem.CreateRequest("B", DateTime.Now);
            foreach (var train in request1.AvailableTrains)
            {
                Console.WriteLine($"Поезд номер {train.Number} со станции {train.StartStation} до станции {train.EndStation} стоит {train.Price}.");
            }
            decimal bill1 = railwaySystem.GenerateBill(request1.AvailableTrains.First());
            Console.WriteLine($"Цена данного поезда: {bill1}");

            // Пример 2
            Request request2 = railwaySystem.CreateRequest("C", DateTime.Now);
            foreach (var train in request2.AvailableTrains)
            {
                Console.WriteLine($"Поезд номер {train.Number} со станции {train.StartStation} до станции {train.EndStation} стоит {train.Price}.");
            }
            decimal bill2 = railwaySystem.GenerateBill(request2.AvailableTrains.First());
            Console.WriteLine($"Цена данного поезда: {bill2}");
        }
    }
}
