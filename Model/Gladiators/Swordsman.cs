namespace Gladiator.Model.Gladiators
{
    public class Swordsman : BaseGladiator
    {
        public Swordsman(int hp, int sp, int dex, int level) :
            base(Multiplier.Medium, Multiplier.Medium, Multiplier.Medium, hp, sp, dex, level)
        {
        }
}