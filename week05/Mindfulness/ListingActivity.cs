using System;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity(string name, string description, int duration, int count, List<string> prompts)
        : base(name, description, duration)
    {
        _count = count;
        _prompts = prompts;
    }


    public void Run()
    {
        DisplayStartingMessage();
        ShowSpinner(5);
        Console.WriteLine("Get ready to list items according to the following prompt:");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"{prompt}");
        ShowCountDown(10);
        List<string> userList = GetListFromUser();
        Console.WriteLine($"You listed {userList.Count} items.");
        ShowCountDown(4);
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];
        return prompt;
    }

    public List<string> GetListFromUser()
    {
        List<string> userList = new List<string>();

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write($"Enter item:");
            string item = Console.ReadLine();
            userList.Add(item);
        }
        return userList;
    }
}