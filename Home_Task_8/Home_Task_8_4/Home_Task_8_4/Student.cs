using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Home_Task_8_4;

public class Student : Person
{
    private string _school;

    public Student(string name, int age, string school)
    {
        _name = name;
        _age = age;
        _school = school;
    }

    public void Update(string name, int age, string school)
    {
        _name = name;
        _age = age;
        _school = school;
        OnPersonChanged(new PersonEventArgs(_name, _age));
    }

    protected override void OnPersonChanged(PersonEventArgs e)
    {
        // Do any student-specific processing here.

        // Call the base class event invocation method.
        base.OnPersonChanged(e);
    }

    public override void Display()
    {
        Console.WriteLine($"Student: Name={_name}, Age={_age}, School={_school}");
    }
}
