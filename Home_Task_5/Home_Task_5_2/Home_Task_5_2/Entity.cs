namespace Home_Task_5_2;

public abstract class Entity
{
    public string Name { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public int Index { get; set; }

    public double Area
    {
        get { return Length * Width; }
    }
}