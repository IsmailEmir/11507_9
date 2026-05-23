using System.Collections.Concurrent;
using CW2.Models;

namespace CW2.Services;

public class ConcurrentSystem
{
    private int _itemCount;
    public ConcurrentSystem(int itemCount) _itemCount = itemCount;

    public List<User> Run()
    {
        BlockingCollection<User> queue = new BlockingCollection<User>();
        List<User> result = new List<User>();

        Producer producer = new Producer(queue, _itemCount);
        Consumer consumer = new Consumer(queue, result);

        Thread producerThread = new Thread(producer.Run);
        Thread consumerThread = new Thread(consumer.Run);

        producerThread.Start();
        consumerThread.Start();
        producerThread.Join();
        consumerThread.Join();

        return result;
    }
}
