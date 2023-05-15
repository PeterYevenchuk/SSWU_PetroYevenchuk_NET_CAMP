using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_8.StrategyTrafficLight;

public sealed class StrategyCrossroadByDefolt : ICrossroadByDefolt
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

    public void WriterColor(string color)
    {
        var colorChange = CheckerColor(color);
        Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15}",
            color, color, colorChange, colorChange);
        Console.WriteLine();
    }

    public void WriterDirection()
    {
        Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15}",
            TypeDirection.East + "-" + TypeDirection.West,
            TypeDirection.West + "-" + TypeDirection.East,
            TypeDirection.North + "-" + TypeDirection.South,
            TypeDirection.South + "-" + TypeDirection.North);
    }
}