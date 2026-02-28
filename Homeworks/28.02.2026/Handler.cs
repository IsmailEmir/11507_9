using System.Numerics;

public abstract class OrderHandler<T> where T : INumber<T>
{
    protected OrderHandler<T>? _next;

    public OrderHandler<T> SetNext(OrderHandler<T> order)
    {
        _next = order;
        return order;
    }

    public abstract void Handle(Order<T> order);
}

public class DiscountHandler<T> : OrderHandler<T> where T : INumber<T>
{
    private readonly T _discount;

    public DiscountHandler(T discount)
    {
        _discount = discount;
    }

    public override void Handle(Order<T> order)
    {
        order.Price -= _discount;
        _next?.Handle(order);        
    }
}

public class TaxHandler<T> : OrderHandler<T> where T : INumber<T>
{
    private readonly T _tax;

    public TaxHandler(T tax)
    {
        _tax = tax;
    }

    public override void Handle(Order<T> order)
    {
        order.Price *= T.CreateChecked(_tax);
        _next?.Handle(order);        
    }
}

public class ValidationHandler<T> : OrderHandler<T> where T : INumber<T>
{
    public override void Handle(Order<T> order)
    {
        if (order.Price < T.Zero) throw new ArgumentException(nameof(order), "Price must be positive number!");
        System.Console.WriteLine($"Final price: {order.Price}");
    }
}

