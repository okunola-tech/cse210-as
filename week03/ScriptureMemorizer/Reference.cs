using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse; // For ranges like 5-6

    // Constructor for single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    // Constructor for verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    // Constructor from string (parses "John 3:16" or "Proverbs 3:5-6")
    public Reference(string reference)
    {
        string[] parts = reference.Split(' ');
        _book = parts[0];
        string[] chapterVerse = parts[1].Split(':');
        _chapter = int.Parse(chapterVerse[0]);
        if (chapterVerse[1].Contains('-'))
        {
            string[] verses = chapterVerse[1].Split('-');
            _verse = int.Parse(verses[0]);
            _endVerse = int.Parse(verses[1]);
        }
        else
        {
            _verse = int.Parse(chapterVerse[1]);
            _endVerse = _verse;
        }
    }

    public string GetDisplayText()
    {
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}