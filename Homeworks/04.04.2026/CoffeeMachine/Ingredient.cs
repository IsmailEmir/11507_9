namespace CoffeeMachine;

public class Ingredient
{
    public string Name { get; set; }
    public int Amount { get; set; }

    public Ingredient(string name, int amount)
    {
        Name = name;
        Amount = amount;
    }

    public bool isEnough(int amount)
    {
        if (Amount > amount)
        {
            Amount -= amount;
            return true;
        }

        return false;
    }

    public void Restock(int amount)
    {
        Amount += amount;
    }
}