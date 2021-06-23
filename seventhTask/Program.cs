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

            Console.WriteLine(firstMatrix.ToString());
            Console.WriteLine("\n");
            Console.WriteLine(firstMatrix.ToString());
            Console.WriteLine("Myltiply: ");
            Console.WriteLine((firstMatrix * secondMatrix).ToString());
            Console.WriteLine("Add: ");
            Console.WriteLine((firstMatrix + secondMatrix).ToString());
            Console.WriteLine("Substract: ");
            Console.WriteLine((firstMatrix - secondMatrix).ToString());
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
