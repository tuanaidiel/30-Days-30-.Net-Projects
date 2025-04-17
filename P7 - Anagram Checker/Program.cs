//Given two strings s and t, return true if t is an anagram of s, and false otherwise.

//Example 1:
//Input: s = "anagram", t = "nagaram"
//Output: true

//Example 2:
//Input: s = "rat", t = "car"
//Output: false

using System;

public class Solution 
{
    public bool IsAnagram(string s, string t) 
    {
        if (s.Length != t.Length)
            return false;

        s = s.ToLower(); // Normalize case
        t = t.ToLower();

        int[] charCount = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            charCount[s[i] - 'a']++;
            charCount[t[i] - 'a']--;
        }

        foreach (int count in charCount)
        {
            if (count != 0)
                return false;
        }

        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new Solution();

        Console.WriteLine(sol.IsAnagram("anagram", "Nagaram")); // True
        Console.WriteLine(sol.IsAnagram("rat", "car")); // False
    }
}
