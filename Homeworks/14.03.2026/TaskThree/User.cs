public class User
{
    public readonly string? Nickname;
    public readonly string? Password;
    public readonly string? Email;

    public User(string nickname, string password, string email)
    {
        Nickname = nickname;
        Password = password;
        Email = email;
    }
}

