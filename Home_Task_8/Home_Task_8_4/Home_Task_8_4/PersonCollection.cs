using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_8_4;

public class PersonCollection
{
    private readonly List<Person> _list;

    public PersonCollection()
    {
        _list = new List<Person>();
    }

    public void AddPerson(Person person)
    {
        _list.Add(person);

        // Subscribe to the base class event.
        person.PersonChanged += HandlePersonChanged;
    }

    private void HandlePersonChanged(object sender, PersonEventArgs e)
    {
        if (sender is Person person)
        {
            // Diagnostic message for demonstration purposes.
            Console.WriteLine($"Received event. Person name is now {e.Name}, age is now {e.Age}");
            // Display person information here.
            person.Display();
        }
    }
}

