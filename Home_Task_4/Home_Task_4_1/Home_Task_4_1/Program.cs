using Home_Task_4_1;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8; // important for the proper functioning of the Ukrainian language

        Console.WriteLine("Write your text!");
        string text = Console.ReadLine();

        SentencesWithParentheses sentencesWithParentheses = new SentencesWithParentheses();
        List<string> sentencesWithInfo = sentencesWithParentheses.Sentences(text);

        Console.WriteLine("Sentences with information in brackets:");
        foreach (string sentence in sentencesWithInfo)
        {
            Console.WriteLine(sentence);
        }

        //Regex
        List<string> strings = sentencesWithParentheses.SentencesRegex(text);

        Console.WriteLine("Sentences with information in brackets:");
        foreach (string sentence in strings)
        {
            Console.WriteLine(sentence);
        }
    }
}