using System;
using System.Text.RegularExpressions;

public class CheckPalindrome
{
    public static bool IsPalindrome(string input)
    {
        string word = Regex.Replace(input, @"\W+_", "").ToLower();
        int left = 0;
        int right = word.Length - 1;

        while (left < right)
        {
            if (word[left] != word[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }
}


public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter a string: ");
        string input = Console.ReadLine()!;

        bool isPalindrome = CheckPalindrome.IsPalindrome(input);

        if (isPalindrome)
        {
            Console.WriteLine($"{input} is a palindrome.");
        }

        else
        {
            Console.WriteLine($"{input} is not a palindrome.");
        }
    }
}