using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_8;

public class TrafficLights
{
    private string _сolorTrafficLight;

    private readonly ControlerCrossroad _controlerTrafficLights;
    public TrafficLights(string color, ControlerCrossroad controlerTrafficLights)
    {
        _сolorTrafficLight = color;

        _controlerTrafficLights = controlerTrafficLights;
        SubscriptionTrafficLights();
    }
    private void SubscriptionTrafficLights()
    {
        _controlerTrafficLights.OnSwipeColorEvent += SetColor;
    }
    public void UnsubscribeTrafficLights()
    {
        _controlerTrafficLights.OnSwipeColorEvent -= SetColor;
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