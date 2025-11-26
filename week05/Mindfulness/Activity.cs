using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _durationSeconds = 0;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---\n");
        Console.WriteLine(_description);
        Console.WriteLine();

        _durationSeconds = PromptForDuration();
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void End()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the activity: {_name}");
        Console.WriteLine($"Duration: {_durationSeconds} seconds");
        ShowSpinner(3);
    }

    protected int GetDuration() => _durationSeconds;

    protected int PromptForDuration()
    {
        while (true)
        {
            Console.Write("Enter duration in seconds: ");
            if (int.TryParse(Console.ReadLine(), out int t) && t > 0)
                return t;

            Console.WriteLine("Please enter a positive integer.");
        }
    }

    protected void ShowSpinner(int seconds)
    {
        char[] spin = { '|', '/', '-', '\\' };
        Stopwatch sw = Stopwatch.StartNew();
        int i = 0;

        while (sw.Elapsed.TotalSeconds < seconds)
        {
            Console.Write(spin[i % spin.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
            i++;
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public abstract void Run();

    protected void LogSession(string extra = "")
    {
        try
        {
            File.AppendAllLines("mindfulness_log.txt",
                new[] { $"{DateTime.Now}\t{_name}\t{_durationSeconds}s\t{extra}" });
        }
        catch { }
    }
}
