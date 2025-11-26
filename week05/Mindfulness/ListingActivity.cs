using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ListingActivity : Activity
{
    private RotatingQueue<string> prompts;
    private Random rng = new Random();

    public ListingActivity() : base(
        "Listing Activity",
        "List as many positive things as you can related to the given prompt.")
    {
        prompts = new RotatingQueue<string>(new()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt spiritual peace recently?",
            "Who are some of your heroes?"
        }, rng);
    }

    public override void Run()
    {
        Start();
        int total = GetDuration();
        string prompt = prompts.Next();

        Console.WriteLine($"\n--- Listing Prompt ---");
        Console.WriteLine(prompt + "\n");

        Console.Write("You may begin in: ");
        Countdown(5);
        Console.WriteLine();

        List<string> items = new();
        Stopwatch sw = Stopwatch.StartNew();

        while (sw.Elapsed.TotalSeconds < total)
        {
            int remaining = (int)(total - sw.Elapsed.TotalSeconds);
            if (remaining <= 0) break;

            if (Console.KeyAvailable)
            {
                string entry = Console.ReadLine().Trim();
                if (entry != "") items.Add(entry);
            }
            else
            {
                Thread.Sleep(200);
            }
        }

        sw.Stop();

        Console.WriteLine($"\nYou listed {items.Count} items!");
        End();
        LogSession($"items:{items.Count};prompt:{prompt}");
    }
}
