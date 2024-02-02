using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WebGame1.Units
{
    internal interface IHealth
    {
        int Health { get; set; }
        int MaxHealth { get; set; }
        void TakeDamage (int damage);
    }
}

