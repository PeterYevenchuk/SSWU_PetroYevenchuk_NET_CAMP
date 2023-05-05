using System.Text;

namespace Home_Task_7;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        MonitorTrafficLights monitorTrafficLights = new MonitorTrafficLights(new StrategyTrafficLightsFirst());

        Console.WriteLine("Введіть час для зміни кольору світлофора: ");
        int time = Convert.ToInt32(Console.ReadLine());

        monitorTrafficLights.Start(time);
    }
}