using Microsoft.Win32.SafeHandles;

public class Employee
{
    public string? Name;
    public decimal Salary;
    public int Experience;

    public Employee(string name, decimal salary, int experience)
    {
        Name = name;
        Salary = salary;
        Experience = experience;
    }

    public static List<Employee>? StaffList = new()
    {
        new Employee("Bor'ka", 10000m, 15),
        new Employee("Artem", 10000000m, 1),
        new Employee("Ya", 50001m, 6)
    };

    public override string ToString()
    {
        return $"{Name}, {Salary}, {Experience}";
    }
}

