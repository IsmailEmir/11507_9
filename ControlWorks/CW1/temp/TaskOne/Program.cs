namespace VariantThree;

class Program
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
    }

    static void Main(string[] args)
    {
        SimpleStorage<Employee> storage = new SimpleStorage<Employee>();
        
        storage.Add(new Employee { Name = "Иван", Age = 28, Department = "IT" });
        storage.Add(new Employee { Name = "Данил", Age = 35, Department = "Тест" });
        storage.Add(new Employee { Name = "Я", Age = 42, Department = "Менеджмент" });
        storage.Add(new Employee { Name = "Дарова", Age = 25, Department = "HR" });
        storage.Add(new Employee { Name = "Тест", Age = 31, Department = "IT" });

        var olderThan30 = storage.FindAll(e => e.Age > 30);
        
        Console.WriteLine("Сотрудники старше 30 лет:");
        foreach (var emp in olderThan30)
        {
            Console.WriteLine($"{emp.Name}, {emp.Age} лет, отдел: {emp.Department}");
        }
    }
}