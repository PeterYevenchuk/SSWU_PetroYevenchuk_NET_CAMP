
namespace Home_Task_10_1;

public class CardTypeDeterminer
{
    public string GetCardType(string cardNumber)
    {
        if (cardNumber.StartsWith("34") || cardNumber.StartsWith("37"))
        {
            return "American Express";
        }
        else if (cardNumber.StartsWith("51") || cardNumber.StartsWith("52") ||
                 cardNumber.StartsWith("53") || cardNumber.StartsWith("54") ||
                 cardNumber.StartsWith("55"))
        {
            return "MasterCard";
        }
        else if (cardNumber.StartsWith("4"))
        {
            return "Visa";
        }

        return "Unknown";
    }
}
