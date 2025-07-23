using System;
class Program
{

    static void Main()
    {
        Challenge1.RunChallenge();
        Console.WriteLine("Thank you for using the program. Goodbye!");
    }
}

class Challenge1
{
    //Method to greet the user
    public static void GreetUser(string name)
    {
        Console.WriteLine($"Hello, {name}! Welcome to the program.");
    }

    //Method to Greet and ask for the user's name
    public static string AskForName()
    {
        Console.Write("Hello, What is your name? ");
        string name = Console.ReadLine();
        return name;
    }
    //Method to ask user for their age
    public static int AskForAge()
    {
        Console.Write("How old are you? ");
        string age = Console.ReadLine();
        int Age = int.Parse(age);
        return Age;
    }

    //Method to calculate how many years until the user turns 100
    public static int YearsUntil100(int age)
    {
        return 100 - age;
    }

    //Method to display the years until the user turns 100
    public static void DisplayYearsUntil100(int years)
    {
        Console.WriteLine($"You will turn 100 in {years} years.");
    }

    //Method to run the challenge
    public static void RunChallenge()
    {
        int attempts = 0;
        const int maxAttempts = 3;

        while (attempts < maxAttempts)
        {
            try
            {
                // Ask for user's name
                string name = Challenge1.AskForName();
                Challenge1.GreetUser(name);

                // Ask for user's age
                int age = Challenge1.AskForAge();

                // Calculate years until 100
                int yearsUntil100 = Challenge1.YearsUntil100(age);

                // Display the result
                Challenge1.DisplayYearsUntil100(yearsUntil100);

                break; // Exit loop if everything is successful
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                attempts++;
            }
        }
    }
}