using System;
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
            string[] lineWords = line.Split(' ');
            words.AddRange(lineWords);
        }

        return words;
    }

    public static List<string> RemoveDuplicateWords(List<string> words)
    {
        HashSet<string> uniqueWords = new HashSet<string>(words);
        return new List<string>(uniqueWords);
    }

    public static void Main()
    {
        List<string> wordsList = ReadWordsFromFile("C:\\Users\\Zoran\\Desktop\\Dario_Internship\\#3_Words\\text.txt");

        List<string> uniqueWordsList = RemoveDuplicateWords(wordsList);

        foreach (string word in uniqueWordsList)
        {
            Console.WriteLine(word);
        }


    }
}
