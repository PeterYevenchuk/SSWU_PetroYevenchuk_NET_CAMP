namespace Home_Task_10_2;

public class FoodProduct : Product
{
    public bool IsPerishable { get; set; }
    public override void Accept(IShippingVisitor visitor)
    {
        visitor.Visit(this);
    }
}
