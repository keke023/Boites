using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    class Mono : IBoite
    {
        public List<string> Texte { get; set; }
       

        public int Largeur { get; set; }
        public int Hauteur { get; set; }
        public Mono(string texte)
        {
            Init_Liste_Texte(texte);
        }
        public Mono(Mono mono)
        {
            Texte = mono.Texte;
            Largeur = mono.Largeur;
            Hauteur = mono.Hauteur;
        }
        public void Init_Liste_Texte(string texte)
        {
            Texte = new List<string>();
            if(texte == "")
            {
                Largeur = 0;
                Hauteur = 0;
                
            }
            else
            {
                var tempLignes = texte.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                foreach (var lign in tempLignes)
                {
                    Texte.Add(lign);
                }
                Largeur = Texte.Max(r => r.Length);
                Hauteur = Texte.Count;
            }
            
            
        }
        public IEnumerator<string> GetEnumerator()
        {
            return new ÉnumMono(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ÉnumMono(this);
        }

        public IBoite Cloner() => new Mono(this);

        public class ÉnumMono : IEnumerator<string>
        {
            int index = -1;
            Mono Mono { get; set; }
            
            public ÉnumMono(Mono mono)
            {
                Mono = mono;
            }

            public string Current { get; set; }
            object IEnumerator.Current => Current;

            public void Dispose()
            {
               
            }

            public bool MoveNext()
            {
                if(index < Mono.Texte.Count - 1)
                {
                    index++;
                    Current = Mono.Texte[index];
                    return true;
                }
                else
                {
                    Current = "";
                }
                return false;
                
            }

            public void Reset()
            {
               
            }
        }
    }

}
