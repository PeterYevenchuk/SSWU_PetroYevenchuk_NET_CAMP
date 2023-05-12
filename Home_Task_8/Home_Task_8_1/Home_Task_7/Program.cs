using Home_Task_8.StrategyTrafficLight;
using Home_Task_8.StrategyTrafficLightWithArrow;
using System;
using System.Threading.Tasks;

namespace Home_Task_8;

public class Program
{

    static async Task Main(string[] args)
    {

        ControlerCrossroad controlerTrafficLights = new();

        Console.WriteLine("In order to change the time of operation of the traffic light, press T," +
            " and in order to exit, press Enter.");

        await controlerTrafficLights.CreateCrossroad(2);
        await controlerTrafficLights.SetTime();
        await controlerTrafficLights.StartShowCrossroad();
        
    }

}
