using System;

internal class Time
{
    private byte hours;
    private byte minutes;

    public Time()
    {
        hours = 0;
        minutes = 0;
    }

    public Time(byte hours, byte minutes)
    {
        Hours = hours;
        Minutes = minutes;
    }

    public Time(uint totalMinutes)
    {
        hours = (byte)((totalMinutes / 60) % 24);
        minutes = (byte)(totalMinutes % 60);
    }

    public Time(Time other)
    {
        if (other != null)
        {
            this.hours = other.hours;
            this.minutes = other.minutes;
        }
    }

    public byte Hours
    {
        get
        {
            return hours;
        }
        set
        {
            hours = (value < 24) ? value : (byte)(value % 24);
        }
    }

    public byte Minutes
    {
        get
        {
            return minutes;
        }
        set
        {
            if (value < 60)
            {
                minutes = value;
            }
            else
            {
                hours = (byte)((hours + value / 60) % 24);
                minutes = (byte)(value % 60);
            }
        }
    }

    public Time AddMinutes(uint mins)
    {
        uint total = (uint)(hours * 60 + minutes + mins);
        return new Time(total);
    }

    public static Time ReadFromConsole()
    {
        byte inputHours;
        byte inputMinutes;
        string input;

        do
        {
            Console.Write("Введите часы (0-23): ");
            input = Console.ReadLine() ?? string.Empty;
        } while (!byte.TryParse(input, out inputHours) || inputHours >= 24);

        do
        {
            Console.Write("Введите минуты (0-59): ");
            input = Console.ReadLine() ?? string.Empty;
        } while (!byte.TryParse(input, out inputMinutes) || inputMinutes >= 60);

        return new Time(inputHours, inputMinutes);
    }

    public static Time operator ++(Time t)
    {
        if (t == null)
        {
            return new Time();
        }
        uint total = (uint)(t.hours * 60 + t.minutes + 1);
        return new Time(total);
    }

    public static Time operator --(Time t)
    {
        if (t == null)
        {
            return new Time();
        }
        int total = t.hours * 60 + t.minutes - 1;
        while (total < 0)
        {
            total += 24 * 60;
        }
        return new Time((uint)total);
    }

    public static explicit operator byte(Time t)
    {
        if (t == null)
        {
            return 0;
        }
        return t.hours;
    }

    public static implicit operator bool(Time t)
    {
        if (t == null)
        {
            return false;
        }
        return t.hours != 0 || t.minutes != 0;
    }

    public static Time operator +(Time t, uint mins)
    {
        if (t == null)
        {
            return new Time();
        }
        return t.AddMinutes(mins);
    }

    public static Time operator +(uint mins, Time t)
    {
        if (t == null)
        {
            return new Time();
        }
        return t.AddMinutes(mins);
    }

    public static Time operator -(Time t, uint mins)
    {
        if (t == null)
        {
            return new Time();
        }
        int total = t.hours * 60 + t.minutes - (int)mins;
        while (total < 0)
        {
            total += 24 * 60;
        }
        return new Time((uint)total);
    }

    public static Time operator -(uint mins, Time t)
    {
        if (t == null)
        {
            return new Time();
        }
        int total = (int)mins - (t.hours * 60 + t.minutes);
        while (total < 0)
        {
            total += 24 * 60;
        }
        return new Time((uint)total);
    }

    public override string ToString()
    {
        return $"{hours:D2}:{minutes:D2}";
    }
}