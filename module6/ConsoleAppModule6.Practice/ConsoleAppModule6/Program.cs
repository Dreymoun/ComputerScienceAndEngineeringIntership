using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule6
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyLibrary.Person person = new MyLibrary.Person("John", "Doe", 30);
            string info = MyLibrary.PersonInfo.GetInfo(person);

            Console.WriteLine(info);
        }
    }
}
