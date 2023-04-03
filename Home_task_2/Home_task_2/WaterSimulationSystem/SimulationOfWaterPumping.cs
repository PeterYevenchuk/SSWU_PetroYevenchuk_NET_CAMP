using Home_task_2.ComponentWaterSimulation;

namespace Home_task_2.WaterSimulationSystem;

public class SimulationOfWaterPumping : WaterSimulation
{
    public SimulationOfWaterPumping()
        : base(new WaterTower(300), new WaterPump(25)) { }

    public override void Simulate(double simulationDuration)
    {
        _waterTower.OnStatePumpEvent += _waterPump.PumpState;

        _waterTower.AddWater(simulationDuration);
        ToString();

        _waterTower.AddWater(simulationDuration);
        ToString();

        _waterTower.AddWater(simulationDuration);
        ToString();

    }
}
