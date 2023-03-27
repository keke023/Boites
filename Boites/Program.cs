using System;

namespace Boites
{
    class Program
    {
        static void Main(string[] args)
        {
            Boite b = new();
            Console.WriteLine(b);
            Console.WriteLine(new Boite("yo"));
            string texte = @"Man! Hey!!!
ceci est un test
multiligne";
            string autTexte = "Ceci\nitou, genre";
            Boite b0 = new(texte);
            Boite b1 = new(autTexte);
            Console.WriteLine(b0);
            Console.WriteLine(b1);
            ComboVertical cv = new(b0, b1);
            Console.WriteLine(new Boite(cv));
            ComboHorizontal ch = new(b0, b1);
            Console.WriteLine(new Boite(ch));
            ComboVertical cvplus = new(new Boite(cv), new Boite(ch));
            Console.WriteLine(new Boite(cvplus));
            ComboHorizontal chplus = new(new Boite(cv), new Boite(ch));
            Console.WriteLine(new Boite(chplus));

        }
    }
}
