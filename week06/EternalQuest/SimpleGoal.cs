using System;

namespace EternalQuest
{
    class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points, bool isComplete = false)
            : base(name, description, points)
        {
            _isComplete = isComplete;
        }

        public override int RecordEvent()
        {
            if (_isComplete)
            {
                Console.WriteLine("This goal is already complete. No points awarded.");
                return 0;
            }

            _isComplete = true;
            Console.WriteLine($"You completed '{Name}' and earned {Points} points!");
            return Points;
        }

        public override bool IsComplete => _isComplete;

        public override string GetDetailsString()
        {
            string mark = _isComplete ? "[X]" : "[ ]";
            return $"{mark} {base.GetDetailsString()}";
        }

        public override string Serialize()
        {
            return $"SimpleGoal,{base.Serialize()},{_isComplete}";
        }
    }
}
