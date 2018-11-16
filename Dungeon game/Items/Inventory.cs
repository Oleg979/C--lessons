using System;
using System.Collections.Generic;

namespace Game.Items
{
    class Inventory
    {
        public List<Armor> Armors { get; }
        public List<Weapon> Weapons { get; }
        public List<Potion> Potions { get; }

        public int MaxSize { get; private set; }

        public Inventory(int max)
        {
            MaxSize = max;
            Armors = new List<Armor>();
            Weapons = new List<Weapon>();
            Potions = new List<Potion>();
        }

        public Inventory Add(Weapon w)
        {
            if(Weapons.Count >= MaxSize) throw new ArgumentOutOfRangeException();
            Weapons.Add(w);
            return this;
        }

        public Inventory Add(Armor w)
        {
            if (Armors.Count >= MaxSize) throw new ArgumentOutOfRangeException();
            Armors.Add(w);
            return this;
        }

        public Inventory Add(Potion w)
        {
            if (Potions.Count >= MaxSize) throw new ArgumentOutOfRangeException();
            Potions.Add(w);
            return this;
        }

        public Inventory Remove(Weapon w)
        {
            if (Weapons.Contains(w)) Weapons.Remove(w);
            return this;
        }

        public Inventory Remove(Armor w)
        {
            if (Armors.Contains(w)) Armors.Remove(w);
            return this;
        }

        public Inventory Remove(Potion w)
        {
            if (Potions.Contains(w)) Potions.Remove(w);
            return this;
        }

        public void IncreaseSize(int s) => MaxSize += s;
    }
}
