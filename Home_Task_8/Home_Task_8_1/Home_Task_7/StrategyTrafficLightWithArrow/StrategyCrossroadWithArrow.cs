using Home_Task_8.StrategyTrafficLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_8.StrategyTrafficLightWithArrow;

public sealed class StrategyCrossroadWithArrow : ICrossroadWithArrow
{
    private string CheckerColor(string color)
    {
        return color switch
        {
            "Green" => TypeTrafficLightState.Red.ToString(),
            "Red" => TypeTrafficLightState.Green.ToString(),
            _ => TypeTrafficLightState.Yellow.ToString(),
        };
    }

    public void WriteDirection(string direction)
    {
        Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15} {4, -15}",
            TypeDirection.East + "-" + TypeDirection.West,
            TypeDirection.West + "-" + TypeDirection.East,
            TypeDirection.North + "-" + TypeDirection.South,
            TypeDirection.South + "-" + TypeDirection.North,
            "Arrow " + direction);
    }

    public void WriterColor(string color, string colorArrow)
    {
        var colorChange = CheckerColor(color);
        Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15} {4, -15}",
            color, color, colorChange, colorChange, colorArrow);
        Console.WriteLine();
    }

}
