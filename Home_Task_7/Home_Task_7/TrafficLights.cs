using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_7;

public class TrafficLights
{
    private string _сolorTrafficLight;

    private readonly SimulatorTrafficLights _simulatorTrafficLights;
    public TrafficLights(string color, SimulatorTrafficLights simulatorTrafficLights)
    {
        _сolorTrafficLight = color;

        _simulatorTrafficLights = simulatorTrafficLights;
        SubscriptionTrafficLights();
    }
    private void SubscriptionTrafficLights()
    {
        _simulatorTrafficLights.OnSwipeColorEvent += SetColor;
    }
    public void UnsubscribeTrafficLights()
    {
        _simulatorTrafficLights.OnSwipeColorEvent -= SetColor;
    }

    private void SetColor(string color)
    {
        _сolorTrafficLight = color;
    }
    public string GetColor()
    {
        return _сolorTrafficLight;
    }
}