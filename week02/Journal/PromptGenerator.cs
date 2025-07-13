using System;
public class PromptGenerator
{
    public List<string> _prompts = new List<string> {

        "What was the best part of your day?",
        "What did you learn today?",
        "What challenges did you face?",
        "What are you grateful for?",
        "What made you smile today?",
        "What is something you want to improve?",
        "Describe a moment that made you proud.",
        "Who inspired you today and why?",
        "What is something new you want to try?",
        "A spiritual moment you experienced today.",
        "A strong feeling you had today.",
        "How did you feel or show love today?"
    };

    private Random random = new Random();

    public void DisplayRandomPrompt()
    {
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];
        Console.WriteLine(prompt);
    }
}