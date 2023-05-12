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

    public async Task Initialize(int count)
    {
        for (int i = 1; i < count + 1; i++)
        {
            await SetStrategy(GetNumStrategy(i), i);
        }
    
    }

    public async Task SetTimeCrossroads()
    {
        foreach (var item in _baseCrossroads)
        {
            await item.DebugeCrossroad();
            await item.InitTime(GetTimeCrossroad());
        }
    }

    public async Task Start()
    {
        foreach (var item in _baseCrossroads)
        {
            await item.StartShow();
        }
    }

    private int GetTimeCrossroad()
    {
        Console.WriteLine("Enter the time for the traffic light to change color: ");
        int numStrategy = Convert.ToInt32(Console.ReadLine());
        return numStrategy;
    }

    private async Task SetStrategy(int numStrategy, int item)
    {
        switch (numStrategy)
        {
            case 1:
                var baseCrossroad = new Crossroad(item, _controlerTrafficLights, RandomColortrafficLight());
                AddCrossroad(baseCrossroad);
                break;
            case 2:
                var baseCrossroadArrow = new CrossroadWithArrow(item, _controlerTrafficLights, RandomColortrafficLight(), RandomLeftOrRight(), RandomColortrafficLight());
                AddCrossroad(baseCrossroadArrow);
                break;
        }
    }

    private int GetNumStrategy(int item)
    {
        Console.WriteLine($"Crossroad {item}");
        Console.WriteLine("Choose a strategy: 1 - StrategyCrossroadByDefault, 2 - StrategyCrossroadWithArrow ");
        int numStrategy = Convert.ToInt16(Console.ReadLine());
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
