namespace Home_Task_10_2;

public class ClothingProduct : Product
{
    public override void Accept(IShippingVisitor visitor)
    {
        visitor.Visit(this);
    }
}
