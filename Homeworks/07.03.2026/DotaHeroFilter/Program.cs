using System.Runtime.CompilerServices;

namespace DotaHeroFilter
{
    class Program
    {
        public static IEnumerable<string> FilterHeroesBy(string path, string stat)
        {
            using (StreamReader ReaderObject = new StreamReader(path))
            {
                string line;
                while ((line = ReaderObject.ReadLine()) != null)
                {
                    if (line.Contains(stat))
                    {
                        yield return line;
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            string FileToRead = @"D:\Repositories\11507_9\Homeworks\07.03.2026\heroes.txt";

            System.Console.WriteLine("Введите информацию о персонаже:");
            var input = Console.ReadLine();

            System.Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            System.Console.WriteLine();

            foreach (string str in FilterHeroesBy(FileToRead, input))
            {
                string[] temp = str.Split(";");
                System.Console.WriteLine($"Name: {temp[0]}");
                System.Console.WriteLine($"Complexity: {temp[1]}");
                System.Console.WriteLine($"Attribute: {temp[2]}");
                System.Console.WriteLine($"Attack Type: {temp[3]}");
                System.Console.WriteLine($"Movement Speed: {temp[4]}");
                System.Console.WriteLine($"Strength: {temp[5]}");
                System.Console.WriteLine($"Agility: {temp[6]}");
                System.Console.WriteLine($"Intelligence: {temp[7]}");
            }

            System.Console.WriteLine();
            System.Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            System.Console.WriteLine();
        }
    }
}
