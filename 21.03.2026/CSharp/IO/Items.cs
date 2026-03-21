namespace IO;

public class Items
{
    public string Name { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }

    public Items(string name, int amount, decimal price)
    {
        Name = name;
        Amount = amount;
        Price = price;
    }
}