// ЗАДАНИЕ 2
// using System.Text;
// using System.Text.Encodings.Web;
// using System.Text.Json;
// using System.Text.Unicode;
// using IO;
//
// var itemsList = new List<Items>
// {
//     new Items("Стол", 12, 4990m),
//     new Items("Мяч", 60, 199m),
//     new Items("Огурец", 35, 15m)
// };
// var path = Path.Combine(Environment.CurrentDirectory, "items.json");
// File.WriteAllText(path, JsonSerializer.Serialize(itemsList, new JsonSerializerOptions
// {
//     WriteIndented = true,
//     Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
// }));

using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using IO;

string jsonContent = File.ReadAllText("items.json");
Console.WriteLine(jsonContent);
List<Items> items = JsonSerializer.Deserialize<List<Items>>(jsonContent);

while (true)
{
    Console.WriteLine("============================");
    Console.WriteLine("Добро пожаловать в магазин!");
    Console.WriteLine("\nВыберите, что вы хотите сделать:");
    Console.WriteLine("\n1. ДОБАВИТЬ товар в базу данных");
    Console.WriteLine("2. УДАЛИТЬ товар из базы данных");
    Console.WriteLine("3. ВЫВЕСТИ список всех товаров");
    Console.WriteLine("0. ВЫХОД");
    Console.WriteLine("\n------------------------------");

    var input = Console.ReadLine();
    switch (input)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("Добавление товара!");
            Console.WriteLine("Введите название товара, количество, цена (через пробел)");
            var itemChoice = Console.ReadLine();
            var itemChoices = itemChoice?.Split(' ');
            if (itemChoices != null && itemChoices.Length == 3)
            {
                try
                {
                    var newItem = new Items(itemChoices[0], int.Parse(itemChoices[1]), decimal.Parse(itemChoices[2]));
                    items.Add(newItem);
                    Console.WriteLine("Добавление прошло успешно!");
                    File.WriteAllText("items.json", JsonSerializer.Serialize(items, new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                    }));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: неверный формат чисел.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: введите 3 значения через пробел.");
            }
            Console.Read();
            Console.Clear();
            break;

        case "2":
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("Удаление товара!");
            Console.WriteLine("Выберите НАЗВАНИЕ товара из списка:");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name} (кол-во: {item.Amount}, цена: {item.Price} руб.)");
            }
            Console.WriteLine($"\nВсего товаров: {items.Count}");
            string itemToDelete = Console.ReadLine();
            
            int initialCount = items.Count;
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].Name == itemToDelete)
                    items.RemoveAt(i);
            }

            if (items.Count < initialCount)
                Console.WriteLine($"Предмет '{itemToDelete}' успешно удалён!");
            else
                Console.WriteLine($"Предмет '{itemToDelete}' не найден.");
            Console.WriteLine("============================");

            File.WriteAllText("items.json", JsonSerializer.Serialize(items, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            }));

            Console.Read();
            Console.Clear();
            break;

        case "3":
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("Вывод всех товаров:");
            if (items.Count == 0)
            {
                Console.WriteLine("Список товаров пуст.");
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine("------------------");
                    Console.WriteLine($"Название товара: {item.Name}");
                    Console.WriteLine($"Количество товара: {item.Amount} шт.");
                    Console.WriteLine($"Цена товара: {item.Price} руб.");
                }
            }
            Console.WriteLine("------------------");
            Console.WriteLine("============================");
            Console.Read();
            Console.Clear();
            break;
        case "0":
            Console.WriteLine("Выход из программы...");
            return;
        default:
            Console.WriteLine("Неверный выбор. Попробуйте снова.");
            Console.Read();
            Console.Clear();
            break;
    }
}