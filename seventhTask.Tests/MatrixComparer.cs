using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Linq;

namespace seventhTask.Tests
{
    class MatrixComparer : IEqualityComparer<Matrix>
    {
        public bool Equals([AllowNull] Matrix x, [AllowNull] Matrix y)
        {
            if (x is null || y is null)
                return false;

            int count = 0;
            x.ProcessActionOverData((i, j) =>
            {
                if (x.Data[i, j] != y.Data[i, j])
                    count++;
            });

            if(count != 0)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode([DisallowNull] Matrix obj)
        {
            return 0;
        }
    }
}
