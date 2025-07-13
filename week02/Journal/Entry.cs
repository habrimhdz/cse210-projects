using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;


    public void CreateFromPrompt(string prompt)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _promptText = prompt;
        Console.WriteLine($"Prompt: {_promptText}");
        Console.Write("Your response: ");
        _entryText = Console.ReadLine();
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine();
    }
}