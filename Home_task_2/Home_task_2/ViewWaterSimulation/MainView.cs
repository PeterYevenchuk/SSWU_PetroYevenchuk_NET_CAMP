using Home_task_2.WaterSimulationSystem;

namespace Home_task_2;

public class MainView : View
{
    private WaterSimulation _waterSimulation;
    public MainView(WaterSimulation waterSimulation)
    {
        _waterSimulation = waterSimulation;
    }

    public override void SendCommand()
    {
        _waterSimulation.Simulate(1);
    }
}
