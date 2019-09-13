using NUnit.Framework;

namespace FixedPointy.FixedPointy.Tests
{
    [TestFixture]
    class Fix_IntTest
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(-100)]
        public void ConvertToFromFix(int val)
        {
            var fix = (Fix)val;

            var result = (int)fix;

            Assert.AreEqual(val, result, 0);
        }
    }
}
