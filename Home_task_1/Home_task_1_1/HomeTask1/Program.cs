using HomeTask1;

internal class Program
{
    private static void Main()
    {//  hjkjhghjkgkhj
        Console.WriteLine("Press ENTER to continue!\n");
        //TEST 1 Defolt value
        Console.WriteLine("----------clockwise---------");
        SnakeMatrixTask1_1.SpiralMatrixСounterClockWise();

        //TEST 2 Random value
        Random rnd = new Random();
        for (int i = 0; i < 10; ++i)
        {
            int n = rnd.Next(2, 10);
            int m = rnd.Next(2, 10);

            Console.WriteLine("----------counterclockwise---------");
            SnakeMatrixTask1_1.SpiralMatrixСlockwiseTop(n, m);

            Console.WriteLine("----------clockwise---------");
            SnakeMatrixTask1_1.SpiralMatrixСounterClockWise(n, m);

        }
    }
}
