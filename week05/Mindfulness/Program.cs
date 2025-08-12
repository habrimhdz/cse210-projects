// I added a way for ythe program to keep track of how many activities were completed and display that information when the user exits the program.

using System;
using System.Threading;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        string choice = "";
        int breathinglog = 0;
        int reflectinglog = 0;
        int listinglog = 0;

        while (choice != "4")
        {
            Console.Clear();

            Console.WriteLine("Please select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter the number of your choice: ");
            choice = Console.ReadLine();
            if (choice == "4")
            {
                if (breathinglog > 0)
                {
                    Console.WriteLine($"You completed {breathinglog} Breathing Activities.");
                }
                if (reflectinglog > 0)
                {
                    Console.WriteLine($"You completed {reflectinglog} Reflecting Activities.");
                }
                if (listinglog > 0)
                {
                    Console.WriteLine($"You completed {listinglog} Listing Activities.");
                }
                Console.WriteLine("Now exiting the Mindfulness Project. Goodbye! Thank you for coming. Take Care of Yourself!");
                Thread.Sleep(5000);
                return;
            }
            Console.WriteLine("How long, in seconds, would you like aproximately for your session to last? ");
            string lengthstr = Console.ReadLine();
            int length = int.Parse(lengthstr);


            if (choice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity("Breathing", "A simple breathing exercise to help you relax.", length);
                breathingActivity.Run();
                breathinglog++;

            }
            else if (choice == "2")
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting", "An activity to help you reflect on your experiences and emotions.", length, prompts: new List<string> { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." }, questions: new List<string> { "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?" });
                reflectingActivity.Run();
                reflectinglog++;
            }
            else if (choice == "3")
            {
                ListingActivity listingActivity = new ListingActivity("Listing", "An activity to help you list your thoughts and feelings.", length, count: 5, prompts: new List<string> { "Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?" });
                listingActivity.Run();
                listinglog++;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }

    }
}