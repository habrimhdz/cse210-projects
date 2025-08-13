using System;

public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, string points)
        : base(shortName, description, points)
    {
    }

    public override void RecordEvent()
    {
        //Nothing here since it's never completed.
    }
    public override bool IsComplete()
    {
        return false;
    }
    public override string GetStringRepresentation()
    {
        // Eternal goals do not change state, so we can return a simple representation.
        return $"{GetDetailsString()}\nStatus: Eternal (never complete)";
    }
}