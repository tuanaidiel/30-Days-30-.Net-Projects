using System;

class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Substract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public int Divide(int a, int b)
    {
        if (b == 0)
        {
            System.Console.WriteLine("Cannot divide by 0");
            return 0;
        }
        return a / b;
    }
}

class Program
{
    public static void Main()
    {
        Calculator calc = new Calculator();

        System.Console.WriteLine("Add: " + calc.Add(10, 5));
        System.Console.WriteLine("Substract: " + calc.Substract(10, 5));
        System.Console.WriteLine("Multiply: " + calc.Multiply(10, 5));
        System.Console.WriteLine("Divide: " + calc.Divide(10,5));
    }
}