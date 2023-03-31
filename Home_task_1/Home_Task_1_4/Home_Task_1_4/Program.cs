using Home_Task_1_4;

internal class Program
{
    static void Main(string[] args)
    {
        Initialization initialization = new Initialization();

        initialization.InitializationTenzor(5, 5, 5, 0, 1000);

        initialization.InitializationMatrix();

        initialization.InitializationVektor();
    }
}