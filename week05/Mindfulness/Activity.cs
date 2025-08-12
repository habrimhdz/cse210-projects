using System;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }


    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} activity!");
        Console.WriteLine(_description);
        Console.WriteLine($"This activity will last for aproximately {_duration} seconds. (As close to that as possible without disrupting the flow.)");
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(2);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Well done! You have completed around {_duration} seconds of the {_name} activity.");
        Console.WriteLine("You did great, be proud of yourself!");
        Thread.Sleep(5000);
    }

    public void ShowSpinner(int seconds)
    {
        char[] frames = { '|', '/', '-', '\\' };
        DateTime end = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < end)
        {
            foreach (char frame in frames)
            {
                if (DateTime.Now >= end) break;
                Console.Write(frame);
                Thread.Sleep(500);
                Console.Write("\b \b");
            }
        }


    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"{i}...");
            Thread.Sleep(1000);
        }

    }

}