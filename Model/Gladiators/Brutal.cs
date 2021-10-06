namespace Gladiator.Model.Gladiators
{
    public class Brute : BaseGladiator
    {
        public Brute(int hp, int sp, int dex, int level) :
            base(Multiplier.High, Multiplier.High, Multiplier.Low, hp, sp, dex, level)
        {
        }
}