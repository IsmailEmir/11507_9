public class Registration
{
    public static User Register()
    {
        Console.Write("Введите никнейм: ");
        string? inputNick = Console.ReadLine();
        Console.Write("Введите пароль: ");
        string? inputPass = Console.ReadLine();
        Console.Write("Введите почту: ");
        string? inputEmail = Console.ReadLine();

        User user = new(inputNick!, inputPass!, inputEmail!);
        return user;
    }
}