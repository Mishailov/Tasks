namespace Tesseract;

public partial class Main : Form
{
    public int widthMainFormLoad = 400;
    public int heightMainFormLoad = 400;

    public static double rotateAgleX;
    public static double startPositionX;

    public static double rotateAgleY;
    public static double startPositionY;

    public bool isButtonPressed;

    public Main()
    {
        InitializeComponent();
    }

    public float[,] GetRotateMatrixX(double rotateAgleX)
    {
        var transformMatrix = new float[3, 3];

        transformMatrix[0, 0] = 1;
        transformMatrix[0, 1] = 0;
        transformMatrix[0, 2] = 0;

        transformMatrix[1, 0] = 0;
        transformMatrix[1, 1] = (float)Math.Cos(rotateAgleX);
        transformMatrix[1, 2] = -1 * (float)Math.Sin(rotateAgleX);

        transformMatrix[2, 0] = 0;
        transformMatrix[2, 1] = (float)Math.Sin(rotateAgleX);
        transformMatrix[2, 2] = -1 * (float)Math.Cos(rotateAgleX);

        return transformMatrix;
    }

    public float[,] GetRotateMatrixY(double rotateAgleY)
    {
        var transformMatrix = new float[3, 3];
        transformMatrix[0, 0] = (float)Math.Cos(rotateAgleY);
        transformMatrix[0, 1] = 0;
        transformMatrix[0, 2] = (float)Math.Sin(rotateAgleY);

        transformMatrix[1, 0] = 0;
        transformMatrix[1, 1] = 1;
        transformMatrix[1, 2] = 0;

        transformMatrix[2, 0] = -1 * (float)Math.Sin(rotateAgleY);
        transformMatrix[2, 1] = 0;
        transformMatrix[2, 2] = (float)Math.Cos(rotateAgleY);

        return transformMatrix;
    }

    public float[,] GetRotateMatrixZ(double rotateAgleZ)
    {
        var transformMatrix = new float[3, 3];
        transformMatrix[0, 0] = (float)Math.Cos(rotateAgleZ);
        transformMatrix[0, 1] = -1 * (float)Math.Sin(rotateAgleZ);
        transformMatrix[0, 2] = 0;

        transformMatrix[1, 0] = (float)Math.Sin(rotateAgleZ);
        transformMatrix[1, 1] = (float)Math.Cos(rotateAgleZ);
        transformMatrix[1, 2] = 0;

        transformMatrix[2, 0] = 0;
        transformMatrix[2, 1] = 0;
        transformMatrix[2, 2] = 1;

        return transformMatrix;
    }

    public float[,] MultiplicationMatrix(float[,] matrix1, float[,] matrix2)
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

    public float[,] MatrixCube()
    {
        return new float[8, 3]
        {
            { -1f, 1f, 1f },
            { 1f, 1f, 1f },
            { 1f, -1f, 1f },
            { -1f, -1f, 1f },
            { -1f, 1f, -1f },
            { 1f, 1f, -1f },
            { 1f, -1f, -1f },
            { -1f, -1f, -1f }
        };
    }

    private double Agle(double degree)
    {
        return degree * Math.PI / 180;
    }

