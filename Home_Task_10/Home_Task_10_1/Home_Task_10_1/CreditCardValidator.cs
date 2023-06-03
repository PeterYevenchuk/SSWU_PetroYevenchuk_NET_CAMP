
namespace Home_Task_10_1;

public class CreditCardValidator
{
    public bool ValidateCardNumber(string cardNumber)
    {
        int sum = 0;
        bool isSecondDigit = false;
        int[] digits = new int[cardNumber.Length];

        for (int i = 0; i < cardNumber.Length; i++)
        {
            digits[i] = int.Parse(cardNumber[i].ToString());
        }

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (isSecondDigit)
            {
                int doubledDigit = digits[i] * 2;
                if (doubledDigit > 9)
                {
                    doubledDigit = doubledDigit % 10 + doubledDigit / 10;
                }
                sum += doubledDigit;
            }
            else
            {
                sum += digits[i];
            }
            isSecondDigit = !isSecondDigit;
        }

        return sum % 10 == 0;
    }
}
