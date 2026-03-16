using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<string> names = new()
        {
            "Salam",
            "Kate",
            "Aleksandr",
            "1",
            "5234"
        };
        names.IndexedForeach((index, name) => Console.WriteLine($"{index} - {name}"));
    }
}