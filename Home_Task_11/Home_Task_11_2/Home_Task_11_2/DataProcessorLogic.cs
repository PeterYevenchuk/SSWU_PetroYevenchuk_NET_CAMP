using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_11_2;

public class DataProcessorLogic
{
    public int[] SortDataFromFile(string inputFile, int partitionSize)
    {
        int[] sortedData = new int[0];

        using (StreamReader reader = new StreamReader(inputFile))
        {
            while (!reader.EndOfStream)
            {
                int[] partition = ReadDataFromStream(reader, partitionSize);
                MergeSort(partition, 0, partition.Length - 1);

                sortedData = MergeArrays(sortedData, partition);
            }
        }

        return sortedData;
    }

    private int[] ReadDataFromStream(StreamReader reader, int partitionSize)
    {
        List<int> dataList = new List<int>();
        int count = 0;

        while (!reader.EndOfStream && count < partitionSize)
        {
            string line = reader.ReadLine();
            if (int.TryParse(line, out int number))
            {
                dataList.Add(number);
                count++;
            }
        }

        return dataList.ToArray();
    }

    private void MergeSort(int[] data, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort(data, left, mid);
            MergeSort(data, mid + 1, right);

            Merge(data, left, mid, right);
        }
    }

    private void Merge(int[] data, int left, int middle, int right)
    {
        int[] temp = new int[data.Length];
        int i, j, k;

        i = left;
        j = middle + 1;
        k = left;

        while (i <= middle && j <= right)
        {
            if (data[i] <= data[j])
            {
                temp[k] = data[i];
                i++;
            }
            else
            {
                temp[k] = data[j];
                j++;
            }
            k++;
        }

        while (i <= middle)
        {
            temp[k] = data[i];
            i++;
            k++;
        }

        while (j <= right)
        {
            temp[k] = data[j];
            j++;
            k++;
        }

        for (k = left; k <= right; k++)
        {
            data[k] = temp[k];
        }
    }

    private int[] MergeArrays(int[] arr1, int[] arr2)
    {
        int[] mergedArray = new int[arr1.Length + arr2.Length];
        int i = 0, j = 0, k = 0;

        while (i < arr1.Length && j < arr2.Length)
        {
            if (arr1[i] <= arr2[j])
            {
                mergedArray[k] = arr1[i];
                i++;
            }
            else
            {
                mergedArray[k] = arr2[j];
                j++;
            }
            k++;
        }

        while (i < arr1.Length)
        {
            mergedArray[k] = arr1[i];
            i++;
            k++;
        }

        while (j < arr2.Length)
        {
            mergedArray[k] = arr2[j];
            j++;
            k++;
        }

        return mergedArray;
    }
}
