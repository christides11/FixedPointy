using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedPointy.FixedPointy.Tests
{
    [TestFixture]
    class FixVec2_MagnitudeTest
    {
        [TestCase(0, 5.5f)]
        [TestCase(1.0f, 0)]
        [TestCase(10, 7.5f)]
        [TestCase(5.0f, 20.0f)]
        public void GetMagnitude(float valL, float valR)
        {
            var fix = new FixVec2((Fix)valL, (Fix)valR);

            var magnitude = fix.GetMagnitude();

            var result = (float)magnitude;

            Assert.AreEqual(Math.Sqrt((valL*valL)+(valR*valR)), result, (Double)Fix.Epsilon);
        }

        [TestCase(0, 5.5f)]
        [TestCase(1.0f, 0)]
        [TestCase(10, 7.5f)]
        [TestCase(5.0f, 20.0f)]
        public void GetMagnitudeSquared(float valL, float valR)
        {
            var fix = new FixVec2((Fix)valL, (Fix)valR);

            var magnitude = fix.GetMagnitudeSquared();

            var result = (float)magnitude;

            Assert.AreEqual((valL * valL) + (valR * valR), result, (Double)Fix.Epsilon);
        }
    }
}