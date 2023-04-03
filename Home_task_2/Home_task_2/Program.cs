using Home_task_2;
using Home_task_2.WaterSimulationSystem;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Print your capacity: ");
        double capacityUser = Convert.ToDouble(Console.ReadLine());

        SimulationOfWaterPumping simulationOfWaterPumping = new ();
        User user = new (capacityUser);
        MainView mainView = new (simulationOfWaterPumping, user);

        mainView.SendCommand();
    }
}