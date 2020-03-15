using System;

namespace Inheritance.Geometry
{
    public abstract class Body
    {
        public abstract double GetVolume();
    }

    public class Ball : Body
    {
        public double Radius { get; set; }
        public override double GetVolume() => 4.0 * Math.PI * Radius * Radius * Radius / 3;
    }

    public class Cube : Body
    {
        public double Size { get; set; }
        public override double GetVolume() => Size * Size * Size;
    }

    public class Cylinder : Body
    {
        public double Height { get; set; }
        public double Radius { get; set; }
        public override double GetVolume() => Math.PI * Radius * Radius * Height;
    }

    public class SurfaceAreaVisitor
    {
        public double SurfaceArea { get; private set; }
    }

    public class DimensionsVisitor
    {
        public Dimensions Dimensions { get; private set; }
    }
}