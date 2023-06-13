using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_11_2;

public class DataProcessor
{
    public void ProcessData(string inputFile, int partitionSize)
    {
        DataProcessorLogic processorLogic = new DataProcessorLogic();
        int[] sortedData = processorLogic.SortDataFromFile(inputFile, partitionSize);

        FileWriter.WriteDataToFile(sortedData, inputFile);
    }
}
