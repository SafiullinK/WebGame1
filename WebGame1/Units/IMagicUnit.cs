using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame1.Units
{
    internal interface IMagicUnit
    {
        int Mana { get; set; }
        void ManaGenetate (int damage);
    }
}
