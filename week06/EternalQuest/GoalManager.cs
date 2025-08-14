using System;

using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string input = "";
        while (input != "6")
        {
            Console.WriteLine("Welcome to Eternal Quest!");
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.WriteLine("Select a menu option (1-6):");

            input = Console.ReadLine();

            if (input == "1")
            {
                CreateGoal();
            }
            else if (input == "2")
            {
                ListGoalDetails();
            }
            else if (input == "3")
            {
                SaveGoals();
            }
            else if (input == "4")
            {
                LoadGoals();
            }
            else if (input == "5")
            {
                RecordEvent();
            }
            else if (input != "6")
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score} ");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Available Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Goal Details:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetStringRepresentation());
            Console.WriteLine();
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose the type of goal to create:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        int choice = int.Parse(Console.ReadLine());
        Console.Write("Write your goal: ");
        string shortName = Console.ReadLine();
        Console.Write("Enter a description: ");
        string description = Console.ReadLine();
        Console.Write("How many points should you get for completing it: ");
        string points = Console.ReadLine();

        Goal newGoal;

        if (choice == 1)
        {
            newGoal = new SimpleGoal(shortName, description, points);
        }
        else if (choice == 2)
        {
            newGoal = new EternalGoal(shortName, description, points);
        }
        else if (choice == 3)
        {
            Console.Write("Enter how many times this needs to be done: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("How many points should you get if fully completed: ");
            int bonus = int.Parse(Console.ReadLine());
            newGoal = new ChecklistGoal(shortName, description, points, target, bonus);
        }
        else
        {
            throw new InvalidOperationException("Invalid choice.");
        }

        _goals.Add(newGoal);
    }

    
    public void RecordEvent()
{
    Console.WriteLine("Select a goal to record an event:");
    ListGoalNames();
    int choice = int.Parse(Console.ReadLine()) - 1;

    if (choice < 0 || choice >= _goals.Count)
    {
        Console.WriteLine("Invalid choice.");
        return;
    }

    var goal = _goals[choice];


    bool wasComplete = goal.IsComplete();

    goal.RecordEvent();


    bool nowComplete = goal.IsComplete();

    int basePoints = int.Parse(goal.GetDetailsString().Split('\n')[2].Split(':')[1].Trim());
    int bonusPoints = 0;

    
    if (goal is ChecklistGoal checklist && nowComplete && !wasComplete)
    {
        bonusPoints = checklist.BonusPoints; 
    }

    if (!wasComplete)
    {
        _score += basePoints + bonusPoints;
    }

    if (nowComplete)
    {
        Console.WriteLine($"Goal '{goal.GetDetailsString()}' completed! Score updated to {_score}.");
    }
    else
    {
        Console.WriteLine($"Goal '{goal.GetDetailsString()}' recorded. Current status: Incomplete.");
    }
}


    public void SaveGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to save.");
            return;
        }
        Console.WriteLine("Write the filename to save goals to:");
        string filename = Console.ReadLine();
        if (string.IsNullOrEmpty(filename))
        {
            Console.WriteLine("Invalid file name.");
            return;
        }
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
                writer.WriteLine();
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.WriteLine("What's the filename to load goals from?");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("Invalid file name.");
            return;
        }

        _goals.Clear(); 

        string[] lines = File.ReadAllLines(filename);
        List<string> currentGoalLines = new List<string>();

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                if (currentGoalLines.Count > 0)
                {
                    
                    Goal goal = CreateGoalFromLines(currentGoalLines);
                    if (goal != null)
                    {
                        _goals.Add(goal);
                    }
                    currentGoalLines.Clear();
                }
            }
            else
            {
                currentGoalLines.Add(line);
            }
        }

        
        if (currentGoalLines.Count > 0)
        {
            Goal goal = CreateGoalFromLines(currentGoalLines);
            if (goal != null)
            {
                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    
    public Goal CreateGoalFromLines(List<string> lines)
    {
        string type = "";
        string goalName = "";
        string description = "";
        string points = "0";
        int amountCompleted = 0;
        int target = 0;
        int bonus = 0;
        bool isComplete = false;

        foreach (string l in lines)
        {
            string[] parts = l.Split(':', 2); 
            if (parts.Length < 2) continue;

            string key = parts[0].Trim();
            string value = parts[1].Trim();

            switch (key)
            {
                case "Goal Type": type = value; break;
                case "Goal": goalName = value; break;
                case "Description": description = value; break;
                case "Points": points = value; break;
                case "Status":
                    if (value == "Complete") isComplete = true;
                    break;
                case "Amount Completed":
                    string[] split = value.Split('/');
                    if (split.Length == 2)
                    {
                        amountCompleted = int.Parse(split[0]);
                        target = int.Parse(split[1]);
                    }
                    break;
                case "Bonus Points": bonus = int.Parse(value); break;
            }
        }

        if (type == "Simple Goal")
        {
            SimpleGoal g = new SimpleGoal(goalName, description, points);
            if (isComplete)
            {
                g.RecordEvent();
            }
            return g;
        }
        else if (type == "Eternal Goal")
        {
            return new EternalGoal(goalName, description, points);
        }
        else if (type == "Checklist Goal")
        {
            ChecklistGoal g = new ChecklistGoal(goalName, description, points, target, bonus);
            g.SetAmountCompleted(amountCompleted); 
            return g;
        }

        return null; 
    }
}
