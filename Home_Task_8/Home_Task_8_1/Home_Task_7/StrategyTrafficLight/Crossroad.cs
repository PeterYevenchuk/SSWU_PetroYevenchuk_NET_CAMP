using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_8.StrategyTrafficLight;

public class Crossroad : BaseCrossroad
{
    private readonly TrafficLights _trafficLights;
    private readonly ControlerCrossroad _controlerTrafficLights;
    private readonly ShowInfo _showInfo;

    private TypeTrafficLightState _color;
    private bool _shouldStop = false;
    private int _delayTime;
    private int _delayTimeLittle;

    public Crossroad(int numberCrossroad, int numberLine, ControlerCrossroad controlerTrafficLights, TypeTrafficLightState color) : base(numberCrossroad, numberLine)
    {
        _controlerTrafficLights = controlerTrafficLights;
        _trafficLights = new TrafficLights(TypeTrafficLightState.Red.ToString(), _controlerTrafficLights);
        _showInfo = new ShowInfo(new StrategyCrossroadByDefolt(), _trafficLights);

        _color = color;
    }

    public override async Task StartShow()
    {
        int time = WorkTime * 1000;
        _delayTime = Convert.ToInt32(time * 0.7);
        _delayTimeLittle = Convert.ToInt32(time * 0.3);


        while (!_shouldStop)
        {
            if (_color.ToString() == TypeTrafficLightState.Red.ToString())
            {
                await ColorTimer(_delayTime, TypeTrafficLightState.Red);
                await ColorTimer(_delayTimeLittle, TypeTrafficLightState.Yellow);
                _color = TypeTrafficLightState.Green;
            }
            else if (_color.ToString() == TypeTrafficLightState.Green.ToString())
            {
                await ColorTimer(_delayTime, TypeTrafficLightState.Green);
                await ColorTimer(_delayTimeLittle, TypeTrafficLightState.Yellow);
                _color = TypeTrafficLightState.Red;
            }
            await ProcessConsoleCommands();
        }
    }

    public override async Task ProcessConsoleCommands()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Enter)
            {
                // При натисканні кнопки "Enter" програма завершить роботу
                _shouldStop = true;
                _trafficLights.UnsubscribeTrafficLights();
            }
            else if (key == ConsoleKey.T)
            {
                Console.WriteLine("Enter the new traffic light operating time in seconds: ");
                var newTimeInput = Console.ReadLine() ?? $"{WorkTime}";
                if (int.TryParse(newTimeInput, out int newTime))
                {
                    newTime = newTime * 1000;
                    _delayTime = Convert.ToInt32(newTime * 0.7);
                    _delayTimeLittle = Convert.ToInt32(newTime * 0.3);
                }
                else
                {
                    Console.WriteLine("Incorrect time. The previous time will be used.\n");
                }
            }
        }
    }

    public async Task ColorTimer(int time, TypeTrafficLightState color)
    {
        await DebugeCrossroad();
        await DebugeLine();
        _controlerTrafficLights.SetColorTrafficLights(color.ToString());
        _showInfo.StringDirection();
        _showInfo.StringColor();
        await Task.Delay(time);
    }
}
