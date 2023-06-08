namespace Home_Task_11_1;

public class Program
{
    static void Main()
    {
        // sorting rows by length
        string[] strings = { "apple", "banana", "cherry", "date", "elderberry" };
        Comparison<string> stringComparison = (x, y) => x.Length.CompareTo(y.Length);
        QuickSort<string>.Sort(strings, stringComparison, 1); // Selecting the first element
        Console.WriteLine("Sort rows by length:");
        foreach (string s in strings)
        {
            Console.WriteLine(s);
        }
        Console.WriteLine();

        // sorting integers in ascending order
        int[] integers = { 5, 3, 9, 1, 7 };
        Comparison<int> intComparison = (x, y) => x.CompareTo(y);
        QuickSort<int>.Sort(integers, intComparison, 2); // Selection of an arbitrary element
        Console.WriteLine("Sorting integers in ascending order:");
        foreach (int i in integers)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();

        // sorting double in ascending order
        double[] doubles = { 12.3, 5.8, 3.1, 9.85, 1.0, 7.8, 12.4, 28.3 };
        Comparison<double> doublecomparison = (x, y) => x.CompareTo(y);
        QuickSort<double>.Sort(doubles, doublecomparison, 3); // Median selection
        Console.WriteLine("Sorting double in ascending order:");
        foreach (double i in doubles)
        {
            Console.WriteLine(i);
        }
    }
}