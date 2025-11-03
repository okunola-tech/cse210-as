using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry e)
    {
        if (e != null) _entries.Add(e);
    }

    public IEnumerable<Entry> GetEntries() => _entries.AsReadOnly();

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        Console.WriteLine("---- Journal Entries ----");
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry.ToString());
        }
        Console.WriteLine("-------------------------");
    }

    // Save as text using the separator chosen in Entry.cs
    public void SaveToFile(string filename)
    {
        var lines = _entries.Select(e => e.ToFileLine()).ToArray();
        File.WriteAllLines(filename, lines);
    }

    // Load from file and replace current entries
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException($"File not found: {filename}");
        }

        var lines = File.ReadAllLines(filename);
        var loaded = new List<Entry>();
        foreach (var line in lines)
        {
            var e = Entry.FromFileLine(line);
            if (e != null) loaded.Add(e);
        }
        _entries = loaded;
    }

    // Extra: export to JSON (demonstrates an exceeded requirement)
    public void ExportToJson(string filename)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(filename, json, Encoding.UTF8);
    }

    // Replace entries completely
    public void ReplaceAll(IEnumerable<Entry> newEntries)
    {
        _entries = newEntries?.ToList() ?? new List<Entry>();
    }
}