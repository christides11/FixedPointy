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

            Assert.AreEqual(ft.Position().x.raw, pos.x.raw);
            Assert.AreEqual(ft.Position().y.raw, pos.y.raw);
            Assert.AreEqual(ft.Position().z.raw, pos.z.raw);
        }

        [TestCase(5, 10, 15, 5, 10, 15, 5, 10, 15)]
        public void DecomposeTRSScale(float tX, float tY, float tZ, float sX, float sY, float sZ, float rX, float rY, float rZ)
        {
            FixVec3 pos = new FixVec3((Fix)tX, (Fix)tY, (Fix)tZ);
            FixVec3 rotation = new FixVec3((Fix)rX, (Fix)rY, (Fix)rZ);
            FixVec3 scale = new FixVec3((Fix)sX, (Fix)sY, (Fix)sZ);

            FixTrans3 ft = new FixTrans3(pos, rotation, scale);

            Assert.AreEqual(scale.x.raw, ft.Scale().x.raw);
            Assert.AreEqual(scale.y.raw, ft.Scale().y.raw);
            Assert.AreEqual(scale.z.raw, ft.Scale().z.raw);
        }

        [TestCase(5, 10, 15, 5, 10, 15, 5, 10, 15)]
        public void DecomposeTRSEulerAngle(float tX, float tY, float tZ, float sX, float sY, float sZ, float rX, float rY, float rZ)
        {
            FixVec3 pos = new FixVec3((Fix)tX, (Fix)tY, (Fix)tZ);
            FixVec3 rotation = new FixVec3((Fix)rX, (Fix)rY, (Fix)rZ);
            FixVec3 scale = new FixVec3((Fix)sX, (Fix)sY, (Fix)sZ);

            FixTrans3 ft = new FixTrans3(pos, rotation, scale);

            Assert.AreEqual(ft.EulerAngle().x.raw, rotation.x.raw);
            Assert.AreEqual(ft.EulerAngle().y.raw, rotation.y.raw);
            Assert.AreEqual(ft.EulerAngle().z.raw, rotation.z.raw);
        }
    }
}