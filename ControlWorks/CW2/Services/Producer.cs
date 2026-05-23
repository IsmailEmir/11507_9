using System.Collections.Concurrent;
using CW2.Models;

namespace CW2.Services;

public class Producer
{
    private BlockingCollection<User> _queue;
    private int _count;

    public Producer(BlockingCollection<User> queue, int count)
    {
        _queue = queue;
        _count = count;
    }

    public void Run()
    {
        for (int i = 1; i <= _count; i++)
        {
            User user = new User();
            user.Name = $"User_{i}";
            user.Email = $"user{i}@example.com";
            user.Age = 20 + i;

            _queue.Add(user);
            Console.WriteLine($"[Producer] Добавлен: {user}");
            Thread.Sleep(100);
        }

        _queue.CompleteAdding();
        Console.WriteLine("[Producer] Завершил генерацию.");
    }
}
