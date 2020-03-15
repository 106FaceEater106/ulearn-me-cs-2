using System;

namespace Incapsulation.RationalNumbers
{
    public class Rational
    {
        public readonly double Numerator;
        public readonly double Denominator;

        public bool IsNan => double.IsNaN(Numerator)
                          || double.IsNaN(Denominator)
                          || Denominator == 0;

        public Rational(double numerator, double denominator = 1)
        {
            Numerator = numerator;
            Denominator = denominator;
            var num = Math.Abs(numerator);
            var den = Math.Abs(denominator);
            while (den != 0 && num != 0)
                if (num % den > 0) (num, den) = (den, num % den);
                else break;
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
            Numerator /= den;
            Denominator /= den;
        }

        public static Rational operator +(Rational p1, Rational p2)
        {
            return new Rational(
                p1.Numerator * p2.Denominator + p2.Numerator * p1.Denominator,
                p1.Denominator * p2.Denominator);
        }

        public static Rational operator -(Rational p1, Rational p2)
        {
            return new Rational(
                p1.Numerator * p2.Denominator - p2.Numerator * p1.Denominator,
                p1.Denominator * p2.Denominator);
        }

        public static Rational operator *(Rational p1, Rational p2)
        {
            return new Rational(
                p1.Numerator * p2.Numerator,
                p1.Denominator * p2.Denominator);
        }

        public static Rational operator /(Rational p1, Rational p2)
        {
            return new Rational(
                p2.Denominator * p1.Numerator,
                p2.Numerator * p1.Denominator);
        }

        public static implicit operator Rational(int v) => new Rational(v);

        public static implicit operator double(Rational r)
        {
            if (r.IsNan) return double.NaN;
            return r.Numerator / r.Denominator;
        }

        public static explicit operator int(Rational r)
        {
            if (r.Denominator == 1 || r.Numerator == r.Denominator)
                return (int)(r.Numerator / r.Denominator);
            throw new InvalidCastException();
        }
    }
}