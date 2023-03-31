using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_2
{
    internal class WaterPump
    {
        private double _capacity; // потужність качання води помпи
        private double _speed; // швидкість качання води помпи

        public WaterPump(double capacity, double speed)
        {
            _capacity = capacity;
            _speed = speed;
        }

        public double GetPumpingTime(double amount) // метод який вираховує час для закачування води
        {
            return amount / _speed;
        }

        public override string ToString()
        {
            return $"WaterPump: Capacity={_capacity}, PumpingSpeed={_speed}";
        }
    }
}
