using System;

public class Fraction
{
    // Private attributes for encapsulation
    private int _numerator;
    private int _denominator;

    // Constructor with no parameters: initializes to 1/1
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Constructor with one parameter: initializes to numerator/1
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    // Constructor with two parameters: initializes to numerator/denominator
    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    // Getter for numerator
    public int GetNumerator()
    {
        return _numerator;
    }

    // Setter for numerator
    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
    }

    // Getter for denominator
    public int GetDenominator()
    {
        return _denominator;
    }

    // Setter for denominator
    public void SetDenominator(int denominator)
    {
        _denominator = denominator;
    }

    // Method to return the fraction as a string (e.g., "3/4")
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Method to return the decimal value (e.g., 0.75)
    public double GetDecimalValue()
    {
        // Note: In a real application, you'd want to handle division by zero (e.g., throw an exception or set a default).
        // For this activity, assuming denominator != 0 as per typical fraction usage.
        return (double)_numerator / _denominator;
    }
}
