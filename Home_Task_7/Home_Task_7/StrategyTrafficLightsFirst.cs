using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_7;

public sealed class StrategyTrafficLightsFirst : IStrategyTrafficLights
{
    public void ConsoleWriterColor(string color1, string color2)
    {
        Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15}", 
            color1, color1, color2, color2);
    }

    public void ConsoleWriterYellow(string color)
    {
        Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15}",
            color, color, color, color);
    }
}
