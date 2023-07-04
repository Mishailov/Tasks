using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesseract
{
    public static class MatrixOperation
    {
        public static float[,] MultiplicationMatrix(float[,] matrix1, float[,] matrix2)
        {
            var resultMatrix = new float[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (var i = 0; i < matrix1.GetLength(0); i++)
            for (var j = 0; j < matrix2.GetLength(1); j++)
            {
                float sum = 0;
                for (var k = 0; k < matrix1.GetLength(1); k++) sum += matrix1[i, k] * matrix2[k, j];
                resultMatrix[i, j] = sum;
            }

            return resultMatrix;
        }
    }
}
