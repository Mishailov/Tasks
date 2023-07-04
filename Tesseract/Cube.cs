using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesseract
{
    public class Cube
    {
        public float SideLength { get; set; }

        public Cube(float sideLength)
        {
            SideLength = sideLength;
        }

        public float[,] GetCube()
        {
            var pointPosition = SideLength / 2;

            return new [,]
            {
                {-pointPosition, -pointPosition, -pointPosition},
                {pointPosition, -pointPosition, -pointPosition},
                {pointPosition, pointPosition, -pointPosition},
                {-pointPosition, pointPosition, -pointPosition},
                {-pointPosition, -pointPosition, pointPosition},
                {pointPosition, -pointPosition, pointPosition},
                {pointPosition, pointPosition, pointPosition},
                {-pointPosition, pointPosition, pointPosition}
            };
        }
    }
}
