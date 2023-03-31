using Home_task_2.ComponentWaterSimulation;

namespace Home_task_2.WaterSimulationSystem;

public abstract class WaterSimulation
{
    protected WaterTower _waterTower;
    protected WaterPump _waterPump;

    public WaterSimulation(WaterTower waterTower, WaterPump waterPump)
    {
        _waterTower = waterTower;
        _waterPump = waterPump;
    }

    public abstract void Simulate(double simulationDuration); //приймає вхідні дані та імітує роботу водонапірної башти
                                                              //та водяного насоса протягом зазначеного періоду
}
