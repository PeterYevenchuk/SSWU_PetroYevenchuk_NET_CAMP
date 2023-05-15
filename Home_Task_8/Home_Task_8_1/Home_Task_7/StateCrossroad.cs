using Home_Task_8.StrategyTrafficLight;
using Home_Task_8.StrategyTrafficLightWithArrow;
using System;
using System.Collections.Generic;
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
                await SetStrategy(GetNumStrategy(j), i, j);
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
        int time = int.TryParse(Console.ReadLine(), out int result) ? result : 10; Console.WriteLine("Set defolt: 10");
        return time;
    }

    private async Task SetStrategy(int numStrategy, int numberCrossroad, int numberLine)
    {
        switch (numStrategy)
        {
            case 1:
                var baseCrossroad = new Crossroad(numberCrossroad, numberLine, _controlerTrafficLights, RandomColortrafficLight());
                AddCrossroad(baseCrossroad);
                break;
            case 2:
                var baseCrossroadArrow = new CrossroadWithArrow(numberCrossroad, numberLine, _controlerTrafficLights, RandomColortrafficLight(), RandomLeftOrRight(), RandomColortrafficLight());
                AddCrossroad(baseCrossroadArrow);
                break;
        }
    }

    private int GetNumStrategy(int item)
    {
        Console.WriteLine($"Lines {item}");
        Console.WriteLine("Choose a Traffic Light: 1 - Traffic Light, 2 - Traffic Light With Arrow ");
        int numStrategy = int.TryParse(Console.ReadLine(), out int result) ? result : 1; Console.WriteLine("Set defolt: 1");
        return numStrategy;
    }

    private TypeTrafficLightState RandomColortrafficLight()
    {

        TypeTrafficLightState[] values = (TypeTrafficLightState[])Enum.GetValues(typeof(TypeTrafficLightState));
        Random random = new Random();
        int randomIndex = random.Next(1, 3);
        return values[randomIndex];
    }

    private string RandomLeftOrRight()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, 2);
        if (randomIndex == 1) return "Right";
        if (randomIndex == 2) return "Left";
        return "Left";
    }
}
