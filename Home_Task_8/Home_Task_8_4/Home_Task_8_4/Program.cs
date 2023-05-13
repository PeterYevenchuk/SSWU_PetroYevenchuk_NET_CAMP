
namespace Home_Task_8_4;
public class Program
{
    static void Main()
    {
        // Create the event publishers and subscriber
        var student = new Student("John Doe", 20, "ABC School");
        var teacher = new Teacher("Jane Carl", 35, "Mathematics");
        var collection = new PersonCollection();

        // Add the people to the collection.
        collection.AddPerson(student);
        collection.AddPerson(teacher);

        // Cause some events to be raised.
        student.Update("John Smith", 21, "XYZ University");
        teacher.Update("Jane Johnson", 40, "Physics");

        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}