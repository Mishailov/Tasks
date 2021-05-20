using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace FifthTask.Test
{
    class EqualsTest : IEqualityComparer<Vector3D>
    {
        public bool Equals(Vector3D x, Vector3D y)
        {
            if(x is null || y is null)
                return false;

            if (!x.coordinates.ToList().SequenceEqual(y.coordinates.ToList()))
                return false;
            
            return true;
        }

        public int GetHashCode(Vector3D obj)
        {
            return 0;
        }
    }
}
