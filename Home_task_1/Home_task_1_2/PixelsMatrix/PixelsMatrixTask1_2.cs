using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelsMatrix;

internal class PixelsMatrixTask1_2
{
    public static void PixelsColor(int[,] pixelsColor)
    {
        int maxLength = 0;
        int maxStartRow = 0;
        int maxStartCol = 0;
        int maxEndCol = 0;

        for (int i = 0; i < pixelsColor.GetLength(0); i++)
        {
            int currentLength = 1;
            int currentStart = 0;

            for (int j = 1; j < pixelsColor.GetLength(1); j++)
            {
                if (pixelsColor[i, j] == pixelsColor[i, j - 1])
                {
                    currentLength++;
// Ви на кожному пікселі порівнюєте з максимумом, хоча можна це зробити тільки коли відбувається зміна кольору.
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        maxStartRow = i;
                        maxStartCol = currentStart;
                        maxEndCol = j;
                    }
                }
                else
                {
                    currentLength = 1;
                    currentStart = j;
                }
            }
        }
//результат треба передавати через параметри методу і як повернення, а не друкувати тут
        Console.WriteLine($"Length longest horizontal line = {maxLength}," +
            $" start in row {maxStartRow} and column {maxStartCol} and end in column {maxEndCol}.");

    }
}
