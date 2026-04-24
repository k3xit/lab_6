using System;

internal class CarBrand
{
    private string? _brandName;

    public CarBrand()
    {
        _brandName = "Toyota";
    }

    public CarBrand(string name)
    {
        BrandName = name;
    }

    public CarBrand(CarBrand other)
    {
        if (other != null)
        {
            _brandName = other.BrandName;
        }
        else
        {
            _brandName = "Toyota";
        }
    }

    public string BrandName
    {
        get
        {
            return _brandName;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _brandName = value.Trim();
            }
        }
    }

    public string GetFirstAndLastChar()
    {
        if (string.IsNullOrEmpty(_brandName))
        {
            return "N/A";
        }

        if (_brandName.Length == 1)
        {
            return $"{_brandName[0]}{_brandName[0]}";
        }

        return $"{_brandName[0]}{_brandName[^1]}";
    }

    public override string ToString()
    {
        return $"Бренд: {_brandName}";
    }
}