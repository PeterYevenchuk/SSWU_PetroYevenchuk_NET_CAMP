using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Home_Task_3_2.Tasks;

internal class ReturnUppercaseLetter
{
    public int ReturnUppercaseLetterCount(string text = "")
    {
        //This problem can also be solved using regular expressions

        /*        Regex regex = new Regex(@"\b[A-Z]\w*\b");
                int count = regex.Matches(text).Count;*/

        int count = text.Split(" ").Count(word => char.IsUpper(word.FirstOrDefault()));
        Console.WriteLine($"Number of words starting with a capital letter: {count}");
        return count;
    }
}
