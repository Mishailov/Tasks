using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace FifthTask.Test
{
    class Vector3DComparer : IEqualityComparer<Vector3D>
    {
        public bool Equals(Vector3D x, Vector3D y)
        {
            if(x is null || y is null)
                return false;

            if (!x.Coordinates.SequenceEqual(y.Coordinates))
                return false;
            
            return true;
        }

        public int GetHashCode(Vector3D obj)
        {
            return 0;
        }
    }
}
