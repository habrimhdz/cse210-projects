using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("This is the Fractions Project.");
        Console.WriteLine("You can create fractions here.");
        Console.WriteLine("Please, enter the numerator:");
        int numerator = int.Parse(Console.ReadLine());
        Console.WriteLine("Please, enter the denominator:");
        int denominator = int.Parse(Console.ReadLine());

        Fraction _fraction1 = new Fraction();
        Fraction _fraction2 = new Fraction(numerator);
        Fraction _fraction3 = new Fraction(numerator, denominator);

        Fraction _numeratorFraction = new Fraction();
        _numeratorFraction.SetNumerator(3);
        _numeratorFraction.SetDenominator(4);

        Console.WriteLine($"Fraction 1 (With preset numbers 1/1): {_fraction1.GetNumerator()}/{_fraction1.GetDenominator()}");
        Console.WriteLine($"Fraction 2 (With preset numbers 3/4 using get and set): {_numeratorFraction.GetNumerator()}/{_numeratorFraction.GetDenominator()}");
        Console.WriteLine($"Fraction 3 (Only used the numerator provided, denominator = 1): {_fraction2.GetNumerator()}/{_fraction2.GetDenominator()}");
        Console.WriteLine($"Fraction 4 (Proper): {_fraction3.GetNumerator()}/{_fraction3.GetDenominator()}");

        // Test to match the activitie's values:
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());
    }
}