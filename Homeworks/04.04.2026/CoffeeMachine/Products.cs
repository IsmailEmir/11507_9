using static CoffeeMachine.SaveSystem;

namespace CoffeeMachine
{
    public class Products
    {
        public static List<CoffeeType?> coffeeTypes = new(LoadCoffeeConfig()); // i dont remember
        
        public static List<FlavorType> flavorTypes = new(LoadFlavorConfig()); // name, price, amount*

        public static List<Ingredient> ingredients = new(LoadIngredientsConfig()); // coffee beans, water, milk
    }
}