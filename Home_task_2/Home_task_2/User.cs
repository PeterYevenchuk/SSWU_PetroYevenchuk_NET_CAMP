namespace Home_task_2;

public class User
{
    private double _waterConsumptionRate;

    public User(double waterConsumptionRate)
    {
        _waterConsumptionRate = waterConsumptionRate;
    }

    public double GetWaterConsumptionRate()
    {
        return _waterConsumptionRate;
    }
}
