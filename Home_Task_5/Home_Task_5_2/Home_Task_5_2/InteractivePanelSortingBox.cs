using System.Text;

namespace Home_Task_5_2;

public class InteractivePanelSortingBox
{
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
