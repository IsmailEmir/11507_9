using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;

namespace DotaHeroFilter
{
    class Printer
    {
        public void StartMenu()
        {
            WriteLine();
            WriteLine("1. Name");
            WriteLine("2. Complexity");
            WriteLine("3. Attribute");
            WriteLine("4. Attack Type");
            WriteLine("5. Movement Speed");
            WriteLine("6. Strength");
            WriteLine("7. Agility");
            WriteLine("8. Intelligence");
            WriteLine();
            WriteLine("0. Exit the program");
            WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            WriteLine();
        }

        public void PrintCharacterInfo(IEnumerable<Character> heroes)
        {
            WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            WriteLine();

            foreach (var hero in heroes)
            {
                WriteLine($"Name: {hero.Name}");
                WriteLine($"Complexity: {hero.Complexity}");
                WriteLine($"Attribute: {hero.Attribute}");
                WriteLine($"Attack Type: {hero.AttackType}");
                WriteLine($"Movement Speed: {hero.MovementSpeed}");
                WriteLine($"Strength: {hero.Strength}");
                WriteLine($"Agility: {hero.Agility}");
                WriteLine($"Intelligence: {hero.Intelligence}");
                WriteLine();
            }

            WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            WriteLine();
        }

        public void PrintInputMessage()
        {
            Clear();
            WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            WriteLine();
            WriteLine("Your choice: 1. Name");
            WriteLine();
            WriteLine("Type here data you want to filter by:");
        }

        public void ShowResult(List<Character> heroes, Printer printer)
        {
            Clear();
            WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            if (heroes.Count == 0)
                WriteLine("No heroes found matching your criteria.");
            else
                printer.PrintCharacterInfo(heroes);
        }
    }
}