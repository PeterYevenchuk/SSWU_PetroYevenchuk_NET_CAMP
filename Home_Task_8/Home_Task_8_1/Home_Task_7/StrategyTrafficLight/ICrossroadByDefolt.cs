using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_8.StrategyTrafficLight;

public interface ICrossroadByDefolt
{
    public void WriterColor(string color);
    public void WriterDirection();
}