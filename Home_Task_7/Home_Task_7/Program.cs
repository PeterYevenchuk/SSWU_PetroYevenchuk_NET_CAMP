using System;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_7;

public class Program
{
    static async Task Main(string[] args)
    {
        MonitorTrafficLights monitorTrafficLights = new MonitorTrafficLights(new StrategyTrafficLightsFirst());

        Console.WriteLine("Enter the time for the traffic light to change color: ");
        int time = Convert.ToInt32(Console.ReadLine());

        monitorTrafficLights.SubscriptionTrafficLights();
        await monitorTrafficLights.Start(time);
    }
}