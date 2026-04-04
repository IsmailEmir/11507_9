using static CoffeeMachine.Products;
using static CoffeeMachine.Printer;
using static CoffeeMachine.Reader;
using static CoffeeMachine.Validator;
using static CoffeeMachine.SaveSystem;
using static CoffeeMachine.AdminService;


namespace CoffeeMachine
{
    internal class Program
    {
        static int _coffeeIndex;
        static int _volumeIndex;
        static int _flavourIndex = -1;

        static void Main(string[] args)
        {
            string? mainSelect = "";
            while (mainSelect != "3")
            {
                StartMenu();

                mainSelect = Console.ReadLine();
                switch (mainSelect)
                {
                    case "1":
                        BuyCoffee();
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        break;
                    case "0":
                        OpenAdminPanel();
                        break;
                    default:
                        Console.WriteLine("Incorrect input. Press Enter to continue...");
                        break;
                }
            }

            static void BuyCoffee()
            {
                //Coffee
                Console.WriteLine("\n");
                string volumesPresentation = "";
                for (int i = 0; i < Products.coffeeTypes!.Count; i++)
                {
                    for (int j = 0; j < Products.coffeeTypes[i].VolumeTypes!.Length; j++)
                    {
                        volumesPresentation += Products.coffeeTypes[i].VolumeTypes![j].Volume + "ml ";
                    }

                    Console.WriteLine(
                        $"{i + 1}. {Products.coffeeTypes[i].Name} - {volumesPresentation}");
                    volumesPresentation = "";
                }

                string? coffeeCommand = Console.ReadLine();
                CoffeeType? coffeeTypes = null;
                if (IsPositiveNumber(coffeeCommand, out int coffeeChoice) &&
                    coffeeChoice <= Products.coffeeTypes.Count)
                {
                    coffeeTypes = Products.coffeeTypes[coffeeChoice - 1];
                    _coffeeIndex = coffeeChoice - 1;
                    ingredients[0].Amount -= Products.coffeeTypes[coffeeChoice - 1].CoffeeBeans;
                    ingredients[1].Amount -= Products.coffeeTypes[coffeeChoice - 1].Milk;
                    ingredients[2].Amount -= Products.coffeeTypes[coffeeChoice - 1].Water;
                    Console.WriteLine($"You've chosen: {coffeeChoice}. {Products.coffeeTypes[coffeeChoice - 1].Name}.");
                    Console.ReadKey();
                }
                else
                {
                    IncorrectInput();
                    return;
                }

                //Coffee Volume
                Console.WriteLine("\n");
                for (int i = 0; i < coffeeTypes.VolumeTypes!.Length; i++)
                {
                    Console.WriteLine(
                        $"{i + 1}. {coffeeTypes.VolumeTypes[i].Volume}ml - {coffeeTypes.VolumeTypes[i].Price} rub");
                }

                string? volumeCommand = Console.ReadLine();
                VolumeType? volumeType = null;
                if (IsPositiveNumber(volumeCommand, out int volumeChoice) &&
                    volumeChoice <= coffeeTypes.VolumeTypes.Length)
                {
                    volumeType = coffeeTypes.VolumeTypes[volumeChoice - 1];
                    _volumeIndex = volumeChoice - 1;
                }

                Console.WriteLine(
                    $"You've chosen: {volumeChoice}. {coffeeTypes.VolumeTypes[volumeChoice - 1].Volume} ml - {coffeeTypes.VolumeTypes[volumeChoice - 1].Price} rub.");
                Console.ReadKey();


                //Flavor
                Console.WriteLine("\n");
                for (int i = 0; i < flavorTypes.Count; i++)
                {
                    Console.WriteLine(
                        $"{i + 1}. {flavorTypes[i].Name} ({flavorTypes[i].Price} rub) - {flavorTypes[i].Amount} left.");
                }

                Console.WriteLine("To avoid adding flavours - press Enter");

                string? flavorCommand = Console.ReadLine();
                FlavorType? flavorType = null;
                switch (flavorCommand)
                {
                    case "":
                    case null:
                        _flavourIndex = -1;
                        break;
                    default:
                        if (IsPositiveNumber(flavorCommand, out int flavourChoice) &&
                            flavourChoice <= flavorTypes.Count)
                        {
                            flavorType = flavorTypes[flavourChoice - 1];
                            _flavourIndex = flavourChoice - 1;
                        }

                        Console.WriteLine(
                            $"You've chosen {flavorTypes[flavourChoice - 1].Name} flavour.");
                        Console.ReadKey();
                        break;
                }

                //Order
                int total = coffeeTypes.VolumeTypes![_volumeIndex].Price;
                Console.WriteLine("=== YOUR ORDER ===");
                Console.WriteLine(
                    $"- {Products.coffeeTypes[_coffeeIndex].Name!} {coffeeTypes.VolumeTypes[_volumeIndex].Volume} ml");
                if (_flavourIndex == -1)
                    Console.WriteLine("No flavours");
                else
                {
                    total += flavorTypes[_flavourIndex].Price;
                    Console.WriteLine($"- {flavorTypes[_flavourIndex].Name}");
                }
                
                Console.WriteLine($"\nTotal cost: {total}");
                Console.WriteLine("You paid: ");
                string? balanceInput = Console.ReadLine();
                if (!int.TryParse(balanceInput, out int balance))
                {
                    Console.WriteLine("Invalid amount. Press Enter to continue...");
                    Console.ReadKey();
                    return;
                }

                if (balance >= total)
                {
                    balance -= total;
                    Console.WriteLine($"Successful! Your change: {balance}");
                    Console.Read();
                    Console.WriteLine("\n");
                    
                    SaveCoffeeConfig();
                    SaveFlavorConfig();
                    SaveIngredientsConfig();
                    SaveHistory($"Sold: {Products.coffeeTypes[_coffeeIndex].Name} {coffeeTypes.VolumeTypes[_volumeIndex].Volume} ml, {coffeeTypes.VolumeTypes[_volumeIndex].Price} rub");
                }
                else
                {
                    Console.WriteLine("Not enough money");
                    Console.Read();
                    Console.WriteLine("\n");
                }
            }
            
            static void OpenAdminPanel()
            {
                Console.WriteLine("\nEnter password:");
                switch (Console.ReadLine())
                {
                    case "123123":
                        Console.WriteLine("\n");
                        AdminCommands();
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("\nInvalid data");
                        Console.ReadKey();
                        break;
                }
            }

            static void AdminCommands()
            {
                AdminPanel();
                switch (ReadString())
                {
                    case "1":
                        AdminService.AddCoffee();
                        break;
                    case "2":
                        AdminService.ChangeCoffee();
                        break;
                    case "3":
                        AdminService.DeleteCoffee();
                        break;
                    case "4":
                        AdminService.AddFlavor();
                        break;
                    case "5":
                        AdminService.ChangeFlavor();
                        break;
                    case "6":
                        AdminService.DeleteFlavor();
                        break;
                    case "7":
                        AdminService.FinishShift();
                        break;
                }
            }
        }
    }
}