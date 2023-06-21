using Home_Task_11_2;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";
        string sortedFile = "sorted.txt";
        int blockSize = 25;

        MergeSorter sorter = new MergeSorter();
        BlockSorter blockSorter = new BlockSorter();

        // Splitting the input file into blocks and sorting each block
        blockSorter.SortBlocks(inputFile, blockSize);

        // Merge sorted blocks into one output file
        sorter.MergeSortedBlocks(inputFile, sortedFile, blockSize);

        // Issue of temporary files
        sorter.DeleteTemporaryFiles();

        Console.WriteLine("Sorting completed. Result saved in the sorted file.");
    }
}