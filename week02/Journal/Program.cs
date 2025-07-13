using System;
// Journal files are automatically stored in a folder named "JournalEntries" in the current directory. There's a test1 file there to test the program, of course.
class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        string choice = "";
        while (choice != "5")
        {
            Console.Clear();

            Console.WriteLine("Your Journal - What do you want to do today?");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                PromptGenerator promptGenerator = new PromptGenerator();
                promptGenerator.DisplayRandomPrompt();

                Entry newEntry = new Entry();
                string selectedPrompt = promptGenerator._prompts[new Random().Next(promptGenerator._prompts.Count)];
                newEntry.CreateFromPrompt(selectedPrompt);
                journal.AddEntry(newEntry);

            }
            else if (choice == "2")
            {
                Console.WriteLine("Displaying all current journal entries:");
                journal.DisplayAllEntries();
                Console.ReadKey();
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename to load your journal: ");
                string filename = Console.ReadLine();

                journal.LoadFromFile(filename);
                Console.WriteLine("Journal loaded from file.");

            }

            else if (choice == "4")
            {
                Console.Write("Enter the filename to save your journal: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
    }
}