using System.Drawing;

namespace Home_Task_5_1;

public class Program
{
    static void Main(string[] args)
    {
        // In this problem, I used the so-called Jarvis algorithm or "rotating march"
        Random random = new Random();

        int numOfPoints1 = random.Next(1, 11);
        List<Point> points1 = new List<Point>();
        for (int i = 0; i < numOfPoints1; i++)
        {
            points1.Add(new Point(random.Next(10), random.Next(10)));
        }
        Garden garden1 = new Garden(points1);

        int numOfPoints2 = random.Next(1, 11);
        List<Point> points2 = new List<Point>();
        for (int i = 0; i < numOfPoints2; i++)
        {
            points2.Add(new Point(random.Next(10), random.Next(10)));
        }
        Garden garden2 = new Garden(points2);

        if (garden1 < garden2)
        {
            Console.WriteLine("Garden 1 has a smaller fence length than Garden 2");
        }
        else
        {
            Console.WriteLine("Garden 2 has a smaller fence length than Garden 1");
        }

        Console.WriteLine($"Fence length of Garden 1: {garden1.GetMinFenceLength():F2}");
        Console.WriteLine($"Fence length of Garden 2: {garden2.GetMinFenceLength():F2}");
    }
}