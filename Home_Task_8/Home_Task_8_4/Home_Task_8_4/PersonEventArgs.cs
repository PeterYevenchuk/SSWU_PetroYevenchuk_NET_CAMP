using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_8_4;

public class PersonEventArgs : EventArgs
{
    public PersonEventArgs(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; }
    public int Age { get; }
}
