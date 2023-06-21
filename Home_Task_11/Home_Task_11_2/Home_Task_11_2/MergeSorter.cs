using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_11_2;

public class MergeSorter
{
    public void MergeSortedBlocks(string inputFile, string outputFile, int blockSize)
    {
        int blockCount = GetBlockCount(inputFile, blockSize);

        if (blockCount == 1)
        {
            File.Copy(inputFile, outputFile, true);
            return;
        }

        string[] blockFiles = GetBlockFiles(blockCount);
        string[] currentLines = new string[blockCount];
        int[] currentValues = new int[blockCount];
        StreamReader[] readers = new StreamReader[blockCount];

        for (int i = 0; i < blockCount; i++)
        {
            readers[i] = new StreamReader(blockFiles[i]);
            currentLines[i] = readers[i].ReadLine();
            currentValues[i] = int.Parse(currentLines[i]);
        }

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            while (true)
            {
                int minIndex = GetMinValueIndex(currentValues);

                if (minIndex == -1)
                    break;

                writer.WriteLine(currentValues[minIndex]);

                currentLines[minIndex] = readers[minIndex].ReadLine();

                if (currentLines[minIndex] == null)
                {
                    currentValues[minIndex] = int.MaxValue;
                }
                else
                {
                    currentValues[minIndex] = int.Parse(currentLines[minIndex]);
                }
            }
        }

        for (int i = 0; i < blockCount; i++)
        {
            readers[i].Dispose();
        }
    }

    public int GetBlockCount(string inputFile, int blockSize)
    {
        int fileSize = (int)new FileInfo(inputFile).Length;
        int blockCount = fileSize / (blockSize * sizeof(int));
        if (fileSize % (blockSize * sizeof(int)) != 0)
            blockCount++;
        return blockCount;
    }

    public string[] GetBlockFiles(int blockCount)
    {
        string[] blockFiles = new string[blockCount];
        for (int i = 0; i < blockCount; i++)
        {
            blockFiles[i] = "block_" + i.ToString("D3") + ".txt";
        }
        return blockFiles;
    }

    public int GetMinValueIndex(int[] values)
    {
        int minValue = int.MaxValue;
        int minIndex = -1;

        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] < minValue)
            {
                minValue = values[i];
                minIndex = i;
            }
        }

        return minIndex;
    }

    public void DeleteTemporaryFiles()
    {
        string[] blockFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "block_*.txt");
        foreach (string blockFile in blockFiles)
        {
            File.Delete(blockFile);
        }
    }
}
