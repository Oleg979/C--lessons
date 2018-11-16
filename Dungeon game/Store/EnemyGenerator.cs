using Game.Characters;
using System;

namespace Game.Store
{
    class EnemyGenerator
    {
        private static readonly Random R = new Random();

        public static Character GetEnemy()
        {
            Tactic T = R.Next(0,2) == 0 ? new AgressiveTactic() : (Tactic)new NormalTactic();
            return new Character("Bandit", R.Next(1, 6))
                .EquipArmor(new Items.Armor("Iron Armor", 20, 15))
                .EquipWeapon(new Items.Weapon("Steel dagger", 10, 20))
                .AddToInventory(PotionGenerator.GetPotion())
                .SetTactic(T);
        }
    }
}
