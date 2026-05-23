using CW2.Services;

var demo = new { Name = "Дарова", Age = 67, City = null };
List<string> log = PropertyLogger.GetLog(demo);

foreach (string entry in log) Console.WriteLine($"  {entry}");

Console.WriteLine();

ConcurrentSystem system = new ConcurrentSystem(5);
List<CW2.Models.User> users = system.Run();
Console.WriteLine();
Console.WriteLine($"Итого обработано пользователей: {users.Count}");
