using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame1.Units
{
    internal interface IArmor
    {
         double Protection { get; set; }
         int LvlArmor { get; set; }
    }
}
