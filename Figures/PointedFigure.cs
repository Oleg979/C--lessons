using System.Collections.Generic;

namespace Figures
{
    public abstract class PointedFigure : Figure
    {
        public abstract List<Point> Points { get; }
        public abstract PointedFigure AddPoint(int x, int y);
    }
}
