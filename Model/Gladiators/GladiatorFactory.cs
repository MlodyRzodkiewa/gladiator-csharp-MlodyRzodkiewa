using Gladiator.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiator.Model.Gladiators
{
    class GladiatorFactory
    {
        public static BaseGladiator GenerateRandomGladiator()
        {
            var statMin = 25; // min expected hp/sp/dex
            var statMax = 101; // max expected hp/sp/dex
            int classSelector = Randomizer.Get(5); // Random class
            int hp = Randomizer.Get(statMin, statMax);
            int sp = Randomizer.Get(statMin, statMax);
            int dex = Randomizer.Get(statMin, statMax);
            int lvl = Randomizer.Get(6); // Random lvl

            return classSelector switch 
            {
                int cs when (cs < 2) => new Swordsman(hp, sp, dex, lvl),
                int cs when (cs == 2) => new Archer(hp, sp, dex, lvl),
                int cs when (cs == 3) => new Assassin(hp, sp, dex, lvl),
                int cs when (cs == 4) => new Brute(hp, sp, dex, lvl),
                _ => throw new ArgumentOutOfRangeException("Wrong random class selector in GladiatorFactory"),
            };
        }
    }
}
