using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_3_2.Validation;

internal class Validator
{
    private string _text;

    public string Text
    {
        get { return _text; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Text cannot be empty or null.");
            }
            _text = value;
        }
    }
}
