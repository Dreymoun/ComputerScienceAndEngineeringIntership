using MyClassLib.WorldOfTanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksBattle
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tank[] t34Tanks = new Tank[5];
            Tank[] panteraTanks = new Tank[5];

            for (int i = 0; i < 5; i++)
            {
                t34Tanks[i] = new Tank("T-34");
                panteraTanks[i] = new Tank("Pantera");
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Battle {i + 1}:");
                Console.WriteLine(t34Tanks[i]);
                Console.WriteLine(panteraTanks[i]);

                Tank winner = t34Tanks[i] ^ panteraTanks[i];
                Console.WriteLine($"Winner: {winner}\n");
            }
        }
    }
}
