namespace Tesseract;

public partial class Main : Form
{
    private int widthMainFormLoad;
    private int heightMainFormLoad;

    private double rotateAngleX;
    private double startPositionX;

    private double rotateAngleY;
    private double startPositionY;

    private bool isButtonPressed;

    private int size = 50;

    private Cube cube = new(2.0f);

    private Isometric isometric = new Isometric(0, 0, new float[,] { { 0, 0, 0 } });

    private Draw draw;

    public Main()
    {
        InitializeComponent();
        this.pictureBox1.MouseWheel += PictureBox1_MouseWheel;
    }

    private void PictureBox1_MouseWheel(object? sender, MouseEventArgs e)
    {
        if (e.Delta > 0)
        {
            size += 5;
        }
        else
        {
            size -= 5;
        }

        Refresh();
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (isButtonPressed)
        {
            rotateAngleX += e.X - startPositionX;
            startPositionX = e.X;

            rotateAngleY -= e.Y - startPositionY;
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
        var cubePoints = cube.GetCube();
        isometric.DegreeX = rotateAngleX;
        isometric.DegreeY = rotateAngleY;
        isometric.Point3D = cubePoints;

        draw = new Draw(widthMainFormLoad, heightMainFormLoad, isometric.GetCube2dPoints(cubePoints), e);

        draw.DrawTesseract(size);
    }
}