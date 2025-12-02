using System;
using System.Collections.Generic;
using System.Linq;

namespace EternalQuest
{
    // Base abstract Goal class
    abstract class Goal
    {
        private string _name;
        private string _description;
        private int _points;

        public string Name => _name;
        public string Description => _description;
        public int Points => _points;

        protected Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
        }

        public abstract int RecordEvent();

        public virtual string GetDetailsString()
        {
            return $"{Name} ({Description})";
        }

        public virtual bool IsComplete => false;

        public virtual string Serialize()
        {
            return $"{Escape(Name)},{Escape(Description)},{Points}";
        }

        protected static string Escape(string s)
        {
            if (s == null) return "";
            return s.Replace("\\", "\\\\").Replace("\n", "\\n").Replace(",", "\\,");
        }

        protected static string Unescape(string s)
        {
            if (s == null) return "";
            return s.Replace("\\,", ",").Replace("\\n", "\n").Replace("\\\\", "\\");
        }

        public static Goal Deserialize(string type, string data)
        {
            var parts = SplitCsv(data).ToList();

            string name = Unescape(parts[0]);
            string description = Unescape(parts[1]);
            int points = int.Parse(parts[2]);

            return type switch
            {
                "SimpleGoal" =>
                    new SimpleGoal(name, description, points, bool.Parse(parts[3])),

                "EternalGoal" =>
                    new EternalGoal(name, description, points),

                "ChecklistGoal" =>
                    new ChecklistGoal(name, description, points,
                                      int.Parse(parts[4]),
                                      int.Parse(parts[5]),
                                      int.Parse(parts[3])),

                _ => throw new InvalidOperationException($"Unknown goal type: {type}")
            };
        }

        private static IEnumerable<string> SplitCsv(string s)
        {
            List<string> result = new();
            string current = "";
            bool escape = false;

            foreach (char c in s)
            {
                if (escape)
                {
                    current += c;
                    escape = false;
                }
                else if (c == '\\')
                {
                    escape = true;
                    current += c; 
                }
                else if (c == ',')
                {
                    result.Add(current);
                    current = "";
                }
                else
                {
                    current += c;
                }
            }

            result.Add(current);
            return result;
        }
    }
}
