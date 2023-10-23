using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLib.WorldOfTanks
{
    public class Tank
    {
        private string _name;
        private int _ammoLevel;      // Боекомплект
        private int _armorLevel;     // Уровень брони
        private int _maneuverabilityLevel;  // Уровень маневренности

        private static Random _random = new Random();

        public Tank(string name)
        {
            _name = name;
            _ammoLevel = _random.Next(101);
            _armorLevel = _random.Next(101);
            _maneuverabilityLevel = _random.Next(101);
        }

        public static Tank operator ^(Tank tank1, Tank tank2)
        {
            int winCriteriaTank1 = 0;
            int winCriteriaTank2 = 0;

            if (tank1._ammoLevel > tank2._ammoLevel) winCriteriaTank1++;
            else winCriteriaTank2++;

            if (tank1._armorLevel > tank2._armorLevel) winCriteriaTank1++;
            else winCriteriaTank2++;

            if (tank1._maneuverabilityLevel > tank2._maneuverabilityLevel) winCriteriaTank1++;
            else winCriteriaTank2++;

            return winCriteriaTank1 > winCriteriaTank2 ? tank1 : tank2;
        }

        public override string ToString()
        {
            return $"{_name}: Ammo Level - {_ammoLevel}, Armor Level - {_armorLevel}, Maneuverability Level - {_maneuverabilityLevel}";
        }
    }
}
