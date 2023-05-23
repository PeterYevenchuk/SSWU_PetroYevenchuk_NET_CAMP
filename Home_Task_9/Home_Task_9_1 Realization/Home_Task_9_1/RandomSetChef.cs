using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_9_1;

public class RandomSetChef
{
    public string SetChef(string dishes, Dictionary<string, List<string>> departmentChefs)
    {
        var random = new Random();

        string[] words = dishes.Split(' ');
        string firstWord = words[0].ToLower();

        if (firstWord.Contains("десерт"))
        {
            List<string> dessertChefs;
            if (departmentChefs.TryGetValue("десерти", out dessertChefs))
            {
                string randomChef = dessertChefs[random.Next(dessertChefs.Count)];
                return randomChef;
            }

        }
        else if (firstWord.Contains("піца"))
        {
            List<string> pizzaChefs;
            if (departmentChefs.TryGetValue("піци", out pizzaChefs))
            {
                string randomChef = pizzaChefs[random.Next(pizzaChefs.Count)];
                return randomChef;
            }
        }
        else if (firstWord.Contains("сік") || firstWord.Contains("вода"))
        {
            List<string> drinkChefs;
            if (departmentChefs.TryGetValue("напої", out drinkChefs))
            {
                string randomChef = drinkChefs[random.Next(drinkChefs.Count)];
                return randomChef;
            }
        }
        throw new Exception("Немає такаго відділу де можна приготувати дане блюдо!");
    }
}
