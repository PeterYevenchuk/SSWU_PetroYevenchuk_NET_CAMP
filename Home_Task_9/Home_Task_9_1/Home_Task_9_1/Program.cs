
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Home_Task_9_1;

public class Program
{
    static void Main(string[] args)
    {
        Cook beverageCook = new BeverageCook();
        Cook pizzaCook = new PizzaCook();
        Cook dessertCook = new DessertCook();

        beverageCook.SetNextCook(pizzaCook);
        pizzaCook.SetNextCook(dessertCook);

        RandomSetChef randomSetChef = new RandomSetChef();

        // Замовлення
        string[] dishes = { "Піца 4 сири", "Піца Гавайська", "Десерт Райський", "Десерт Тірамісу", "Сік Ананасовий", "Вода Газована" };
        int[] quantities = { 2, 2, 1, 3, 5, 1 };

        // Словник з поварами та їхніми департаментами
        Dictionary<string, List<string>> departmentChefs = new Dictionary<string, List<string>>
        {
            { "десерти", new List<string> { "Pierre Hermé", "Dominique Ansel", "Christina Tosi", "Adriano Zumbo", "Claire Ptak", "Johnny Iuzzini" } },
            { "піци", new List<string> { "Giuseppe Pepe", "Antonio Carluccio", "Gennaro Contaldo", "Nancy Silverton", "Chris Bianco", "Tony Gemignani"} },
            { "напої", new List<string> { "Dale DeGroff", "Salvatore Calabrese", "Audrey Saunders", "Charles Schumann", "Tony Conigliaro", "Julie Reiner" } }
        };

        // Обробка замовлення
        string result = string.Empty;
        for (int i = 0; i < dishes.Length; i++)
        {
            result += beverageCook.HandleOrder(dishes[i], quantities[i], randomSetChef.SetChef(dishes[i], departmentChefs));
        }

        Console.WriteLine(result);
    }
}