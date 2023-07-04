using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesseract
{
    public class Isometric
    {
        public double DegreeX { get; set; }
        public double DegreeY { get; set; }
        public float[,] Point3D { get; set; }

        public Isometric(double degreeX, double degreeY, float[,] point3D)
        {
            DegreeX = degreeX;
            DegreeY = degreeY;
            Point3D = point3D;
        }

        public float[,] GetCube2dPoints(float[,] cube3dPoints)
        {
            var pointRow = new float[3, 1];

            var cube2dPoints = new float[cube3dPoints.GetLength(0), 2];

            DegreeX = ConvertToRadians(DegreeX);
            DegreeY = ConvertToRadians(DegreeY);

            for (var i = 0; i < cube3dPoints.GetLength(0); i++)
            {
                pointRow[0, 0] = cube3dPoints[i, 0];
                pointRow[1, 0] = cube3dPoints[i, 1];
                pointRow[2, 0] = cube3dPoints[i, 2];

                Point3D = pointRow;
                pointRow = GetResultPointAfterRotate();
                Point3D = pointRow;
                pointRow = Get2dPoint();

                for (var j = 0; j < 2; j++) cube2dPoints[i, j] = pointRow[j, 0];
            }

            return cube2dPoints;
        }

        public float[,] GetResultPointAfterRotate()
        {
            var resultRotateMatrix = MatrixOperation.MultiplicationMatrix(GetRotateMatrixByY(), GetRotateMatrixByX());
            return MatrixOperation.MultiplicationMatrix(resultRotateMatrix, Point3D);
        }

        private float[,] Get2dPoint()
        {
            return MatrixOperation.MultiplicationMatrix(new float[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } }, Point3D);
        }

        private double ConvertToRadians(double degree)
        {
            return degree * Math.PI / 180;
        }

        private float[,] GetRotateMatrixByY()
        {
            var rotateMatrix = new float[3, 3];
            rotateMatrix[0, 0] = 1;
            rotateMatrix[0, 1] = 0;
            rotateMatrix[0, 2] = 0;
            rotateMatrix[1, 0] = 0;
            rotateMatrix[1, 1] = (float)Math.Cos(DegreeY);
            rotateMatrix[1, 2] = (float)Math.Sin(DegreeY);
            rotateMatrix[2, 0] = 0;
            rotateMatrix[2, 1] = -1 * (float)Math.Sin(DegreeY);
            rotateMatrix[2, 2] = (float)Math.Cos(DegreeY);
            return rotateMatrix;
        }

        private float[,] GetRotateMatrixByX()
        {
            var rotateMatrix = new float[3, 3];
            rotateMatrix[0, 0] = (float)Math.Cos(DegreeX);
            rotateMatrix[0, 1] = 0;
            rotateMatrix[0, 2] = -1 * (float)Math.Sin(DegreeX);
            rotateMatrix[1, 0] = 0;
            rotateMatrix[1, 1] = 1;
            rotateMatrix[1, 2] = 0;
            rotateMatrix[2, 0] = (float)Math.Sin(DegreeX);
            rotateMatrix[2, 1] = 0;
            rotateMatrix[2, 2] = (float)Math.Cos(DegreeX);
            return rotateMatrix;
        }
    }
}
