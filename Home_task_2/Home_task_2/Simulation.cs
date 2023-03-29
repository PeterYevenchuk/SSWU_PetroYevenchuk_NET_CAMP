using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_2
{
    abstract class Simulation
    {
        private WaterTower WaterTower;
        private WaterPump WaterPump;

        protected Simulation(WaterTower waterTower, WaterPump waterPump)
        {
            WaterTower = waterTower;
            WaterPump = waterPump;
        }

        public abstract void Simulate(double simulationDuration); //приймає вхідні дані та імітує роботу водонапірної башти
                                                                  //та водяного насоса протягом зазначеного періоду
    }
}
