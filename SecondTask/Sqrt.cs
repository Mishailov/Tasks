using System;
using System.Collections.Generic;
using System.Text;

namespace SecondTask
{
    class Sqrt
    {
        private double _inputNum;
        private int _rootNum;
        private double _eps;

        public Sqrt(double inputNum, int rootNum, double eps)
        {
            _inputNum = inputNum;
            _rootNum = rootNum;
            _eps = eps;
        }

        public double GetSqrtByNewton()
        {
            if (_eps >= 1)
                _eps = Double.Epsilon;

            if (_rootNum < 2)
                return _inputNum;

            if (_inputNum < 0 && _rootNum % 2 == 0)
                return Double.NaN;

            double xk1 = _inputNum;
            double xk = 0;
            for (; ; )
            {
                xk1 = (1.0 / _rootNum) * ((_rootNum - 1) * xk1 + _inputNum / (Math.Pow(xk1, _rootNum - 1)));
                if (Math.Abs(xk - xk1) <= _eps) break;
                xk = xk1;
            }

            return (xk1 - xk1 % _eps);
        }

        public bool GetCompareWithPowValue()
        {
            if (_eps >= 1)
                _eps = Double.Epsilon;
            double result = Math.Pow(_inputNum, 1 / (double)_rootNum)
                - Math.Pow(_inputNum, 1 / (double)_rootNum) % _eps;

            return result == GetSqrtByNewton();
        }
    }
}
