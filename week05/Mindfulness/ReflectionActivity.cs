using System;
using System.Diagnostics;

public class ReflectionActivity : Activity
{
    private RotatingQueue<string> prompts;
    private RotatingQueue<string> questions;
    private Random rng = new Random();

    public ReflectionActivity() : base(
        "Reflection Activity",
        "Think deeply about moments of strength. Let the questions guide meaningful reflection.")
    {
        prompts = new RotatingQueue<string>(new()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        }, rng);

        questions = new RotatingQueue<string>(new()
        {
            "Why was this meaningful?",
            "How did you get started?",
            "How did you feel afterward?",
            "What did you learn from it?",
            "Why was this experience unique?",
            "What is your favorite part of this memory?",
            "How does this strengthen you today?"
        }, rng);
    }

    public override void Run()
    {
        Start();
        int total = GetDuration();
        Stopwatch sw = Stopwatch.StartNew();

        string prompt = prompts.Next();
        Console.WriteLine($"\n--- Reflection Prompt ---");
        Console.WriteLine(prompt + "\n");

        while (sw.Elapsed.TotalSeconds < total)
        {
            string q = questions.Next();
            Console.WriteLine($"> {q}");

            int remaining = Math.Max(1, (int)(total - sw.Elapsed.TotalSeconds));
            int pause = Math.Min(5, remaining);
            ShowSpinner(pause);

            Console.WriteLine();
        }

        sw.Stop();
        End();
        LogSession($"prompt:{prompt}");
    }
}
