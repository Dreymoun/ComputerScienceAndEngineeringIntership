using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Practice
{
    interface IPart
    {
        bool IsBuilt { get; set; }
    }

    interface IWorker
    {
        void Work(House house);
    }

    class House
    {
        public Basement Basement { get; set; }
        public List<Wall> Walls { get; set; }
        public Door Door { get; set; }
        public List<Window> Windows { get; set; }
        public Roof Roof { get; set; }

        public House()
        {
            Basement = new Basement();
            Walls = new List<Wall> { new Wall(), new Wall(), new Wall(), new Wall() };
            Door = new Door();
            Windows = new List<Window> { new Window(), new Window(), new Window(), new Window() };
            Roof = new Roof();
        }
    }

    class Basement : IPart
    {
        public bool IsBuilt { get; set; }
    }

    class Wall : IPart
    {
        public bool IsBuilt { get; set; }
    }

    class Door : IPart
    {
        public bool IsBuilt { get; set; }
    }

    class Window : IPart
    {
        public bool IsBuilt { get; set; }
    }

    class Roof : IPart
    {
        public bool IsBuilt { get; set; }
    }

    class Worker : IWorker
    {
        public void Work(House house)
        {
            if (!house.Basement.IsBuilt)
            {
                house.Basement.IsBuilt = true;
            }
            else if (house.Walls.Exists(w => !w.IsBuilt))
            {
                house.Walls.Find(w => !w.IsBuilt).IsBuilt = true;
            }
            else if (!house.Door.IsBuilt)
            {
                house.Door.IsBuilt = true;
            }
            else if (house.Windows.Exists(w => !w.IsBuilt))
            {
                house.Windows.Find(w => !w.IsBuilt).IsBuilt = true;
            }
            else if (!house.Roof.IsBuilt)
            {
                house.Roof.IsBuilt = true;
            }
        }
    }

    class TeamLeader : IWorker
    {
        public void Work(House house)
        {
            Console.WriteLine("Строительство дома:");
            Console.WriteLine($"Фундамент: {(house.Basement.IsBuilt ? "построен" : "не построен")}");
            Console.WriteLine($"Стены: {house.Walls.FindAll(w => w.IsBuilt).Count} из 4 построены");
            Console.WriteLine($"Дверь: {(house.Door.IsBuilt ? "установлена" : "не установлена")}");
            Console.WriteLine($"Окна: {house.Windows.FindAll(w => w.IsBuilt).Count} из 4 установлены");
            Console.WriteLine($"Крыша: {(house.Roof.IsBuilt ? "построена" : "не построена")}");
        }
    }

    class Team
    {
        private List<IWorker> workers;
        private TeamLeader leader;

        public Team()
        {
            workers = new List<IWorker>
        {
            new Worker(),
            new Worker(),
            new Worker()
        };
            leader = new TeamLeader();
        }

        public void BuildHouse(House house)
        {
            while (!house.Basement.IsBuilt || house.Walls.Exists(w => !w.IsBuilt) ||
                   !house.Door.IsBuilt || house.Windows.Exists(w => !w.IsBuilt) ||
                   !house.Roof.IsBuilt)
            {
                foreach (var worker in workers)
                {
                    worker.Work(house);
                    leader.Work(house);
                }
            }
            Console.WriteLine("Строительство дома завершено!");
            // Добавить здесь отображение рисунка дома
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            House house = new House();
            Team team = new Team();
            team.BuildHouse(house);
            DrawHouse();
        }

        static void DrawHouse()
        {
            Console.WriteLine("    /\\");
            Console.WriteLine("   /  \\");
            Console.WriteLine("  /____\\");
            Console.WriteLine("  |    |");
            Console.WriteLine("  |[]  |");
            Console.WriteLine("  |    |");
            Console.WriteLine(" _|____|_");
        }
    }

}
