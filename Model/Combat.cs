using Gladiator.Model.Gladiators;
using Gladiator.Utilities;
using System;
using System.Collections.Generic;
using static Gladiator.Model.Gladiators.BaseGladiator;

namespace Gladiator.Model
{

    public class Combat
    {
        public List<string> Log { get; private set; } = new List<string>();
        public BaseGladiator Attacker { get; private set; }
        public BaseGladiator Defender { get; private set; }

        private int _randomizer = Randomizer.Get(1);
        private int _damage;

        public Combat(BaseGladiator fighterA, BaseGladiator fighterB)
        {
            if (_randomizer > 0)
            {
                Attacker = fighterA;
                Defender = fighterB;
            }
            else
            {
                Attacker = fighterB;
                Defender = fighterA;
            }
        }
        public BaseGladiator Simulate()
        {
            if (Attacker is null)
            {
                return Defender;
            }
            else if (Defender is null)
            {
                return Attacker;
            }
            Fight();

            Log.Add(GetLog(CombatStatus.End));
            return Attacker;
        }

        private void Fight()
        {
            do
            {
                if (TargetMissed())
                {
                    Log.Add(GetLog(CombatStatus.Miss));
                    SwapFighters();
                    continue;
                }
                _damage = (int)(Attacker.SP * Randomizer.Get(1, 6) / 10);
                Log.Add(GetLog(CombatStatus.Hit));
                Defender.DecreaseHealthBy(_damage);
                SwapFighters();
            } while (!Defender.IsDead());
        }

        private void SwapFighters()
        {
            if (!Defender.IsDead())
            {
                var temp = Attacker;
                Attacker = Defender;
                Defender = temp;
            }
        }

        private bool TargetMissed()
        {
            int hitChance = Math.Clamp(Attacker.DEX - Defender.DEX, 10, 100);
            int deffenseTreshold = Randomizer.Get(10, 100);
            return hitChance < deffenseTreshold;
        }

        private string GetLog(CombatStatus status)
        {
            return status switch
            {
                CombatStatus.Miss => $"{Attacker.Name} missed",
                CombatStatus.Hit => $"{Attacker.Name} deals {_damage} damage",
                CombatStatus.End => $"{Defender.Name} has died, {Attacker.Name} wins!",
                _ => throw new ArgumentOutOfRangeException("Wrong combat status in Combat"),
            };
        }


    }
}