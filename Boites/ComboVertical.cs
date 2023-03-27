using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    class ComboVertical : IBoite
    {
        public IBoite Boite1 { get; private set;}
        public IBoite Boite2 { get; private set; }
        
        public int Hauteur { get; set; }
        public int Largeur { get; set; }

     

        public ComboVertical(IBoite boite1 , IBoite boite2)
        {
            Boite1 = boite1.Cloner();
            Boite2 = boite2.Cloner();

            Hauteur = Boite1.Hauteur + Boite2.Hauteur;
            Largeur = Boite1.Largeur > Boite2.Largeur ? Boite1.Largeur : Boite2.Largeur;

  

        }
        public ComboVertical(ComboVertical combo)
        {

            Boite1 = combo.Boite1.Cloner();
            Boite2 = combo.Boite2.Cloner();

            Hauteur = Boite1.Hauteur + Boite2.Hauteur;
            Largeur = Boite1.Largeur > Boite2.Largeur ? Boite1.Largeur : Boite2.Largeur;
           


        }
        public IBoite Cloner()
        {
            return new ComboVertical(Boite1, Boite2);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new ÉnumComboVertical(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ÉnumComboVertical(this);
        }
        public class ÉnumComboVertical : IEnumerator<string>
        {
            enum étape {Haut,Milieu,Bas}

            étape étapeCourante = étape.Haut;


            public ComboVertical Combo { get; set; }

            public IEnumerator<string> EnumBoite1 { get; set; }
            public IEnumerator<string> EnumBoite2 { get; set; }
            public string Current { 
                get
                {
                    switch (étapeCourante)
                    {
                        case étape.Haut:
                            return EnumBoite1.Current;
                        case étape.Milieu:
                            return new string('-', Combo.Largeur);
                        case étape.Bas:
                            return EnumBoite2.Current;
                        default:
                            break;
                            

                    }
                    return "thisisnotsupposedtohappen";
                    
                } 
            
            
            }

            object IEnumerator.Current => Current;

            public ÉnumComboVertical(ComboVertical combo)
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
                if(étapeCourante == étape.Haut)
                {
                    if (!EnumBoite1.MoveNext())
                    {
                        étapeCourante = étape.Milieu;
                    }
                    return true;
                }
                if (étapeCourante == étape.Milieu)
                {
                    étapeCourante = étape.Bas;
                    if (!EnumBoite2.MoveNext())
                    {
                        return false;
                    }
                    return true;
                }
                if(étapeCourante == étape.Bas)
                {
                    if (EnumBoite2.MoveNext())
                    {
                        return true;
                    }

                }
                    
                return false;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
