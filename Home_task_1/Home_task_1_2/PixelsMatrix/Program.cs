using PixelsMatrix;

class Program
{
    static void Main()
    {
        //TEST 1
        int[,] matrix = new int[,] {
            { 0, 1, 2, 3, 4 },
            { 3, 3, 3, 3, 3 },
            { 0, 1, 4, 0, 1 },
            { 5, 0, 1, 0, 0 }
        };
        PixelsMatrixTask1_2.PixelsColor(matrix);
        Console.WriteLine();

        //TEST 2 Random value
        Random random = new Random();
        int n = 10;
        int m = 10;
        int[,] rndMatrix = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                rndMatrix[i, j] = random.Next(0, 16);
            }
        }

        Console.WriteLine("Matrix:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write("{0}\t", rndMatrix[i, j]);
            }
            Console.WriteLine();
        }
        PixelsMatrixTask1_2.PixelsColor(rndMatrix);
    }   
}
