using System;
using System.Collections.Generic;
using System.Linq;
using Kata.Features.BankOCR.Parsers;
using Kata.Features.BankOCR.Servcices;
using Kata.Foundation.FileAccess.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickNDirty;

namespace QuickNDirtyTests
{
    [TestClass]
    public class UserStory1Tests
    {
        //there is probably a better place for this and a nicer way to reference it.
        private const string Filename = "..\\..\\..\\UserStory1.txt";
        private readonly List<string> _expected = new List<string>()
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

        [TestMethod]
        public void UserStory1FullTest_QuickNDirty()
        {
            var actual = QuickNDirtyParser.GetNumbers(Filename);

            TestResults(actual.ToList());

        }

        [TestMethod]
        public void UserStory1FullTest_Full_Fat()
        {
            var itemUnderTest = new BankOCRService(new FileParser(), new EntryParser(), new DigitalNumberParser(), new IntegerParser());
            
            var actual = itemUnderTest.GenerateAccountNumbers(Filename);

            TestResults(actual.ToList());
        }

        private void TestResults(List<string> actual)
        {
            Assert.AreEqual(_expected[0], actual[0]);
            Assert.AreEqual(_expected[1], actual[1]);
            Assert.AreEqual(_expected[2], actual[2]);
            Assert.AreEqual(_expected[3], actual[3]);
            Assert.AreEqual(_expected[4], actual[4]);
            Assert.AreEqual(_expected[5], actual[5]);
            Assert.AreEqual(_expected[6], actual[6]);
            Assert.AreEqual(_expected[7], actual[7]);
            Assert.AreEqual(_expected[8], actual[8]);
            Assert.AreEqual(_expected[9], actual[9]);
            Assert.AreEqual(_expected[10], actual[10]);
        }
    }
}
