using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;

        if (_denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
    }

    // Getters and Setters:
    public int GetNumerator()
    {
        return _numerator;
    }

    public int GetDenominator()
    {
        return _denominator;
    }

    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
    }

    public void SetDenominator(int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _denominator = denominator;
    }

    //Display Methods:

    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public double GetDecimalValue()
    {
        return (double)_numerator / (double)_denominator;
    }
}