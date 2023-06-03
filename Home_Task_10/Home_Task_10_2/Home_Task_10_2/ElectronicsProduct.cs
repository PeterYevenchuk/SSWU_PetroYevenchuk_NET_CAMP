namespace Home_Task_10_2;

public class ElectronicsProduct : Product
{
    public double StandardSize { get; set; }
    public double ExtraSizeSurcharge { get; set; }
    public override void Accept(IShippingVisitor visitor)
    {
        visitor.Visit(this);
    }
}
