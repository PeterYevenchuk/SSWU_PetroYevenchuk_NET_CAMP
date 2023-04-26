using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_6_2;

public class ArrayMerge
{
    public IEnumerable<int> SortMassives(params int[][] arrays)
    {
        List<int> mergeList = new List<int>();

        foreach (int[] array in arrays) // merges everything into one array
        {
            mergeList.AddRange(array);
        }

        mergeList.Sort();

        foreach(int num in mergeList)
        {
            yield return num;
        }
    }
}
