// Hide random words, get the display text as a string
//Also check if scripture is fully hidden

using System;

public class Scripture
{
    private string _scripture = "Y otra vez os digo, según dije antes, que así como habéis llegado al conocimiento de la gloria de Dios, o si habéis sabido de su bondad, y probado su amor, y habéis recibido la remisión de vuestros pecados, lo que ocasiona tan inmenso gozo en vuestras almas, así quisiera que recordaseis y retuvieseis siempre en vuestra memoria la grandeza de Dios, y vuestra propia nulidad, y su bondad y longanimidad para con vosotros, indignas criaturas, y os humillaseis aun en las profundidades de la humildad, invocando el nombre del Señor diariamente, y permaneciendo firmes en la fe de lo que está por venir, que fue anunciado por boca del ángel. \nY he aquí, os digo que si hacéis esto, siempre os regocijaréis, y seréis llenos del amor de Dios y siempre retendréis la remisión de vuestros pecados; y aumentaréis en el conocimiento de la gloria de aquel que os creó, o sea, en el conocimiento de lo que es justo y verdadero.";
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


