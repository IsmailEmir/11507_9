using static System.Console;

public delegate void LogHandler(string path);

public class OrderProcessor
{
    public LogHandler Logger;
    public void Process()
    {
        Logger?.Invoke("Заказ принят");
        Logger?.Invoke("Платеж прошел");
    }
}

class Program
{
    static void LogToConsoleRed(string message)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(message);
        ResetColor();
    }

    static void LogToConsoleNormal(string message)
    {
        WriteLine(message);
    }

    static void Main()
    {
        var processor = new OrderProcessor();
        processor.Logger += LogToConsoleRed;
        processor.Logger += LogToConsoleNormal;

        processor.Process();
    }
}