using System;
using System.Collections.Generic;
using System.Text;

namespace FourthTask
{
    public class Triangle
    {
        private double _firstSideOfTheTriangle { get; set; }
        private double _secondSideOfTheTriangle { get; set; }
        private double _thirdSideOfTheTriangle { get; set; }

        public Triangle(double firstSideOfTheTriangle,
            double secondSideOfTheTriangle,
            double thirdSideOfTheTriangle)
        {
            _firstSideOfTheTriangle = firstSideOfTheTriangle;
            _secondSideOfTheTriangle = secondSideOfTheTriangle;
            _thirdSideOfTheTriangle = thirdSideOfTheTriangle;
        }

        public bool IsTriangle()
        {
            double maxSideLength = Math.Max(_firstSideOfTheTriangle,
                Math.Max(_secondSideOfTheTriangle, _thirdSideOfTheTriangle));
            if(maxSideLength < ((_firstSideOfTheTriangle +
                _secondSideOfTheTriangle + _thirdSideOfTheTriangle) - maxSideLength))
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
                return Math.Sqrt(semiPerimetr * (semiPerimetr - _firstSideOfTheTriangle) *
                    (semiPerimetr - _secondSideOfTheTriangle) *
                    (semiPerimetr - _thirdSideOfTheTriangle));
            }

            return 0.0f;
        }

        public double GetPerimetrOfATriangle()
        {
            if (IsTriangle())
            {
                return _firstSideOfTheTriangle +
                    _secondSideOfTheTriangle +
                    _thirdSideOfTheTriangle;
            }

            return 0.0;
        }

    }
}
