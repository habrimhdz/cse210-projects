using System;

class Program
{
    static void Main(string[] args)
    {

        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int UserNumSquare = SquareNumber(userNumber);

        DisplayResult(userName, UserNumSquare);

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName()
        {
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();
            return userName;
        }

        static int PromptUserNumber()
        {
            Console.WriteLine("What is your favorite number?");
            int userNum = int.Parse(Console.ReadLine());
            return userNum;
        }

        static int SquareNumber(int userNum)
        {
            int userNumSquare = userNum * userNum;
            return userNumSquare;
        }

        static void DisplayResult(string userName, int userNumSquare)
        {
            Console.WriteLine($"Brother {userName}, the square of your number is {userNumSquare}");
        }
    }
}