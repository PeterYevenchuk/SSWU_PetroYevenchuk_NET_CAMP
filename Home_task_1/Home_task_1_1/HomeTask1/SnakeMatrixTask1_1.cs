using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask1;

internal class SnakeMatrixTask1_1
{
    public static void SpiralMatrixСounterClockWise(int n = 3, int m = 4)
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

        int[,] result = new int[n, m]; //flip the matrix
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < m; ++j)
            {
                result[n - 1 - i, j] = matrixSnake[i, j];
            }
        }

        for (int i = 0; i < n; ++i) //Print matrix
        {
            for (int j = 0; j < m; ++j)
            {
                Console.Write("{0,4}", result[i, j]);
            }
            Console.WriteLine();
        }

        Console.ReadKey();
    }

    public static void SpiralMatrixСlockwiseTop(int n = 3, int m = 4)
    {
        int[,] matrix = new int[n, m];

        int value = 1;
        int top = 0, bottom = n - 1, left = 0, right = m - 1;

        while (value <= n * m)
        {
            for (int i = left; i <= right; i++) // fill top row from left to right
                matrix[top, i] = value++;

            top++;

            for (int i = top; i <= bottom; i++) // fill right column from top to bottom
                matrix[i, right] = value++;

            right--;

            for (int i = right; i >= left; i--) // fill bottom row from right to left
                matrix[bottom, i] = value++;

            bottom--;

            for (int i = bottom; i >= top; i--) // fill left column from bottom to top
                matrix[i, left] = value++;

            left++;
        }
                
        for (int i = 0; i < n; i++) // print the matrix
        {
            for (int j = 0; j < m; j++)
                Console.Write("{0,4}", matrix[i, j]);

            Console.WriteLine();
        }

        Console.ReadKey();
    }
}