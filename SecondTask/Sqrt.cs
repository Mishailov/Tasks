using System;
using System.Collections.Generic;
using System.Text;

namespace SecondTask
{
    class Sqrt
    {
        private double _inputNum;
        private int _rootNum;
        private double _lengthAfterDecimalPoint;

        public Sqrt(double inputNum, int rootNum, double lengthAfterDecimalPoint)
        {
            _inputNum = inputNum;
            _rootNum = rootNum;

            if(_lengthAfterDecimalPoint >= 1)
                _lengthAfterDecimalPoint = Double.Epsilon;
            else
                _lengthAfterDecimalPoint = lengthAfterDecimalPoint;
        }

        public double GetSqrtByNewton()
        {
            if (_rootNum < 2)
                return _inputNum;

            if (_inputNum < 0 && _rootNum % 2 == 0)
                return Double.NaN;

            double stepResult = _inputNum;
            double desiredLengthResult = 0;
            while(Math.Abs(desiredLengthResult - stepResult) >= _lengthAfterDecimalPoint)
            {
                desiredLengthResult = stepResult;
                stepResult = (1.0 / _rootNum) * ((_rootNum - 1) * stepResult + _inputNum / (Math.Pow(stepResult, _rootNum - 1)));
            }

            return (stepResult - stepResult % _lengthAfterDecimalPoint);
        }

        public bool GetCompareWithPowValue()
        {
            double result = Math.Pow(_inputNum, 1 / (double)_rootNum)
                - Math.Pow(_inputNum, 1 / (double)_rootNum) % _lengthAfterDecimalPoint;

            return result == GetSqrtByNewton();
        }
    }
}
