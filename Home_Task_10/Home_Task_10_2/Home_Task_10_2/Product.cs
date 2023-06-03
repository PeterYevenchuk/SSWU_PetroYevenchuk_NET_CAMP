namespace Home_Task_10_2;

public abstract class Product
{
    public abstract void Accept(IShippingVisitor visitor);
    public double Weight { get; set; }
    public double Size { get; set; }
}
