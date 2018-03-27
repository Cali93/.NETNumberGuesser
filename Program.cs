// Importing other namespaces with other functions
using System;

// Container for classes and functions
namespace NumberGuesser
{
    // Main object
    class Program
    {
        // declaring methods and properties (funcs & vars)
        // Entry point method
        static void Main(string[] args)
        // Void is going to be the return type of the func (basicaly, no return value)
        // Static is refering to the functions itself (no instances)
        {
            GetAppInfo(); // Run GetAppInfo function
            GreetUser(); // Ask for user's name and greet
            TheGame();
        } // end main

        static void TheGame()
        {
            while (true)
            {
                // Init correct number
                //int correctNumber = 7;

                // Create a new random object
                Random random = new Random();

                int correctNumber = random.Next(1, 20);

                // Init guess var
                int guess = 0;
                int toast = 0;

                // Ask user for number
                Console.WriteLine("Guess a number between 1 and 20");

                // While guess is not correct
                while (guess != correctNumber)
                {
                    // Get users input
                    string input = Console.ReadLine();
                    // Make sure it's a number

                    if (!int.TryParse(input, out guess))
                    {
                        // Print error message
                        PrintColorMessage(ConsoleColor.Red, "Please use an actual number");

                        // Keep going
                        continue;
                    }
                    // Cast to int and put in guess
                    guess = Int32.Parse(input);

                    // Match guess to correct number
                    if (guess != correctNumber)
                    {
                        if (guess < correctNumber)
                        {
                            PrintColorMessage(ConsoleColor.Red, "It's more");
                            toast++;
                            PrintColorMessage(ConsoleColor.Yellow, (10 - toast) + " try left");
                        }
                        if (guess > correctNumber)
                        {
                            PrintColorMessage(ConsoleColor.Red, "It's less");
                            toast++;
                            PrintColorMessage(ConsoleColor.Yellow, (10-toast)+" try left");
                        }
                        if (toast >= 10)
                        {
                            PrintColorMessage(ConsoleColor.Red, "Game Over !");
                            EndOfTheGame();
                        }
                        // Print error message
                        // PrintColorMessage(ConsoleColor.Red, "Wrong number, please try again");
                    }
                }

                // Print success message
                PrintColorMessage(ConsoleColor.Green, "You guessed it ! Well played");
                EndOfTheGame();

            }
        }

        static void EndOfTheGame()
        {
            // Ask to play again
            Console.WriteLine("Play again ?[Y or N]");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                TheGame();
            }
            else if (answer == "N")
            {
                return;
            }
            else
            {
                return;
            }
        }

        // Get and display app info
        static void GetAppInfo()
        {
            // string name = "Cali Armut";
            //int age = 24;
            // START HERE //
            // Console.WriteLine("Hello " + name + "you are" + age);
            // Console.WriteLine("{0} is {1}", name, age);

            // SET APP VARS //
            string appName = "Number Guessser";
            string appVersion = "1.0.0";
            string appAuthor = "Cali Armut";

            // Change text color

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            // Console.BackgroundColor = ConsoleColor.Gray;

            // Write app Info
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);
            // Reset text color
            Console.ResetColor();
        }
        // Ask user's name and greet
        static void GreetUser()
        {
            // Prompting user for its name
            Console.WriteLine("Hi ! What's your name ?");
            // Get user input
            string inputName = Console.ReadLine();
            Console.WriteLine("Ok {0}, let's play a game...", inputName);

        }
        // Print color message
        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            // Console.BackgroundColor = ConsoleColor.Gray;

            // Tell user it's not a number
            Console.WriteLine(message);
            // Reset text color
            Console.ResetColor();
        }
    }
}
