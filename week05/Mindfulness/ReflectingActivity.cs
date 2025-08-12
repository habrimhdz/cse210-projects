using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity(string name, string description, int duration, List<string> prompts, List<string> questions) : base(name, description, duration)
    {
        _prompts = prompts;
        _questions = questions;
    }

    public void Run()
    {
        DisplayStartingMessage();
        ShowSpinner(5);
        DisplayPrompt();
        ShowCountDown(10);
        Console.WriteLine("Now, think about the following questions:");
        DisplayQuestions();
        ShowCountDown(5);
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Reflect on the following prompt:");
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine("Take a moment to think about it.");
    }

    public void DisplayQuestions()
    {
        DateTime end = DateTime.Now.AddSeconds(_duration);
        int i = 0;

        while (DateTime.Now < end && i < _questions.Count)
        {
            i++;
            Console.WriteLine($"Question {i}: {GetRandomQuestion()}");
            ShowSpinner(15);

        }


    }
}