using System;

public class Program
{
    public static void Main (string[] args)
    {
        System.Console.WriteLine("Enter a string: ");
        string input = Console.ReadLine();

        bool isPalindrome = IsPalindrome(input);

        if (isPalindrome)
        {
            System.Console.WriteLine("palindrome");
        }
        else
        {
            System.Console.WriteLine("not palindrome");
        }
    }

    public static bool IsPalindrome(string str)
    {
        string cleaned = str.ToLower().Replace(" ", "");

        int left = 0;
        int right = cleaned.Length - 1;

        while (left < right)
        {
            if (cleaned[left] != cleaned[right])
            {
                return false;
            }
            left++;
            right--;
        }

        return true;
    }
}