using System;

namespace EternalQuest
{
    class ChecklistGoal : Goal
    {
        private int _currentCount;
        private int _targetCount;
        private int _bonusOnComplete;

        public ChecklistGoal(string name, string description, int points,
                             int targetCount, int bonusOnComplete,
                             int currentCount = 0)
            : base(name, description, points)
        {
            _targetCount = Math.Max(1, targetCount);
            _bonusOnComplete = Math.Max(0, bonusOnComplete);
            _currentCount = Math.Max(0, currentCount);
        }

        public override int RecordEvent()
        {
            if (_currentCount >= _targetCount)
            {
                Console.WriteLine("This checklist goal is already complete. No points awarded.");
                return 0;
            }

            _currentCount++;
            int earned = Points;

            Console.WriteLine($"Progressed '{Name}' ({_currentCount}/{_targetCount}). You earned {Points} points.");

            if (_currentCount == _targetCount)
            {
                earned += _bonusOnComplete;
                Console.WriteLine($"Goal complete! Bonus {_bonusOnComplete} points awarded.");
            }

            return earned;
        }

        public override bool IsComplete => _currentCount >= _targetCount;

        public override string GetDetailsString()
        {
            string mark = IsComplete ? "[X]" : "[ ]";
            return $"{mark} {base.GetDetailsString()} -- Completed {_currentCount}/{_targetCount}";
        }

        public override string Serialize()
        {
            return $"ChecklistGoal,{base.Serialize()},{_currentCount},{_targetCount},{_bonusOnComplete}";
        }
    }
}
