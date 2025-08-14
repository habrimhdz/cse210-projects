//I spent a ton of time making sure the loading and saving worked correctly, I added a feature so that once a goal is completed it stops awarding the user points! I left a test3 file in there for testing purposes if you want to try it.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}