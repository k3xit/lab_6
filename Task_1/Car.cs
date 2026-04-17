using System;

internal class Car : CarBrand
{
    public string model { get; set; } = string.Empty;
    public int year { get; set; }
    public int power { get; set; }

    public Car()
    {
        BrandName = "Toyota";
        model = "Corolla";
        year = 2020;
        power = 120;
    }

    public Car(string brandName, string model, int year, int power) 
        : base(brandName)
    {
        this.model = model;
        this.year = year;
        this.power = power;
    }

    public Car(Car other) : base(other)
    {
        if (other != null)
        {
            this.model = other.model;
            this.year = other.year;
            this.power = other.power;
        }
    }

    public static Car ReadFromConsole()
    {
        string brand;
        do
        {
            Console.Write("Введите бренд: ");
            brand = Console.ReadLine() ?? string.Empty;
        } while (string.IsNullOrWhiteSpace(brand));

        string model;
        do
        {
            Console.Write("Введите модель: ");
            model = Console.ReadLine() ?? string.Empty;
        } while (string.IsNullOrWhiteSpace(model));

        int year;
        bool validYear;
        do
        {
            Console.Write("Введите год выпуска (1900-2026): ");
            validYear = int.TryParse(Console.ReadLine(), out year)
                        && year >= 1900 && year <= 2026;
            if (!validYear)
            {
                Console.WriteLine("Ошибка: введите корректный год.");
            }
        } while (!validYear);

        int power;
        bool validPower;
        do
        {
            Console.Write("Введите мощность в л.с. (50-1000): ");
            validPower = int.TryParse(Console.ReadLine(), out power)
                        && power >= 50 && power <= 1000;
            if (!validPower)
            {
                Console.WriteLine(
                    "Ошибка: мощность должна быть от 50 до 1000 л.с.");
            }
        } while (!validPower);

        return new Car(brand, model, year, power);
    }

    public bool IsHighTax()
    {
        return power > 160;
    }

    public string GetFullInfo()
    {
        string taxStatus = IsHighTax() ? "повышенный" : "стандартный";
        return $"{BrandName} {model} ({year}), мощность: {power} л.с., "
            + $"налог: {taxStatus}";
    }

    public override string ToString()
    {
        return base.ToString()
            + $", Модель: {model}, Год: {year}, Мощность: {power} л.с.";
    }
}