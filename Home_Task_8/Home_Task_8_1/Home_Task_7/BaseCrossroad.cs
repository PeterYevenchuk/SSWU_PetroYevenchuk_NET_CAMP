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
    public int NumberCrossroad { get; set; }
    public int NumberLine {get; set; }
    public int WorkTime { get; set; }

    public abstract Task StartShow();

    public abstract Task ProcessConsoleCommands();

    protected BaseCrossroad(int numberCrossroad, int numberLine)
    {
        NumberCrossroad = numberCrossroad;
        NumberLine = numberLine;
    }

    public async Task DebugeCrossroad()
    {
        Console.WriteLine($"Number crossroad = {NumberCrossroad}");
    }

    public async Task DebugeLine()
    {
        Console.WriteLine($"Number line = {NumberLine}");
    }

    public async Task InitTime(int time)
    {
        WorkTime = time;
    }
}
