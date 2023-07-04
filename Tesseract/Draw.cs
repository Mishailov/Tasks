namespace Tesseract;

public class Draw
{
    public int WidthMainFormLoad { get; set; }
    public int HeightMainFormLoad { get; set; }
    public float[,] Cube2dPoints { get; set; }

    private readonly PaintEventArgs e;

    public Draw(int widthMainFormLoad, int heightMainFormLoad, float[,] cube2dPoints, PaintEventArgs paintEventArgs)
    {
        WidthMainFormLoad = widthMainFormLoad;
        HeightMainFormLoad = heightMainFormLoad;
        Cube2dPoints = cube2dPoints;
        e = paintEventArgs;
    }

    public void DrawTesseract(int size)
    {
        var pen = new Pen(Color.Black, 2);

        DrawCube(size);
        DrawCube(size / 2);

        for (var i = 0; i < Cube2dPoints.GetLength(0); i++)
            e.Graphics.DrawLine(pen, Get2dPointFromCenter(Cube2dPoints, i, size),
                Get2dPointFromCenter(Cube2dPoints, i, size / 2));
    }

    private PointF Get2dPointFromCenter(float[,] points, int row, int size)
    {
        return new PointF(points[row, 0] * size + WidthMainFormLoad / 2,
            points[row, 1] * size + HeightMainFormLoad / 2);
    }

    private void DrawCube(int size)
    {
        var pen = new Pen(Color.Black, 2);

        for (var i = 0; i < Cube2dPoints.GetLength(0) - 1; i++)
        {
            if (i == 3)
            {
                e.Graphics.DrawLine(pen, Get2dPointFromCenter(Cube2dPoints, i, size),
                    Get2dPointFromCenter(Cube2dPoints, 0, size));
                e.Graphics.DrawLine(pen, Get2dPointFromCenter(Cube2dPoints, i, size),
                    Get2dPointFromCenter(Cube2dPoints, 7, size));
                continue;
            }

            if (i < 3)
                e.Graphics.DrawLine(pen, Get2dPointFromCenter(Cube2dPoints, i, size),
                    Get2dPointFromCenter(Cube2dPoints, i + 4, size));

            if (i == 6)
                e.Graphics.DrawLine(pen, Get2dPointFromCenter(Cube2dPoints, i + 1, size),
                    Get2dPointFromCenter(Cube2dPoints, 4, size));

            e.Graphics.DrawLine(pen, Get2dPointFromCenter(Cube2dPoints, i, size),
                Get2dPointFromCenter(Cube2dPoints, i + 1, size));
        }
    }
}