using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame1.Units
{
    internal class Rogue : IArmor, IBattleUnit, IHealth, IMagicUnit
    {
        public int Health { get ; set ; }
        public int MaxHealth { get; set; }
        public double MinDamage { get ; set ; }
        public double Damage { get; set; }
        public double MaxDamage { get; set; }
        public int LvlWeapon { get; set; }
        public double Protection { get; set; }
        public int LvlArmor { get; set; }
        public int Mana { get; set; }
        public void Attack(IHealth currentHealth)
        {
            throw new NotImplementedException();
        }

        public void ManaGenetate(int damage)
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int damage)
        {
            throw new NotImplementedException();
        }
    }
}
