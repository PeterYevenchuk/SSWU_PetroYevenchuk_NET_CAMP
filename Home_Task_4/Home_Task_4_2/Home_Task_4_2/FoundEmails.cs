using System.Net.Mail;

namespace Home_Task_4_2;

public class FoundEmails
{
    public void Email(string text)
    {
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
}
