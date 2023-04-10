using Home_Task_4_2;
using System.Net.Mail;
using System.Runtime.CompilerServices;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Write your text:");
        string text = Console.ReadLine();

        FoundEmails foundEmails = new FoundEmails();
        foundEmails.Email(text);
    }
}
