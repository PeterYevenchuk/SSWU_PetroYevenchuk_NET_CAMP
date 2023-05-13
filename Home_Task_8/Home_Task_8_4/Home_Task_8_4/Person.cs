using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_8_4;

public abstract class Person
{
    protected string _name;
    protected int _age;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int Age
    {
        get => _age;
        set => _age = value;
    }

    // The event. Note that by using the generic EventHandler<T> event type
    // we do not need to declare a separate delegate type.
    public event EventHandler<PersonEventArgs> PersonChanged;

    public abstract void Display();

    //The event-invoking method that derived classes can override.
    protected virtual void OnPersonChanged(PersonEventArgs e)
    {
        // Safely raise the event for all subscribers
        PersonChanged?.Invoke(this, e);
    }
}
