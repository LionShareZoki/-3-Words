using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class WordCounter
{
    public static void ProcessFile(string filePath)
    {
        List<string> words = new List<string>();
        HashSet<string> uniqueWords = new HashSet<string>();
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
        int maxFrequency = 0;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] lineWords = line.Split(' ');

                foreach (string word in lineWords)
                {
                    string cleanedWord = CleanWord(word);

                    if (!string.IsNullOrWhiteSpace(cleanedWord))
                    {
                        words.Add(cleanedWord);

                        if (uniqueWords.Add(cleanedWord))
                            wordFrequency[cleanedWord] = 1;
                        else
                            wordFrequency[cleanedWord]++;

                        if (wordFrequency[cleanedWord] > maxFrequency)
                            maxFrequency = wordFrequency[cleanedWord];
                    }
                }
            }
        }

        int totalWords = words.Count;
        int uniqueWordCount = uniqueWords.Count;
        List<string> mostFrequentWords = GetMostFrequentWords(wordFrequency, maxFrequency);

        PrintSummary(totalWords, uniqueWordCount, maxFrequency, mostFrequentWords);
    }

    private static string CleanWord(string word)
    {
        string cleanedWord = new string(word.Where(c => !char.IsPunctuation(c)).ToArray());
        return cleanedWord.ToLower();
    }

    private static List<string> GetMostFrequentWords(Dictionary<string, int> wordFrequency, int maxFrequency)
    {
        List<string> mostFrequentWords = new List<string>();
        foreach (KeyValuePair<string, int> pair in wordFrequency)
        {
            if (pair.Value == maxFrequency)
                mostFrequentWords.Add(pair.Key);
        }
        return mostFrequentWords;
    }

    public static void PrintSummary(int totalWords, int uniqueWordCount, int maxFrequency, List<string> mostFrequentWords)
    {
        Console.WriteLine($"Total number of words in the document: {totalWords}");
        Console.WriteLine($"Number of unique words: {uniqueWordCount}");
        Console.WriteLine($"Most frequent word(s) with frequency {maxFrequency}: {string.Join(", ", mostFrequentWords)}");
    }

    public static void Main()
    {
        string filePath = "C:\\Users\\Zoran\\Desktop\\Dario_Internship\\#3_Words\\text.txt";
        ProcessFile(filePath);
    }
}
