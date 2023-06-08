using Home_Task_11_2;
using System;
using System.IO;

class Program
{
    // Я постарався в даній задачі виконати обі умови(Виконати це ж завдання при поділі набору даних більше ніж на 2 частини.), тобто я можу ділити не тільки на 2 частини а і на більше частин
    static void Main()
    {
        string inputFile = "input.txt";
        int[] data = FileReader.ReadDataFromFile(inputFile);

        int partitionSize = 25/*50*/; // The size of each part
        Sorter.MergeSort(data, 0, data.Length - 1, partitionSize);

        FileWriter.WriteDataToFile(data, inputFile);

        Console.WriteLine("Sorting complete.");
    }
}
