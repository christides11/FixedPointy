using NUnit.Framework;
using System;

namespace FixedPointy.FixedPointy.Tests
{
    class FixTrans3_Test
    {
        [TestCase(5, 10, 15, 5, 10, 15, 5, 10, 15)]
        public void DecomposeTRSPosition(float tX, float tY, float tZ, float sX, float sY, float sZ, float rX, float rY, float rZ)
        {
            FixVec3 pos = new FixVec3((Fix)tX, (Fix)tY, (Fix)tZ);
            FixVec3 rotation = new FixVec3((Fix)rX, (Fix)rY, (Fix)rZ);
            FixVec3 scale = new FixVec3((Fix)sX, (Fix)sY, (Fix)sZ);

            FixTrans3 ft = new FixTrans3(pos, rotation, scale);

            Assert.AreEqual(ft.Position().X.raw, pos.X.raw);
            Assert.AreEqual(ft.Position().Y.raw, pos.Y.raw);
            Assert.AreEqual(ft.Position().Z.raw, pos.Z.raw);
        }

        [TestCase(5, 10, 15, 5, 10, 15, 5, 10, 15)]
        public void DecomposeTRSScale(float tX, float tY, float tZ, float sX, float sY, float sZ, float rX, float rY, float rZ)
        {
            FixVec3 pos = new FixVec3((Fix)tX, (Fix)tY, (Fix)tZ);
            FixVec3 rotation = new FixVec3((Fix)rX, (Fix)rY, (Fix)rZ);
            FixVec3 scale = new FixVec3((Fix)sX, (Fix)sY, (Fix)sZ);

            FixTrans3 ft = new FixTrans3(pos, rotation, scale);

            Assert.AreEqual(scale.X.raw, ft.Scale().X.raw);
            Assert.AreEqual(scale.Y.raw, ft.Scale().Y.raw);
            Assert.AreEqual(scale.Z.raw, ft.Scale().Z.raw);
        }

        [TestCase(5, 10, 15, 5, 10, 15, 5, 10, 15)]
        public void DecomposeTRSEulerAngle(float tX, float tY, float tZ, float sX, float sY, float sZ, float rX, float rY, float rZ)
        {
            FixVec3 pos = new FixVec3((Fix)tX, (Fix)tY, (Fix)tZ);
            FixVec3 rotation = new FixVec3((Fix)rX, (Fix)rY, (Fix)rZ);
            FixVec3 scale = new FixVec3((Fix)sX, (Fix)sY, (Fix)sZ);

            FixTrans3 ft = new FixTrans3(pos, rotation, scale);

            Assert.AreEqual(ft.EulerAngle().X.raw, rotation.X.raw);
            Assert.AreEqual(ft.EulerAngle().Y.raw, rotation.Y.raw);
            Assert.AreEqual(ft.EulerAngle().Z.raw, rotation.Z.raw);
        }
    }
}
