using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourthTask
{
    public class Triangle
    {
        private List<double> _sidesOfTheTriangle;

        public Triangle(double firstSideOfTheTriangle,
            double secondSideOfTheTriangle,
            double thirdSideOfTheTriangle)
        {
            _sidesOfTheTriangle = new List<double>();
            _sidesOfTheTriangle.Add(firstSideOfTheTriangle);
            _sidesOfTheTriangle.Add(secondSideOfTheTriangle);
            _sidesOfTheTriangle.Add(thirdSideOfTheTriangle);
        }

        public bool IsTriangle()
        {
            double maxSideLength = _sidesOfTheTriangle.Max();
            if(maxSideLength < _sidesOfTheTriangle.Where(x => x != maxSideLength).Sum())
            {
                return true;
            }

            return false;
        }

        public double GetAreaOfATriangle()
        {
            if (IsTriangle())
            {
                double semiPerimetr = GetPerimetrOfATriangle() / 2;

                return Math.Sqrt(semiPerimetr * _sidesOfTheTriangle
                    .Select(x => semiPerimetr - x)
                    .Aggregate((av, e) => av * e));
            }

            return 0.0;
        }

        public double GetPerimetrOfATriangle()
        {
            if (IsTriangle())
            {
                return _sidesOfTheTriangle.Sum();
            }

            return 0.0;
        }

    }
}
