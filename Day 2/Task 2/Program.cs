using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class WordFrequency
{
    public static Dictionary<string, int> CountWordFrequency(string input)
    {
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        string[] words = Regex.Split(input, @"\W+");
        
        foreach (string word in words)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {    
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word.ToLower()]++;
                }

                else
                {
                    wordFrequency[word.ToLower()] = 1;
                }
            }
        }

        return wordFrequency;
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter a string: ");
        string input = Console.ReadLine()!;

        Dictionary<string, int> wordFrequency = WordFrequency.CountWordFrequency(input);

        Console.WriteLine("Word Frequency\n");

        foreach (KeyValuePair<string, int> element in wordFrequency)
        {
            Console.WriteLine($"{element.Key}: {element.Value}");
        }
    }
}