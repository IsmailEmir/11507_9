public class Receipt
{
    public readonly string FullName;
    public readonly decimal FinalPrice;
    public readonly DateTime Date;
    public Receipt(string fullName, decimal finalPrice)
    {
        FullName = fullName;
        FinalPrice = finalPrice;
        Date =  DateTime.Now;
    }
}