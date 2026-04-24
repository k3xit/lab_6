using System;

internal class Car : CarBrand
{
    private string _model = string.Empty;
    private int _year;
    private int _power;

    public string Model
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
}