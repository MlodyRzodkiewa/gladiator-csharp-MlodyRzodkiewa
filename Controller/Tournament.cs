using Gladiator.Model;
using Gladiator.Model.Gladiators;
using System.Collections.Generic;

namespace Gladiator.Controller
{
    public class Tournament
    {
        public List<BaseGladiator> Winners { get; private set; }
        public List<string> Log { get; private set; } = new List<string>();
        public Tournament(params BaseGladiator[][] pairs)
        {
            Winners = new List<BaseGladiator>();
            foreach (BaseGladiator[] pair in pairs)
            {
                var duel = new Combat(pair[0], pair[1]);
                BaseGladiator winner = duel.Simulate();
                winner.HealUp();
                winner.LevelUp();
                Winners.Add(winner);
                UpdateLog(duel);
            }
        }

        private void UpdateLog(Combat duel)
        {
            if (duel.Attacker is null || duel.Defender is null)
            {
                return;
            }
            Log.Add($"Duel {duel.Attacker.Name} vs {duel.Defender.Name}:");
            Log.Add($"  - {duel.Attacker.FullName} ({duel.Attacker.HP} HP, {duel.Attacker.SP} SP, {duel.Attacker.DEX} DEX, {duel.Attacker.Level} LVL)");
            Log.Add($"  - {duel.Defender.FullName} ({duel.Defender.HP} HP, {duel.Defender.SP} SP, {duel.Defender.DEX} DEX, {duel.Defender.Level} LVL)");
            var i = 0;
            foreach (string line in duel.Log)
            {
                if (i < duel.Log.Count - 1)
                {
                    Log.Add("  - " + line);
                }
                else
                {
                    Log.Add(line);
                }
                i++;
            }
        }
    }
}