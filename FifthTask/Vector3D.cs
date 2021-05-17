using System;
using System.Collections.Generic;
using System.Text;

namespace FifthTask
{
    public class Vector3D
    {
        private double _x;
        private double _y;
        private double _z;

        public Vector3D(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }    

        public Vector3D Add(Vector3D vector)
        {
            return this + vector;
            //return new Vector3D(_x + vector._x, _y + vector._y, _z + vector._z);
        }

        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1._x + vector2._x, vector1._y + vector2._y, vector1._z + vector2._z);
        }

        public Vector3D Subtract(Vector3D vector)
        {
            return this - vector;
            //return new Vector3D(_x - vector._x, _y - vector._y, _z - vector._z);
        }

        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1._x - vector2._x, vector1._y - vector2._y, vector1._z - vector2._z);
        }

        public Vector3D Multiply(Vector3D vector)
        {
            return this * vector;
            //return new Vector3D((_y * vector._z) - (_z * vector._y)
            //    , (_z * vector._x) - (_x * vector._z)
            //    , (_x * vector._y) - (_y * vector._x));
        }

        public static Vector3D operator *(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D((vector1._y * vector2._z) - (vector1._z * vector2._y)
                , (vector1._z * vector2._x) - (vector1._x * vector2._z)
                , (vector1._x * vector2._y) - (vector1._y * vector2._x));
        }

        public override string ToString()
        {
            return string.Format("X:{0}, Y:{1}, Z:{2}", _x, _y, _z);
        }
    }
}
