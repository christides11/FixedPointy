using NUnit.Framework;
using System;

namespace FixedPointy.FixedPointy.Tests
{
    [TestFixture]
    class Fix_FloatTest
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(0.1f)]
        [TestCase(-0.1f)]
        [TestCase((float)Math.PI)]
        [TestCase((float)Math.E)]
        public void ConvertToFromFix(float val)
        {
            var fix = (Fix)val;

            var result = (float)fix;

            Assert.AreEqual(val, result, (Double)Fix.Epsilon);
        }
    }
}