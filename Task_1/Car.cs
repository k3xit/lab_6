using System;

internal class Car : CarBrand
{
    private string? _model;
    private int _year;
    private int _power;

    public string? Model
    {
        get 
        { 
            return _model; 
        }
        set 
        { 
            _model = value; 
        }
    }

    public int Year
    {
        get 
        { 
            return _year; 
        }
        set 
        {
            _year = value; 
        }
    }

    public int Power
    {
        get 
        { 
            return _power; 
        }
        set 
        { 
            _power = value; 
        }
    }

    public Car()
    {
        BrandName = "Toyota";
        Model = "Corolla";
        Year = 2020;
        Power = 120;
    }

    public Car(string brandName, string model, int year, int power)
        : base(brandName)
    {
        Model = model;
        Year = year;
        Power = power;
    }

    public Car(Car other) : base(other)
    {
        if (other != null)
        {
            Model = other.Model;
            Year = other.Year;
            Power = other.Power;
        }
    }

    public bool IsHighTax()
    {
        return Power > 160;
    }

    public string GetFullInfo()
    {
        string taxStatus = IsHighTax() ? "повышенный" : "стандартный";
        return $"{BrandName} {Model} ({Year}), мощность: {Power} л.с., "
               + $"налог: {taxStatus}";
    }

    public override string ToString()
    {
        return base.ToString()
               + $", Модель: {Model}, Год: {Year}, Мощность: {Power} л.с.";
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
}