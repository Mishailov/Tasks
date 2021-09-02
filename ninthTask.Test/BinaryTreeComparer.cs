using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ninthTask.Test
{
    class BinaryTreeComparer : IEqualityComparer<Student>
    {
        public bool Equals([AllowNull] Student x, [AllowNull] Student y)
        {
            if (x is null || y is null)
                return false;

            if (!(/*x.EndTime == y.EndTime && */x.Mark == y.Mark
                && x.Name == y.Name && x.TestName == y.TestName))
                return false;

            return true;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return 0;
        }
    }
}
