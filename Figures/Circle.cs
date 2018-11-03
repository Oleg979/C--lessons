using System;

namespace Figures
{
    public class Circle : Figure
    {
        public readonly double Radius;

        public Circle(double r)
        {
            Radius = r;
        }

        public override void Draw() => Console.WriteLine($"Circle with raduis {Radius}");
       
        public override double GetArea() => Math.PI * Radius * Radius;
    }
}
