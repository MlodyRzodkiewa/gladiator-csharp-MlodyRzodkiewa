using Gladiator.Model.Gladiators;
using System;
using System.Collections.Generic;

namespace Gladiator.View
{
    public class ConsoleView
    {
        public List<string> Log { get; set; }

        public void Display()
        {
            foreach (string line in Log)
            {
                Console.WriteLine(line);
            }
        }

        public void DisplayWinMessage(BaseGladiator winner)
        {
            Console.WriteLine($"{winner.Name} wins!!!");
        }

        public int GetNumberBetween()
        {
            throw new NotImplementedException();
        }
    }
}