using System;

namespace Lab4.Tasks6and7;

class Program
{
    static uint ReadUInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            
            if (uint.TryParse(input, out uint res)) 
            {
                return res;
            }
            
            Console.WriteLine("Ошибка! Введите целое положительное число (0 или больше).");
        }
    }

    static byte ReadByte(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            
            if (byte.TryParse(input, out byte res) && res <= 99) 
            {
                return res;
            }
            
            Console.WriteLine("Ошибка! Введите число от 0 до 99.");
        }
    }

    static void Main()
    {
        Console.WriteLine("ЗАДАНИЯ 6-7. ДЕНЬГИ");
        
        try
        {
            Console.WriteLine("\nВведите первую сумму:");
            Money m1 = new Money(ReadUInt("  Рубли: "), ReadByte("  Копейки: "));

            Console.WriteLine("\nВведите вторую сумму:");
            Money m2 = new Money(ReadUInt("  Рубли: "), ReadByte("  Копейки: "));

            Console.WriteLine($"\nm1 = {m1}");
            Console.WriteLine($"m2 = {m2}");

            Console.WriteLine($"\nРазность (m1 - m2): {m1 - m2}");
            Console.WriteLine($"Разность (m1 - 10 копеек): {m1 - 10u}");
            Console.WriteLine($"Разность (10 копеек - m1): {10u - m1}");

            m1++;
            Console.WriteLine($"\nm1++ (добавили 1 копейку): {m1}");
            m1--;
            Console.WriteLine($"m1-- (убрали 1 копейку):  {m1}");

            uint rub = m1;
            double frac = (double)m1;
            Console.WriteLine($"\nПриведение к uint (только рубли): {rub}");
            Console.WriteLine($"Приведение к double (только копейки): {frac}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[ПОЙМАНА ОШИБКА]: {ex.Message}");
        }

        Console.WriteLine("\nНажмите Enter для выхода...");
        Console.ReadLine();
    }
}