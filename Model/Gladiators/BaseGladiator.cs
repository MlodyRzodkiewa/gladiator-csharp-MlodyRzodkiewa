using Gladiator.Utilities;
using System;

namespace Gladiator.Model.Gladiators
{
    public class BaseGladiator
    {
        public enum Multiplier
        {
            Low,
            Medium,
            High,
        }

        public string Name = _names[Randomizer.Get(_names.Length)];
        public string FullName => $"{GetType().Name} {Name}";
        public int Level { get; private set; }

        public int HP => (int)(_baseHP * HPMultiplier * Level);
        public int SP => (int)(_baseSP * SPMultiplier * Level);
        public int DEX => (int)(_baseDEX * DEXMultiplier * Level);
        private readonly int _baseHP;
        private readonly int _baseSP;
        private readonly int _baseDEX;
        protected double HPMultiplier { get; }
        protected double SPMultiplier { get; }
        protected double DEXMultiplier { get; }
        public int Health { get; private set; }

        private static string _namesPath = Environment.CurrentDirectory + @"\Names.txt";
        private static string[] _names = GetNames();

        protected BaseGladiator(Multiplier hpMult, Multiplier spMult, Multiplier dexMult, int hp, int sp, int dex, int lvl)
        {
            HPMultiplier = hpMult.GetMultiplier();
            SPMultiplier = spMult.GetMultiplier();
            DEXMultiplier = dexMult.GetMultiplier();
            _baseHP = hp;
            _baseSP = sp;
            _baseDEX = dex;
            Level = lvl;
            Health = HP;
        }



        private static string[] GetNames()
        {
            return System.IO.File.ReadAllLines(_namesPath);
        }

    }
}