// Hide random words, get the display text as a string
//Also check if scripture is fully hidden

using System;

public class Scripture
{
    private string _scripture;
    private List<Word> _words;

    Reference _reference = new Reference("Mosiah", 4, 11, 12);

    public Scripture(Reference reference, string scripture)
    {
        _reference = reference;
        _scripture = scripture;
        _words = _scripture.Split(' ')
                    .Select(w => new Word(w))
                    .ToList();
    }
    public void HideRandomWords(int numToHide)
    {
        Random rand = new Random();
        int hidden = 0;

        while (hidden < numToHide)
        {
            int index = rand.Next(0, _words.Count);

            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hidden++;
            }
        }
    }

    public string GetDisplayText()
    {
        string displayText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetReferenceText()} {displayText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public int CountUnhiddenWords()
    {
        return _words.Count(w => !w.IsHidden());
    }




}


