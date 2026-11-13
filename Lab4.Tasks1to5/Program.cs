using System;
using System.Collections.Generic;

namespace Lab4.Tasks1to5;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("       ЛАБОРАТОРНАЯ РАБОТА №4. ЗАДАНИЯ 1-5");
            Console.WriteLine("\n  1. Задание 1 (List): Вставка элементов");
            Console.WriteLine("  2. Задание 2 (LinkedList): Добавление в концы");
            Console.WriteLine("  3. Задание 3 (HashSet): Прочитанные книги");
            Console.WriteLine("  4. Задание 4 (HashSet): Анализ текста из файла");
            Console.WriteLine("  5. Задание 5 (Dictionary): Результаты олимпиады");
            Console.WriteLine("\n  0. Выход");
            Console.Write("\nВыберите пункт (0-5): ");

            string? choice = Console.ReadLine() ?? "";
            
            if (choice == "0") 
            { 
                break; 
            }

            Console.Clear();
            
            try
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("    ЗАДАНИЕ 1. ВСТАВКА СПИСКА    ");
                        var list1 = Lab4Tasks.SafeInputList("Введите элементы списка L (через пробел): ");
                        int e1 = Lab4Tasks.SafeInputInt("Введите число E: ");
                        
                        Console.WriteLine($"\nБыло:  {string.Join(", ", list1)}");
                        Lab4Tasks.Task01_InsertList(list1, e1);
                        Console.WriteLine($"Стало: {string.Join(", ", list1)}");
                        break;

                    case "2":
                        Console.WriteLine("    ЗАДАНИЕ 2. LINKEDLIST    ");
                        var list2 = new LinkedList<int>(Lab4Tasks.SafeInputList("Введите элементы списка (через пробел): "));
                        int e2 = Lab4Tasks.SafeInputInt("Введите число E: ");
                        
                        Console.WriteLine($"\nБыло:  {string.Join(", ", list2)}");
                        Lab4Tasks.Task02_AddToEnds(list2, e2);
                        Console.WriteLine($"Стало: {string.Join(", ", list2)}");
                        break;

                    case "3":
                        Console.WriteLine("    ЗАДАНИЕ 3. КНИГИ    \n");
                        var allBooks = new HashSet<string> { "Война и мир", "Преступление и наказание", "Мастер и Маргарита", "Идиот" };
                        var readers = new List<HashSet<string>>
                        {
                            new HashSet<string> { "Война и мир", "Мастер и Маргарита" },
                            new HashSet<string> { "Война и мир", "Идиот" },
                            new HashSet<string> { "Война и мир", "Преступление и наказание", "Мастер и Маргарита" }
                        };
                        Lab4Tasks.Task03_Books(allBooks, readers);
                        break;

                    case "4":
                        Console.WriteLine("    ЗАДАНИЕ 4. ТЕКСТ ИЗ ФАЙЛА    \n");
                        Lab4Tasks.Task04_TextFile();
                        break;

                    case "5":
                        Console.WriteLine("    ЗАДАНИЕ 5. ОЛИМПИАДА    \n");
                        Lab4Tasks.Task05_Olympiad();
                        break;

                    default:
                        Console.WriteLine("Такого пункта нет.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ПЕРЕХВАЧЕНА ОШИБКА]: {ex.Message}");
            }

            Console.WriteLine("\nНажми Enter, чтобы вернуться в меню...");
            Console.ReadLine();
        }
    }
}