using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace Home_Task_8;

public class ControlerCrossroad
{

    public event Action<string> OnSwipeColorEvent;

    private readonly StateCrossroad _stateCrossroad;

    public ControlerCrossroad()
    {
        this._stateCrossroad = new StateCrossroad(this);
    }

    public void SetColorTrafficLights(string color)
    {
        OnSwipeColorEvent?.Invoke(color);
    }

    public async Task CreateCrossroad(int countCrossroad, int countLines)
    {
        await _stateCrossroad.Initialize(countCrossroad, countLines);
    }

    public async Task SetTime()
    {
        await _stateCrossroad.SetTimeCrossroads();
    }

    public async Task StartShowCrossroad()
    {
        await _stateCrossroad.Start();
    }
}
