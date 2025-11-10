using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Creativity/Exceeding Requirements:
// - Loads scriptures from a file ("scriptures.txt") with format: "Reference|Text" (e.g., "John 3:16|For God so loved the world...").
// - Selects a random scripture from the library for variety.
// - Adds a "hint" command: User can type "hint" to reveal one random hidden word, helping with memorization challenges.
// - This exceeds core by providing a scripture library and interactive hints, making memorization more engaging.

class Program
{
    static void Main(string[] args)
    {
        // Load scriptures from file
        List<Scripture> scriptures = LoadScriptures("scriptures.txt");
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in file. Exiting.");
            return;
        }

        // Select random scripture
        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        // Main loop
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, type 'hint' to reveal a word, or 'quit' to exit:");

            string input = Console.ReadLine().ToLower();
            if (input == "quit")
            {
                break;
            }
            else if (input == "hint")
            {
                scripture.RevealRandomWord();
            }
            else
            {
                scripture.HideRandomWords(3); // Hide 3 words at a time
            }
        }

        // Final display
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("All words hidden. Program ended.");
    }

    static List<Scripture> LoadScriptures(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();
        if (File.Exists(filename))
        {
            foreach (string line in File.ReadLines(filename))
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    Reference reference = new Reference(parts[0]);
                    scriptures.Add(new Scripture(reference, parts[1]));
                }
            }
        }
        return scriptures;
    }
}