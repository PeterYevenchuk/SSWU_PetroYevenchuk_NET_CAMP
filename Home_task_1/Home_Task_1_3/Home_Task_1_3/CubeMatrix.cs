using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_1_3;
// Не враховано, що є подібність в обчисленні  в 3 випадках
internal class CubeMatrix
{
    public int[,,] CreateCube(int size)
    {
        // Заповнення куба рандомними значеннями
        int[,,] cube = new int[size, size, size]; // Створення куба
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    cube[i, j, k] = random.Next(2);
                }
            }
        }
        return cube;
    }

    public void DispayCube(int[,,] cube, int size)
    {
        // Виводимо куб
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine("Layer " + (i + 1) + " of the cube:");
            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    Console.Write(cube[i, j, k].ToString("0") + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    public bool CheckThroughLinearHoleInCube(int[,,] cube, int size)
    {
        bool hasCrossLine = false; // Перевірка на наскрізний лінійний отвір
        // Перевірка на наскрізний лінійний отвір
        for (int i = 0; i < size; i++)
        {
            if (cube[0, 0, i] == 0 && cube[size - 1, size - 1, i] == 0)
            {
                hasCrossLine = true;
                break;
            }
        }
        return hasCrossLine;
    }
    public bool CheckVerticalLinear(int[,,] cube, int size)
    {
        bool hasVerticalLine = false;
        for (int i = 0; i < size; i++)
        {
            if (cube[0, i, 0] == 0 && cube[size - 1, i, size - 1] == 0)
            {
                hasVerticalLine = true;
            }
        }
        return hasVerticalLine;
    }
    public bool CheckHorizontalLinear(int[,,] cube, int size)
    {
        bool hasHorizontalLine = false;
        for (int i = 0; i < size; i++)
        {
            if (cube[i, 0, 0] == 0 && cube[i, size - 1, size - 1] == 0)
            {
                hasHorizontalLine = true;
            }
        }
        return hasHorizontalLine;
    }

    public void DisplayLinearHoles(int[,,] cube, int size, bool hasCrossLine, bool hasVerticalLine, bool hasHorizontalLine)
    {
        for (int i = 0; i < size; i++)
        {
            if (hasCrossLine)
            {
                Console.WriteLine("Наскрізний лінійний отвір з {0}, {1}, {2} до {3}, {4}, {5}", 0, 0, i, size - 1, size - 1, i);
            }
            if (hasVerticalLine)
            {
                Console.WriteLine("Вертикальний отвір по діагоналі з {0}, {1}, {2} до {3}, {4}, {5}", 0, i, 0, size - 1, i, size - 1);
            }
            if (hasHorizontalLine)
            {
                Console.WriteLine("Горизонтальний отвір по діагоналі з {0}, {1}, {2} до {3}, {4}, {5}", i, 0, 0, i, size - 1, size - 1);
            }
        }
    }
}

