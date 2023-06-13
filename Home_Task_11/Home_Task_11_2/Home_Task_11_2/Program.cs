using Home_Task_11_2;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";
        int partitionSize = 50; // Кількість символів, яку можна обробити за раз

        DataProcessor processor = new DataProcessor();
        processor.ProcessData(inputFile, partitionSize);

        Console.WriteLine("Sorting complete.");
    }
}
