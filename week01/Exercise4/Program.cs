using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when done.");
        int userNum = int.Parse(Console.ReadLine());

        while (userNum != 0)
        {
            numbers.Add(userNum);
            Console.WriteLine("Enter number:");
            userNum = int.Parse(Console.ReadLine());
        }

        int totalSum = 0;
        int maxNum = 0;
        int previousNum = numbers[0];
        foreach (int number in numbers)
        {
            totalSum = totalSum + number;


            if (number >= previousNum)
            {
                maxNum = number;
            }
            previousNum = number;
        }

        float avg = (float)totalSum / (numbers.Count);


        Console.WriteLine($"The sum is {totalSum}");
        Console.WriteLine($"The average is {avg.ToString("F2")}");
        Console.WriteLine($"The Largest number is {maxNum}");



    }
}