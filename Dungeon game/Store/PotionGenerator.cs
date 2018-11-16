using Game.Items;
using System;

namespace Game.Store
{
    class PotionGenerator
    {
        private static readonly Random R = new Random();

        public static Potion GetPotion()
        {
            int Amount = R.Next(2, 16);
            int Stat = R.Next(0, 2);
            return new Potion("Potion", 15, new Effects.Effect(Amount, Stat == 0 ? global::Stat.HP : global::Stat.MP));    
        }
    }
}
