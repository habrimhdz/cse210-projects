using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, string points, int target, int bonus)
        : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {

        _amountCompleted++;

    }
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }
    public override string GetStringRepresentation()
    {
        return $"Goal Type: Checklist Goal\n{GetDetailsString()}\nStatus: {(_amountCompleted >= _target ? "Complete" : "Incomplete")}\nAmount Completed: {_amountCompleted}/{_target}\nBonus Points: {_bonus}\n";
    }

    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }

public int BonusPoints
{
    get { return _bonus; }
}

}