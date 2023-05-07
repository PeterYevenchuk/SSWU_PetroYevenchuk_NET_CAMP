using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_7;

public sealed class StrategyTrafficLightsFirst : IStrategyTrafficLights
{
    private string CheckerColor(string color) //Цей метод я використовую для свайпання кольорів
    {
        return color switch
        {
            "Green" => TypeTrafficLightState.Red.ToString(),
            "Red" => TypeTrafficLightState.Green.ToString(),
            _ => TypeTrafficLightState.Yellow.ToString(),
        };
    }

    public void ConsoleWriterColor(string color)
    {
        var colorChange = CheckerColor(color);
        Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15}", 
            color, color, colorChange, colorChange);
    }
}