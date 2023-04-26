using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_6_3;

public class UniqueWords
{
    public IEnumerable<string> GetUniqueWords(string text)
    {
        char[] chars = { ' ', ',', '.', '!', '?', ':', ';', '-', '\n', '\r' };
        string[] words = text.Split(chars, StringSplitOptions.RemoveEmptyEntries); // I divide the line of text into separate words and delete empty field

        HashSet<string> result = new();

        for (int i = 0; i < words.Length; ++i)
        {
            if (!result.Contains(words[i]))
            {
                result.Add(words[i]);
                yield return words[i];
            }
        }
    }
}
