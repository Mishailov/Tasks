using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace FifthTask
{
    public class Vector3D
    {
        private List<double> coordinates = new List<double>();

        public Vector3D(double x, double y, double z)
        {
            coordinates.Add(x);
            coordinates.Add(y);
            coordinates.Add(z);
        }    

        public Vector3D Add(Vector3D vector)
        {
            return this + vector;
        }

        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            var sumList = vector1.coordinates.Zip(vector2.coordinates, (first, second) => first + second).ToList();

            return new Vector3D(sumList[0], sumList[1], sumList[2]);
        }

        public Vector3D Subtract(Vector3D vector)
        {
            return this - vector;
        }

        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            var subtractList = vector1.coordinates.Zip(vector2.coordinates, (first, second) => first - second).ToList();

            return new Vector3D(subtractList[0], subtractList[1], subtractList[2]);
        }

        public Vector3D ScalarMultiplication(double scalar)
        {
            var scalarMultList = this.coordinates.Select(x => x * scalar).ToList();

            return new Vector3D(scalarMultList[0], scalarMultList[1], scalarMultList[2]);
        }

        public Vector3D Multiply(Vector3D vector)
        {
            return this * vector;
        }

        public static Vector3D operator *(Vector3D vector1, Vector3D vector2)
        {
            Vector3 firstVector = new Vector3((float)vector1.coordinates[0], (float)vector1.coordinates[1], (float)vector1.coordinates[2]);
            Vector3 secondVector = new Vector3((float)vector2.coordinates[0], (float)vector2.coordinates[1], (float)vector2.coordinates[2]);

            var vector = Vector3.Cross(firstVector, secondVector);

            return new Vector3D(vector.X, vector.Y, vector.Z);
            //List<double> mult = new List<double>();

            ////foreach in foreach is not a good idea, i know that)
            ////but this logic has the right to life, i think)
            //foreach (var item in vector1.coordinates)
            //{
            //    var list = vector2.coordinates.Where(x => vector2.coordinates.IndexOf(x) 
            //        != vector1.coordinates.IndexOf(item)).Select(x => x * item).ToList();
            //    foreach(var moreItems in list)
            //    {
            //        mult.Add(moreItems);
            //    }
            //}

            ////this hard code only for check
            //mult.Add(mult[0] - mult[2]);
            //mult.Add(mult[4] - mult[1]);
            //mult.Add(mult[3] - mult[5]);
            //mult.RemoveRange(0, 6);
            //return new Vector3D(mult[0], mult[1], mult[2]);
            //return new Vector3D((vector1._y * vector2._z) - (vector1._z * vector2._y)
            //    , (vector1._z * vector2._x) - (vector1._x * vector2._z)
            //    , (vector1._x * vector2._y) - (vector1._y * vector2._x));
        }

        public override string ToString()
        {
            return string.Format("X:{0}, Y:{1}, Z:{2}", coordinates[0], coordinates[1], coordinates[2]);
        }

        public override bool Equals(object obj)
        {
            Vector3D vector = obj as Vector3D;
            if (vector != null && vector.coordinates.ToList().SequenceEqual(this.coordinates.ToList()))
                return true;

            return false;
        }
    }
}
