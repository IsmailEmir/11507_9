using System.Reflection;

namespace CW2.Services;

public static class PropertyLogger
{
    public static List<string> GetLog(object obj)
    {
        List<string> result = new List<string>();

        if (obj == null) return result;

        Type type = obj.GetType();
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo prop in properties)
        {
            object? value = prop.GetValue(obj);
            if (value != null) result.Add($"{prop.Name}: {value}");
        }

        return result;
    }
}
