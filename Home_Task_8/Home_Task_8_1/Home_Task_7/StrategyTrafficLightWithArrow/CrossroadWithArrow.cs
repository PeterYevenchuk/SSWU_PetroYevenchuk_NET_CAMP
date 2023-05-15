using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Humanizer;
using System.Threading.Tasks;
using Home_Task_8.StrategyTrafficLight;

namespace Home_Task_8.StrategyTrafficLightWithArrow;

public class CrossroadWithArrow : BaseCrossroad
{

    private readonly TrafficLights _trafficLights;
    private readonly ControlerCrossroad _controlerTrafficLights;
    private readonly ShowInfo _showInfo;

    private TypeTrafficLightState _color;
    private string _arrowState;
    private TypeTrafficLightState _arrowColor;
    private bool _shouldStop = false;
    private int _delayTime;
    private int _delayTimeLittle;

    public CrossroadWithArrow(int numberCrossroad, int numberLine, ControlerCrossroad controlerTrafficLights, TypeTrafficLightState color, string arrowState, TypeTrafficLightState arrowColor) : base(numberCrossroad, numberLine)
    {
        _controlerTrafficLights = controlerTrafficLights;
        _trafficLights = new TrafficLights(TypeTrafficLightState.Red.ToString(), _controlerTrafficLights);
        _showInfo = new ShowInfo(new StrategyCrossroadWithArrow(), _trafficLights);

        _color = color;
        _arrowState = arrowState;
        _arrowColor = arrowColor;
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
                await ColorTimer(_delayTime, TypeTrafficLightState.Red, _arrowState, _arrowColor);
                await ColorTimer(_delayTimeLittle, TypeTrafficLightState.Yellow, _arrowState, TypeTrafficLightState.Yellow);
                _color = TypeTrafficLightState.Green;
                if (_arrowColor.ToString() == TypeTrafficLightState.Green.ToString()) _arrowColor = TypeTrafficLightState.Red;
                else _arrowColor = TypeTrafficLightState.Green;
            }
            else if (_color.ToString() == TypeTrafficLightState.Green.ToString())
            {
                await ColorTimer(_delayTime, TypeTrafficLightState.Green, _arrowState, _arrowColor);
                await ColorTimer(_delayTimeLittle, TypeTrafficLightState.Yellow, _arrowState, TypeTrafficLightState.Yellow);
                _color = TypeTrafficLightState.Red;
                if (_arrowColor.ToString() == TypeTrafficLightState.Red.ToString()) _arrowColor = TypeTrafficLightState.Green;
                else _arrowColor = TypeTrafficLightState.Red;
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
            else if (key == ConsoleKey.U)
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

    public async Task ColorTimer(int time, TypeTrafficLightState color, string arrowState, TypeTrafficLightState colorArrow)
    {
        await DebugeCrossroad();
        await DebugeLine();
        arrowState = arrowState.Humanize(LetterCasing.Title).Trim();
        _controlerTrafficLights.SetColorTrafficLights(color.ToString());
        _showInfo.StringDirectionArrow(arrowState);
        _showInfo.StringColorArrow(colorArrow.ToString());
        await Task.Delay(time);
    }

}
