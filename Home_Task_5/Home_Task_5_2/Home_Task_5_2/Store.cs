namespace Home_Task_5_2;

public class Store
{
    public List<Department> departments = new();

    public Store(int[] numbers)
    {
        SetStructStore(numbers);
    }

    private void SetStructStore(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; ++i)
        {
            string name = Enum.GetName(typeof(TypeDepartment), numbers[i]);
            CreateDepartment(name);
        }
    }

    private List<Department> CreateDepartment(string name)
    {
        Department departament = new(name, name);
        this.departments.Add(departament);
        return departments;
    }
}