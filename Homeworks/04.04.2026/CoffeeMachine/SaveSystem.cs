using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace CoffeeMachine;

public class SaveSystem
{
    static string pathCoffeeConfig = Path.Combine(Directory.GetCurrentDirectory(), "coffeeConfig.json");
    static string pathFlavorConfig = Path.Combine(Directory.GetCurrentDirectory(), "flavorConfig.json");
    static string pathIngredientsConfig = Path.Combine(Directory.GetCurrentDirectory(), "ingredientsConfig.json");
    static string salesHistoryConfig = Path.Combine(Directory.GetCurrentDirectory(), "sales_history.txt");

    public static void SaveCoffeeConfig()
    {
        File.WriteAllText(pathCoffeeConfig, JsonSerializer.Serialize(Products.coffeeTypes, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        }));
    }

    public static void SaveFlavorConfig()
    {
        File.WriteAllText(pathFlavorConfig, JsonSerializer.Serialize(Products.flavorTypes, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        }));
    }

    public static void SaveIngredientsConfig()
    {
        File.WriteAllText(pathIngredientsConfig, JsonSerializer.Serialize(Products.ingredients, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        }));
    }
    
    public static List<CoffeeType> LoadCoffeeConfig()
    {
        return JsonSerializer.Deserialize<List<CoffeeType>>(File.ReadAllText(pathCoffeeConfig))!;
    }

    public static List<FlavorType> LoadFlavorConfig()
    {
        return JsonSerializer.Deserialize<List<FlavorType>>(File.ReadAllText(pathFlavorConfig))!;
    }
    
    public static List<Ingredient> LoadIngredientsConfig()
    {
        return JsonSerializer.Deserialize<List<Ingredient>>(File.ReadAllText(pathIngredientsConfig))!;
    }

    public static void SaveHistory(string input)
    {
        DateTime date = DateTime.Now;
        input = "[" + date.ToString("dd/MM/yyyy") + "] " + input;
        File.AppendAllText(salesHistoryConfig, input + "\n");
    }

    public static void FinishShift()
    {
        DateTime date = DateTime.Now;
        string historyData = "";
        if (File.Exists(salesHistoryConfig))
            historyData = File.ReadAllText(salesHistoryConfig);
        string[] data = historyData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        string path = Path.Combine(Directory.GetCurrentDirectory(), $"report_{date:yyyy_MM_dd}.json");
        File.WriteAllText(path, JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        }));
        File.WriteAllText(salesHistoryConfig, string.Empty);
    }
}