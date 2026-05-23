namespace CW2.Models;

public class User
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public int Age { get; set; }

    public override string ToString()
    {
        return $"{Name}, {Age} лет, {Email}";
    }
}
