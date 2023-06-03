
namespace Home_Task_10_1;

public class CardInfoExtractor
{
    public string ExtractCardNumber(string input)
    {
        int startIndex = input.IndexOf('=') + 1;
        string cardNumber = input.Substring(startIndex).Replace("\"", "").Replace(" ", "");

        return cardNumber;
    }
}
