namespace Home_Task_10_2;

public interface IShippingVisitor
{
    public void Visit(FoodProduct product);
    public void Visit(ElectronicsProduct product);
    public void Visit(ClothingProduct product);
}
