using Gladiator.Controller;

namespace Gladiator
{
    public static class Program
    {
        public static void Main()
        {
            var colo = new Colosseum();
            colo.GenerateGladiators(25);
            colo.SimulateCombat();

        }
    }
}