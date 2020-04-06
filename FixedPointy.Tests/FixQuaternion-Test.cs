using NUnit.Framework;
using System;

namespace FixedPointy.FixedPointy.Tests
{
    class FixQuaternion_Test
    {
        // You are not guarenteed to get the same euler back, but you should get the same
        // Quaternion when you convert it back.
        [TestCase(0, 0, 0)]
        [TestCase(1, 1, 1)]
        [TestCase(100, 1, 1)]
        [TestCase(1, 100, 1)]
        [TestCase(1, 1, 100)]
        [TestCase(100, 100, 100)]
        public void EulerForwardBack(int x, int y, int z)
        {
            FixQuaternion quat = new FixQuaternion(new FixVec3(x, y, z));

            FixVec3 fv = FixQuaternion.ToEuler(quat);

            FixQuaternion final = new FixQuaternion(fv);

            Assert.AreEqual(final.x.raw, quat.x.raw);
            Assert.AreEqual(final.y.raw, quat.y.raw);
            Assert.AreEqual(final.z.raw, quat.z.raw);
            Assert.AreEqual(final.w.raw, quat.w.raw);
        }
    }
}
