namespace TaskTwo;

public class Sensor
{
    private double _currentValue;
    public event EventHandler<SensorEventArgs>? Alert;

    public void SetValue(double newValue)
    {
        double oldValue = _currentValue;
        
        if (oldValue != 0)
        {
            double percentChange = Math.Abs((newValue - oldValue) / oldValue * 100);
            if (percentChange > 10)
            {
                Alert?.Invoke(this, new SensorEventArgs
                {
                    OldValue = oldValue,
                    NewValue = newValue,
                    PercentChange = percentChange
                });
            }
        }
        _currentValue = newValue;
    }
}