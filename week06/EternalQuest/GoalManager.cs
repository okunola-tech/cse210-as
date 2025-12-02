using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class GoalManager
    {
        private List<Goal> _goals = new();
        private int _score = 0;

        public IReadOnlyList<Goal> Goals => _goals.AsReadOnly();
        public int Score => _score;

        public void AddGoal(Goal g)
        {
            if (g != null)
                _goals.Add(g);
        }

        public void RecordEvent(int index)
        {
            if (index < 0 || index >= _goals.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            int earned = _goals[index].RecordEvent();
            _score += earned;
        }

        public void ListGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals created.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void Save(string filename)
        {
            List<string> lines = new() { _score.ToString() };

            foreach (var g in _goals)
                lines.Add(g.Serialize());

            File.WriteAllLines(filename, lines);
            Console.WriteLine($"Saved to {filename}");
        }

        public void Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            _goals.Clear();
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                int commaIdx = line.IndexOf(',');

                string type = line.Substring(0, commaIdx);
                string data = line.Substring(commaIdx + 1);

                _goals.Add(Goal.Deserialize(type, data));
            }

            Console.WriteLine($"Loaded {_goals.Count} goals. Score: {_score}");
        }
    }
}
