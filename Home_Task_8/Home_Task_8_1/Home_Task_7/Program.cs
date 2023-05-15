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

        Console.WriteLine("In order to change the time of operation of the traffic light," +
            " press T for defolt traffic lights or U for traffic lights with arrow," +
            " and in order to exit, press Enter.");

        Console.Write("Enter the number of crossroads: ");
        int countCrossroad = Convert.ToInt32(Console.ReadLine() ?? "1");
        Console.WriteLine("Enter the number of lines in one full crossroad: ");
        int countLine = Convert.ToInt32(Console.ReadLine() ?? "4");
        Console.WriteLine();

        await controlerTrafficLights.CreateCrossroad(countCrossroad, countLine);
        await controlerTrafficLights.SetTime();
        await controlerTrafficLights.StartShowCrossroad();
        
    }

}
