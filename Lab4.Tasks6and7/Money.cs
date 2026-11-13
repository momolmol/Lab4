using System;

namespace Lab4.Tasks6and7;

public class Money
{
    private uint _rubles;
    private byte _kopeks;

    public uint Rubles 
    { 
        get 
        { 
            return _rubles; 
        } 
        set 
        { 
            _rubles = value; 
        } 
    }
    
    public byte Kopeks 
    { 
        get 
        { 
            return _kopeks; 
        } 
        set 
        {
            if (value > 99) 
            {
                throw new ArgumentException("Копеек не может быть больше 99.");
            }
            _kopeks = value; 
        } 
    }

    public Money(uint rubles, byte kopeks)
    {
        Rubles = rubles;
        Kopeks = kopeks; 
    }

    public Money Subtract(Money other)
    {
        if (other == null) 
        {
            throw new ArgumentNullException(nameof(other), "Вычитаемое не может быть null.");
        }
        
        long totalKopeks1 = (long)_rubles * 100 + _kopeks;
        long totalKopeks2 = (long)other._rubles * 100 + other._kopeks;
        long result = totalKopeks1 - totalKopeks2;

        if (result < 0) 
        {
            return new Money(0, 0);
        }

        return new Money((uint)(result / 100), (byte)(result % 100));
    }

    public override string ToString() 
    { 
        return $"{_rubles} руб. {_kopeks} коп."; 
    }

    public static Money operator ++(Money m)
    {
        if (m == null) 
        {
            throw new ArgumentNullException(nameof(m));
        }
        
        long totalKopeks = (long)m._rubles * 100 + m._kopeks + 1;
        return new Money((uint)(totalKopeks / 100), (byte)(totalKopeks % 100));
    }

    public static Money operator --(Money m)
    {
        if (m == null) 
        {
            throw new ArgumentNullException(nameof(m));
        }
        
        long totalKopeks = (long)m._rubles * 100 + m._kopeks - 1;
        
        if (totalKopeks < 0) 
        {
            totalKopeks = 0;
        }
        
        return new Money((uint)(totalKopeks / 100), (byte)(totalKopeks % 100));
    }

    public static implicit operator uint(Money m) 
    { 
        if (m == null) 
        {
            return 0; 
        }
        return m._rubles; 
    }
    
    public static explicit operator double(Money m) 
    { 
        if (m == null) 
        {
            return 0.0; 
        }
        return m._kopeks / 100.0; 
    }

    public static Money operator -(Money m, uint kopeks)
    {
        if (m == null) 
        {
            throw new ArgumentNullException(nameof(m));
        }
        
        long totalKopeks = (long)m._rubles * 100 + m._kopeks - kopeks;
        
        if (totalKopeks < 0) 
        {
            totalKopeks = 0;
        }
        
        return new Money((uint)(totalKopeks / 100), (byte)(totalKopeks % 100));
    }

    public static Money operator -(uint kopeks, Money m)
    {
        if (m == null) 
        {
            throw new ArgumentNullException(nameof(m));
        }
        
        long totalKopeks = kopeks - ((long)m._rubles * 100 + m._kopeks);
        
        if (totalKopeks < 0) 
        {
            totalKopeks = 0;
        }
        
        return new Money((uint)(totalKopeks / 100), (byte)(totalKopeks % 100));
    }

    public static Money operator -(Money m1, Money m2)
    {
        if (m1 == null || m2 == null) 
        {
            throw new ArgumentNullException("Денежные суммы не могут быть null.");
        }
        
        return m1.Subtract(m2);
    }
}