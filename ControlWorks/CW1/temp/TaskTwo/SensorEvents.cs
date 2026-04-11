namespace TaskTwo;

public class SensorEventArgs : EventArgs
{
    public double OldValue { get; set; }
    public double NewValue { get; set; }
    public double PercentChange { get; set; }
}