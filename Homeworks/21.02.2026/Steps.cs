public class PaymentStep : PipelineStep<Product, Receipt>
{
    public decimal balance = 555;

    public override Receipt Process(Product product)
    {
        if (balance < product.Price)
        {
            Console.WriteLine("Not enough money");
        }
        
        return new Receipt(product.Name, product.Price);
    }
} 

public class LoggerStep : PipelineStep <Receipt , string>
{
    public override string Process(Receipt input)
    {
        var result = $"Product: {input.FullName}: {input.FinalPrice} rub\n" + $"Date: {input.Date}\n";
        return result;
    }
}

public class WarehouseStep : PipelineStep<int, Product>
{
    private Dictionary<int, Product> baseProduct = new()
    {
        {1, new Product("Cookie", 120)},
        {2, new Product("Apple Juice", 50)}
    };

    public override Product Process(int idProduct)
    {
        if (!baseProduct.ContainsKey(idProduct))
        {
            throw new KeyNotFoundException($"id: {idProduct} not found");
        }
        return baseProduct[idProduct];
    }
}