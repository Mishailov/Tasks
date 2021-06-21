using System;
using System.Collections.Generic;
using System.Text;

namespace seventhTask
{
    class Matrix
    {
        private float[,] _data;
        private int _width;
        private int _height;

        public Matrix(int width, int height)
        {
            _width = width;
            _height = height;
            _data = new float[_width, _height];
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

        public void FillTheArray(params float[] data)
        {
            if(data.Length != _data.Length)
            {
                throw new ArgumentOutOfRangeException("input array length longer than this matrix length");
            }

            int inputDataIndex = 0;
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    _data[i, j] = data[inputDataIndex];
                    inputDataIndex++;
                }
            }
        }

        private void ProcessFunctionOverData(Action<int, int> func)
        {
            for (var i = 0; i < _width; i++)
            {
                for (var j = 0; j < _height; j++)
                {
                    func(i, j);
                }
            }
        }

        public static Matrix operator* (Matrix firstMatrix, Matrix secondMatrix)
        {
            if(firstMatrix._height != secondMatrix._width)
            {
                throw new ArgumentException("matrixes can not be myltiplied");
            }

            var resultMatrix = new Matrix(firstMatrix._width, secondMatrix._height);

            resultMatrix.ProcessFunctionOverData((i, j) => {
                resultMatrix[i, j] = 0;
                for (int k = 0; k < firstMatrix._height; k++)
                {
                    resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                }
            });

            return resultMatrix;
        }

        public static Matrix operator+ (Matrix firstMatrix, Matrix secondMatrix)
        {
            if(firstMatrix._height != secondMatrix._height || firstMatrix._width != secondMatrix._width)
            {
                throw new ArgumentException("matrixes can not be added");
            }

            var resultMatrix = new Matrix(firstMatrix._width, secondMatrix._height);

            resultMatrix.ProcessFunctionOverData((i, j) =>
            {
                resultMatrix[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
            });

            return resultMatrix;
        }

        public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix._height != secondMatrix._height || firstMatrix._width != secondMatrix._width)
            {
                throw new ArgumentException("matrixes can not be subtracted");
            }

            var resultMatrix = new Matrix(firstMatrix._width, secondMatrix._height);

            resultMatrix.ProcessFunctionOverData((i, j) =>
            {
                resultMatrix[i, j] = firstMatrix[i, j] - secondMatrix[i, j];
            });

            return resultMatrix;
        }
    }
}
