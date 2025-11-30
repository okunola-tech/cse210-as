// -------------------------------------------------------------
// ADDITIONAL FEATURES BEYOND CORE REQUIREMENTS
// -------------------------------------------------------------
//
// To go beyond the basic requirements of the Mindfulness Program,
// I added the following enhancements:
//
// 1. Organized Activity Selection Using a Dictionary
//    - Instead of using multiple if/else or switch statements,
//      the program stores all activities in a Dictionary<int, Activity>.
//      This makes the menu system cleaner, more scalable, and easier
//      to maintain if new activities are added.
//
// 2. Improved Program Structure with Multiple Activity Classes
//    - Each activity is fully separated into its own class file,
//      making the project more modular and easier to extend.
//      This also demonstrates proper use of inheritance.
//
// 3. Enhanced User Experience
//    - Added input validation, cleaner menu navigation, and
//      consistent UI formatting to make the program feel more polished.
//    - Pausing, countdowns, and animations were improved within
//      the activity classes to provide a smoother mindfulness flow.
//
// These additions help improve code readability, user experience,
// and overall program maintainability, going beyond the minimum
// assignment requirements.
// -------------------------------------------------------------

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

