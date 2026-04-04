using static CoffeeMachine.Products;
using static CoffeeMachine.Printer;
using static CoffeeMachine.Reader;
using static CoffeeMachine.Validator;
using static CoffeeMachine.SaveSystem;

namespace CoffeeMachine
{
    public class AdminService
    {
        public static void AddCoffee()
        {
            var coffeeData = ReadCoffeeData(); // name, amount, volume, price

            AddedNewData();
            Console.WriteLine("|================================================|");
            Console.WriteLine("|                                                |");
            Console.WriteLine(ChangeFormat($"Name - {coffeeData!.Name}", 50));
            Console.WriteLine(ChangeFormat($"Amount - {coffeeData.Amount}", 50));
            Console.WriteLine("|                                                |");
            Console.WriteLine(ChangeFormat("Available volumes:", 50));
            Console.WriteLine("|                                                |");
            for (int i = 0; i < coffeeData.VolumeTypes!.Length; i++)
            {
                Console.WriteLine(ChangeFormat($"{i + 1}. {coffeeData.VolumeTypes[i].Volume} ml - {coffeeData.VolumeTypes[i].Price} rub", 50));
            }
            Console.WriteLine("|                                                |");
            Console.WriteLine("|================================================|");

            coffeeTypes!.Add(coffeeData);
            SaveCoffeeConfig();
            SaveFlavorConfig();
            SaveIngredientsConfig();
        }

        public static void DeleteCoffee()
        {
            CoffeeShowcase();
            string deleteCoffeeCommand = ReadString();
            if (IsPositiveNumber(deleteCoffeeCommand, out int deleteCoffeeChoice) &&
                deleteCoffeeChoice <= coffeeTypes.Count)
            {
                string? tempName = coffeeTypes[deleteCoffeeChoice - 1].Name;
                coffeeTypes.RemoveAt(deleteCoffeeChoice - 1);
                WasRemoved(tempName!);
            }
            
            SaveCoffeeConfig();
            SaveFlavorConfig();
            SaveIngredientsConfig();
        }

        public static void AddFlavor()
        {
            AdminPanelAddFlavor();

            var flavorData = ReadString().Split(' ');
            string flavorName = flavorData[0];

            if (flavorData.Length != 3) IncorrectInput();

            if (int.TryParse(flavorData[1], out int flavorPrice) && int.TryParse(flavorData[2], out int flavorAmount))
            {
                if (flavorPrice > 0 && flavorAmount > 0)
                {
                    AdminPanelAddFlavorSuccess(flavorName, flavorPrice, flavorAmount);
                    flavorTypes!.Add(new FlavorType()
                    {
                        Name = flavorName,
                        Price = flavorPrice,
                        Amount = flavorAmount
                    });
                    
                    SaveCoffeeConfig();
                    SaveFlavorConfig();
                    SaveIngredientsConfig();
                }
                else IncorrectInput();
            }
            else IncorrectInput();
        }

        public static void ChangeFlavor()
        {
            FlavorShowcase();

            string? changeFlavorCommand = ReadString();
            if (IsPositiveNumber(changeFlavorCommand, out int changeFlavorChoice) &&
                changeFlavorChoice <= flavorTypes.Count)
            {
                ChangeFlavorParameter();
                string? tempFlavorParamater = ReadString();
                switch (tempFlavorParamater)
                {
                    case "1":
                        ChangeItToPrompt();
                        string? tempName = ReadString();
                        flavorTypes[changeFlavorChoice - 1].Name = tempName;
                        Success();
                        break;
                    case "2":
                        ChangeItToPrompt();
                        string? tempPrice = ReadString();
                        if (int.TryParse(tempPrice, out int priceValue))
                        {
                            flavorTypes[changeFlavorChoice - 1].Price = priceValue;
                            Success();
                        }
                        else IncorrectInput();
                        break;
                    case "3":
                        ChangeItToPrompt();
                        string? tempAmount = ReadString();
                        if (int.TryParse(tempAmount, out int amountValue))
                        {
                            flavorTypes[changeFlavorChoice - 1].Amount = amountValue;
                            Success();
                        }
                        else IncorrectInput();
                        break;
                    default:
                        IncorrectInput();
                        break;
                    
                }
                
                SaveCoffeeConfig();
                SaveFlavorConfig();
                SaveIngredientsConfig();
            }
            else IncorrectInput();
        }

