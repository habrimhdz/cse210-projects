using System;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private const string FolderPath = "JournalEntries";


    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAllEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }

        Console.WriteLine("Press any key to return to main menu.");
    }

    public void SaveToFile(string file)
    {
        Directory.CreateDirectory(FolderPath);

        string fullPath = Path.Combine(FolderPath, file);

        using (StreamWriter writer = new StreamWriter(fullPath))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }

        Console.WriteLine($"Journal saved to {fullPath}");

    }

    public void LoadFromFile(string file)
    {
        string fullPath = Path.Combine(FolderPath, file);

        if (File.Exists(fullPath))
        {
            _entries.Clear();

            using (StreamReader reader = new StreamReader(fullPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        Entry entry = new Entry
                        {
                            _date = parts[0],
                            _promptText = parts[1],
                            _entryText = parts[2]
                        };
                        _entries.Add(entry);
                    }
                }
            }
            Console.WriteLine($"Journal loaded from {fullPath}");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
