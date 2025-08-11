using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("John Doe", "Doing my best");
        Console.WriteLine(assignment1.getSummary());

        MathAssignment mathAssignment1 = new MathAssignment("Bingus", "Bingulus", "Section 5.2", "Problems 1-10");
        Console.WriteLine(mathAssignment1.getSummary());
        Console.WriteLine(mathAssignment1.GetHomeworkList());

        WritingAssignment writingAssignment1 = new WritingAssignment("Sun Tzu", "The Art of War", "Analysis of Strategy");
        Console.WriteLine(writingAssignment1.getSummary());
        Console.WriteLine(writingAssignment1.GetWritingInformation());
    }
}