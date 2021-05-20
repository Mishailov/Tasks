using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace FifthTask
{
    public class Vector3D
    {
        private List<double> _coordinates = new List<double>();

        public List<double> coordinates{
            get
            {
                return _coordinates;
            }

            set
            {
                _coordinates = value;
            }       
        }

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

        public Vector3D ScalarMultiplicationOnPrimitiveValue(double scalar)
        {
            return this * scalar;
        }

        public static Vector3D operator *(Vector3D vector, double scalar)
        {
            var scalarMultList = vector.coordinates.Select(x => x * scalar).ToList();

            return new Vector3D(scalarMultList[0], scalarMultList[1], scalarMultList[2]);
        }

        public double ScalarMultiplicationOnVector(Vector3D vector)
        {
            return this * vector;
        }

        public static double operator *(Vector3D vector1, Vector3D vector2)
        {
            var scalarMult = vector1.coordinates.Zip(vector2.coordinates, (first, second) => first * second).Sum();

            return scalarMult;
        }

        public Vector3D Multiply(Vector3D vector)
        {
            return this ^ vector;
        }

        public static Vector3D operator ^(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D((vector1.coordinates[1] * vector2.coordinates[2])
                - (vector1.coordinates[2] * vector2.coordinates[1])
                , (vector1.coordinates[2] * vector2.coordinates[0])
                - (vector1.coordinates[0] * vector2.coordinates[2])
                , (vector1.coordinates[0] * vector2.coordinates[1])
                - (vector1.coordinates[1] * vector2.coordinates[0]));
        }
    }
}
