using System.Numerics;
using System.Reflection.Metadata.Ecma335;

public class OrderBuilder<T> :
    Order<T>,
    IIdStep<T>,
    IPriceStep<T>,
    IFinalStep<T>
    where T : INumber<T>

{
    public IPriceStep<T> WithSetId(int id)
    {
        Id = id;
        return this;
    }

    public IFinalStep<T> WithPriceStep(T value)
    {
        Price = value;
        return this;
    }

    public Order<T> Build()
    {
        return this;
    }

    public static OrderBuilder<T> Craft()
    {
        return new OrderBuilder<T>();
    }
}