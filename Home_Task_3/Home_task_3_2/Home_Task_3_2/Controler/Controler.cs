using Home_Task_3_2.Tasks;
using Home_Task_3_2.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Home_Task_3_2.Controler
{
    internal class Controler
    {
        public void Control()
        {
            Validator validator = new Validator();
            FoundIndex foundIndex = new FoundIndex();
            ReturnUppercaseLetter returnUppercaseLetter = new ReturnUppercaseLetter();
            DoublingLetters doublingLetters = new DoublingLetters();

            Console.WriteLine("Choose what you want to do with your text:\n" +
                " 1 - find the index by character,\n" +
                " 2 - find out the words that start with a capital letter,\n" +
                " 3 - replace all words containing doubling of letters with the text you specify.\n" +
                " Write 1 or 2 or 3!");
            string chose = Console.ReadLine();
            switch (Convert.ToInt32(chose))
            {
                case 1:
                    Console.WriteLine("Write youre text: ");
                    string text = Console.ReadLine();
                    Console.WriteLine("Write a letter for found index: ");
                    string subString = Console.ReadLine();

                    validator.Text = text;
                    validator.Text = subString;
                    foundIndex.FoundIndexSubString(subString, text);
                    break;
                case 2:
                    Console.WriteLine("Write youre text: ");
                    string textUpper = Console.ReadLine();

                    validator.Text = textUpper;
                    returnUppercaseLetter.ReturnUppercaseLetterCount(textUpper);
                    break;
                case 3:
                    Console.WriteLine("Write youre text: ");
                    string textDoublingLetters = Console.ReadLine();
                    Console.WriteLine("Write the replacement text: ");
                    string textUser = Console.ReadLine();

                    validator.Text = textDoublingLetters;
                    validator.Text = textUser;
                    doublingLetters.DoublingLettersCheck(textDoublingLetters, textUser);
                    break;
                default:
                    Console.WriteLine("The data is entered incorrectly");
                    break;
            }
        }
    }
}
