using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask1;

internal class SnakeMatrixTask1_1
{
    public static int[,] Array(int n = 3, int m = 4)
    {
        int[,] matrixSnake = new int[n, m];

        int val = 1; // iterator
        int topLine = 0;
        int bottomLine = n - 1;
        int leftLine = 0;
        int rightLine = m - 1;

        while (val <= n * m) // while matrix don`t fill
        {
            for (int i = bottomLine; i >= topLine; --i) //fill bottom border from bottom to top
            {
                matrixSnake[i, leftLine] = val;
                val++;
            }
            leftLine++;

            for (int i = leftLine; i <= rightLine; ++i) //fill left border from left to right
            {
                matrixSnake[topLine, i] = val;
                val++;
            }
            topLine++;

            for (int i = topLine; i <= bottomLine; ++i) //fill the top border from top to bottom 
            {
                matrixSnake[i, rightLine] = val;
                val++;
            }
            rightLine--;

            for (int i = rightLine; i >= leftLine; --i) //fill right border from right to left
            {
                matrixSnake[bottomLine, i] = val;
                val++;
            }
            bottomLine--;
        }

        int[,] result = new int[n, m];  //flip the matrix
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < m; ++j)
            {
                result[n - 1 - i, j] = matrixSnake[i, j];
            }
        }

        for (int i = 0; i < n; ++i)     //Print matrix
        {
            for (int j = 0; j < m; ++j)
            {
                Console.Write("{0,4}", result[i, j]);
            }
            Console.WriteLine();
        }

        Console.ReadKey();
        return matrixSnake;
    }
}