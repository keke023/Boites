using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Boites
{
    class Boite : IEnumerable<string>, IBoite
    {
        IBoite Contenue { get; init; }
        public int Hauteur { get => Contenue.Hauteur; set => Contenue.Hauteur = value; }
        public int Largeur { get => Contenue.Largeur; set => Contenue.Largeur = value; }


        public Boite()
        {
            Contenue = new Mono("");
        }
        public Boite(string texte)
        {
            Contenue = new Mono(texte);
        }
        public Boite(IBoite boite)
        {
            Contenue = boite;
        }
        public Boite(Boite boite)
        {
            Contenue = boite.Contenue;
        }
        public IBoite Cloner()
        {
            return new Boite(this);
        }
        public IEnumerator<string> GetEnumerator()
        {
            return Contenue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Contenue.GetEnumerator();
        }
        public override string ToString()
        {
            string leStringDlaBoête = "";
            leStringDlaBoête += '+' + new string('-', Contenue.Largeur) + '+' + "\n";
            foreach (var ligne in Contenue)
            {

                leStringDlaBoête += $"|{ligne.PadRight(Contenue.Largeur)}|\n";

            }
            leStringDlaBoête += '+' + new string('-', Contenue.Largeur) + '+' + "\n";

            return leStringDlaBoête;
        }



    }
    
}
