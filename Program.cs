﻿using System;
using System.Collections.Generic;
using System.IO;

public class WordCounter
{
    public static List<string> ReadWordsFromFile(string filePath)
    {
        List<string> words = new List<string>();

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] lineWords = line.Split(' ')
            .Select(word => CleanWord(word))
            .ToArray();
            words.AddRange(lineWords);
        }

        return words;
    }

    private static string CleanWord(string word)
    {
        string cleanedWord = new string(word.Where(c => !char.IsPunctuation(c)).ToArray());

        string lowercaseWord = cleanedWord.ToLower();

        return lowercaseWord;
    }

    public static List<string> RemoveDuplicateWords(List<string> words)
    {
        HashSet<string> uniqueWords = new HashSet<string>(words);
        return new List<string>(uniqueWords);
    }

    public static Dictionary<string, int> CountWordFrequency(List<string> words)
    {
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>(); 
        foreach (string word in words)
        {
            if (wordFrequency.ContainsKey(word)) wordFrequency[word]++;
            else wordFrequency[word] = 1;
        }
        return wordFrequency;
    }

    public static void PrintSummary(List<string> wordsList, Dictionary<string, int> wordFrequency)
    {
        int totalWords = wordsList.Count;
        int uniqueWords = wordFrequency.Count;

        Console.WriteLine($"Total number of words in the document: {totalWords}");
        Console.WriteLine($"Number of unique words: {uniqueWords}");

        int maxFrequency = wordFrequency.Values.Max();
        List<string> mostFrequentWords = wordFrequency.Where(pair => pair.Value == maxFrequency)
                                                     .Select(pair => pair.Key)
                                                     .ToList();
        string mostFrequentWordsStr = string.Join(", ", mostFrequentWords);
        Console.WriteLine($"Most frequent word(s) with frequency {maxFrequency}: {mostFrequentWordsStr}");
    }

    public static void Main()
    {
        List<string> wordsList = ReadWordsFromFile("C:\\Users\\Zoran\\Desktop\\Dario_Internship\\#3_Words\\text.txt");

        List<string> uniqueWordsList = RemoveDuplicateWords(wordsList);

        Dictionary<string, int> wordFrequency = CountWordFrequency(wordsList);

        //foreach (KeyValuePair<string, int> pair in wordFrequency)
        //{
        //    Console.WriteLine($"{pair.Key}: {pair.Value}");
        //}
        PrintSummary(wordsList, wordFrequency);


    }
}
