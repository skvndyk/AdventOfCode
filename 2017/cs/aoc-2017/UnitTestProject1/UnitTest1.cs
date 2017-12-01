using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Day1Part2_A()
        {
            string input = "1212";
            Assert.AreEqual(6, Day1.Program.Part2(input));
        }

        [TestMethod]
        public void Day1Part2_B()
        {
            string input = "1221";
            Assert.AreEqual(0, Day1.Program.Part2(input));
        }

        [TestMethod]
        public void Day1Part2_C()
        {
            string input = "123425";
            Assert.AreEqual(4, Day1.Program.Part2(input));
        }

        [TestMethod]
        public void Day1Part2_D()
        {
            string input = "123123";
            Assert.AreEqual(12, Day1.Program.Part2(input));
        }

        [TestMethod]
        public void Day1Part2_E()
        {
            string input = "12131415";
            Assert.AreEqual(4, Day1.Program.Part2(input));
        }
    }

}
