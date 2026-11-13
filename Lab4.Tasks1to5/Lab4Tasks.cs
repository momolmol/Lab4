using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab4.Tasks1to5;

public static class Lab4Tasks
{
    public static int SafeInputInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            
            if (int.TryParse(input, out int result) && result >= min && result <= max)
            {
                return result;
            }
            else 
            {
                Console.WriteLine($"Ошибка! Введите целое число от {min} до {max}.");
            }
        }
    }

    public static List<int> SafeInputList(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(input)) 
            {
                continue;
            }

            try
            {
                string[] parts = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                List<int> list = new List<int>();
                foreach (string part in parts) {
                    list.Add(int.Parse(part));
                }
                return list;
            }
            catch
            {
                Console.WriteLine("Ошибка! Вводите только целые числа через пробел.");
            }
        }
    }

    public static List<int> Task01_InsertList(List<int> list, int e)
    {
        if (list == null) 
        {
            throw new ArgumentNullException(nameof(list), "Список не может быть пустым (null).");
        }
        
        int index = list.IndexOf(e);
        
        if (index == -1) 
        {
            return list;
        }

        var copy = new List<int>(list);
        list.InsertRange(index + 1, copy);
        return list;
    }

    public static LinkedList<int> Task02_AddToEnds(LinkedList<int> list, int e)
    {
        if (list == null) 
        {
            throw new ArgumentNullException(nameof(list), "Список не может быть пустым (null).");
        }
        
        list.AddFirst(e);
        list.AddLast(e);
        return list;
    }

    public static void Task03_Books(HashSet<string> allBooks, List<HashSet<string>> readers)
    {
        if (allBooks == null || readers == null)
        {
            throw new ArgumentNullException("Списки книг и читателей не могут быть пустыми (null).");
        }
        
        if (allBooks.Count == 0)
        {
            Console.WriteLine("Перечень книг пуст.");
            return;
        }
        
        if (readers.Count == 0)
        {
            Console.WriteLine("Нет ни одного читателя.");
            return;
        }

        foreach (var r in readers)
        {
            if (r == null) 
            {
                throw new ArgumentException("У читателя не может быть null вместо списка книг.");
            }
        }

        var allRead = new HashSet<string>(readers[0]);
        for (int i = 1; i < readers.Count; i++)
        {
            allRead.IntersectWith(readers[i]);
        }
        
        Console.WriteLine("Прочли все: " + (allRead.Count > 0 ? string.Join(", ", allRead) : "нет таких"));

        var someRead = new HashSet<string>();
        foreach (var r in readers)
        {
            someRead.UnionWith(r);
        }
        
        Console.WriteLine("Прочли некоторые: " + (someRead.Count > 0 ? string.Join(", ", someRead) : "нет таких"));

        var nobodyRead = new HashSet<string>(allBooks);
        nobodyRead.ExceptWith(someRead);
        Console.WriteLine("Не прочёл никто: " + (nobodyRead.Count > 0 ? string.Join(", ", nobodyRead) : "нет таких"));
    }

    public static void Task04_TextFile(string path = "data/task04.txt")
    {
        if (string.IsNullOrWhiteSpace(path)) 
        {
            throw new ArgumentException("Путь к файлу не может быть пустым.");
        }
        
        if (!File.Exists(path)) 
        { 
            Console.WriteLine($"Файл {path} не найден!"); 
            return; 
        }

        string[] words = File.ReadAllText(path).Split(new[] { ' ', '\n', '\r', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
        
        if (words.Length < 2) 
        { 
            Console.WriteLine("В файле меньше двух слов."); 
            return; 
        }

        var firstWordChars = new HashSet<char>(words[0]);
        var commonChars = new HashSet<char>(words[1]);
        
        for (int i = 2; i < words.Length; i++)
        {
            commonChars.IntersectWith(words[i]);
        }

        commonChars.ExceptWith(firstWordChars);
        Console.WriteLine("Символы, которых нет в первом слове, но есть в остальных: " + (commonChars.Count > 0 ? string.Join(", ", commonChars) : "нет таких"));
    }

    public static void Task05_Olympiad(string path = "data/task05.txt")
    {
        if (string.IsNullOrWhiteSpace(path)) 
        { 
            throw new ArgumentException("Путь к файлу не может быть пустым."); 
        }
        
        if (!File.Exists(path)) 
        { 
            Console.WriteLine($"Файл {path} не найден!"); 
            return; 
        }

        string[] lines = File.ReadAllLines(path);
        
        if (lines.Length == 0) 
        { 
            return; 
        }

        if (!int.TryParse(lines[0], out int n) || n <= 0)
        {
            Console.WriteLine("Ошибка в файле: неверное количество участников.");
            return;
        }

        var participants = new List<(int Class, int Score)>();
        
        for (int i = 1; i <= n && i < lines.Length; i++)
        {
            var parts = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            if (parts.Length == 4 && int.TryParse(parts[2], out int cls) && int.TryParse(parts[3], out int score))
            {
                if (cls < 7 || cls > 11) 
                { 
                    continue; 
                }
                
                if (score < 0 || score > 70) 
                { 
                    continue; 
                }
                
                participants.Add((cls, score));
            }
        }

        if (participants.Count == 0) 
        { 
            Console.WriteLine("Нет корректных данных."); 
            return; 
        }


        for (int i = 0; i < participants.Count; i++) {
            for (int j = i + 1; j < participants.Count; j++) {
                if (participants[i].Score < participants[j].Score) {
                    var temp = participants[i];
                    participants[i] = participants[j];
                    participants[j] = temp;
                }
            }
        }

        int count25 = participants.Count * 25 / 100;
        
        if (count25 == 0) 
        { 
            Console.WriteLine("Слишком мало участников для 25%."); 
            return; 
        }

        int threshold = participants[count25 - 1].Score;
        int minWinnerScore = -1;
        int[] classCounts = new int[5];

        foreach (var p in participants)
        {
            bool isWinner = false;

            if (p.Score > threshold)
            {
                isWinner = true;
            }
            else if (p.Score == threshold)
            {
                if (p.Score > 35)
                {
                    isWinner = true;
                }
            }

            if (isWinner)
            {
                classCounts[p.Class - 7]++;
                minWinnerScore = p.Score;
            }
        }

        if (minWinnerScore == -1)
        {
            Console.WriteLine("Призеров нет (все баллы на границе и ниже 35).");
        }
        else
        {
            Console.WriteLine($"Минимальный балл призера: {minWinnerScore}");
            Console.WriteLine($"Призеры по классам (7-11): {string.Join(" ", classCounts)}");
        }
    }
}
