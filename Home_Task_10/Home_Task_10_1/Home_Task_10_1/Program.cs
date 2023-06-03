
namespace Home_Task_10_1;

class Program
{
    static void Main(string[] args)
    {
        //string input = "# MasterCard # card_number = \"5555555555554444\"";
        //string input = "# Visa # card_number = \"4003 7891 0020 5381\"";
        string input = "# American Express # card_number = \"378282246310005\"";

        CreditCardValidator validator = new CreditCardValidator();
        CardInfoExtractor extractor = new CardInfoExtractor();
        CardTypeDeterminer determiner = new CardTypeDeterminer();

        string cardNumber = extractor.ExtractCardNumber(input);
        string cardType = determiner.GetCardType(cardNumber);
        bool isValid = validator.ValidateCardNumber(cardNumber);

        if( isValid )
        {
            Console.WriteLine("Card Type: " + cardType);
            Console.WriteLine("Card Number: " + cardNumber);
            Console.WriteLine("Valid: " + isValid);
        }
        else
        {
            Console.WriteLine("Valid: " + isValid);
        }
    }
}