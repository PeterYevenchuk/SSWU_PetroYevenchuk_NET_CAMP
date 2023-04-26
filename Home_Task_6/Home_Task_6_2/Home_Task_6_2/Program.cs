namespace Home_Task_6_2;

public class Program
{
    static void Main(string[] args)
    {
        ArrayMerge arrayMerge = new ArrayMerge();

        int[] array1 = { 3, 1, 4, 10, 15 };
        int[] array2 = { 2, 8, 5, 11, 12 };
        int[] array3 = { 20, 6, 19, 13, 17 };
        int[] array4 = { 7, 18, 9, 14, 16 };

        IEnumerable<int> sortedArray = arrayMerge.SortMassives(array1, array2, array3, array4);

        Console.WriteLine("Sorted Array:");
        foreach (int num in sortedArray)
        {
            Console.Write(num + " ");
        }
    }
}