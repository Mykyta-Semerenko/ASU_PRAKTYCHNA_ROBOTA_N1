using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть шлях до TXT-файлу:");

        string path = Console.ReadLine() ?? "";

        if (!File.Exists(path))
        {
            Console.WriteLine("Файл не знайдено!");
            return;
        }

        string text = File.ReadAllText(path);

        string[] words = text
            .ToLower()
            .Split(new char[] { ' ', ',', '.', '!', '?', ':', ';', '\n', '\t' },
                StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> wordCounts = new();

        foreach (string word in words)
        {
            if (wordCounts.ContainsKey(word))
                wordCounts[word]++;
            else
                wordCounts[word] = 1;
        }

        var sortedWords = wordCounts
            .OrderByDescending(x => x.Value);

        Console.WriteLine("\nРезультати аналізу:");

        foreach (var pair in sortedWords)
        {
            Console.WriteLine($"{pair.Key} — {pair.Value}");
        }

        Console.WriteLine($"\nУсього слів: {words.Length}");
    }
}