using System;

class Program
{
    static void Main(string[] args)
    {
        string response = "yes";
        while (response == "yes")
        {
            Random randomNumber = new Random();
            int number = randomNumber.Next(1, 100);
            Console.WriteLine($"Magic Number: {number}");

            Console.WriteLine("Guess the Magic Number (1-100): ");
            string userNumber = Console.ReadLine();
            int userGuess = int.Parse(userNumber);
            int attempts = 1;

            while (userGuess != number)
            {
                attempts++;
                if (userGuess > number)
                {
                    Console.WriteLine("Try Lower: ");
                    userNumber = Console.ReadLine();
                    userGuess = int.Parse(userNumber);
                }
                else if (userGuess < number)
                {
                    Console.WriteLine("Try Higher: ");
                    userNumber = Console.ReadLine();
                    userGuess = int.Parse(userNumber);
                }

            }
            Console.WriteLine($"That's correct! You guessed the Magic Number {number} in {attempts} tries!");
            Console.WriteLine("Do you want to play again? (type yes, otherwise the game will end) ");
            response = Console.ReadLine();
        }







    }
}