using System;
using System.Collections.Generic;
using System.Text;
using static Gladiator.Model.Gladiators.BaseGladiator;

namespace Gladiator.Utilities
{
    public static class MultiplierEnum
    {
        public static double GetMultiplier(this Multiplier multiplier) => multiplier switch
        {
            Multiplier.Low => 1,
            Multiplier.Medium => 1.25,
            Multiplier.High => 1.45,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}
