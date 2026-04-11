namespace TaskTwo;

class Program
{
    static void Main(string[] args)
    {
        Sensor temperatureSensor = new Sensor();
        temperatureSensor.Alert += (sender, e) =>
        {
            Console.WriteLine($"Внимание! Изменение на {Math.Round(e.PercentChange, 2)}%! Старое значение: {e.OldValue}, Новое: {e.NewValue}");
        };
        temperatureSensor.SetValue(20.0);
        temperatureSensor.SetValue(22.5);
    }
}