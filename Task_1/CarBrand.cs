internal class CarBrand
{
    private string brandName;

    public CarBrand()
    {
        brandName = "Toyota";
    }

    public CarBrand(string name)
    {
        brandName = name;
    }

   public CarBrand(CarBrand other)
    {
        if (other != null)
            this.brandName = other.brandName;
        else
            this.brandName = "Toyota";
    }

    public string BrandName
    {
        get 
        {
            return brandName;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                brandName = value.Trim();
        }
    }

    public string GetFirstAndLastChar()
    {
        if (string.IsNullOrEmpty(brandName))
             return "N/A";
        if (brandName.Length == 1)
             return $"{brandName[0]}{brandName[0]}";
        return $"{brandName[0]}{brandName[^1]}";
    }

    public override string ToString()
    {
        return $"Бренд: {brandName}";
    }
}