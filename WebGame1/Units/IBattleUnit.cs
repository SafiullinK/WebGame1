using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame1.Units
{
    internal interface IBattleUnit
    {
         void Attack(IHealth currentHealth);
        double MinDamage { get; set; } 
        double Damage { get; set; }
           
         double MaxDamage { get; set; }
         int LvlWeapon { get; set; }
    }
}
