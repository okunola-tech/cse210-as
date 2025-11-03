using System;

public class Entry
{
    // Stored as strings per assignment simplification
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    // Extra optional metadata (creativity / extra feature)
    public string Mood { get; set; } = "";

    // Separator chosen to be unlikely to appear in text
    private const string SEP = "~|~";

    public Entry() { }

    public Entry(string date, string prompt, string response, string mood = "")
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    // Convert to a single-line representation for file save
    public string ToFileLine()
    {
        // We don't escape separator; chosen unlikely token per instructions
        return $"{Date}{SEP}{Prompt}{SEP}{Response}{SEP}{Mood}";
    }

    // Read from a saved line
    public static Entry FromFileLine(string line)
    {
        if (line == null) return null;
        var parts = line.Split(new string[] { SEP }, StringSplitOptions.None);
        // Expecting 4 parts; if fewer, pad with empty strings to remain robust
        while (parts.Length < 4)
        {
            Array.Resize(ref parts, parts.Length + 1);
            parts[parts.Length - 1] = "";
        }
        return new Entry(parts[0], parts[1], parts[2], parts[3]);
    }

    public override string ToString()
    {
        var moodText = string.IsNullOrWhiteSpace(Mood) ? "" : $" (Mood: {Mood})";
        return $"Date: {Date}{moodText}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}