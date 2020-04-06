using NUnit.Framework;
using System;

namespace FixedPointy.FixedPointy.Tests
{
    [TestFixture]
    public class FixMatrix4x4Test
    {
        [TestCase(
            9,  1,  3, 8,
            10, 15, 1, 8,
            4,   4, 2, 8,
            10,  9, 2, 20)]
        public void MultiplyMatrixes(
            int m00, int m01, int m02, int m03,
            int m10, int m11, int m12, int m13,
            int m20, int m21, int m22, int m23,
            int m30, int m31, int m32, int m33)
        {
            FixMatrix4x4 a = new FixMatrix4x4(
                    4, 0, 8, 0,
                    0, 2, 2, 1,
                    8, 0, 5, 3,
                    6, 0, 4, 2
                );

            FixMatrix4x4 b = new FixMatrix4x4(
                    m00, m01, m02, m03,
                    m10, m11, m12, m13,
                    m20, m21, m22, m23,
                    m30, m31, m32, m33
                );

            FixMatrix4x4 result = a * b;

            Fix expectedm00 = (a.m11 * b.m11) + (a.m12 * b.m21)
                + (a.m13 * b.m31) + (a.m14 * b.m41);
            Fix expectedm01 = (a.m11 * b.m12) + (a.m12 * b.m22)
                + (a.m13 * b.m32) + (a.m14 * b.m42);

            Assert.AreEqual(expectedm00, result.m11);
        }
    }
}
