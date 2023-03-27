using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    interface IBoite : IEnumerable<string>
    {
         int Hauteur { get; set; }
         int Largeur { get; set; }

        public IBoite Cloner();
    }
}
