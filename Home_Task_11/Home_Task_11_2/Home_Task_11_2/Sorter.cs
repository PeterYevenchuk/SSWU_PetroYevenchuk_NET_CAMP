using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_11_2;

public class Sorter
{
    public static void MergeSort(int[] data, int left, int right, int partitionSize)
    {
        if (left < right)
        {
            if (right - left + 1 > partitionSize)
            {
                int mid = (left + right) / 2;

                MergeSort(data, left, mid, partitionSize);
                MergeSort(data, mid + 1, right, partitionSize);

                Merge(data, left, mid, right);
            }
            else
            {
                InsertionSort(data, left, right);
            }
        }
    }

    private static void Merge(int[] data, int left, int middle, int right)
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

    private static void InsertionSort(int[] data, int left, int right)
    {
        for (int i = left + 1; i <= right; i++)
        {
            int key = data[i];
            int j = i - 1;

            while (j >= left && data[j] > key)
            {
                data[j + 1] = data[j];
                j--;
            }

            data[j + 1] = key;
        }
    }
}
