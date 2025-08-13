using System;

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

        string input = Console.ReadLine();

        while (input != "6")
        {
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
            else
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
        goal.RecordEvent();

        if (goal.IsComplete())
        {
            _score += int.Parse(goal.GetDetailsString().Split('\n')[2].Split(':')[1].Trim());
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
        else if (string.IsNullOrEmpty(Console.ReadLine()))
        {
            Console.WriteLine("Invaild file name.");
        }
        else
        {
            Console.WriteLine("Write the filename to save goals to:");
            string filename = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }

            }
            Console.WriteLine("Goals saved successfully.");
        }

    }

    public void LoadGoals()
    {
        Console.WriteLine("What's the filaname to load goals from?");
        string filename = Console.ReadLine();
        if (!File.Exists(filename))
        {
            Console.WriteLine("Invalid file name.");
            return;
        }
        else using (StreamReader reader = new StreamReader(filename))
            {
                _goals.Clear();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('\n');
                    string type = parts[0].Split(':')[1].Trim();
                    string shortName = parts[1].Split(':')[1].Trim();
                    string description = parts[2].Split(':')[1].Trim();
                    string points = parts[3].Split(':')[1].Trim();

                    if (type == "Simple Goal")
                    {
                        _goals.Add(new SimpleGoal(shortName, description, points));
                    }
                    else if (type == "Eternal Goal")
                    {
                        _goals.Add(new EternalGoal(shortName, description, points));
                    }
                    else if (type == "Checklist Goal")
                    {
                        int target = int.Parse(parts[4].Split(':')[1].Trim());
                        int bonus = int.Parse(parts[5].Split(':')[1].Trim());
                        _goals.Add(new ChecklistGoal(shortName, description, points, target, bonus));
                    }
                }
            }



    }

}