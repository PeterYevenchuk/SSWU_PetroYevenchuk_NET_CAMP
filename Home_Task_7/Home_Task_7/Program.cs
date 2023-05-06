using System;
using System.Threading.Tasks;

namespace Home_Task_7;

public class Program
{
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