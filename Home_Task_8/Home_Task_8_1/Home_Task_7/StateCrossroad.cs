using Home_Task_8.StrategyTrafficLight;
using Home_Task_8.StrategyTrafficLightWithArrow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_8;

public class StateCrossroad
{
    private List<BaseCrossroad> _baseCrossroads = new();

    private readonly ControlerCrossroad _controlerTrafficLights;

    public StateCrossroad(ControlerCrossroad controlerTrafficLights)
    {
        _controlerTrafficLights = controlerTrafficLights;
    }

    private TypeTrafficLightState _colorArrow;
    private string _directionArrow;

    public void AddCrossroad(BaseCrossroad baseCrossroad)
    {
        _baseCrossroads.Add(baseCrossroad);
    }

    public async Task Initialize(int count, int lines)
    {
        for (int i = 1; i < count + 1; i++)
        {
            Console.WriteLine($"Crossroad {i}");
            for (int j = 1; j < lines + 1; j++)
            {
                await SetStrategy(GetNumStrategy(j), GetColorForTrafficLight(j), i, j);
            }
        }
    }

    public async Task SetTimeCrossroads()
    {
        
        foreach (var item in _baseCrossroads)
        {
            await item.DebugeCrossroad();
            await item.DebugeLine();
            await item.InitTime(GetTimeCrossroad());
        }
    }

    public async Task Start()
    {
        List<Task> showTasks = _baseCrossroads.Select(crossroad => crossroad.StartShow()).ToList();
        await Task.WhenAll(showTasks);

        List<Task> commandTasks = _baseCrossroads.Select(crossroad => crossroad.ProcessConsoleCommands()).ToList();
        await Task.WhenAll(commandTasks);
    }

    private int GetTimeCrossroad()
    {
        Console.WriteLine("Enter the time for the traffic light to change color: ");
        int time = int.TryParse(Console.ReadLine(), out int result) ? result : 10;
        return time;
    }

    private async Task SetStrategy(int numStrategy, TypeTrafficLightState color, int numberCrossroad, int numberLine)
    {
        switch (numStrategy)
        {
            case 1:
                var baseCrossroad = new Crossroad(numberCrossroad, numberLine, _controlerTrafficLights, color);
                AddCrossroad(baseCrossroad);
                break;
            case 2:
                var baseCrossroadArrow = new CrossroadWithArrow(numberCrossroad, numberLine, _controlerTrafficLights, color, _directionArrow, _colorArrow);
                AddCrossroad(baseCrossroadArrow);
                break;
        }
    }

    private int GetNumStrategy(int item)
    {
        Console.WriteLine($"Lines {item}");
        Console.WriteLine("Choose a Traffic Light: 1 - Traffic Light, 2 - Traffic Light With Arrow ");
        int numStrategy = int.TryParse(Console.ReadLine(), out int result) ? result : 1;
        if (numStrategy == 2)
        {
            DirectionArrowAndColor();
            return numStrategy;
        }
        return numStrategy;
    }

    private TypeTrafficLightState GetColorForTrafficLight(int item)
    {
        Console.WriteLine($"Lines {item}");
        Console.WriteLine("Choose a Traffic Light color: 1 - Red, 2 - Green ");
        int numColor = int.TryParse(Console.ReadLine(), out int result) ? result : 1;
        if (numColor == 1) return TypeTrafficLightState.Red;
        else if (numColor == 2) return TypeTrafficLightState.Green;
        else throw new Exception("Not correct!");
    }

    private void DirectionArrowAndColor()
    {
        Console.WriteLine("Choose a Traffic Light color: 1 - Red, 2 - Green ");
        int numColor = int.TryParse(Console.ReadLine(), out int result) ? result : 1;
        if (numColor == 1) _colorArrow = TypeTrafficLightState.Red;
        else if (numColor == 2) _colorArrow = TypeTrafficLightState.Green;
        else throw new Exception("Not correct!");

        Console.WriteLine("Choose a direction arrow color: 1 - Left, 2 - Right ");
        int numArrow = int.TryParse(Console.ReadLine(), out result) ? result : 1;
        if (numColor == 1) _directionArrow = "Left";
        else if (numColor == 2) _directionArrow = "Right";
        else throw new Exception("Not correct!");
    }

}
