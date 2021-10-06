namespace Gladiator.Model.Gladiators
{
    public class Archer : BaseGladiator
    {
        public Archer(int hp, int sp, int dex, int level) :
            base(Multiplier.Medium, Multiplier.Medium, Multiplier.High, hp, sp, dex, level)
        {

        }
    }
}