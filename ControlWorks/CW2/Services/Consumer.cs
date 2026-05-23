using System.Collections.Concurrent;
using CW2.Models;

namespace CW2.Services;

public class Consumer
{
    private BlockingCollection<User> _queue;
    private List<User> _result;

    public Consumer(BlockingCollection<User> queue, List<User> result)
    {
        _queue = queue;
        _result = result;
    }

    public void Run()
    {
        foreach (User user in _queue.GetConsumingEnumerable())
        {
            Console.WriteLine("[Consumer] Свойства объекта:");
            List<string> log = PropertyLogger.GetLog(user);
            foreach (string entry in log)
            {
                Console.WriteLine($"  {entry}");
            }

            _result.Add(user);
            Console.WriteLine($"[Consumer] Обработан: {user}");
        }

        Console.WriteLine("[Consumer] Завершил обработку.");
    }
}
