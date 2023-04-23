using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Define the directory containing the text files to be searched.
        string directoryPath = @"E:\mohaymen\practice C#\P1\FullTextSearch\Texts";

        // Define a dictionary to store the inverted index.
        Dictionary<string, List<string>> invertedIndex = new Dictionary<string, List<string>>();

        // Iterate over each text file in the directory and parse its contents.
        foreach (string filePath in Directory.GetFiles(directoryPath))
        {
            // Read the contents of the text file.
            string fileContents = File.ReadAllText(filePath);

            // Split the file contents into individual words.
            string[] words = fileContents.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Iterate over each word and add it to the inverted index.
            foreach (string word in words)
            {
                if (!invertedIndex.ContainsKey(word))
                {
                    invertedIndex[word] = new List<string>();
                }

                invertedIndex[word].Add(filePath);
            }
        }

        // Prompt the user for a search term.
        Console.Write("Enter a search query: ");
        string[] searchQuery = Console.ReadLine().Split(' ');

        List<string> requireKey = new List<string>();
        List<string> optionalKey = new List<string>();
        List<string> noKey = new List<string>();

        foreach (string key in searchQuery)
        {
            if (key.StartsWith('+'))
            {
                optionalKey.Add(key.Substring(1));
            }
            else if (key.StartsWith('-'))
            {
                noKey.Add(key.Substring(1));
            }
            else
            {
                requireKey.Add(key);
            }
        }

        List<string> result = new List<string>();
        List<string> optionalResult = new List<string>();
        
        
        foreach (string key in optionalKey)
        {
            if (invertedIndex.ContainsKey(key))
            {
                foreach (string filePath in invertedIndex[key])
                {
                    optionalResult.Add(filePath);
                }
            }
        }
        
        foreach (string key in requireKey)
        {
            if (invertedIndex.ContainsKey(key))
            {
                foreach (string filePath in invertedIndex[key])
                {
                    result.Add(filePath);
                }
            }
        }
        
        if(optionalKey.Count > 0)
            result = result.Intersect(optionalResult).ToList();
        
        foreach (string key in noKey)
        {
            if (invertedIndex.ContainsKey(key))
            {
                foreach (string filePath in invertedIndex[key])
                {
                    if (result.Contains(filePath))
                    {
                        result.Remove(filePath);
                    }
                }
            }
        }

        Console.WriteLine(String.Join("\n", result));


    }
}