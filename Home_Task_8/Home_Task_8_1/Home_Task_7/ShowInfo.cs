using Home_Task_8.StrategyTrafficLight;
using Home_Task_8.StrategyTrafficLightWithArrow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_8;

public class ShowInfo
{
    private readonly TrafficLights _trafficLights;
    private readonly ICrossroadByDefolt _strategyTrafficLights;
    private readonly ICrossroadWithArrow _strategyTrafficLightsWithArrow;

    public ShowInfo(ICrossroadByDefolt strategyTrafficLights, TrafficLights trafficLights)
    {
        _strategyTrafficLights = strategyTrafficLights;
        _trafficLights = trafficLights;
    }

    public ShowInfo(ICrossroadWithArrow strategyTrafficLightsWithArrow, TrafficLights trafficLights)
    {
        _strategyTrafficLightsWithArrow = strategyTrafficLightsWithArrow;
        _trafficLights = trafficLights;
    }

    public void StringColor()
    {
        _strategyTrafficLights.WriterColor(_trafficLights.GetColor());
        
    }
    public void StringDirection()
    {
        _strategyTrafficLights.WriterDirection();
    }

    public void StringColorArrow(string colorArrow)
    {
        _strategyTrafficLightsWithArrow.WriterColor(_trafficLights.GetColor(), colorArrow);

    }

    public void StringDirectionArrow(string arrowState)
    {
        _strategyTrafficLightsWithArrow.WriteDirection(arrowState);
    }



}
