using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    class ComboHorizontal : IBoite
    {
        public IBoite Boite1 { get; private set; }
        public IBoite Boite2 { get; private set; }


        public int Hauteur { get; set; }
        public int Largeur { get; set; }
        public ComboHorizontal(IBoite boite1, IBoite boite2)
        {
            Boite1 = boite1.Cloner();
            Boite2 = boite2.Cloner();

            Hauteur = Boite1.Hauteur > Boite2.Hauteur ? Boite1.Hauteur : Boite2.Hauteur;
            Largeur = Boite1.Largeur + Boite2.Largeur + 1;

            




        }
        public ComboHorizontal(ComboHorizontal combo)
        {
            Boite1 = combo.Boite1.Cloner();
            Boite2 = combo.Boite2.Cloner();

            Hauteur = Boite1.Hauteur > Boite2.Hauteur ? Boite1.Hauteur : Boite2.Hauteur;
            Largeur = Boite1.Largeur + Boite2.Largeur + 1;



        }
        public IBoite Cloner()
        {
            return new ComboHorizontal(this);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new ÉnumComboHorizontal(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ÉnumComboHorizontal(this);
        }

        public class ÉnumComboHorizontal : IEnumerator<string>
        {

            public string CurrentBoite { get; set; }
            public int Index { get; set; }
            public bool boite1Vide = false;
            public bool boite2Vide = false;
            string stringVide = "";
            public ComboHorizontal Combo { get; set; }

            public IEnumerator<string> EnumBoite1 { get; set; }
            public IEnumerator<string> EnumBoite2 { get; set; }
            public string Current
            {
                get
                {

                    if (boite1Vide)
                    {
                        return stringVide.PadRight(Combo.Boite1.Largeur) + "|" + EnumBoite2.Current.PadRight(Combo.Boite2.Largeur);
                    }
                    
                    return EnumBoite1.Current.PadRight(Combo.Boite1.Largeur) + "|" + EnumBoite2.Current.PadRight(Combo.Boite2.Largeur);
                }

            }
            
            object IEnumerator.Current => Current;

            public ÉnumComboHorizontal(ComboHorizontal combo)
            {
                Combo = combo;
                EnumBoite1 = combo.Boite1.GetEnumerator();
                EnumBoite2 = combo.Boite2.GetEnumerator();

            }
            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                
                
                if (EnumBoite1.MoveNext())
                {
                    if (EnumBoite2.MoveNext())
                    {
                        return true;
                    }
                    else
                    {
                        boite2Vide = true;
                        return true;
                    }
                    
                }
                else
                {
                    if (EnumBoite2.MoveNext())
                    {
                        boite1Vide = true;
                        return true;
                    }

                    return false;
                    
                }

            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
