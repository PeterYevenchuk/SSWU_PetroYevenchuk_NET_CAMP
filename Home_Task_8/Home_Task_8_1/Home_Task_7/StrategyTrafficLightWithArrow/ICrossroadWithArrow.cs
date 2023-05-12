using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_8.StrategyTrafficLightWithArrow;

public interface ICrossroadWithArrow
{
    public void WriterColor(string color, string colorArrow);
    public void WriteDirection(string direction);
}
