using System;

namespace EternalQuest
{
    class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            Console.WriteLine($"Recorded '{Name}'. You earned {Points} points!");
            return Points;
        }

        public override string GetDetailsString()
        {
            return $"[~] {base.GetDetailsString()}";
        }

        public override string Serialize()
        {
            return $"EternalGoal,{base.Serialize()}";
        }
    }
}
