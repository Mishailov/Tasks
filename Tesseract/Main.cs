namespace Tesseract
{
    public partial class Main : Form
    {
        public int widthMainFormLoad = 400;
        public int heightMainFormLoad = 400;

        public static double rotateAgleX = 0;
        public static double startPositionX = 0;

        public static double rotateAgleY = 0;
        public static double startPositionY = 0;

        public bool isButtonPressed = false;

        public Main()
        {
            InitializeComponent();
        }

        public float[,] GetRotateMatrixX(double rotateAgleX)
        {
            float[,] transformMatrix = new float[3, 3];

            transformMatrix[0, 0] = 1;
            transformMatrix[0, 1] = 0;
            transformMatrix[0, 2] = 0;

            transformMatrix[1, 0] = 0;
            transformMatrix[1, 1] = (float)Math.Cos(rotateAgleX);
            transformMatrix[1, 2] = (-1)*(float)Math.Sin(rotateAgleX);

            transformMatrix[2, 0] = 0;
            transformMatrix[2, 1] = (float)Math.Sin(rotateAgleX);
            transformMatrix[2, 2] = (-1)* (float)Math.Cos(rotateAgleX);

            return transformMatrix;
        }

        public float[,] MultiplicationMatrix(float[,] matrix1, float[,] matrix2)
        {
            float[,] resultMatrix = new float[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    float sum = 0;
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    resultMatrix[i, j] = sum;
                }
            }
            return resultMatrix;
        }

        public float[,] MatrixCube()
        {
            return new float[8, 3]
            {
                {-0.5f, 0.5f, 0.5f},
                {0.5f, 0.5f, 0.5f},
                {0.5f, -0.5f, 0.5f},
                {-0.5f, -0.5f, 0.5f},
                {-0.5f, 0.5f, -0.5f},
                {0.5f, 0.5f, -0.5f},
                {0.5f, -0.5f, -0.5f},
                {-0.5f, -0.5f, -0.5f},
            };
        }

        private double Agle(double degree)
        {
            return degree * Math.PI / 180;
        }

        private float[,] RotateCube(float[,] cubePoints, double degreeX, double degreeY)
        {
            float[,] cubePointsIn2d = Convert3dTo2dPoints(cubePoints);
            for (int i = 0; i < cubePointsIn2d.GetLength(0); i++)
            {
                cubePointsIn2d[i, 0] = (float)(cubePointsIn2d[i, 0] * Math.Cos(Agle(degreeX))) - (float)(cubePointsIn2d[i, 1] * Math.Sin(Agle(degreeY)));
                cubePointsIn2d[i, 1] = (float)(cubePointsIn2d[i, 0] * Math.Sin(Agle(degreeX))) + (float)(cubePointsIn2d[i, 1] * Math.Cos(Agle(degreeY)));
            }
            return cubePointsIn2d;
        }

        public void DrawCube(float[,] cubePoints, double degreeX, double degreeY, PaintEventArgs e)
        {
            float[,] cubePointsIn2d = RotateCube(cubePoints, degreeX, degreeY);

            Pen pen = new Pen(Color.Black, 2);

            int count = 0;

            //var temp = new float[3,1];

            //var matrixCube = MatrixCube();

            //for (int i = 0; i < 8; i++)
            //{
            //    temp[0,0] = matrixCube[i, 0];
            //    temp[1,0] = matrixCube[i, 1];
            //    temp[2,0] = matrixCube[i, 2];

            //    temp = MultiplicationMatrix(GetRotateMatrixX(Agle(45.0)), temp);

            //    for (int j = 0; j < 3; j++)
            //    {
            //        cubePoints[i,j] = temp[j,0];
            //    }
            //}

            //var cubePointsIn2d = Convert3dTo2dPoints(cubePoints);

            PointF point11 = new PointF(cubePointsIn2d[0, 0] * 70 + widthMainFormLoad / 2,
                               cubePointsIn2d[0, 1] * 70 + heightMainFormLoad / 2);
            PointF point12 = new PointF(cubePointsIn2d[1, 0] * 70 + widthMainFormLoad / 2,
                    cubePointsIn2d[1, 1] * 70 + heightMainFormLoad / 2);
            e.Graphics.DrawLine(pen, point11, point12);

            PointF point21 = new PointF(cubePointsIn2d[1, 0] * 70 + widthMainFormLoad / 2,
                                   cubePointsIn2d[1, 1] * 70 + heightMainFormLoad / 2);
            PointF point22 = new PointF(cubePointsIn2d[2, 0] * 70 + widthMainFormLoad / 2,
                cubePointsIn2d[2, 1] * 70 + heightMainFormLoad / 2);
            e.Graphics.DrawLine(pen, point21, point22);

            PointF point31 = new PointF(cubePointsIn2d[2, 0] * 70 + widthMainFormLoad / 2,
                                                  cubePointsIn2d[2, 1] * 70 + heightMainFormLoad / 2);
            PointF point32 = new PointF(cubePointsIn2d[3, 0] * 70 + widthMainFormLoad / 2,
                cubePointsIn2d[3, 1] * 70 + heightMainFormLoad / 2);
            e.Graphics.DrawLine(pen, point31, point32);

            PointF point41 = new PointF(cubePointsIn2d[3, 0] * 70 + widthMainFormLoad / 2,
                                                                 cubePointsIn2d[3, 1] * 70 + heightMainFormLoad / 2);
            PointF point42 = new PointF(cubePointsIn2d[0, 0] * 70 + widthMainFormLoad / 2,
                cubePointsIn2d[0, 1] * 70 + heightMainFormLoad / 2);
            e.Graphics.DrawLine(pen, point41, point42);

            PointF point43 = new PointF(cubePointsIn2d[4, 0] * 70 + widthMainFormLoad / 2,
                               cubePointsIn2d[4, 1] * 70 + heightMainFormLoad / 2);
            PointF point44 = new PointF(cubePointsIn2d[5, 0] * 70 + widthMainFormLoad / 2,
                cubePointsIn2d[5, 1] * 70 + heightMainFormLoad / 2);
            e.Graphics.DrawLine(pen, point43, point44);

            PointF point45 = new PointF(cubePointsIn2d[5, 0] * 70 + widthMainFormLoad / 2,
                                                  cubePointsIn2d[5, 1] * 70 + heightMainFormLoad / 2);
            PointF point46 = new PointF(cubePointsIn2d[6, 0] * 70 + widthMainFormLoad / 2,
                cubePointsIn2d[6, 1] * 70 + heightMainFormLoad / 2);
            e.Graphics.DrawLine(pen, point45, point46);

            PointF point47 = new PointF(cubePointsIn2d[6, 0] * 70 + widthMainFormLoad / 2,
                                                                                cubePointsIn2d[6, 1] * 70 + heightMainFormLoad / 2);
            PointF point48 = new PointF(cubePointsIn2d[7, 0] * 70 + widthMainFormLoad / 2,
                cubePointsIn2d[7, 1] * 70 + heightMainFormLoad / 2);
            e.Graphics.DrawLine(pen, point47, point48);

            PointF point49 = new PointF(cubePointsIn2d[7, 0] * 70 + widthMainFormLoad / 2,
                                                                                cubePointsIn2d[7, 1] * 70 + heightMainFormLoad / 2);
            PointF point410 = new PointF(cubePointsIn2d[4, 0] * 70 + widthMainFormLoad / 2,
                cubePointsIn2d[4, 1] * 70 + heightMainFormLoad / 2);
            e.Graphics.DrawLine(pen, point49, point410);

            //for (int i = 0; i < cubePointsIn2d.GetLength(0) - 1; i++)
            //{
            //    count++;
            //    PointF point1 = new PointF(cubePointsIn2d[i, 0] * 70 + widthMainFormLoad / 2,
            //        cubePointsIn2d[i, 1] * 70 + heightMainFormLoad / 2);
            //    PointF point2 = new PointF(cubePointsIn2d[i + 1, 0] * 70 + widthMainFormLoad / 2,
            //        cubePointsIn2d[i + 1, 1] * 70 + heightMainFormLoad / 2);
            //    e.Graphics.DrawLine(pen, point1, point2);

            //    if (count == 7)
            //    {
            //        point1 = new PointF(cubePointsIn2d[i + 1, 0] * 70 + widthMainFormLoad / 2,
            //            cubePointsIn2d[i + 1, 1] * 70 + heightMainFormLoad / 2);
            //        point2 = new PointF(cubePointsIn2d[0, 0] * 70 + widthMainFormLoad / 2,
            //            cubePointsIn2d[0, 1] * 70 + heightMainFormLoad / 2);
            //        e.Graphics.DrawLine(pen, point1, point2);
            //    }
            //}
        }

        public float[,] Convert3dTo2dPoints(float[,] points3d)
        {
            float[,] matrix2d = new float[points3d.GetLength(0), points3d.GetLength(1)];
            for (int i = 0; i < points3d.GetLength(0); i++)
            {
                matrix2d[i, 0] = points3d[i, 0] + points3d[i, 2];
                matrix2d[i, 1] = points3d[i, 1] + points3d[i, 2];
            }
            return matrix2d;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isButtonPressed)
            {
                rotateAgleX += e.X - startPositionX;
                startPositionX = e.X;

                rotateAgleY += e.Y - startPositionY;
                startPositionY = e.Y;

                this.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isButtonPressed = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startPositionX = e.X;
            startPositionY = e.Y;
            isButtonPressed = true;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            widthMainFormLoad = pictureBox1.Width;
            heightMainFormLoad = pictureBox1.Height;

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            float[,] cubePoints = MatrixCube();

            DrawCube(cubePoints, rotateAgleX, rotateAgleY, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}