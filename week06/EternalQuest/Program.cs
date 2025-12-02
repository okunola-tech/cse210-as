using System;

namespace EternalQuest
{
    class Program
    {
        static GoalManager manager = new();

        static void Main()
        {
            Console.WriteLine("Welcome to Eternal Quest!");

            bool exit = false;
            while (!exit)
            {
                ShowHeader();
                ShowMenu();

                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": CreateGoalMenu(); break;
                    case "2": manager.ListGoals(); break;
                    case "3": RecordEventMenu(); break;
                    case "4": Console.WriteLine($"Score: {manager.Score}"); break;
                    case "5":
                        Console.Write("Save file name: ");
                        manager.Save(Console.ReadLine());
                        break;
                    case "6":
                        Console.Write("Load file name: ");
                        manager.Load(Console.ReadLine());
                        break;
                    case "7": exit = true; break;
                    default: Console.WriteLine("Invalid choice."); break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            Console.WriteLine("Good luck on your Eternal Quest!");
        }

        static void ShowHeader()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("     Eternal Quest");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Score: {manager.Score}     Level: {CalculateLevel(manager.Score)}\n");
        }

        static void ShowMenu()
        {
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit\n");
        }

        static int CalculateLevel(int score) => 1 + (score / 1000);

        static void CreateGoalMenu()
        {
            Console.WriteLine("Select Goal Type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choice: ");

            string type = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Description: ");
            string desc = Console.ReadLine();

            int points = ReadInt("Points: ");

            switch (type)
            {
                case "1":
                    manager.AddGoal(new SimpleGoal(name, desc, points));
                    break;

                case "2":
                    manager.AddGoal(new EternalGoal(name, desc, points));
                    break;

                case "3":
                    int target = ReadInt("Target count: ");
                    int bonus = ReadInt("Bonus on completion: ");
                    manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                    break;

                default:
                    Console.WriteLine("Invalid type.");
                    break;
            }
        }

        static void RecordEventMenu()
        {
            manager.ListGoals();
            int index = ReadInt("Select goal number: ") - 1;
            manager.RecordEvent(index);
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;

                Console.WriteLine("Enter a valid integer.\n");
            }
        }
    }
}
