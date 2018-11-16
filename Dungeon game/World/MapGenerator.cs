using System;

namespace Game.World
{
    class MapGenerator
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public int X { get; private set; }
        public int Y { get; private set; }

        private Random r1 = new Random();
        private Random r2 = new Random();

        public char[,] Web { get; private set; }

        public MapGenerator(int h, int w)
        {
            Width = w;
            Height = h;
            Y = 0;
            X = 0;

            Web = new char[Height, Width];
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    Web[i,j] = ' ';
        }

        private int GetRandomLength() => r1.Next(3, 8);

        private bool IsDirectionPossible(int dir, int len)
        {
            switch (dir)
            {
                case 0:
                    return Y - len >= 0;
                case 1:
                    return X + len < Width;
                case 2:
                    return Y + len < Height;
                case 3:
                    return X - len >= 0;
                default:
                    return false;
            }
        }

        private void Fill(int dir, int len)
        {
            for (int i = 0; i < len; i++)
            {
                Web[Y,X] = '*';
                switch (dir)
                {
                    case 0:
                        Y--;
                        break;
                    case 1:
                        X++;
                        break;
                    case 2:
                        Y++;
                        break;
                    case 3:
                        X--;
                        break;
                }
            }
        }

        private int GetRandomDirection(int len)
        {
            int dir;
            do
            {
                dir = r2.Next(0, 4);
            } while (!IsDirectionPossible(dir, len));
            return dir;
        }

        private void Generate()
        {
            for (int i = 0; i < 150; i++)
            {
                int len = GetRandomLength();
                int dir = GetRandomDirection(len);
                Fill(dir, len);
            }
        }

        public char[,] GetWeb()
        {
            Generate();
            return Web;
        }

        public void Print()
        {
            Generate();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                   Console.Write(Web[i, j]);
                Console.WriteLine();
            }
        }

    }
}
