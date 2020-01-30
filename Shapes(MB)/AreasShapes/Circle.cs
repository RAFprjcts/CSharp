using System;

namespace AreasShapes
{
    public class Circle : Shape
    {
        public Circle(int s) : base(s) { }
        public override double Square()
        {
            return Math.PI * sides[0] * sides[0];//pi*r^2
        }
    }
}
