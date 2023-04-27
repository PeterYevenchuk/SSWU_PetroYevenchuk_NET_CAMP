using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_6_1;

public class DiagonalMatrix : IEnumerable<int>
{

    private int size;
    private int[][] matrix;
    private int index = 0, x = -1, y = 1;

    public DiagonalMatrix(int size)
    {
        this.size = size;
        matrix = new int[size][];
        for (int i = 0; i < size; i++)
        {
            matrix[i] = new int[size];
        }

        int o = 0;

        while (o < size - 1)
        {
            FillMatrixDiagonaleDown();

            FillMatrixDiagonaleUp();
            o++;
        }
    }

    public void FillMatrixDiagonaleDown()
    {
        while (y > 0 && x < size - 1)
        {
            y--;
            x++;
            AddIndexInMatrix();
        }
        if (y == 0 && x < size - 1)
        {
            x++;
            AddIndexInMatrix();
        }
        else
        {
            y++;
            AddIndexInMatrix();
        }
    }

    public void FillMatrixDiagonaleUp()
    {
        while (x > 0 && y < size - 1)
        {
            y++;
            x--;
            AddIndexInMatrix();
        }
        if (x == 0 && y < size - 1)
        {
            y++;
            AddIndexInMatrix();
        }
        else if (x == 0 && y == size - 1)
        {
            x++;
            AddIndexInMatrix();
        }
        else
        {
            x++;
            AddIndexInMatrix();
        }
    }

    public void AddIndexInMatrix()
    {
        index++;
        matrix[x][y] = index;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                yield return matrix[i][j];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}