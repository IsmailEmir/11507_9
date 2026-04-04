namespace CoffeeMachine;

public class Validator
{
    public static bool IsPositiveNumber(string? number, out int result)
    {
        result = 0;
        if (string.IsNullOrEmpty(number))
            return false;
        if (!int.TryParse(number, out result))
            return false;
        if (result <= 0)
            return false;
        return true;
    }
}