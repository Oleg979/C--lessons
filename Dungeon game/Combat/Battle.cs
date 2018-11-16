using Game.Characters;
using System;

namespace Game.Combat
{
    class Battle
    {
        public Character Player { get; }
        public Character Enemy { get; }

        public Battle(Character p, Character e)
        {
            Player = p;
            Enemy = e;
        }

        private bool IsEnemyFirst() => new Random().Next(2) == 1;
        private void Line() => Console.WriteLine("\n***********************************************************\n");
        private void BattleInfo()
        {
            Line();
            Console.WriteLine($"You: {Player.MP} MP  {Player.HP}/{Player.MaxHP} HP              {Enemy.Name}: {Enemy.MP} MP  {Enemy.HP}/{Enemy.MaxHP} HP");
            Line();
        }

        public void Start()
        {
            Player.InitMP();
            Enemy.InitMP();

            Console.WriteLine($"Battle between {Player.Name} and {Enemy.Name} has begun!");

            bool turn = IsEnemyFirst();
            bool end = false;
            Console.WriteLine(turn ? $"{Enemy.Name} attacks first." : "Your turn first.");

            Console.WriteLine("\nPress to next...");
            Console.ReadKey();
            Console.Clear();

            BattleInfo();

            if (turn)
                while (!end)
                {
                    end = EnemyTurn();
                    if (end) break;
                    end = YourTurn();
                }
            else
                while (!end)
                {
                    end = YourTurn();
                    if (end) break;
                    end = EnemyTurn();
                };
            Console.WriteLine("Battle is over.");
            Console.ReadKey();
        }

        private bool EnemyTurn()
        {
            while (!Enemy.Tactic.NextAction(Player))
            {
                Console.WriteLine("\nPress to next...");
                Console.ReadKey();
                Console.Clear();
                BattleInfo();
            }
            if (EndTurn()) return true;

            Console.WriteLine("Enemy turn is over. Your turn...");
            Console.ReadKey();
            Console.Clear();
            Enemy.RefreshMP();
            BattleInfo();
            Player.Unblock();
            return false;
        }

        private bool YourTurn()
        {
            while(Player.MP > 0)
            {
                Console.WriteLine("\n1. Attack (2 MP)\n2. Ultimate attack (3 MP)\n3. Block (1 MP)");
                var i = 4;
                Player.Inventory.Potions.ForEach(p => Console.WriteLine($"{i++}. Use {p.ToString()}"));
                Console.Write("Enter the number of action: ");
                int res = int.Parse(Console.ReadLine());
                switch (res)
                {
                    case 1:
                        Player.Attack(Enemy);
                        break;
                    case 2:
                        Player.UltimateAttack(Enemy);
                        break;
                    case 3:
                        Player.Block();
                        break;
                    default:
                        if((res - 4) < Player.Inventory.Potions.Count)
                            Player.DrinkPotion(Player.Inventory.Potions[res - 4]);
                        else
                        {
                            Console.Clear();
                            BattleInfo();
                            return YourTurn();
                        }
                        break;
                }
                Console.Clear();
                BattleInfo();
            }
            Console.WriteLine("Your turn is over. Enemy turn...");
            Console.ReadKey();
            Console.Clear();
            Player.RefreshMP();
            BattleInfo();
            Enemy.Unblock();
            if (EndTurn()) return true;
            return false;
        }

        private bool EndTurn()
        {
            if (Player.HP <= 0)
            {
                Console.WriteLine("YOU ARE DEAD.");
                Console.ReadKey();
                Environment.Exit(0);
                return true;
            }
            else if (Enemy.HP <= 0)
            {
                Console.WriteLine($"{Enemy.Name.ToUpper()} IS DEAD.");
                Console.WriteLine("\nYour loot: ");
                Enemy.Inventory.Weapons.ForEach(w =>
                {
                    Console.WriteLine("* " + w.Name + " x 1");
                    Player.AddToInventory(w);
                });
                Enemy.Inventory.Armors.ForEach(w =>
                {
                    Console.WriteLine("* " + w.Name + " x 1");
                    Player.AddToInventory(w);
                });
                Enemy.Inventory.Potions.ForEach(w =>
                {
                    Console.WriteLine("* " + w.Name + " x 1");
                    Player.AddToInventory(w);
                });
                Console.WriteLine();
                return true;
            }
            return false;
        }
    }
}
