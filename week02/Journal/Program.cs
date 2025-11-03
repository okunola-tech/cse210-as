using System;

class Program
{
    // NOTE: Creativity / exceeding requirements:
    // - I added a Mood field to each Entry to let the user optionally tag how they felt.
    // - I provided an Export to JSON feature to demonstrate an alternate storage format (can be opened by other tools).
    // - These steps are documented here per assignment instructions.
    //
    // To exceed further: you could extend PromptGenerator to download prompts from a web source,
    // or implement a real CSV writer that escapes commas and quotes.

    static void Main(string[] args)
    {
        var journal = new Journal();
        var promptGen = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file (replaces current)");
            Console.WriteLine("5. Export journal to JSON (extra)");
            Console.WriteLine("6. Add a custom prompt");
            Console.WriteLine("0. Quit");
            Console.Write("Choose an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    WriteNewEntry(journal, promptGen);
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    ExportJson(journal);
                    break;
                case "6":
                    AddCustomPrompt(promptGen);
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void WriteNewEntry(Journal journal, PromptGenerator promptGen)
    {
        string prompt = promptGen.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("Enter your response (single line). If you'd like multiple lines, type your text and then press Enter twice:");
        // Read potentially multi-line input: accumulate until an empty line is entered
        string response = ReadMultiLineInput();

        Console.Write("Optional - How would you describe your mood today? (press Enter to skip): ");
        string mood = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");
        var entry = new Entry(date, prompt, response, mood);
        journal.AddEntry(entry);
        Console.WriteLine("Entry saved to journal.");
    }

    // Read lines until an empty line is entered (or single-line if user presses enter once)
    static string ReadMultiLineInput()
    {
        var lines = new System.Collections.Generic.List<string>();
        while (true)
        {
            var line = Console.ReadLine();
            // If user pressed Enter on an empty line => stop (supports multi-line)
            if (string.IsNullOrEmpty(line))
            {
                // If no lines yet, that's fine—treat as empty response
                break;
            }
            lines.Add(line);
            // If only single-line desired, the user can just press Enter on empty next line to finish
        }
        return string.Join(Environment.NewLine, lines);
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save to (e.g., journal.txt): ");
        var filename = Console.ReadLine();
        try
        {
            journal.SaveToFile(filename);
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load from (this will replace current journal): ");
        var filename = Console.ReadLine();
        try
        {
            journal.LoadFromFile(filename);
            Console.WriteLine($"Journal loaded from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    static void ExportJson(Journal journal)
    {
        Console.Write("Enter filename to export JSON to (e.g., journal.json): ");
        var filename = Console.ReadLine();
        try
        {
            journal.ExportToJson(filename);
            Console.WriteLine($"Journal exported to JSON at {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error exporting JSON: {ex.Message}");
        }
    }

    static void AddCustomPrompt(PromptGenerator promptGen)
    {
        Console.Write("Enter a new prompt to add: ");
        var p = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(p))
        {
            promptGen.AddPrompt(p);
            Console.WriteLine("Prompt added.");
        }
        else
        {
            Console.WriteLine("No prompt entered.");
        }
    }
}