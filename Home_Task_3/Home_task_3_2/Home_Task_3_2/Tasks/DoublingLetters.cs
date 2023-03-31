using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_3_2.Tasks
{
    internal class DoublingLetters
    {
        public void DoublingLettersCheck(string text = "", string textUser = "")
        {
            string[] words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (HasDuplicateLetters(words[i]))
                {
                    // if the word contains doubling of letters, we replace it with the given text
                    words[i] = textUser;
                }
            }

            string result = string.Join(" ", words);
            Console.WriteLine("Result:");
            Console.WriteLine(result);
        }

        private bool HasDuplicateLetters(string word)
        {
            // check whether the word contains doubling of letters
            for (int i = 0; i < word.Length - 1; i++)
            {
                if (word[i] == word[i + 1])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
