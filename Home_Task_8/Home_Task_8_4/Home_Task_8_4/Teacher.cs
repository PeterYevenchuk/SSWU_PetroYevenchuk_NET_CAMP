using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_8_4;

public class Teacher : Person
{
    private string _subject;

    public Teacher(string name, int age, string subject)
    {
        _name = name;
        _age = age;
        _subject = subject;
    }

    public void Update(string name, int age, string subject)
    {
        _name = name;
        _age = age;
        _subject = subject;
        OnPersonChanged(new PersonEventArgs(_name, _age));
    }

    protected override void OnPersonChanged(PersonEventArgs e)
    {
        // Do any teacher-specific processing here.

        // Call the base class event invocation method.
        base.OnPersonChanged(e);
    }

    public override void Display()
    {
        Console.WriteLine($"Teacher: Name={_name}, Age={_age}, Subject={_subject}");
    }
}
