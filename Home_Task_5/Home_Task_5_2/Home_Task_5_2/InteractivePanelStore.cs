using System.Security.Cryptography.X509Certificates;

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

            Console.WriteLine(" Box: " +
                " Height: " + maxHeight +
                " Width: " + products.Last().Width +
                " Length: " + products.Last().Length +
                " Department " + Enum.GetName(typeof(TypeDepartment), products.Last().Index));

            Box box = new();
            box.Height = maxHeight;
            box.Width = products.Last().Width;
            box.Length = products.Last().Length;
            box.Index = products.Last().Index;

            boxes.Add(box);

            //Methods Сontents products Big Box 
            foreach (Product product in products)
            {
                Console.WriteLine(" Name: " + product.Name +
                    " Height: " + product.Height +
                    " Width: " + product.Width +
                    " Length: " + product.Length +
                    " Area: " + product.Area);
            }

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

        Console.WriteLine(" Big Box: " +
            " Height: " + maxHeight +
            " Width: " + boxes.Last().Width +
            " Length: " + boxes.Last().Length +
            " NameStore: " + nameStore);
    }
}