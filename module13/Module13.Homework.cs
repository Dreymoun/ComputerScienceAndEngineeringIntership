using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13.Homework
{
    class Client
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ServiceType { get; private set; }

        public Client(int id, string name, string serviceType)
        {
            Id = id;
            Name = name;
            ServiceType = serviceType;
        }

        public override string ToString()
        {
            return $"Client {Id}: {Name}, Service: {ServiceType}";
        }
    }

    class BankQueue
    {
        private Queue<Client> queue = new Queue<Client>();
        private int nextId = 1;

        public void AddClient(string name, string serviceType)
        {
            var client = new Client(nextId++, name, serviceType);
            queue.Enqueue(client);
            Console.WriteLine($"{client} added to the queue.");
        }

        public void ServeClient()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("No clients in the queue.");
                return;
            }

            var client = queue.Dequeue();
            Console.WriteLine($"{client} has been served.");
        }

        public void DisplayQueue()
        {
            Console.WriteLine("Current Queue:");
            foreach (var client in queue)
            {
                Console.WriteLine(client);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankQueue bankQueue = new BankQueue();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Add client to queue");
                Console.WriteLine("2. Serve client");
                Console.WriteLine("3. Display queue");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Service Type: ");
                        string serviceType = Console.ReadLine();
                        bankQueue.AddClient(name, serviceType);
                        break;
                    case "2":
                        bankQueue.ServeClient();
                        break;
                    case "3":
                        bankQueue.DisplayQueue();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
