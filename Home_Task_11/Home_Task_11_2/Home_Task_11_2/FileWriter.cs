using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_11_2;

public class FileWriter
{
    public static void WriteDataToFile(int[] data, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < data.Length; i++)
            {
                writer.WriteLine(data[i]);
            }
        }
    }
}
