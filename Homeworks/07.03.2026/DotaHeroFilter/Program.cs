using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;

namespace DotaHeroFilter
{
    class Program
    {
        public static IEnumerable<Character> ReadHeroes(string path, int fieldIndex, string filterValue)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()!) != null)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length < 8) continue;

                    var hero = new Character
                    {
                        Name = parts[0],
                        Complexity = parts[1],
                        Attribute = parts[2],
                        AttackType = parts[3],
                        MovementSpeed = int.Parse(parts[4]),
                        Strength = int.Parse(parts[5]),
                        Agility = int.Parse(parts[6]),
                        Intelligence = int.Parse(parts[7])
                    };

                    bool matches = fieldIndex switch
                    {
                        1 => hero.Name.Contains(filterValue, StringComparison.OrdinalIgnoreCase),
                        2 => hero.Complexity == filterValue,
                        3 => hero.Attribute.Equals(filterValue, StringComparison.OrdinalIgnoreCase),
                        4 => hero.AttackType.Equals(filterValue, StringComparison.OrdinalIgnoreCase),
                        5 => hero.MovementSpeed.ToString() == filterValue,
                        6 => hero.Strength.ToString() == filterValue,
                        7 => hero.Agility.ToString() == filterValue,
                        8 => hero.Intelligence.ToString() == filterValue,
                        _ => false
                    };

                    if (matches)
                        yield return hero;
                }
            }
        }

        public static List<Character> FilterExistingList(List<Character> heroes, int fieldIndex, string filterValue)
        {
            var result = new List<Character>();
            foreach (var hero in heroes)
            {
                bool matches = fieldIndex switch
                {
                    1 => hero.Name!.Contains(filterValue, StringComparison.OrdinalIgnoreCase),
                    2 => hero.Complexity == filterValue,
                    3 => hero.Attribute!.Equals(filterValue, StringComparison.OrdinalIgnoreCase),
                    4 => hero.AttackType!.Equals(filterValue, StringComparison.OrdinalIgnoreCase),
                    5 => hero.MovementSpeed.ToString() == filterValue,
                    6 => hero.Strength.ToString() == filterValue,
                    7 => hero.Agility.ToString() == filterValue,
                    8 => hero.Intelligence.ToString() == filterValue,
                    _ => false
                };
                if (matches)
                    result.Add(hero);
            }
            return result;
        }

        private static void Main(string[] args)
        {
            string fileToRead = @"D:\Repositories\11507_9\Homeworks\07.03.2026\heroes.txt"; // поменяй на свою директорию
            Printer printer = new Printer();

            while (true)
            {
                Clear();
                WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                WriteLine("Select the aspect you want to filter by:");
                printer.StartMenu();
                var input = ReadLine();
                if (input == "0") break;

                string? prompt = input switch
                {
                    "1" => "Name",
                    "2" => "Complexity (1/2/3)",
                    "3" => "Attribute (Agility/Strength/Intelligence)",
                    "4" => "Attack Type (Melee/Ranged)",
                    "5" => "Movement Speed (e.g. 300)",
                    "6" => "Strength (e.g. 25)",
                    "7" => "Agility (e.g. 30)",
                    "8" => "Intelligence (e.g. 20)",
                    _ => null
                };

                if (prompt == null)
                {
                    WriteLine("Invalid option. Press Enter...");
                    ReadLine();
                    continue;
                }

                Write($"Enter value for '{prompt}': ");
                var filterValue = ReadLine();
                if (string.IsNullOrWhiteSpace(filterValue)) continue;

                var currentHeroes = new List<Character>();
                foreach (var hero in ReadHeroes(fileToRead, int.Parse(input!), filterValue))
                    currentHeroes.Add(hero);

                if (input is "5" or "6" or "7" or "8")
                {
                    currentHeroes.Sort((a, b) => input switch
                    {
                        "5" => Comparer<int?>.Default.Compare(a.MovementSpeed, b.MovementSpeed),
                        "6" => Comparer<int?>.Default.Compare(a.Strength, b.Strength),
                        "7" => Comparer<int?>.Default.Compare(a.Agility, b.Agility),
                        "8" => Comparer<int?>.Default.Compare(a.Intelligence, b.Intelligence),
                        _ => 0
                    });
                }

                printer.ShowResult(currentHeroes, printer);

                while (currentHeroes.Count > 0)
                {
                    WriteLine("\nOptions:");
                    WriteLine("1. Apply another filter");
                    WriteLine("2. Return to main menu");
                    Write("Choose: ");
                    var subChoice = ReadLine();

                    if (subChoice != "1")
                        break;

                    Clear();
                    WriteLine("Apply additional filter:");
                    printer.StartMenu();
                    var nextField = ReadLine();
                    if (nextField == "0" || !int.TryParse(nextField, out int fieldIndex) || fieldIndex < 1 || fieldIndex > 8)
                    {
                        WriteLine("Invalid field. Returning to main menu.");
                        break;
                    }

                    prompt = nextField switch
                    {
                        "1" => "Name", "2" => "Complexity", "3" => "Attribute",
                        "4" => "Attack Type", "5" => "Movement Speed", "6" => "Strength",
                        "7" => "Agility", "8" => "Intelligence", _ => null
                    };

                    Write($"Enter value for '{prompt}': ");
                    var nextFilter = ReadLine();
                    if (string.IsNullOrWhiteSpace(nextFilter)) break;

                    currentHeroes = FilterExistingList(currentHeroes, fieldIndex, nextFilter);

                    printer.ShowResult(currentHeroes, printer);
                    if (currentHeroes.Count == 0)
                        break;
                }
            }
        }
    }
}