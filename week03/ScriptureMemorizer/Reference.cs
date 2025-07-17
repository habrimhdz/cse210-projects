//Get display text book, chapter, and verse
// Use Getters and Setters or constructors

using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse1;
    private int _verse2;

    public Reference(string book, int chapter, int verse1)
    {
        _book = book;
        _chapter = chapter;
        _verse1 = verse1;
        _verse2 = verse1;

    }

    public Reference(string book, int chapter, int verse1, int verse2)
    {
        _book = book;
        _chapter = chapter;
        _verse1 = verse1;
        _verse2 = verse2;
    }



    public string GetReferenceText()
    {
        if (_verse1 == _verse2)
        {
            return $"{_book} {_chapter}:{_verse1}";
        }
        else if (_verse1 < _verse2)
        {
            return $"{_book} {_chapter}:{_verse1}-{_verse2}";
        }
        else
        {
            return "End verse cannot be less than starting verse.";
        }
    }
}



