using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_2
{
    internal class WaterTower
    {
        private double _maxCapacity;
        public double CurrentCapacity { get; private set; } // рівень води на даний час

        public WaterTower(double maxCapacity)
        {
            _maxCapacity = maxCapacity;
        }

        public bool IsFull()
        {
            return CurrentCapacity >= _maxCapacity;
        }

        public void AddWater(double water) 
        {
            if (CurrentCapacity + water > _maxCapacity)
            {
                throw new ArgumentException("Cannot add water to the tower as it exceeds the max volume.");
            }

            CurrentCapacity += water;
        }

        public void RemoveWater(double water)
        {
            if(CurrentCapacity - water <= 0)
            {
                throw new ArgumentException("Cannot remove water from the tower as it will go below zero.");
            }
            CurrentCapacity -= water;
        }

        public override string ToString()
        {
            return  $"WaterTower: MaxVolume={_maxCapacity}, CurrentVolume={CurrentCapacity}";
        }

    }
}
