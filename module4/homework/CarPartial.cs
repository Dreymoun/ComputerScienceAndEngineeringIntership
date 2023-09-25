using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNamespace
{
    public partial class Car
    {
        public void Honk()
        {
            Console.WriteLine($"{model} гудит: БИП БИП!");
        }
    }
}
