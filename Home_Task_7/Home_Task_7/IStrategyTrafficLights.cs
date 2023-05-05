using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_7;

public interface IStrategyTrafficLights
{
    public void ConsoleWriterColor(string color1, string color2);
    public void ConsoleWriterYellow(string color);
}
