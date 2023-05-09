using System;
using System.Threading.Tasks;

namespace Home_Task_7;
// не побачила копій екрану.
// сумарний бал 92
public class Program
{
    //В своїй програмі я використав патерн стратегію для подальшого розширення програми в майбутньому,
    //а також за допомогою івента я свайпаю кольори світловори. Для регулювання часу роботи кольорів
    //світлофора я заюзав асинхронне програмування.
    
    //І добавлю те що при першому запуску програми користувач сам вибирає час і на якому напрямку дороги буде зелене світло, а на якому червоне

    static async Task Main(string[] args)
    {
        SimulatorTrafficLights simulatorTrafficLights = new SimulatorTrafficLights(new StrategyTrafficLightsFirst());

        Console.WriteLine("Enter the time for the traffic light to change color: ");
        int time = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Select the road number on which the traffic light will be green (East-West West-East = 1, " +
            "North-South South-North = 2): ");
        int roadTrafficLight = Convert.ToInt32(Console.ReadLine());

        await simulatorTrafficLights.StartShow(time, roadTrafficLight);
    }
}
