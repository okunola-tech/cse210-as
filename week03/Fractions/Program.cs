using System;

class Program
{
    static void Main(string[] args)
    {
        // Create fractions using all three constructors
        Fraction f1 = new Fraction();  // 1/1
        Fraction f2 = new Fraction(5); // 5/1
        Fraction f3 = new Fraction(3, 4); // 3/4
        Fraction f4 = new Fraction(1, 3); // 1/3

        // Demonstrate getters and setters
        Console.WriteLine("Original values:");
        Console.WriteLine($"f1: Numerator={f1.GetNumerator()}, Denominator={f1.GetDenominator()}");
        Console.WriteLine($"f2: Numerator={f2.GetNumerator()}, Denominator={f2.GetDenominator()}");

        // Change values using setters
        f1.SetNumerator(2);
        f1.SetDenominator(5);
        f2.SetNumerator(7);
        f2.SetDenominator(2);

        Console.WriteLine("\nAfter using setters:");
        Console.WriteLine($"f1: Numerator={f1.GetNumerator()}, Denominator={f1.GetDenominator()}");
        Console.WriteLine($"f2: Numerator={f2.GetNumerator()}, Denominator={f2.GetDenominator()}");

        // Demonstrate representation methods
        Console.WriteLine("\nFraction representations:");
        Console.WriteLine($"{f1.GetFractionString()} {f1.GetDecimalValue()}");
        Console.WriteLine($"{f2.GetFractionString()} {f2.GetDecimalValue()}");
        Console.WriteLine($"{f3.GetFractionString()} {f3.GetDecimalValue()}");
        Console.WriteLine($"{f4.GetFractionString()} {f4.GetDecimalValue()}");
    }
}
