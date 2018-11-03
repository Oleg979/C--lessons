using System;
using System.Collections.Generic;

namespace Figures
{
    public class Line : PointedFigure
    {
        public override List<Point> Points { get; }

        public Line() => Points = new List<Point>();

        public override PointedFigure AddPoint(int x, int y)
        {
            if (Points.Count >= 2) throw new ArgumentOutOfRangeException();
            Points.Add(new Point(x, y));
            return this;
        }

        public override void Draw() => Console.WriteLine($"Line with points: {Points[0]}; {Points[1]}");

        public override double GetArea() => 0;
    }
}
