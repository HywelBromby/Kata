using Kata.Featres.CheckSum.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.Featres.CheckSum.Tests
{
    [TestClass]
    public class CheckSumHelperTests
    {
        private CheckSumHelper ItemUnderTest = new CheckSumHelper();

        [TestMethod]
        public void IsValidCheckSum_Valid()
        {
            var validNumber = "457508000";
            var expected = true;

            var actual = ItemUnderTest.IsValidCheckSum(validNumber);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsValidCheckSum_InValid()
        {
            var validNumber = "664371495";
            var expected = false;

            var actual = ItemUnderTest.IsValidCheckSum(validNumber);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsValidCheckSum_HandlesIllDefiendNumber()
        {
            var validNumber = "6643?1495";
            var expected = false;

            var actual = ItemUnderTest.IsValidCheckSum(validNumber);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsValidCheckSum_ValidExtras()
        {
            var expected = true;

            var actual = ItemUnderTest.IsValidCheckSum("711111111");
            actual &= ItemUnderTest.IsValidCheckSum("123456789");
            actual &= ItemUnderTest.IsValidCheckSum("490867715");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsValidCheckSum_InValidExtras()
        {
            var expected = false;

            var actual = ItemUnderTest.IsValidCheckSum("888888888");
            actual |= ItemUnderTest.IsValidCheckSum("490067715");
            actual |= ItemUnderTest.IsValidCheckSum("012345678");

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Format_ValidNumber()
        {
            var expected = "711111111";

            var actual = ItemUnderTest.Format("711111111");
          

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_IllFormedNumber()
        {
            var expected = "?11111111 ILL";

            var actual = ItemUnderTest.Format("?11111111");


            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_InValidNumber()
        {
            var expected = "111111111 ERR";

            var actual = ItemUnderTest.Format("111111111");


            Assert.AreEqual(expected, actual);
        }


    }
}
