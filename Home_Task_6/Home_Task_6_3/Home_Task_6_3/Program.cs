namespace Home_Task_6_3;

public class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Write your text:");
        //string userText = Console.ReadLine();

        string text = "First I check. Second I check! Third I check? Next time, in time.";

        UniqueWords uniqueWords = new UniqueWords();

        Console.WriteLine("Unique words:");
        foreach (string word in uniqueWords.GetUniqueWords(text))
        {
            Console.Write("{0,-10}", word);
        }
    }
}