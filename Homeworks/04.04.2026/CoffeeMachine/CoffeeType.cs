namespace CoffeeMachine
{
    public class CoffeeType
    {
        public string? Name { get; set; }
        public int Amount { get; set; }
        public VolumeType[]? VolumeTypes { get; set; }

        public int CoffeeBeans { get; set; }
        public int Milk { get; set; }
        public int Water { get; set; }
    }

    public class FlavorType
    {
        public string? Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }

    public class VolumeType
    {
        public string? Volume { get; set; }
        public int Price { get; set; }
    }
}