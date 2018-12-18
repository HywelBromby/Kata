using System.Collections.Generic;
using System.Linq;
using Kata.Featres.CheckSum.Services;
using Kata.Features.BankOCR.Parsers;
using Kata.Features.BankOCR.Servcices;
using Kata.Foundation.FileAccess.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickNDirty;

namespace QuickNDirtyTests
{
    [TestClass]
    public class TopLevelTests
    {
        //there is probably a better place for this and a nicer way to reference it.
        private const string Filename = "..\\..\\..\\Example.txt";
      
        [TestMethod]
        public void UserStory1FullTest_QuickNDirty()
        {
            var expected = new List<string>()
            {
                "000000000",
                "111111111",
                "222222222",
                "333333333",
                "444444444",
                "555555555",
                "666666666",
                "777777777",
                "888888888",
                "999999999",
                "123456789"
            };
            var actual = QuickNDirtyParser.GetNumbers(Filename).ToArray();

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
            Assert.AreEqual(expected[4], actual[4]);
            Assert.AreEqual(expected[5], actual[5]);
            Assert.AreEqual(expected[6], actual[6]);
            Assert.AreEqual(expected[7], actual[7]);
            Assert.AreEqual(expected[8], actual[8]);
            Assert.AreEqual(expected[9], actual[9]);
            Assert.AreEqual(expected[10], actual[10]);

        }

        [TestMethod]
        public void UserStory1FullTest_Full_Fat()
        {
            var expected = new List<string>()
            {
                "000000000",
                "111111111 ERR",
                "222222222 ERR",
                "333333333 ERR",
                "444444444 ERR",
                "555555555 ERR",
                "666666666 ERR",
                "777777777 ERR",
                "888888888 ERR",
                "999999999 ERR",
                "123456789"
            };

            var itemUnderTest = new BankOCRService(new FileParser(), new EntryParser(), new DigitalNumberParser(), new IntegerParser(), new CheckSumHelper());
            
            var actual = itemUnderTest.GenerateAccountNumbers(Filename).ToArray();
            
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
            Assert.AreEqual(expected[4], actual[4]);
            Assert.AreEqual(expected[5], actual[5]);
            Assert.AreEqual(expected[6], actual[6]);
            Assert.AreEqual(expected[7], actual[7]);
            Assert.AreEqual(expected[8], actual[8]);
            Assert.AreEqual(expected[9], actual[9]);
            Assert.AreEqual(expected[10], actual[10]);
        }
    }
}
