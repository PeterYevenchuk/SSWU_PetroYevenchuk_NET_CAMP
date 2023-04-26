using System.Xml.Linq;
using System;

namespace Home_Task_5_2;
// не враховано ієрархічну структуру, а також не враховано формат даних, який запропоновано в умові задачі.
public class Department
{
    private const string FILE_EXTANSION = ".txt";
    public string NameDepartment { get; set; }
    public List<Product> Products { get; set; }

    public Department(string nameDepartment, string fileName)
    {
        NameDepartment = nameDepartment;
        Products = ProductsInfo(fileName);
    }

    public List<Product> ProductsInfo(string fileName)
    {
        var lines = File.ReadAllLines(fileName + FILE_EXTANSION);
        var products = new List<Product>();
        for (int i = 0; i < lines.Length; ++i)
        {
            TypeDepartment value = (TypeDepartment)Enum.Parse(typeof(TypeDepartment), NameDepartment);
            TypeDepartment[] values = (TypeDepartment[])Enum.GetValues(typeof(TypeDepartment));

            var productInfo = lines[i].Split(" ");
            var product = new Product
            {
                Name = productInfo[0],
                Height = double.Parse(productInfo[1]),
                Width = double.Parse(productInfo[2]),
                Length = double.Parse(productInfo[3]),
                Index = Array.IndexOf(values, value)
            };

            products.Add(product);
        }
        return products;
    }
}
