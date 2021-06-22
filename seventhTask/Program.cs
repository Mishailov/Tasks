using System;

namespace seventhTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write first matrix (col and row)");
            Matrix firstMatrix = CreateAndFillMatrix();
            Console.WriteLine("Write second matrix (col and row)");
            Matrix secondMatrix = CreateAndFillMatrix();
            if (firstMatrix is null || secondMatrix is null)
                return;

            ViewMatrix(firstMatrix);
            Console.WriteLine("\n");
            ViewMatrix(secondMatrix);
            Console.WriteLine("Myltiply: ");
            ViewMatrix(firstMatrix * secondMatrix);
            Console.WriteLine("Add: ");
            ViewMatrix(firstMatrix + secondMatrix);
            Console.WriteLine("Substract: ");
            ViewMatrix(firstMatrix - secondMatrix);
        }

        static Matrix CreateAndFillMatrix()
        {
            if (!int.TryParse(Console.ReadLine(), out int col)
                || !int.TryParse(Console.ReadLine(), out int row))
            {
                Console.WriteLine("uncorrect values");
                return null;
            }

            float[,] data = new float[col, row];
            Console.WriteLine("write paramm for matrix");

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if(!float.TryParse(Console.ReadLine(), out float value))
                    {
                        Console.WriteLine("uncorrect value");
                        return null;
                    }
                    data[i, j] = value;
                }
            }

            return new Matrix(data);
        }

        static void ViewMatrix(Matrix matrix)
        {
            matrix.ProcessActionOverData((i, j) =>
            {
                if(j == matrix.Data.GetLength(1) - 1)
                    Console.Write(matrix.Data[i, j] + "\n");
                else
                    Console.Write(matrix.Data[i, j] + " ");
            }); 
        }
    }
}
