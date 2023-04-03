using Home_task_2.WaterSimulationSystem;

namespace Home_task_2;

public class MainView : View
{
    private WaterSimulation _waterSimulation;
    private User _user;
    public MainView(WaterSimulation waterSimulation, User user)
    {
        _waterSimulation = waterSimulation;
        _user = user;
    }

    public override void SendCommand()
    {
        _waterSimulation.Simulate(_user.GetWaterConsumptionRate());
    }
}
