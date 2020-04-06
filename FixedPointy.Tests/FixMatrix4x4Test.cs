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

            Fix expectedm11 = (a.m11 * b.m11) + (a.m12 * b.m21)
                + (a.m13 * b.m31) + (a.m14 * b.m41);
            Fix expectedm12 = (a.m11 * b.m12) + (a.m12 * b.m22)
                + (a.m13 * b.m32) + (a.m14 * b.m42);
            Fix expectedm13 = (a.m11 * b.m13) + (a.m12 * b.m23)
                + (a.m13 * b.m33) + (a.m14 * b.m43);
            Fix expectedm14 = (a.m11 * b.m14) + (a.m12 * b.m24)
                + (a.m13 * b.m34) + (a.m14 * b.m44);

            Fix expectedm21 = (a.m21 * b.m11) + (a.m22 * b.m21)
                + (a.m23 * b.m31) + (a.m24 * b.m41);
            Fix expectedm22 = (a.m21 * b.m12) + (a.m22 * b.m22)
                + (a.m23 * b.m32) + (a.m24 * b.m42);
            Fix expectedm23 = (a.m21 * b.m13) + (a.m22 * b.m23)
                + (a.m23 * b.m33) + (a.m24 * b.m43);
            Fix expectedm24 = (a.m21 * b.m14) + (a.m22 * b.m24)
                + (a.m23 * b.m34) + (a.m24 * b.m44);

            Fix expectedm31 = (a.m31 * b.m11) + (a.m32 * b.m21)
                + (a.m33 * b.m31) + (a.m34 * b.m41);
            Fix expectedm32 = (a.m31 * b.m12) + (a.m32 * b.m22)
                + (a.m33 * b.m32) + (a.m34 * b.m42);
            Fix expectedm33 = (a.m31 * b.m13) + (a.m32 * b.m23)
                + (a.m33 * b.m33) + (a.m34 * b.m43);
            Fix expectedm34 = (a.m31 * b.m14) + (a.m32 * b.m24)
                + (a.m33 * b.m34) + (a.m34 * b.m44);

            Fix expectedm41 = (a.m41 * b.m11) + (a.m42 * b.m21)
                + (a.m43 * b.m31) + (a.m44 * b.m41);
            Fix expectedm42 = (a.m41 * b.m12) + (a.m42 * b.m22)
                + (a.m43 * b.m32) + (a.m44 * b.m42);
            Fix expectedm43 = (a.m41 * b.m13) + (a.m42 * b.m23)
                + (a.m43 * b.m33) + (a.m44 * b.m43);
            Fix expectedm44 = (a.m41 * b.m14) + (a.m42 * b.m24)
                + (a.m43 * b.m34) + (a.m44 * b.m44);

            Assert.AreEqual(expectedm11, result.m11);
            Assert.AreEqual(expectedm12, result.m12);
            Assert.AreEqual(expectedm13, result.m13);
            Assert.AreEqual(expectedm14, result.m14);

            Assert.AreEqual(expectedm21, result.m21);
            Assert.AreEqual(expectedm22, result.m22);
            Assert.AreEqual(expectedm23, result.m23);
            Assert.AreEqual(expectedm24, result.m24);

            Assert.AreEqual(expectedm31, result.m31);
            Assert.AreEqual(expectedm32, result.m32);
            Assert.AreEqual(expectedm33, result.m33);
            Assert.AreEqual(expectedm34, result.m34);

            Assert.AreEqual(expectedm41, result.m41);
            Assert.AreEqual(expectedm42, result.m42);
            Assert.AreEqual(expectedm43, result.m43);
            Assert.AreEqual(expectedm44, result.m44);
        }
    }
}
