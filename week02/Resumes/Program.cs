using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "CEO";
        job1._companyName = "Carbiz";
        job1._startYear = 2024;
        job1._endYear = 2025;

        Job job2 = new Job();
        job2._jobTitle = "Software Engineer";
        job2._companyName = "Tech Solutions";
        job2._startYear = 2022;
        job2._endYear = 2025;

        job1.Display();
        job2.Display();

        Resume myResume = new Resume();
        myResume._name = "John Doe";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }

}