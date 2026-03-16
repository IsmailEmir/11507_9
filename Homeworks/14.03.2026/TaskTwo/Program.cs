
Filter filter = new Filter();

System.Console.WriteLine("Фильтр по стажу:");
filter.FilterEmployees(Employee.StaffList, filter.IsExperienced);
System.Console.WriteLine("\nФильтр по ЗП:");
filter.FilterEmployees(Employee.StaffList, filter.IsEnoughSalary);