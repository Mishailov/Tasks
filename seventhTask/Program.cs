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

            firstMatrix.ToString();
            Console.WriteLine("\n");
            firstMatrix.ToString();
            Console.WriteLine("Myltiply: ");
            (firstMatrix * secondMatrix).ToString();
            Console.WriteLine("Add: ");
            (firstMatrix + secondMatrix).ToString();
            Console.WriteLine("Substract: ");
            (firstMatrix - secondMatrix).ToString();
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
    }
}
