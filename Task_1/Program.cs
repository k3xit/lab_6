using System;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("\nБазовые параметры:");
        var defaultCar = new Car();
        Console.WriteLine(defaultCar);
        Console.WriteLine(defaultCar.GetFullInfo());

        Console.WriteLine("\nЗаданные параметры:");
        var customCar = new Car("BMW", "M3", 2022, 480);
        Console.WriteLine(customCar);
        Console.WriteLine(customCar.GetFullInfo());

        Console.WriteLine("\nКопирование:");
        var copyCar = new Car(customCar);
        copyCar.Model = "M340i";
        copyCar.Power = 385;
        Console.WriteLine(copyCar);
        Console.WriteLine(copyCar.GetFullInfo());
        Console.WriteLine(
            $"Первый и последний символ: {copyCar.GetFirstLastChar()}");

        Console.WriteLine("\nРучной ввод с проверкой:");
        var inputCar = Car.ReadFromConsole();
        Console.WriteLine("\nСозданный автомобиль:");
        Console.WriteLine(inputCar);
        Console.WriteLine(inputCar.GetFullInfo());
        Console.WriteLine(
            $"Первый и последний символ: {inputCar.GetFirstLastChar()}");
    }
}