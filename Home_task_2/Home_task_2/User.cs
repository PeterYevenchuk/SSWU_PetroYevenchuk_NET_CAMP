using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_2
{
    internal class User
    {
        private string _name;
        private double _waterConsumptionRate;

        public User(double waterConsumptionRate)
        {
            _waterConsumptionRate = waterConsumptionRate;
        }
    }
}
