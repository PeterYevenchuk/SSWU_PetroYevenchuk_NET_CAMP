using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_11_2;

public class FileReader
{
    public static int[] ReadDataFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        int[] data = new int[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            data[i] = int.Parse(lines[i]);
        }

        return data;
    }
}
