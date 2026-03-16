
public class Filter{
    public void FilterEmployees(List<Employee>? employees, Predicate<Employee> predicate)
    {
        foreach(var person in employees!)
        {
            if (predicate(person))
            {
                Console.WriteLine(person);
            }
        }
    }

    public bool IsExperienced(Employee employee)
    {
        if (employee.Experience > 5) return true;
        return false;
    }

    public bool IsEnoughSalary(Employee employee)
    {
        if (employee.Salary > 50000m) return true;
        return false;
    }
}