        public static void DeleteFlavor()
        {
            FlavorShowcase();
            string deleteFlavorCommand = ReadString();
            if (IsPositiveNumber(deleteFlavorCommand, out int deleteFlavorChoice) &&
                deleteFlavorChoice <= flavorTypes.Count)
            {
                string? tempName = flavorTypes[deleteFlavorChoice - 1].Name;
                flavorTypes.RemoveAt(deleteFlavorChoice - 1);
                WasRemoved(tempName!);
                
                SaveCoffeeConfig();
                SaveFlavorConfig();
                SaveIngredientsConfig();
            }
        }


        public static void RestockIngredients(int coffeeBeans, int water, int milk)
        {
            RestockUI();
            string[]? restockInput = ReadString().Split();
            ingredients[0].Amount += int.Parse(restockInput[0]);
            ingredients[1].Amount += int.Parse(restockInput[1]);
            ingredients[2].Amount += int.Parse(restockInput[2]);
            RestockedSuccessfully();
            Console.ReadKey();
        }

        public static void ChangeCoffee()
        {
            CoffeeShowcase();

            string? changeCoffeeCommand = ReadString();
            if (IsPositiveNumber(changeCoffeeCommand, out int changeCoffeeChoice) &&
                changeCoffeeChoice <= coffeeTypes.Count)
            {
                ChangeCoffeeParameter();
                string? tempCoffeeParamater = ReadString();
                switch (tempCoffeeParamater)
                {
                    case "1":
                        ChangeItToPrompt();
                        string? tempName = ReadString();
                        coffeeTypes[changeCoffeeChoice - 1].Name = tempName;
                        Success();
                        break;
                    case "2":
                        ChangeItToPrompt();
                        string? tempAmount = ReadString();
                        if (int.TryParse(tempAmount, out int amountValue))
                        {
                            coffeeTypes[changeCoffeeChoice - 1].Amount = amountValue;
                            Success();
                        }
                        else IncorrectInput();
                        break;
                    case "3":
                        ChangeItToPrompt();
                        string? tempCoffeeBeans = ReadString();
                        if (int.TryParse(tempCoffeeBeans, out int beansValue))
                        {
                            coffeeTypes[changeCoffeeChoice - 1].CoffeeBeans = beansValue;
                            Success();
                        }
                        else IncorrectInput();
                        break;
                    case "4":
                        ChangeItToPrompt();
                        string? tempWater = ReadString();
                        if (int.TryParse(tempWater, out int waterValue))
                        {
                            coffeeTypes[changeCoffeeChoice - 1].Water = waterValue;
                            Success();
                        }
                        else IncorrectInput();
                        break;
                    case "5":
                        ChangeItToPrompt();
                        string? tempMilk = ReadString();
                        if (int.TryParse(tempMilk, out int milkValue))
                        {
                            coffeeTypes[changeCoffeeChoice - 1].Milk = milkValue;
                            Success();
                        }
                        else IncorrectInput();
                        break;
                    default:
                        IncorrectInput();
                        break;
                    
                }
                
                SaveCoffeeConfig();
                SaveFlavorConfig();
                SaveIngredientsConfig();
            }
            else IncorrectInput();
        }

        public static void FinishShift()
        {
            SaveSystem.FinishShift();
            Console.WriteLine("|================================================|");
            Console.WriteLine("|                                                |");
            Console.WriteLine(ChangeFormat("Shift finished. Report saved.", 50));
            Console.WriteLine("|                                                |");
            Console.WriteLine("|================================================|");
            Console.ReadKey();
        }
    }
}