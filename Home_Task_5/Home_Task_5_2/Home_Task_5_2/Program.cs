using System.Text;

namespace Home_Task_5_2;

class Program
{ 
    static void Main(string[] args)
    {
        Console.OutputEncoding = UnicodeEncoding.UTF8;

        Console.WriteLine("Ведіть назву магазина: ");
        string nameStore = Console.ReadLine();

        InteractivePanelStore intectivePanelStore = new();

        Console.WriteLine("\nВведіть структуру магазина вибираючи номера підрозділів(номера писати без пробіла): ");
        string numStr = Console.ReadLine();

        var numbersDertament = intectivePanelStore.SetNumbersDepartmens(numStr);
        Store store = new(numbersDertament);

        foreach (var department in store.departments)
        {
            string str;

            foreach (var product in department.Products)
            {
                str = product.Name;

                if (product != department.Products.Last())
                {
                    str += ", ";
                }
                else
                {
                    str += ".";
                }
                Console.Write(str);
            }
            Console.WriteLine();
        }

        Console.WriteLine("Напишіть назви продуктів через ПРОБІЛ які ви хочете купити: ");
        string nameProduct = Console.ReadLine();

        var selectedProducts =  intectivePanelStore.FoundProduct(nameProduct, store);
        var organizeBoxes = intectivePanelStore.OrganizeProductsByBox(numbersDertament, selectedProducts);

        intectivePanelStore.SortingBoxByArea(organizeBoxes, nameStore);
    }
}