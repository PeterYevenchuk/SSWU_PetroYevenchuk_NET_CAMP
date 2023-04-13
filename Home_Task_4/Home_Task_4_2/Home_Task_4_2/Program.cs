using Home_Task_4_2;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Write your text:");
        string text = Console.ReadLine();

        FoundEmails foundEmails = new FoundEmails();
        foundEmails.Email(text);

        //Regex
        MatchCollection validEmails = foundEmails.GetValidEmails(text);
        Console.WriteLine("Found {0} valid emails:", validEmails.Count);
        foreach (Match email in validEmails)
        {
            Console.WriteLine(email.Value);
        }

        MatchCollection invalidEmails = foundEmails.GetInvalidEmails(text);
        Console.WriteLine("\nFound {0} invalid emails:", invalidEmails.Count);
        foreach (Match email in invalidEmails)
        {
            Console.WriteLine(email.Value);
        }
    }
}
