using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_9_1;

public class PizzaCook : Cook
{
    private const int COOKINGTIME = 15; // час приготування піци

    public override string HandleOrder(string dishName, int quantity, string chefName)
    {
        Console.OutputEncoding = Encoding.UTF8;

        string[] words = dishName.Split(' ');
        string firstWord = words[0].ToLower();

        if (quantity > 0 && firstWord.Contains("піца"))
        {
            return $"Приготування піци: {dishName} ({quantity} шт.) виконає {chefName} за {COOKINGTIME} хв!\n";
        }
        else if (nextCook != null)
        {
            return nextCook.HandleOrder(dishName, quantity, chefName);
        }
        return string.Empty;
    }
}
