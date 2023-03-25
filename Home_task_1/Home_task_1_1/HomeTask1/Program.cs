using HomeTask1;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Press ENTER to continue!\n");
        //TEST 1 Defolt value
        SnakeMatrixTask1_1.Array();
        Console.WriteLine("-------------------");
        //TEST 2 Random value
        Random rnd = new Random();
        for (int i = 0; i < 10; ++i)
        {
            int n = rnd.Next(2, 10);
            int m = rnd.Next(2, 10);
            SnakeMatrixTask1_1.Array(n, m);
            Console.WriteLine("-------------------");
        }
    }
}