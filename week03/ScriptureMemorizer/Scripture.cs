using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private List<int> _unhidIndices; // For stretch: track unhid words

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] wordStrings = text.Split(' ');
        foreach (string word in wordStrings)
        {
            _words.Add(new Word(word));
        }
        _unhidIndices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            _unhidIndices.Add(i);
        }
    }

    public string GetDisplayText()
    {
        string display = _reference.GetDisplayText() + "\n";
        foreach (Word word in _words)
        {
            display += word.GetDisplayText() + " ";
        }
        return display.Trim();
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        for (int i = 0; i < count && _unhidIndices.Count > 0; i++)
        {
            int index = rand.Next(_unhidIndices.Count);
            int wordIndex = _unhidIndices[index];
            _words[wordIndex].Hide();
            _unhidIndices.RemoveAt(index);
        }
    }

    public void RevealRandomWord()
    {
        if (_unhidIndices.Count < _words.Count)
        {
            Random rand = new Random();
            List<int> hidIndices = new List<int>();
            for (int i = 0; i < _words.Count; i++)
            {
                if (_words[i].IsHidden())
                {
                    hidIndices.Add(i);
                }
            }
            if (hidIndices.Count > 0)
            {
                int index = rand.Next(hidIndices.Count);
                int wordIndex = hidIndices[index];
                _words[wordIndex].Show();
                _unhidIndices.Add(wordIndex);
            }
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}