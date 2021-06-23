using System;
using System.Collections.Generic;
using System.Text;

namespace seventhTask
{
    public class Matrix
    {
        private float[,] _data;

        public Matrix(float[,] data)
        {
            _data = new float[data.GetLength(0), data.GetLength(1)];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    _data[i, j] = data[i, j];
                }
            }
        }

        public float this[int x, int y]
        {
            get
            {
                return _data[x, y];
            }
            set
            {
                _data[x, y] = value;
            }
        }

        public void ProcessActionOverData(Action<int, int> func)
        {
            for (var i = 0; i < _data.GetLength(0); i++)
            {
                for (var j = 0; j < _data.GetLength(1); j++)
                {
                    func(i, j);
                }
            }
        }

        public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix._data.GetLength(0) != secondMatrix._data.GetLength(1))
            {
                throw new ArgumentException("matrixes can not be myltiplied");
            }

            var resultMatrix = new Matrix(new float[firstMatrix._data.GetLength(0), secondMatrix._data.GetLength(1)]);

            resultMatrix.ProcessActionOverData((i, j) =>
            {
                resultMatrix[i, j] = 0;
                for (int k = 0; k < firstMatrix._data.GetLength(1); k++)
                {
                    resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                }
            });

            return resultMatrix;
        }

        public static Matrix operator +(Matrix firstMatrix, Matrix secondMatrix)
        {
            return MinusPlusMethod("matrixes can not be added", 1, firstMatrix, secondMatrix);
        }

        public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
        {
            return MinusPlusMethod("matrixes can not be subtracted", -1, firstMatrix, secondMatrix);
        }

        private static Matrix MinusPlusMethod(string message, int sign, Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix._data.GetLength(0) != secondMatrix._data.GetLength(0) || firstMatrix._data.GetLength(1) != secondMatrix._data.GetLength(1))
            {
                throw new ArgumentException(message);
            }

            var resultMatrix = new Matrix(new float[firstMatrix._data.GetLength(0), secondMatrix._data.GetLength(1)]);

            resultMatrix.ProcessActionOverData((i, j) =>
            {
                resultMatrix[i, j] = firstMatrix[i, j] + (sign * secondMatrix[i, j]);
            });

            return resultMatrix;
        }

        public override string ToString()
        {
            string matrixToString = string.Empty;
            this.ProcessActionOverData((i, j) =>
            {
                if (j == _data.GetLength(1) - 1)
                    matrixToString += _data[i, j] + " \n";
                else
                    matrixToString += _data[i, j] + " ";
            });

            return matrixToString;
        }
    }
}
