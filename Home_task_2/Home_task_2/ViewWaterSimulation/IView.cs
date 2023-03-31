namespace Home_task_2;

public interface IView
{
    string CheckCommandIsNull { get; set; }
    abstract void SendCommand();
}
