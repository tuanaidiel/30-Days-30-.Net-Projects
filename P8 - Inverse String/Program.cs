using System;

public class Program
{
    public static void Main (string[] args)
    {
        System.Console.WriteLine("Enter a string: ");
        string input = Console.ReadLine();

        string reversed = ReverseString(input);
        System.Console.WriteLine("Reversed string: " + reversed);
    }

    public static string ReverseString(string str)
    {
        char[] chars = str.ToCharArray();
        Array.Reverse(chars);
        return new string (chars);
    }
}