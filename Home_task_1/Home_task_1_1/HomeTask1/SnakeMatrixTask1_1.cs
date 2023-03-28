using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask1;

internal class SnakeMatrixTask1_1
{
    private static int[,] matrixSnake; //matrix
    private static int _topLine;
    private static int _bottomLine;
    private static int _leftLine;
    private static int _rightLine;
    private static int _value; // iterator

    public static void SpiralMatrixСounterClockWise(int n = 3, int m = 4)
    {
        matrixSnake = new int[n, m];
        _topLine = 0;
        _bottomLine = n - 1;
        _leftLine = 0;
        _rightLine = m - 1;
        _value = 1; 

        while (_value <= n * m) // while matrix don`t fill
        {
            for (int i = _bottomLine; i >= _topLine; --i) //fill bottom border from bottom to top
            {
                matrixSnake[i, _leftLine] = _value;
                _value++;
            }
            _leftLine++;

            for (int i = _leftLine; i <= _rightLine; ++i) //fill left border from left to right
            {
                matrixSnake[_topLine, i] = _value;
                _value++;
            }
            _topLine++;

            for (int i = _topLine; i <= _bottomLine; ++i) //fill the top border from top to bottom 
            {
                matrixSnake[i, _rightLine] = _value;
                _value++;
            }
            _rightLine--;

            for (int i = _rightLine; i >= _leftLine; --i) //fill right border from right to left
            {
                matrixSnake[_bottomLine, i] = _value;
                _value++;
            }
            _bottomLine--;
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
        matrixSnake = new int[n, m];
        _topLine = 0;
        _bottomLine = n - 1;
        _leftLine = 0;
        _rightLine = m - 1;
        _value = 1;

        while (_value <= n * m)
        {
            for (int i = _leftLine; i <= _rightLine; i++) // fill top row from left to right
                matrixSnake[_topLine, i] = _value++;

            _topLine++;

            for (int i = _topLine; i <= _bottomLine; i++) // fill right column from top to bottom
                matrixSnake[i, _rightLine] = _value++;

            _rightLine--;

            for (int i = _rightLine; i >= _leftLine; i--) // fill bottom row from right to left
                matrixSnake[_bottomLine, i] = _value++;

            _bottomLine--;

            for (int i = _bottomLine; i >= _topLine; i--) // fill left column from bottom to top
                matrixSnake[i, _leftLine] = _value++;

            _leftLine++;
        }
                
        for (int i = 0; i < n; i++) // print the matrix
        {
            for (int j = 0; j < m; j++)
                Console.Write("{0,4}", matrixSnake[i, j]);

            Console.WriteLine();
        }

        Console.ReadKey();
    }
}