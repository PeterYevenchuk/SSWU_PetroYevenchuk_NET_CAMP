using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Home_Task_9_1;

public class BeverageCook : Cook
{
    private const int COOKINGTIME = 5; // час приготування напоїв

    public override string HandleOrder(string dishName, int quantity, string chefName)
    {
        Console.OutputEncoding = Encoding.UTF8;

        string[] words = dishName.Split(' ');
        string firstWord = words[0].ToLower();

        if (quantity > 0 && (firstWord.Contains("сік") || firstWord.Contains("вода")))
        {
            return $"Приготування напоїв: {dishName} ({quantity} шт.) виконає {chefName} за {COOKINGTIME} хв!\n";
        }
        else if (nextCook != null)
        {
            return nextCook.HandleOrder(dishName, quantity, chefName);
        }
        return string.Empty;
    }
}