    public void DrawCube(float[,] cubePoints, double degreeX, double degreeY, PaintEventArgs e)
    {
        var pen = new Pen(Color.Black, 2);

        var temp = new float[3, 1];

        var matrixCube = MatrixCube();

        for (var i = 0; i < 8; i++)
        {
            temp[0, 0] = matrixCube[i, 0];
            temp[1, 0] = matrixCube[i, 1];
            temp[2, 0] = matrixCube[i, 2];

            temp = MultiplicationMatrix(GetRotateMatrixX(Agle(degreeX)), temp);
            temp = MultiplicationMatrix(GetRotateMatrixY(Agle(degreeY)), temp);
            temp = MultiplicationMatrix(GetRotateMatrixZ(Agle(0)), temp);

            for (var j = 0; j < 3; j++) cubePoints[i, j] = temp[j, 0];
        }

        var cubePointsIn2d = Convert3dTo2dPoints(cubePoints);

        var point11 = new PointF(cubePointsIn2d[0, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[0, 1] * 70 + heightMainFormLoad / 2);
        var point12 = new PointF(cubePointsIn2d[1, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[1, 1] * 70 + heightMainFormLoad / 2);
        e.Graphics.DrawLine(pen, point11, point12);

        var point21 = new PointF(cubePointsIn2d[1, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[1, 1] * 70 + heightMainFormLoad / 2);
        var point22 = new PointF(cubePointsIn2d[2, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[2, 1] * 70 + heightMainFormLoad / 2);
        e.Graphics.DrawLine(pen, point21, point22);

        var point31 = new PointF(cubePointsIn2d[2, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[2, 1] * 70 + heightMainFormLoad / 2);
        var point32 = new PointF(cubePointsIn2d[3, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[3, 1] * 70 + heightMainFormLoad / 2);
        e.Graphics.DrawLine(pen, point31, point32);

        var point41 = new PointF(cubePointsIn2d[3, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[3, 1] * 70 + heightMainFormLoad / 2);
        var point42 = new PointF(cubePointsIn2d[0, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[0, 1] * 70 + heightMainFormLoad / 2);
        e.Graphics.DrawLine(pen, point41, point42);

        var point43 = new PointF(cubePointsIn2d[4, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[4, 1] * 70 + heightMainFormLoad / 2);
        var point44 = new PointF(cubePointsIn2d[5, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[5, 1] * 70 + heightMainFormLoad / 2);
        e.Graphics.DrawLine(pen, point43, point44);

        var point45 = new PointF(cubePointsIn2d[5, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[5, 1] * 70 + heightMainFormLoad / 2);
        var point46 = new PointF(cubePointsIn2d[6, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[6, 1] * 70 + heightMainFormLoad / 2);
        e.Graphics.DrawLine(pen, point45, point46);

        var point47 = new PointF(cubePointsIn2d[6, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[6, 1] * 70 + heightMainFormLoad / 2);
        var point48 = new PointF(cubePointsIn2d[7, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[7, 1] * 70 + heightMainFormLoad / 2);
        e.Graphics.DrawLine(pen, point47, point48);

        var point49 = new PointF(cubePointsIn2d[7, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[7, 1] * 70 + heightMainFormLoad / 2);
        var point410 = new PointF(cubePointsIn2d[4, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[4, 1] * 70 + heightMainFormLoad / 2);
        e.Graphics.DrawLine(pen, point49, point410);

        var point51 = new PointF(cubePointsIn2d[0, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[0, 1] * 70 + heightMainFormLoad / 2);
        var point52 = new PointF(cubePointsIn2d[4, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[4, 1] * 70 + heightMainFormLoad / 2);
        e.Graphics.DrawLine(pen, point51, point52);

        var point53 = new PointF(cubePointsIn2d[1, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[1, 1] * 70 + heightMainFormLoad / 2);
        var point54 = new PointF(cubePointsIn2d[5, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[5, 1] * 70 + heightMainFormLoad / 2);
        e.Graphics.DrawLine(pen, point53, point54);

        var point55 = new PointF(cubePointsIn2d[2, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[2, 1] * 70 + heightMainFormLoad / 2);
        var point56 = new PointF(cubePointsIn2d[6, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[6, 1] * 70 + heightMainFormLoad / 2);
        e.Graphics.DrawLine(pen, point55, point56);

        var point57 = new PointF(cubePointsIn2d[3, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[3, 1] * 70 + heightMainFormLoad / 2);
        var point58 = new PointF(cubePointsIn2d[7, 0] * 70 + widthMainFormLoad / 2,
            cubePointsIn2d[7, 1] * 70 + heightMainFormLoad / 2);
        e.Graphics.DrawLine(pen, point57, point58);
    }

    public float[,] Convert3dTo2dPoints(float[,] points3d)
    {
        var matrix2d = new float[points3d.GetLength(0), points3d.GetLength(1)];
        for (var i = 0; i < points3d.GetLength(0); i++)
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

            Refresh();
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
        var cubePoints = MatrixCube();

        DrawCube(cubePoints, rotateAgleY, rotateAgleX, e);
    }
}