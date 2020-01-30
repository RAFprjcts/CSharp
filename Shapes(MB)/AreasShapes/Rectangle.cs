using System;

namespace AreasShapes
{
    public class Rectangle : Shape
    {
        public Rectangle(int w, int h) : base(w, h) { }
        public override double Square()
        {
            return sides[0] * sides[1];
        }
    }
}
