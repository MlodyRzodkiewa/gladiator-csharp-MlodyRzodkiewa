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


        private static string[] GetNames()
        {
            return System.IO.File.ReadAllLines(_namesPath);
        }

    }
}