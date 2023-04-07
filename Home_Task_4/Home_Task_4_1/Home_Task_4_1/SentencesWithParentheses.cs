namespace Home_Task_4_1;

public class SentencesWithParentheses
{
    public List<string> Sentences(string text)
    {
        List<string> sentences = new List<string>();

        int startIndex = 0;
        for (int i = 0; i < text.Length; i++)
        {
            char currentChar = text[i];
            if (currentChar == '.' || currentChar == '!' || currentChar == '?') 
            {
                string sentence = text.Substring(startIndex, i - startIndex + 1); // Split the text into sentences
                sentences.Add(sentence);
                startIndex = i + 2; // Skip the space after the period
            }
        }

        List<string> sentencesWithInfoInBrackets = new List<string>();

        foreach (string sentence in sentences)
        {
            if (sentence.Contains("(") && sentence.Contains(")")) // Find sentences containing information in parentheses
            {
                sentencesWithInfoInBrackets.Add(sentence.Trim());
            }
        }
        return sentencesWithInfoInBrackets;
    }
}
