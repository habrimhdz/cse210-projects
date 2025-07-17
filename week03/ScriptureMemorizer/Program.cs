using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("This is the ScriptureMemorizer Project.");
        Reference reference = new Reference("Mosiah", 4, 11, 12);
        Scripture scripture = new Scripture(reference, "Y otra vez os digo, según dije antes, que así como habéis llegado al conocimiento de la gloria de Dios, o si habéis sabido de su bondad, y probado su amor, y habéis recibido la remisión de vuestros pecados, lo que ocasiona tan inmenso gozo en vuestras almas, así quisiera que recordaseis y retuvieseis siempre en vuestra memoria la grandeza de Dios, y vuestra propia nulidad, y su bondad y longanimidad para con vosotros, indignas criaturas, y os humillaseis aun en las profundidades de la humildad, invocando el nombre del Señor diariamente, y permaneciendo firmes en la fe de lo que está por venir, que fue anunciado por boca del ángel. \nY he aquí, os digo que si hacéis esto, siempre os regocijaréis, y seréis llenos del amor de Dios y siempre retendréis la remisión de vuestros pecados; y aumentaréis en el conocimiento de la gloria de aquel que os creó, o sea, en el conocimiento de lo que es justo y verdadero.");

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to finish:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
            int remaining = scripture.CountUnhiddenWords();
            scripture.HideRandomWords(Math.Min(5, remaining));
        }



        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nFinished");



    }
}