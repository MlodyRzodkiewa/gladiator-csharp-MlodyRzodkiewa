using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiator.Utilities
{
    class Randomizer
    {
        private static readonly Random _random = new Random();

        public static int Get(int ceiling)
        {
            return _random.Next(ceiling);
        }
        public static int Get(int floor, int ceiling)
        {
            return _random.Next(floor, ceiling);
        }

    }
}
