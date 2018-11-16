using Game.Effects;
using Game.Items;
using System;

namespace Game.Characters
{
    class Character
    {
        public int HP { get; protected set; }
        public int MaxHP { get; private set; }

        public int MP { get; private set; }
        public int InitialMP { get; private set; }
        public bool Blocked { get; private set; }

        public string Name { get; }
        public int Dmg { get; private set; }
        public int Lvl { get; }

        public Tactic Tactic { get; private set; }

        public Inventory Inventory { get; }
        public Weapon Weapon { get; private set; }
        public Armor Armor { get; private set; }

        public Character(string n, int l)
        {
            Name = n;
            Lvl = l;
            Inventory = new Inventory(10 * Lvl);

            MaxHP = 20 * Lvl;
            HP = MaxHP;

            InitialMP = 2 * l;
            MP = InitialMP;

            Tactic = new NormalTactic(this);
        }

        public virtual void LvlUp()
        {
            Inventory.IncreaseSize(10);
            MaxHP += 20;
            InitialMP += 2;
        }

        public Character EquipWeapon(Weapon w)
        {
            if (Weapon != null) throw new ArgumentException();
            Weapon = w;
            Dmg += Weapon.Dmg;
            return this;
        }
        public Character RemoveWeapon()
        {
            Dmg -= Weapon.Dmg;
            Weapon = null;
            return this;
        }

        public Character EquipArmor(Armor a)
        {
            if (Armor != null) throw new ArgumentException();
            Armor = a;
            HP += Armor.Defense;
            MaxHP += Armor.Defense;
            return this;
        }
        public Character RemoveArmor()
        {
            HP -= Armor.Defense;
            MaxHP -= Armor.Defense;
            Armor = null;
            return this;
        }

        public Character AddToInventory(Item item) {
            if (item is Armor)
                Inventory.Add(item as Armor);
            else if (item is Weapon)
                Inventory.Add(item as Weapon);
            else if (item is Potion)
                Inventory.Add(item as Potion);
            return this;
        }
        public Character RemoveFromInventory(Item item) {
            if (item is Armor)
                Inventory.Remove(item as Armor);
            else if (item is Weapon)
                Inventory.Remove(item as Weapon);
            else if (item is Potion)
                Inventory.Remove(item as Potion);
            return this;
        }

        public Character SetTactic(Tactic t)
        {
            Tactic = t;
            t.Character = this;
            return this;
        }

        public void RefreshMP() => MP += 2;
        public void InitMP() => MP = InitialMP;

        public void ReceiveDamage(int dmg) => HP -= Blocked ? dmg / 2 : dmg;

        public void Attack(Character c)
        {
            c.ReceiveDamage(Dmg);
            MP -= 2;
        }
        public void UltimateAttack(Character c)
        {
            MP -= 3;
            c.ReceiveDamage(2 * Dmg);
        }
        public void Block()
        {
            MP -= 1;
            Blocked = true;
        }
        public void Unblock() => Blocked = false;

        private void ApplyEffect(Effect e)
        {
            if (e.Stat == Stat.HP) HP += e.Amount;
            else if (e.Stat == Stat.MP) MP += e.Amount;
        }
        public void DrinkPotion(Potion p)
        {
            p.Effects.ForEach(e => ApplyEffect(e));
            Inventory.Potions.Remove(p);
        } 

        public override string ToString() => $"Name: {Name}\nHP: {HP}/{MaxHP}\nLvl: {Lvl}\nArmor: {Armor}\nWeapon: {Weapon}";
    }
}
