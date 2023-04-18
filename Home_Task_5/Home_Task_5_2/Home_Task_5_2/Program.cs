using System.Text;

namespace Home_Task_5_2;

class Program
{ 
    static void Main(string[] args)
    {
        Console.OutputEncoding = UnicodeEncoding.UTF8;
        InteractivePanelStore interactivePanelStore = new();
        InteractivePanelSortingBox interactivePanelSortingBox = new();

        Console.WriteLine("Ведіть назву магазина: ");
        string nameStore = Console.ReadLine();

        Console.WriteLine("\nВиберіть підрозділи які будуть знаходитися в магазині: ");
        interactivePanelStore.DisplayDepartmens();

        Console.WriteLine("\nВведіть структуру магазина вибираючи номера підрозділів(номера писати без пробіла): ");
        string numStr = Console.ReadLine();

        var numbersDertament = interactivePanelStore.SetNumbersDepartmens(numStr);
        Store store = new(numbersDertament);
        Console.WriteLine();
        foreach (var department in store.departments)
        {
            string str;

            foreach (var product in department.Products)
            {
                str = product.Name + " ";
                Console.Write("{0,-12}", str);
            }
            Console.WriteLine("\n");
        }

        Console.WriteLine("Напишіть назви продуктів через ПРОБІЛ які ви хочете купити: ");
        string nameProduct = Console.ReadLine();

        var selectedProducts = interactivePanelStore.FoundProduct(nameProduct, store);
        var organizeBoxes = interactivePanelSortingBox.OrganizeProductsByBox(numbersDertament, selectedProducts);
        interactivePanelSortingBox.SortingBoxByArea(organizeBoxes, nameStore);
    }
}