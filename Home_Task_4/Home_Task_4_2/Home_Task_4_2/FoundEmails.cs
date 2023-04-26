using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Home_Task_4_2;

public class FoundEmails
{
    public void Email(string text)
    {// пропусків може бути і кілька між словами.
        string[] words = text.Split(' ');
        List<string> invalidEmails = new List<string>();

        foreach (string word in words)
        {
            try
            {
                MailAddress email = new MailAddress(word);
                Console.WriteLine("Found email: " + email.Address);
            }
            catch (FormatException)
            {
                if (word.Contains("@"))
                {
                    Console.WriteLine("Found invalide email: " + word);
                }
            }
        }
    }
// Ці регулярні вирази не повністю враховують наше визначення.
    public MatchCollection GetValidEmails(string text)
    {
        string emailPattern = @"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}\b";
        return Regex.Matches(text, emailPattern);
    }

    public MatchCollection GetInvalidEmails(string text)
    {// 
        string invalidEmailPattern = @"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}\b";
        return Regex.Matches(text, invalidEmailPattern);
    }
}
