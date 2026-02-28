using System.Numerics;

public interface IIdStep<T> where T : INumber<T>
{
    public IPriceStep<T> WithSetId(int id);
}

public interface IPriceStep<T> where T : INumber<T>
{
    public IFinalStep<T> WithPriceStep(T value);
}

public interface IFinalStep<T> where T : INumber<T>
{
    public Order<T> Build();
}