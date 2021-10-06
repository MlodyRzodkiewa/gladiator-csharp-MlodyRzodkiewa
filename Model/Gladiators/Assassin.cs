namespace Gladiator.Model.Gladiators
{
    public class Assassin : BaseGladiator
    {
        public Assassin(int hp, int sp, int dex, int level) :
            base(Multiplier.Low, Multiplier.High, Multiplier.High, hp, sp, dex, level)
        {
        }
    }
}