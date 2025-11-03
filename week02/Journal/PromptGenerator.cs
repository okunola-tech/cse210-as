using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;
    private Random _rng;

    public PromptGenerator()
    {
        _rng = new Random();
        _prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What surprised me today?",
            // Additional custom prompts
            "What am I grateful for today?",
            "One small win I had today was..."
        };
    }

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0) return "Write something about your day.";
        int idx = _rng.Next(_prompts.Count);
        return _prompts[idx];
    }

    // Optional: allow other parts of program to add prompts
    public void AddPrompt(string prompt)
    {
        if (!string.IsNullOrWhiteSpace(prompt))
            _prompts.Add(prompt);
    }

    public IEnumerable<string> GetAllPrompts() => _prompts.AsReadOnly();
}