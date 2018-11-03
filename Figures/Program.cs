using System;
using System.Collections.Generic;

namespace Figures
{
    public class Program
    {
        public static void Main()
        {
            PointedFigure line = 
                new Line()
                .AddPoint(0, 0)
                .AddPoint(5, 5);

            PointedFigure rect =
                new Rectangle()
                .AddPoint(0, 0)
                .AddPoint(0, 1)
                .AddPoint(1, 0)
                .AddPoint(1, 1);

            Circle circle = new Circle(2);

            Ring ring = new Ring(new Circle(5), new Circle(3));

            new List<Figure>()
                { line, rect, circle, ring }
                .ForEach((f) => f.Draw());

            Console.ReadKey();
        }
    }
}
