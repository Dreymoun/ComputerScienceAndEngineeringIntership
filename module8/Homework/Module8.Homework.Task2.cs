using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8.Homework
{
    public class Tariffs
    {
        public double HeatingRate { get; set; }
        public double WaterRate { get; set; }
        public double GasRate { get; set; }
        public double RepairRate { get; set; }
    }

    public enum Season
    {
        Autumn, Winter, Spring, Summer
    }

    public enum Benefit
    {
        None, LaborVeteran, WarVeteran
    }

    public class UtilityBillCalculator
    {
        private Tariffs _tariffs;
        private Season _season;
        private Benefit _benefit;

        public UtilityBillCalculator(Tariffs tariffs, Season season, Benefit benefit)
        {
            _tariffs = tariffs;
            _season = season;
            _benefit = benefit;
        }

        public void CalculateAndPrintBill(double area, int numberOfPeople)
        {
            double heating = _tariffs.HeatingRate * area * (_season == Season.Autumn || _season == Season.Winter ? 1.5 : 1.0);
            double water = _tariffs.WaterRate * numberOfPeople;
            double gas = _tariffs.GasRate * numberOfPeople;
            double repair = _tariffs.RepairRate * area;

            double total = heating + water + gas + repair;
            double benefitDiscount = (_benefit == Benefit.LaborVeteran ? 0.3 : (_benefit == Benefit.WarVeteran ? 0.5 : 0)) * heating;

            Console.WriteLine("Вид платежа | Начислено | Льготная скидка | Итого");
            Console.WriteLine($"Отопление   | {heating:F2} | {benefitDiscount:F2}          | {heating - benefitDiscount:F2}");
            Console.WriteLine($"Вода        | {water:F2} | 0.00          | {water:F2}");
            Console.WriteLine($"Газ         | {gas:F2} | 0.00          | {gas:F2}");
            Console.WriteLine($"Ремонт      | {repair:F2} | 0.00          | {repair:F2}");
            Console.WriteLine($"Итого       | {total:F2} | {benefitDiscount:F2}          | {total - benefitDiscount:F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tariffs tariffs = new Tariffs { HeatingRate = 1.2, WaterRate = 0.5, GasRate = 0.7, RepairRate = 0.3 };
            UtilityBillCalculator calculator = new UtilityBillCalculator(tariffs, Season.Winter, Benefit.LaborVeteran);

            calculator.CalculateAndPrintBill(50, 3); // Пример: площадь 50 м2, 3 человека, зима, льготы ветерана труда
        }
    }

}
