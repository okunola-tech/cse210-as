using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        bool playing = true;

        while (playing)
        {
            // Generate a random magic number between 1 and 100
            int magicNumber = randomGenerator.Next(1, 101);
            int guessCount = 0;
            bool guessed = false;

            Console.WriteLine("I've picked a magic number between 1 and 100. Try to guess it!");

            while (!guessed)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                int guess;

                // Validate input
                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Please enter a valid integer.");
                    continue;
                }

                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    guessed = true;
                }
            }

            // Inform the user of the number of guesses
            Console.WriteLine($"It took you {guessCount} guesses.");

            // Ask if they want to play again
            Console.Write("Do you want to play again? ");
            string response = Console.ReadLine().ToLower();

            if (response != "yes")
            {
                playing = false;
            }
        }

        Console.WriteLine("Thanks for playing!");
    }
}
