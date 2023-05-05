using System.Threading.Tasks;

namespace Home_Task_7;

public delegate void GreenAndRedTrafficLights(int time);

public class MonitorTrafficLights
{
    private readonly IStrategyTrafficLights _strategyTrafficLights;

    public MonitorTrafficLights(IStrategyTrafficLights strategyTrafficLights)
    {
        _strategyTrafficLights = strategyTrafficLights;
    }

    public event GreenAndRedTrafficLights OnSwipeColorEvent;

    public async void StartShowGreen(int time)
    {
        bool result = false;
        int timeResult = time * 1000;
        int delayTime = Convert.ToInt32(timeResult * 0.7);
        int delayTimeLittle = Convert.ToInt32(timeResult * 0.3);
        bool shouldStop = false;

        DirectionWriter();

        while (!shouldStop)
        {
            if (result == false)
            {
                result = true;
                _strategyTrafficLights.ConsoleWriterColor(TypeTrafficLightState.Red.ToString(), 
                    TypeTrafficLightState.Green.ToString());
                await Task.Delay(delayTime);
                _strategyTrafficLights.ConsoleWriterYellow(TypeTrafficLightState.Yellow.ToString());
                await Task.Delay(delayTimeLittle);
            }
            else
            {
                result = false;
                _strategyTrafficLights.ConsoleWriterColor(TypeTrafficLightState.Green.ToString(),  
                    TypeTrafficLightState.Red.ToString());
                await Task.Delay(delayTimeLittle);

                _strategyTrafficLights.ConsoleWriterYellow(TypeTrafficLightState.Yellow.ToString());
                await Task.Delay(delayTimeLittle);
            }

            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                shouldStop = true;
            }
        }
        Stop();
    }

    public void Start(int time)
    {
        OnSwipeColorEvent += StartShowGreen;
        OnSwipeColorEvent(time);
    }

    public void Stop()
    {
        OnSwipeColorEvent -= StartShowGreen;
    }

    private void DirectionWriter()
    {
        Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15}",
            TypeDirection.East + "-" + TypeDirection.West,
            TypeDirection.West + "-" + TypeDirection.East,
            TypeDirection.North + "-" + TypeDirection.South,
            TypeDirection.South + "-" + TypeDirection.North);
    }
}
