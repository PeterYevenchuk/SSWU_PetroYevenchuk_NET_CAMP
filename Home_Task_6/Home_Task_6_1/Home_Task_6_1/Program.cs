using System;

namespace Home_Task_6_1;

public class Program
{
    static void Main(string[] args)
    {
        int sizeMatrix = 4;

        DiagonalMatrix matrix = new DiagonalMatrix(sizeMatrix);

        IEnumerator<int> enumerator = matrix.GetEnumerator();
        while (enumerator.MoveNext())
        {
            int line = enumerator.Current;
            Console.Write(line + " ");
        }

        /*foreach (int line in matrix)
        {
            Console.Write(line + " ");
        }
        Console.WriteLine();*/
    }
}