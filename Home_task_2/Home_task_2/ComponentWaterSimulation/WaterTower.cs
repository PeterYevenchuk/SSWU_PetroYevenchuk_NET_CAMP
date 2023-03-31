namespace Home_task_2.ComponentWaterSimulation;

public class WaterTower
{
    public event Action<bool> OnStatePumpEvent;

    private double _maxWaterLevel;
    private double _currentWaterLevel;

    public double CurrentWaterLevel
    {
        get => _currentWaterLevel;
        private set => _currentWaterLevel = value;
    } // рівень води на даний час

    public WaterTower(double maxCapacity)
    {
        _maxWaterLevel = maxCapacity;
        RandomWaterFill();
    }

    public bool IsFull()
    {
        return CurrentWaterLevel >= _maxWaterLevel;
    }

    public void RandomWaterFill()
    {
        Random random = new Random();
        _currentWaterLevel = random.Next(50, 200);
    }

    public void AddWater(double water)
    {
        if (water <= 0)
        {
            throw new ArgumentOutOfRangeException("Water cannot zero.");
        }
        if (CurrentWaterLevel + water > _maxWaterLevel)
        {
            IsFull();
            OnStatePumpEvent?.Invoke(IsFull());
            throw new ArgumentException("Cannot add water to the tower as it exceeds the max volume.");
        }

        CurrentWaterLevel += water;
    }

    public void RemoveWater(double water)
    {
        if (water <= 0)
        {
            throw new ArgumentOutOfRangeException("Water cannot zero.");
        }
        if (CurrentWaterLevel - water <= 0)
        {
            IsFull();
            OnStatePumpEvent?.Invoke(IsFull());
            throw new ArgumentException("Cannot remove water from the tower as it will go below zero.");
        }
        CurrentWaterLevel -= water;
    }

    public override string ToString()
    {
        return $"WaterTower: MaxVolume={_maxWaterLevel}, CurrentVolume={CurrentWaterLevel}";
    }

}
