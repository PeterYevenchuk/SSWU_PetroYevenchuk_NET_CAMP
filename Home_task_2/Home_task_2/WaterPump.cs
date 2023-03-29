using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_2
{
    internal class WaterPump
    {
        private double _capacity;
        private double _speed;

        public WaterPump(double capacity, double speed)
        {
            _capacity = capacity;
            _speed = speed;
        }

        public double GetPumpingTime(double amount)
        {
            return amount / _speed;
        }

        public override string ToString()
        {
            return $"WaterPump: Capacity={_capacity}, PumpingSpeed={_speed}";
        }
    }
}
