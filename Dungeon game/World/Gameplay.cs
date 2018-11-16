using Game.Characters;
using Game.Items;
using System;
using System.Collections.Generic;
using Game.Store;
using Game.Combat;

namespace Game.World
{
    class Gameplay
    {
        public char[,] Web { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        private int PlayerX;
        private int PlayerY;

        private List<Character> Enemies;
        private List<Potion> Potions;

        private readonly int NUM_OF_ENEMIES = 15;
        private readonly int NUM_OF_LOOT = 15;

        private readonly Character Player;

        public Gameplay()
        {
            Enemies = new List<Character>();
            Potions = new List<Potion>();
            Player = new Character("Player", 2)
                .EquipArmor(new Armor("Steel armor", 20, 10))
                .EquipWeapon(new Weapon("Rust sword", 15, 15));

            Height = 50;
            Width = 70;
            InitWeb();

            PlayerX = 0;
            PlayerY = 0;

            Web[PlayerX, PlayerY] = '0';

            InitEnemies();
            InitLoot();

            PrintWeb();

            Info();
            while (true)
            {
                WaitInput();
                Console.Clear();
                PrintWeb();
                Info();
            }
        }

        private void Info()
        {
            Console.WriteLine("Press arrow keys to move.");
            Console.WriteLine("0 - you");
            Console.WriteLine("# - enemies");
            Console.WriteLine("$ - loot");
        }

        private void WaitInput()
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.UpArrow && IsPossible(0))
            {
                MovePlayer(0);
            }
            else if (key == ConsoleKey.DownArrow && IsPossible(2))
            {
                MovePlayer(2);
            }
            else if (key == ConsoleKey.LeftArrow && IsPossible(3))
            {
                MovePlayer(3);
            }
            else if (key == ConsoleKey.RightArrow && IsPossible(1))
            {
                MovePlayer(1);
            }
        }
        private void InitWeb() => Web = new MapGenerator(Height, Width).GetWeb();
        private void PrintWeb()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                    Console.Write(Web[i, j]);
                Console.WriteLine();
            }
        }
        private bool IsPossible(int dir)
        {
            switch (dir)
            {
                case 0:
                    return PlayerX - 1 >= 0 && Web[PlayerX - 1, PlayerY] != ' ';
                case 1:
                    return PlayerY + 1 < Width && Web[PlayerX, PlayerY + 1] != ' ';
                case 2:
                    return PlayerX + 1 < Height && Web[PlayerX + 1, PlayerY] != ' ';
                case 3:
                    return PlayerY - 1 >= 0 && Web[PlayerX, PlayerY - 1] != ' ';
                default:
                    return false;
            }
        }
        private void MovePlayer(int dir)
        {
            Web[PlayerX, PlayerY] = '*';
            switch (dir)
            {
                case 0:
                    PlayerX--;
                    break;
                case 1:
                    PlayerY++;
                    break;
                case 2:
                    PlayerX++;
                    break;
                case 3:
                    PlayerY--;
                    break;
                default:
                    return;


            }
            MakeMove();
        }
        private void MakeMove()
        {
            if(Web[PlayerX, PlayerY] == '$')
            {
                Console.WriteLine("\n********************************\n");
                Console.WriteLine("You have found something:");
                Console.WriteLine(Potions[0]);
                Player.AddToInventory(Potions[0]);
                Potions.RemoveAt(0);
                Console.WriteLine("Press to next...");
                Console.WriteLine("\n********************************\n");
                Console.ReadKey();
            }
            else if(Web[PlayerX, PlayerY] == '#')
            {
                Console.WriteLine("\n********************************\n");
                Console.WriteLine("You meet enemy!");
                Console.WriteLine(Enemies[0]);
                Console.WriteLine("Press to start battle...");
                Console.WriteLine("\n********************************\n");
                Console.ReadKey();
                Console.Clear();
                new Battle(Player, Enemies[0]).Start();
                Enemies.RemoveAt(0);
            }
            Web[PlayerX, PlayerY] = '0';
        } 
        private void InitEnemies()
        {
            for (int i = 0; i < NUM_OF_ENEMIES; i++)
                Enemies.Add(EnemyGenerator.GetEnemy());

            Random r = new Random();
            int x, y;
            for(int i = 0; i < NUM_OF_ENEMIES; i++)
            {
                do
                {
                    x = r.Next(0, Height - 1);
                    y = r.Next(0, Width - 1);
                } while (Web[x, y] != '*');
                Web[x, y] = '#';
            }
            
        }
        private void InitLoot()
        {
            for (int i = 0; i < NUM_OF_LOOT; i++)
                Potions.Add(PotionGenerator.GetPotion());

            Random r = new Random();
            int x, y;
            for (int i = 0; i < NUM_OF_LOOT; i++)
            {
                do
                {
                    x = r.Next(0, Height - 1);
                    y = r.Next(0, Width - 1);
                } while (Web[x, y] != '*');
                Web[x, y] = '$';
            }
        }
    }
}
