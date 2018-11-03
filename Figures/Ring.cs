using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Ring : Figure
    {
        public readonly Circle Inner;
        public readonly Circle Outer;

        public Ring(Circle i, Circle o)
        {
            Inner = i;
            Outer = o;
        }

        public override void Draw() => Console.WriteLine($"Ring with two circles: radius {Outer.Radius} and {Inner.Radius}");
        
        public override double GetArea() => Inner.GetArea() - Outer.GetArea();
    }
}
