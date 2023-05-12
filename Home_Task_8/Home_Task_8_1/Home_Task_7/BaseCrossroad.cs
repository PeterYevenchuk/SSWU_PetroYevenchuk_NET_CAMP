using Home_Task_8.StrategyTrafficLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Home_Task_8;

public abstract class BaseCrossroad
{
    public int Number { get; set; }
    public int WorkTime { get; set; }

    public abstract Task StartShow();

    protected BaseCrossroad(int number)
    {
        Number = number;
    }

    public async Task DebugeCrossroad()
    {
        Console.WriteLine($"Number crossroad = {Number}");
    }

    public async Task InitTime(int time)
    {
        WorkTime = time;
    }
}
