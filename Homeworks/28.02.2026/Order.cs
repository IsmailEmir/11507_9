using System.Numerics;

public class Order<T> where T : INumber<T>
{
    public int Id;
    public T? Price;
}