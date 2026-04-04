using static CoffeeMachine.Validator;

namespace CoffeeMachine
{
    public class Reader
    {
        public static string ReadString()
        {
            return Console.ReadLine()!;
        }

        public static CoffeeType? ReadCoffeeData()
        {
            Console.WriteLine("Type the name of coffee:");
            string? name = Console.ReadLine();
            Console.WriteLine($"Type the amount of {name}:");
            int amount = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"Type amount of available coffee volumes:");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Invalid data");
                Console.ReadKey();
                return null;
            }

            var volumes = new List<VolumeType>();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Volume {i + 1}:");
                string? volumeString = Console.ReadLine();
                Console.WriteLine($"Price {i + 1}:");
                string? priceString = Console.ReadLine();

                if (IsPositiveNumber(volumeString, out int volume) &&
                    IsPositiveNumber(priceString, out int price))
                {
                    volumes.Add(new VolumeType
                    {
                        Volume = volume.ToString(),
                        Price = price
                    });
                }
                else
                {
                    Console.WriteLine("Invalid data. Skipping this item.");
                }
            }

            return new CoffeeType
            {
                Name = name,
                Amount = amount,
                VolumeTypes = volumes.ToArray()
            };
        }
    }
}