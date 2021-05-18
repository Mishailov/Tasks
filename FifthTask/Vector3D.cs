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
            List<double> sum = new List<double>();
            int index = 0;
            foreach (var item in vector1.coordinates)
            {
                sum.Add(item + vector2.coordinates[index]);
                index++;
            }
            return new Vector3D(sum[0], sum[1], sum[2]);
        }

        public Vector3D Subtract(Vector3D vector)
        {
            return this - vector;
        }

        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            List<double> subtract = new List<double>();
            int index = 0;
            foreach (var item in vector1.coordinates)
            {
                subtract.Add(item - vector2.coordinates[index]);
                index++;
            }
            return new Vector3D(subtract[0], subtract[1], subtract[2]);
        }

        public Vector3D Multiply(Vector3D vector)
        {
            return this * vector;
        }

        public static Vector3D operator *(Vector3D vector1, Vector3D vector2)
        {
            List<double> mult = new List<double>();

            //foreach in foreach is not a good idea, i know that)
            //but this logic has the right to life, i think)
            foreach (var item in vector1.coordinates)
            {
                var list = vector2.coordinates.Where(x => vector2.coordinates.IndexOf(x) 
                    != vector1.coordinates.IndexOf(item)).Select(x => x * item).ToList();
                foreach(var moreItems in list)
                {
                    mult.Add(moreItems);
                }
            }

            //this hard code only for check
            mult.Add(mult[0] - mult[2]);
            mult.Add(mult[4] - mult[1]);
            mult.Add(mult[3] - mult[5]);
            mult.RemoveRange(0, 6);
            return new Vector3D(mult[0], mult[1], mult[2]);
            //return new Vector3D((vector1._y * vector2._z) - (vector1._z * vector2._y)
            //    , (vector1._z * vector2._x) - (vector1._x * vector2._z)
            //    , (vector1._x * vector2._y) - (vector1._y * vector2._x));
        }

        public override string ToString()
        {
            return string.Format("X:{0}, Y:{1}, Z:{2}", coordinates[0], coordinates[1], coordinates[2]);
        }
    }
}
