using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Home_Task_5_2;

public class InteractivePanelStore
{
    public InteractivePanelStore()
    {
        DisplayDepartmens();
    }

    private void DisplayDepartmens()
    {
        TypeDepartment[] days = (TypeDepartment[])Enum.GetValues(typeof(TypeDepartment));

        Console.WriteLine("\nВиберіть підрозділи які будуть знаходитися в магазині: ");
        int number = 0;
        foreach (TypeDepartment day in days)
        {
            Console.WriteLine("{0,-15} {1,-10} {2,-10}", day, "Номер", number);
            number++;
        }
    }

    public int[] SetNumbersDepartmens(string numbersDepartmens)
    {
        char[] charArray = numbersDepartmens.ToCharArray();

        int[] intArray = charArray.Select(c => int.Parse(c.ToString())).ToArray();

        return intArray;
    }

    public List<Product> FoundProduct(string productName, Store store)
    {
        List<Product> products = new();
        string[] names = productName.Split(" ");

        for (int i = 0; i < names.Length; i++)
        {
            foreach (var department in store.departments)
            {
                foreach (var product in department.Products)
                {
                    if (names[i] == product.Name)
                    {
                        products.Add(product);
                    }
                }
            }
        }

        return products;
    }

    public List<Box> OrganizeProductsByBox(int[] numbersDepartaments, List<Product> protuctsAllDepartament)
    {
        Console.OutputEncoding = UnicodeEncoding.UTF8;
        List<Box> boxes = new();
        List<Product> products = new();

        for (int i = 0; i < numbersDepartaments.Length; i++)
        {
            foreach (Product product in protuctsAllDepartament)
            {
                if (numbersDepartaments[i] == product.Index)
                {
                    products.Add(product);
                }
            }

            products.Sort((a, b) => a.Area.CompareTo(b.Area));

            //Methods Organize Products Box
            double maxHeight = 0;
            foreach (Product product in products)
            {
                maxHeight += product.Height;
            }

            Console.WriteLine("\nКоробка з продуктами підрозділу:" +
                 "\nВисота: " + maxHeight +
                 "\tШирина: " + products.Last().Width +
                 "\tДовжина: " + products.Last().Length +
                 "\tПідрозділ магазина: " + Enum.GetName(typeof(TypeDepartment), products.Last().Index));

            Box box = new();
            box.Height = maxHeight;
            box.Width = products.Last().Width;
            box.Length = products.Last().Length;
            box.Index = products.Last().Index;

            boxes.Add(box);

            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10}",
                    "Продукт:", "Висота:", "Ширина:", "Довжина:", "Площа:");
            //Methods Сontents products Big Box 
            foreach (Product product in products)
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10}", 
                    product.Name, product.Height, product.Width, product.Length, product.Area);
            }
            Console.WriteLine();

            products.Clear();
        }

        return boxes;
    }

    public void SortingBoxByArea(List<Box> boxes, string nameStore)
    {
        boxes.Sort((a, b) => a.Area.CompareTo(b.Area));

        //Methods Organize Box in Big box
        double maxHeight = 0;
        foreach (Box box in boxes)
        {
            maxHeight += box.Height;
        }

        Console.WriteLine("Коробка з продуктами магазина:" +
            "\nВисота: " + maxHeight +
            "\tШирина: " + boxes.Last().Width +
            "\tДовжина: " + boxes.Last().Length +
            "\tНазва магазина: " + nameStore);
    }
}