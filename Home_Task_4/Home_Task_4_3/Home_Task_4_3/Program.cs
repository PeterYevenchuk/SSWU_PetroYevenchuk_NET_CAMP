namespace Home_Task_4_3;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "data.txt";
        //string fileName = Console.ReadLine(); // Можна вводити назву файлу користувачу
        if (fileName == null)
        {
            Console.WriteLine("Not Found!");
            return;
        }
        else if (!File.Exists(fileName))
        {
            Console.WriteLine($"File {fileName} not found!");
            return;
        }

        PrintInformation printInformation = new PrintInformation();
        printInformation.PrintInfo(fileName);
    }
}
