using static Database;

class EventChain
{
    public void SendEmail(User user)
    {
        Console.WriteLine($"Sent To Email: {user.Email}");
        Thread.Sleep(2500);
    }
    
    public void WriteDatabase(User user)
    {
        try
        {
            Users?.Add(Count, user);
            Count++;
            Console.WriteLine("Written To Database");
            Thread.Sleep(2500);
        }
        catch
        {
            Console.WriteLine("Error: Database Writing CRASHED");
            Thread.Sleep(2500);
        }
    }
    
    public void RefreshCount(User user)
    {
        Console.WriteLine($"Counter Refreshed: {Count}");
        Thread.Sleep(2500);
    }
}

