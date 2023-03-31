namespace Home_task_2.ComponentWaterSimulation;

public class WaterPump
{
    private double _speedWater; // швидкість качання води помпи

    public WaterPump(double speedWater)
    {
        _speedWater = speedWater;
    }

    public double GetPumpingTime(double amount) // метод який вираховує час для закачування води
    {
        return amount / _speedWater;
    }

    public void PumpState(bool isActive)
    {
        string str;
        if (isActive)
        {
            str = "Pump open.";
        }
        else
        {
            str = "Pump close";
        }
        Console.WriteLine(str);

    }

    public override string ToString()
    {
        return $"WaterPump: PumpingSpeed={_speedWater}";
    }
}
