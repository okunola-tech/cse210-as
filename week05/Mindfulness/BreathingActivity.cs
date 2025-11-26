using System;
using System.Diagnostics;

public class BreathingActivity : Activity
{
    private int inhaleSeconds = 4;
    private int exhaleSeconds = 6;

    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by guiding slow breathing. Focus on your breath.")
    { }

    public override void Run()
    {
        Start();
        int total = GetDuration();
        Stopwatch sw = Stopwatch.StartNew();
        bool inhale = true;

        while (sw.Elapsed.TotalSeconds < total)
        {
            int remaining = Math.Max(1, (int)(total - sw.Elapsed.TotalSeconds));
            int length = inhale ? inhaleSeconds : exhaleSeconds;
            length = Math.Min(length, remaining);

            Console.WriteLine();
            Console.Write(inhale ? "Breathe in... " : "Breathe out... ");
            Countdown(length);

            inhale = !inhale;
        }

        sw.Stop();
        End();
        LogSession();
    }
}
