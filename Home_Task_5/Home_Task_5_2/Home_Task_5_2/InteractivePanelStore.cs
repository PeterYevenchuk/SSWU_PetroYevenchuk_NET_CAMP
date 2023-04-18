﻿namespace Home_Task_5_2;

public class InteractivePanelStore
{
    public void DisplayDepartmens()
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
}