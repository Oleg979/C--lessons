using System;
using System.Collections.Generic;

namespace Figures
{
    class Rectangle : PointedFigure
    {
        public override List<Point> Points { get; }

        public Rectangle() => Points = new List<Point>();

        public override PointedFigure AddPoint(int x, int y)
        {
            if (Points.Count >= 4) throw new ArgumentOutOfRangeException();
            Points.Add(new Point(x, y));
            return this;
        }

        public override void Draw() => Console.WriteLine($"Rectangle with points: {Points[0]}; {Points[1]}; {Points[2]}; {Points[3]}");

        public override double GetArea() => 1;
    }
}
