using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Тестирование класса Time ===\n");

        Console.WriteLine("1. Конструкторы:");
        var t1 = new Time();
        var t2 = new Time(14, 30);
        var t3 = new Time(150);
        var t4 = new Time(t2);
        Console.WriteLine("По умолчанию: " + t1.ToString());
        Console.WriteLine("Часы+минуты: " + t2.ToString());
        Console.WriteLine("Из минут (150): " + t3.ToString());
        Console.WriteLine("Копирование: " + t4.ToString());

        Console.WriteLine("\n2. Метод AddMinutes:");
        Console.WriteLine(t2.ToString() + " + 45 мин = " + t2.AddMinutes(45).ToString());
        Console.WriteLine(t2.ToString() + " + 120 мин = " + t2.AddMinutes(120).ToString());

        Console.WriteLine("\n3. Унарные операторы ++ и --:");
        var t5 = new Time(23, 59);
        Console.WriteLine("Исходное: " + t5.ToString());
        t5++;
        Console.WriteLine("После ++: " + t5.ToString());
        t5--;
        Console.WriteLine("После --: " + t5.ToString());

        Console.WriteLine("\n4. Приведение типов:");
        var t6 = new Time(10, 45);
        byte h = (byte)t6;
        bool isActive = t6;
        Console.WriteLine(t6.ToString() + " -> (byte) часы: " + h.ToString());
        Console.WriteLine(t6.ToString() + " -> (bool) Не нули??: " + isActive.ToString());
        var t7 = new Time(0, 0);
        Console.WriteLine(t7.ToString() + " -> (bool) Не нули??: " + ((bool)t7).ToString());

        Console.WriteLine("\n5. Бинарные операторы + и -:");
        var t8 = new Time(10, 30);
        Console.WriteLine(t8.ToString() + " + 45 мин = " + (t8 + 45).ToString());
        Console.WriteLine("45 мин + " + t8.ToString() + " = " + (45 + t8).ToString());
        Console.WriteLine(t8.ToString() + " - 15 мин = " + (t8 - 15).ToString());
        Console.WriteLine("90 мин - " + t8.ToString() + " = " + (90 - t8).ToString());

        Console.WriteLine("\n6. Ввод с клавиатуры с проверкой:");
        var userInput = Time.ReadFromConsole();
        Console.WriteLine("\nСоздано время: " + userInput.ToString());
        Console.WriteLine("+30 мин: " + (userInput + 30).ToString());
        userInput++;
        Console.WriteLine("После ++: " + userInput.ToString());
        Console.WriteLine("Часы: " + ((byte)userInput).ToString() + ", Не нули??: " + ((bool)userInput).ToString());
    }
}