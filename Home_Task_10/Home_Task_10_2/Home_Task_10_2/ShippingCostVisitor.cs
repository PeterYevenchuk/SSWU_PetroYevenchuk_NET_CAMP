namespace Home_Task_10_2;

public class ShippingCostVisitor : IShippingVisitor
{
    public double TotalCost { get; private set; }

    public void Visit(FoodProduct product)
    {
        double baseCost = product.Weight * product.Size;
        double urgencySurcharge = product.IsPerishable ? baseCost * 0.2 : 0;
        TotalCost += baseCost + urgencySurcharge;
    }

    public void Visit(ElectronicsProduct product)
    {
        double baseCost = product.Weight * product.Size;
        double sizeSurcharge = product.Size > product.StandardSize ? baseCost * product.ExtraSizeSurcharge : 0;
        TotalCost += baseCost + sizeSurcharge;
    }

    public void Visit(ClothingProduct product)
    {
        TotalCost += product.Weight * product.Size;
    }
}
