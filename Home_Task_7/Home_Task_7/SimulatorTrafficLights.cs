using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_7;

public class SimulatorTrafficLights
{
    public event Action<string> OnSwipeColorEvent;

    private TrafficLights _trafficLights;

    private readonly IStrategyTrafficLights _strategyTrafficLights;

    public SimulatorTrafficLights(IStrategyTrafficLights strategyTrafficLights)
    {
        _strategyTrafficLights = strategyTrafficLights;
        _trafficLights = new(TypeTrafficLightState.Red.ToString(), this);
    }

    public async Task StartShow(int time, int roadTrafficLightNumber)
    {
        int timeResult = time * 1000;
        int delayTime = Convert.ToInt32(timeResult * 0.7);
        int delayTimeLittle = Convert.ToInt32(timeResult * 0.3);
        bool shouldStop = false;

        DirectionWriter();

        while (!shouldStop)
        {
            if (roadTrafficLightNumber == 1)
            {
                roadTrafficLightNumber = 2;
                SetColorTrafficLights(TypeTrafficLightState.Green.ToString());
                await Task.Delay(delayTime);
                SetColorTrafficLights(TypeTrafficLightState.Yellow.ToString());
                await Task.Delay(delayTimeLittle);
            }
            else if (roadTrafficLightNumber == 2)
            {
                roadTrafficLightNumber = 1;
                SetColorTrafficLights(TypeTrafficLightState.Red.ToString());
                await Task.Delay(delayTime);
                SetColorTrafficLights(TypeTrafficLightState.Yellow.ToString());
                await Task.Delay(delayTimeLittle);
            }
            else
            {
                await Console.Out.WriteLineAsync("Not correct number!");
                break;
            }

            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                shouldStop = true;
            }
        }

        _trafficLights.UnsubscribeTrafficLights();
    }

    private void SetColorTrafficLights(string color)
    {
        OnSwipeColorEvent.Invoke(color);
        _strategyTrafficLights.ConsoleWriterColor(_trafficLights.GetColor());
    }
    private void DirectionWriter()
    {
        Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15}",
            TypeDirection.East + "-" + TypeDirection.West,
            TypeDirection.West + "-" + TypeDirection.East,
            TypeDirection.North + "-" + TypeDirection.South,
            TypeDirection.South + "-" + TypeDirection.North);
    }
}