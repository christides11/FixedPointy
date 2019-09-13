using NUnit.Framework;
using System;

namespace FixedPointy.FixedPointy.Tests
{
    [TestFixture]
    class Fix_DoubleTest
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(0.1)]
        [TestCase(-0.1)]
        [TestCase(Math.PI)]
        [TestCase(Math.E)]
        public void ConvertToFromFix(double val)
        {
            var fix = (Fix)val;

            var result = (double)fix;

            Assert.AreEqual(val, result, (Double)Fix.Epsilon);
        }
    }
}
