using Home_Task_4_1;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Write your text!");
        string text = Console.ReadLine();

        SentencesWithParentheses sentencesWithParentheses = new SentencesWithParentheses();
        List<string> sentencesWithInfo = sentencesWithParentheses.Sentences(text);

        Console.OutputEncoding = Encoding.UTF8; // important for the proper functioning of the Ukrainian language

        // Print sentences
        Console.WriteLine("Sentences with information in brackets:");
        foreach (string sentence in sentencesWithInfo)
        {
            Console.WriteLine(sentence);
        }
    }
}