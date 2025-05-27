using System;

class Program
{
    public static void Main()
    {
        System.Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        System.Console.Write("Enter your age: ");
        string age = Console.ReadLine();

        System.Console.WriteLine($"Hello {name}, you are {age} years old.");
    }
}