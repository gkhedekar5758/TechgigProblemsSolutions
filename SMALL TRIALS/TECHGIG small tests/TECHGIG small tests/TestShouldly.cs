using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace TECHGIG_small_tests
{
    [TestClass]
    public class TestShouldly
    {
        [TestMethod]
        public void Test_ShouldBe()
        {
            string actual = "actual";
            string expected = "expected";

            actual.ShouldBe(expected, true);
        }
    }
}
