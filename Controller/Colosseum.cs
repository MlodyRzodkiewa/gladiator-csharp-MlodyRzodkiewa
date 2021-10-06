using Gladiator.Model.Gladiators;
using Gladiator.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiator.Controller
{
    class Colosseum
    {
        public BaseGladiator[] Contestants { get; private set; }
        public List<BaseGladiator[]> Pairs { get; private set; }

        private ConsoleView _view = new ConsoleView();

        public void SimulateCombat()
        {
            SplitGladiatorsIntoPairs(Contestants);
            var round = new Tournament(Pairs.ToArray());
            Contestants = round.Winners.ToArray();
            _view.Log = round.Log;
            _view.Display();
            if (Contestants.Length > 1)
            {
                SimulateCombat();
            }
            else
            {
                BaseGladiator winner = Contestants[0];
                _view.DisplayWinMessage(winner);
            }
        }

        public void GenerateGladiators(int amount)
        {
            var gladiators = new BaseGladiator[amount];
            for (var i = 0; i < amount; i++)
            {
                gladiators[i] = GladiatorFactory.GenerateRandomGladiator();
            }

            Contestants = gladiators;
        }
        private void SplitGladiatorsIntoPairs(BaseGladiator[] gladiators)
        {
            Pairs = new List<BaseGladiator[]>();
            for (var i = 0; i < gladiators.Length; i += 2)
            {
                var gladiator = gladiators[i];
                var nextGladiator = i + 1 < gladiators.Length ? gladiators[i + 1] : null;
                var pair = new BaseGladiator[] { gladiator, nextGladiator };
                Pairs.Add(pair);
            }
        }
    }
}
