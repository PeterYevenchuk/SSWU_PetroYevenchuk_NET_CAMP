using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_3_2.Tasks
{
    internal class FoundIndex
    {
        public string FoundIndexSubString(string subString = "", string text = "")
        {
            int firstIndex = text.IndexOf(subString);
            int secondIndex = text.IndexOf(subString, firstIndex + 1);

            if (firstIndex == -1)
            {
                Console.WriteLine("Not found!");
                return null;
            }
            else
            {
                if (secondIndex == -1)
                {
                    Console.WriteLine("Second occurrence of substring not found.");
                    return null;
                }
                else
                {
                    Console.WriteLine($"The index of the second occurrence of the substring: {secondIndex}");
                    return $"{secondIndex}";
                }
            }
            return null;
        }
    }
}
