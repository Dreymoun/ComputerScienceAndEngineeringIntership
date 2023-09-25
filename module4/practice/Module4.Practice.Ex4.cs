using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp2
{
    /* 3.	Описать класс «домашняя библиотека». Предусмотреть возможность работы с 
     * произвольным числом книг, поиска книги по какому-либо признаку 
     * (например, по автору или по году издания), добавления книг в библиотеку, 
     * удаления книг из нее, сортировки книг по разным полям.
 */

    public class Car
    {
        public string Model { get; set; }
        public bool IsInRepair { get; set; } = false;
    }

    public class Driver
    {
        public string Name { get; set; }
        public bool IsAvailable { get; set; } = true;
    }

    public class Request
    {
        public Driver Driver { get; set; }
        public Car Car { get; set; }
        public string Destination { get; set; }
        public bool IsCompleted { get; set; } = false;
    }

    public class Dispatcher
    {
        private List<Driver> drivers = new List<Driver>();
        private List<Car> cars = new List<Car>();
        private List<Request> requests = new List<Request>();

        public Dispatcher()
        {
            // Initial drivers and cars
            drivers.Add(new Driver { Name = "Дмитрий" });
            drivers.Add(new Driver { Name = "Олег" });

            cars.Add(new Car { Model = "Toyota" });
            cars.Add(new Car { Model = "Hyundai" });
        }

        public void CreateRequest(string destination)
        {
            var availableDriver = drivers.Find(d => d.IsAvailable);
            var availableCar = cars.Find(c => !c.IsInRepair);

            if (availableDriver == null || availableCar == null)
            {
                Console.WriteLine("Нет доступных водителей или автомобилей.");
                return;
            }

            var request = new Request
            {
                Driver = availableDriver,
                Car = availableCar,
                Destination = destination
            };

            requests.Add(request);
            availableDriver.IsAvailable = false;

            Console.WriteLine($"Запрос в {destination} создан для водителя {availableDriver.Name} и автомобиля {availableCar.Model}.");
        }

        public void CompleteRequest(Driver driver)
        {
            var request = requests.Find(r => r.Driver == driver && !r.IsCompleted);
            if (request != null)
            {
                request.IsCompleted = true;
                driver.IsAvailable = true;
                Console.WriteLine($"Водитель {driver.Name} прибыл в место назначения {request.Destination}.");
            }
            else
            {
                Console.WriteLine($"Нет активных задач у {driver.Name}.");
            }
        }

        public void RepairRequest(Car car)
        {
            car.IsInRepair = true;
            Console.WriteLine($"Автомобиль {car.Model} в ремонте.");
        }

        public void ReturnCarFromRepair(Car car)
        {
            car.IsInRepair = false;
            Console.WriteLine($"Автомобиль {car.Model} доступен.");
        }

        public void SuspendDriver(Driver driver)
        {
            driver.IsAvailable = false;
            Console.WriteLine($"Водитель {driver.Name} приостановил работу.");
        }
    }

    public class Program
    {
        public static void Main()
        {
            Dispatcher dispatcher = new Dispatcher();

            // Create a request for a trip
            dispatcher.CreateRequest("Центр города");

            // Complete the trip
            dispatcher.CompleteRequest(new Driver { Name = "Дмитрий" });

            // Car needs a repair
            dispatcher.RepairRequest(new Car { Model = "Toyota" });

            // Return car after repair
            dispatcher.ReturnCarFromRepair(new Car { Model = "Toyota" });

            // Suspend a driver
            dispatcher.SuspendDriver(new Driver { Name = "Олег" });
        }
    }
}
