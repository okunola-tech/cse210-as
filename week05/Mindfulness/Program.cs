using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var activities = new Dictionary<int, Activity>
        {
            {1, new BreathingActivity()},
            {2, new ReflectionActivity()},
            {3, new ListingActivity()}
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program\n");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit\n");

            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            if (input == "4")
            {
                Console.WriteLine("Goodbye!");
                return;
            }

            if (int.TryParse(input, out int choice) && activities.ContainsKey(choice))
            {
                activities[choice].Run();
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid choice. Press Enter to continue.");
                Console.ReadLine();
            }
        }
    }
}
