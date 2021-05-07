using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourthTask
{
    public class Triangle
    {
        private List<double> _sides;

        public Triangle(double firstSide,
            double secondSide,
            double thirdSide)
        {
            _sides = new List<double>();
            _sides.Add(firstSide);
            _sides.Add(secondSide);
            _sides.Add(thirdSide);
        }

        public bool IsTriangle()
        {
            double maxSideLength = _sides.Max();
            var legs = _sides.Where(x => x != maxSideLength);
            if (maxSideLength >= legs.Sum())
            {
                return false;
            }

            foreach (var side in legs)
            {
                if(side > maxSideLength + legs.Where(x => x != side).Sum())
                {
                    return false;
                }
            }

            return true;
        }

        public double GetAreaOfATriangle()
        {
            if (IsTriangle())
            {
                double semiPerimetr = GetPerimetrOfATriangle() / 2;

                return Math.Sqrt(semiPerimetr * _sides
                    .Select(x => semiPerimetr - x)
                    .Aggregate((av, e) => av * e));
            }

            return 0.0;
        }

        public double GetPerimetrOfATriangle()
        {
            if (IsTriangle())
            {
                return _sides.Sum();
            }

            return 0.0;
        }

    }
}
