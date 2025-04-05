// Write a C# program that:
// Takes an array of integers from the user (comma-separated input)
// Outputs the sum of even numbers and count of odd numbers

using System;
using System.Linq;

class Program
{
    static void Main (string [] args)
    {
        Console.WriteLine("Enter integers separated by commas: ");
        string input = Console.ReadLine();

        try
        {
            // split input by commas and convert to integers
            int[] numbers = input.Split(',')
                                 .Select(int.Parse)
                                 .ToArray();

            // calculate sum of even numbers
            int sumOfEvens = numbers.Where(n => n % 2 == 0).Sum();

            // count of odd numbers
            int countOfOdds = numbers.Count(n => n % 2 != 0);

            // output results
            Console.WriteLine($"Sum of even numbers: {sumOfEvens}");
            Console.WriteLine($"Count of odd numbers: {countOfOdds}");

        
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter integers separated by commas.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}