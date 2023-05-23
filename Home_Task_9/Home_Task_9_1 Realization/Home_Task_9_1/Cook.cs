using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_9_1;

public abstract class Cook
{
    protected Cook nextCook;

    public void SetNextCook(Cook cook)
    {
        nextCook = cook;
    }

    public abstract string HandleOrder(string dishName, int quantity, string chefName);
}
