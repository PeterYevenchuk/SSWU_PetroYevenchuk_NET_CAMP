using Home_Task_10_2;

class Program
{
    public static void Main()
    {
        // Products
        var milk = new FoodProduct { Weight = 1.5, Size = 1.0, IsPerishable = true };
        var orange = new FoodProduct { Weight = 1.1, Size = 0.8, IsPerishable = false };

        var tv = new ElectronicsProduct { Weight = 8.5, Size = 10.0, StandardSize = 2.0, ExtraSizeSurcharge = 0.25 };
        var mobile = new ElectronicsProduct { Weight = 0.7, Size = 1.2, StandardSize = 2.0, ExtraSizeSurcharge = 0.25 };

        var tshirt = new ClothingProduct { Weight = 0.4, Size = 0.2 };
        var nike = new ClothingProduct { Weight = 0.8, Size = 0.6 };

        // Creation of goods
        var foodProduct = orange;
        var electronicsProduct = mobile;
        var clothingProduct = nike;

        var shippingCostVisitor = new ShippingCostVisitor();
        foodProduct.Accept(shippingCostVisitor);
        electronicsProduct.Accept(shippingCostVisitor);
        clothingProduct.Accept(shippingCostVisitor);

        Console.WriteLine($"Total shipping cost: {shippingCostVisitor.TotalCost:F2}");
    }
}