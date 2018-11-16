using System;

namespace Game.Characters
{
    abstract class Tactic
    {
        public Character Character { get; set; }
        public Tactic() {}
        public Tactic(Character c)
        {
            Character = c;
        }
        public abstract bool NextAction(Character enemy);

        protected void Attack(Character enemy)
        {
            Character.Attack(enemy);
            Console.WriteLine($"{Character.Name} deals {Character.Dmg} damage to {enemy.Name}{(enemy.Blocked ? $", but {enemy.Name} receives only {Character.Dmg / 2} damage because of block" : "")}");
        }
        protected void UltimateAttack(Character enemy)
        {
            Character.UltimateAttack(enemy);
            Console.WriteLine($"{Character.Name} deals {Character.Dmg * 2} damage to {enemy.Name}{(enemy.Blocked ? $", but {enemy.Name} receives only {Character.Dmg} damage because of block" : "")}");
        }
        protected void Block()
        {
            Character.Block();
            Console.WriteLine($"{Character.Name} blocked");
        }
    }
}
