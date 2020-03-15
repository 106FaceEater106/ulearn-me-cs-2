using System;

namespace Inheritance.Geometry
{
    public interface IVisitor
    {
        void Visit(Ball ball);
        void Visit(Cylinder cylinder);
        void Visit(Cube cube);
    }

    public abstract class Body
    {
        public abstract double GetVolume();
        public abstract void Accept(IVisitor visitor);
    }

    public class Ball : Body
    {
        public double Radius { get; set; }

        public override void Accept(IVisitor visitor) => visitor.Visit(this);

        public override double GetVolume()
        {
            return 4.0 * Math.PI * Radius * Radius * Radius / 3;
        }
    }

    public class Cube : Body
    {
        public double Size { get; set; }

        public override void Accept(IVisitor visitor) => visitor.Visit(this);
        public override double GetVolume() => Size * Size * Size;
    }

    public class Cylinder : Body
    {
        public double Height { get; set; }
        public double Radius { get; set; }

        public override void Accept(IVisitor visitor) => visitor.Visit(this);
        public override double GetVolume() => Math.PI * Radius * Radius * Height;
    }

    public class SurfaceAreaVisitor : IVisitor
    {
        public double SurfaceArea { get; private set; }

        public void Visit(Ball b)
        {
            SurfaceArea = 4 * Math.PI * b.Radius * b.Radius;
        }

        public void Visit(Cylinder c)
        {
            SurfaceArea = 2 * Math.PI * c.Radius * (c.Radius + c.Height);
        }

        public void Visit(Cube c)
        {
            SurfaceArea = 6 * c.Size * c.Size;
        }
    }

    public class DimensionsVisitor : IVisitor
    {
        public Dimensions Dimensions { get; private set; }

        public void Visit(Ball b)
        {
            Dimensions = new Dimensions(b.Radius * 2, b.Radius * 2);
        }

        public void Visit(Cylinder c)
        {
            Dimensions = new Dimensions(c.Radius * 2, c.Height);
        }

        public void Visit(Cube c)
        {
            Dimensions = new Dimensions(c.Size, c.Size);
        }
    }
}
