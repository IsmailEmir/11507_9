using static CoffeeMachine.Products;

namespace CoffeeMachine
{
    public class Printer
    {
        public static string ChangeFormat(string value, int width)
        {
            string output = $"| {value}";
            while (output.Length < width - 1) output += " ";
            return output + "|";
        }

        public static void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("|================================================|");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|           Welcome to Coffee Machine!           |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| 1. Order coffee                                |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| 3. Exit                                        |");
            Console.WriteLine(
                "|                                                |\n| 0. Admin panel                                 |");
            Console.WriteLine("|================================================|");
        }

        public static void AdminPanel()
        {
            Console.Clear();
            Console.WriteLine("|================================================|");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|             Welcome To Admin Panel             |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|         What changes you want to make?         |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| ------------------- Coffee ------------------- |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| 1. Add coffee                                  |");
            Console.WriteLine("| 2. Change coffee data                          |");
            Console.WriteLine("| 3. Delete coffee                               |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| ------------------- Flavor ------------------- |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| 4. Add flavour                                 |");
            Console.WriteLine("| 5. Change flavor data                          |");
            Console.WriteLine("| 6. Delete flavor                               |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| ------------------- Shift -------------------- |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| 7. Finish shift                                |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|================================================|");
        }

        public static void CoffeeShowcase()
        {
            Console.Clear();
            Console.WriteLine("|================================================|");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|                Select an option                |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| ------------------- Coffee ------------------- |");
            Console.WriteLine("|                                                |");
            for (int i = 0; i < coffeeTypes!.Count; i++)
            {
                Console.WriteLine(Printer.ChangeFormat($"{i + 1}. {coffeeTypes[i].Name!}", 50));
            }

            Console.WriteLine("|                                                |");
            Console.WriteLine("|================================================|");
        }

        public static void AdminPanelAddFlavor()
        {
            Console.Clear();
            Console.WriteLine("|================================================|");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| Write the name of the flavor, price and amount |");
            Console.WriteLine("|          (write separated by a space)          |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|================================================|");
        }

        public static void AdminPanelAddFlavorSuccess(string name, int price, int amount)
        {
            Console.Clear();
            Console.WriteLine("|================================================|");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|                Added new flavor                |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| -------------------- Name -------------------- |");
            Console.WriteLine("|                                                |");
            Console.WriteLine(ChangeFormat(name, 50));
            Console.WriteLine("|                                                |");
            Console.WriteLine("| -------------------- Price -------------------- |");
            Console.WriteLine("|                                                |");
            Console.WriteLine(ChangeFormat(name + " rub", 50));
            Console.WriteLine("|                                                |");
            Console.WriteLine("| ------------------- Amount ------------------- |");
            Console.WriteLine("|                                                |");
            Console.WriteLine(ChangeFormat(name, 50));
            Console.WriteLine("|                                                |");
            Console.WriteLine("|================================================|");
        }

        public static void FlavorShowcase()
        {
            Console.Clear();
            Console.WriteLine("|================================================|");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|                Select an option                |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| ------------------- Flavor ------------------- |");
            Console.WriteLine("|                                                |");
            for (int i = 0; i < flavorTypes!.Count; i++)
            {
                Console.WriteLine(Printer.ChangeFormat($"{i + 1}. {flavorTypes[i].Name}", 50));
            }

            Console.WriteLine("|                                                |");
            Console.WriteLine("|================================================|");
        }

        public static void ChangeFlavorParameter()
        {
            Console.Clear();
            Console.WriteLine("|================================================|");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|          Choose a parameter to change          |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| ----------------- Parameters ----------------- |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| 1. Name                                        |");
            Console.WriteLine("| 2. Price                                       |");
            Console.WriteLine("| 3. Amount                                      |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|================================================|");
        }

        public static void ChangeCoffeeParameter()
        {
            Console.Clear();
            Console.WriteLine("|================================================|");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|          Choose a parameter to change          |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| ----------------- Parameters ----------------- |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("| 1. Name                                        |");
            Console.WriteLine("| 2. Amount                                      |");
            Console.WriteLine("| 3. Coffee Beans                                |");
            Console.WriteLine("| 4. Water                                       |");
            Console.WriteLine("| 5. Milk                                        |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|================================================|");
        }

        public static void ChangeItToPrompt()
        {
            Console.WriteLine("|================================================|");
            Console.WriteLine("|                                                |");
            Console.WriteLine(ChangeFormat("Changing it to:", 50));
            Console.WriteLine("|                                                |");
            Console.WriteLine("|================================================|");
        }

        public static void AddedNewData()
        {
            Console.WriteLine("|================================================|");
            Console.WriteLine("|                                                |");
            Console.WriteLine(ChangeFormat("ADDED NEW DATA", 50));
            Console.WriteLine("|                                                |");
            Console.WriteLine("|================================================|");
        }

        public static void WasRemoved(string name)
        {
            Console.WriteLine("|================================================|");
            Console.WriteLine("|                                                |");
            Console.WriteLine(ChangeFormat($"{name} was removed.", 50));
            Console.WriteLine("|                                                |");
            Console.WriteLine("|================================================|");
        }

        public static void RestockUI()
        {
            Console.WriteLine("|================================================|");
            Console.WriteLine("|                                                |");
            Console.WriteLine(ChangeFormat("RESTOCK UI", 50));
            Console.WriteLine("|                                                |");
            Console.WriteLine(ChangeFormat("Write amount of: Coffee Beans, Water and Milk", 50));
            Console.WriteLine(ChangeFormat("(via spacebar)", 50));
            Console.WriteLine("|                                                |");
            Console.WriteLine("|================================================|");
        }

        public static void RestockedSuccessfully()
        {
            Console.WriteLine("|================================================|");
            Console.WriteLine("|                                                |");
            Console.WriteLine(ChangeFormat("Restocked successfully.", 50));
            Console.WriteLine("|                                                |");
            Console.WriteLine("|================================================|");
        }

        public static void Success()
        {
            Console.WriteLine("Succesful!");
        }

        public static void IncorrectInput()
        {
            Console.WriteLine("Incorrect input. Press Enter to continue...");
            Console.ReadKey();
            return;
        }
    }
}