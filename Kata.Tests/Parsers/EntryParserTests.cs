using System;
using System.Collections.Generic;
using Kata.Features.BankOCR.Models;
using Kata.Features.BankOCR.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.Features.BankOCR.Tests.Parsers
{
    [TestClass]
    public class EntryParserTests
    {
        protected EntryParser ItemUnderTest = new EntryParser();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Parse_ArgumentNull()
        {
            ItemUnderTest.Parse(null);
        }

        /// <summary>
        /// Could parse 0 and 1 as extra tests
        /// </summary>
        [TestMethod]
        public void Parse_TwoLine_Successfully()
        {
            EntryParserRequest request = new EntryParserRequest()
            {
                Lines = new List<string>()
                {
                    "1",
                    "2",
                    "3",
                    "4",
                    "5",
                    "6",
                    "7",
                    "8"
                }
            };

            var expected = new EntryParserResponse()
            {
                Entries = new List<Entry>()
                {
                    new Entry()
                    {
                        Line1 = "1",
                        Line2 = "2",
                        Line3 = "3",
                        Line4 = "4"
                    },
                    new Entry()
                    {
                        Line1 = "5",
                        Line2 = "6",
                        Line3 = "7",
                        Line4 = "8"
                    }
                }
            };
            
            var actual = ItemUnderTest.Parse(request);

            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Entries);
            Assert.IsTrue(actual.Entries.Count==2);

            //Check Item Values
            var expectedFirstItem = expected.Entries.ToArray()[0];
            var actualFirstItem = actual.Entries[0];
            Assert.AreEqual(expectedFirstItem.Line1, actualFirstItem.Line1);
            Assert.AreEqual(expectedFirstItem.Line2, actualFirstItem.Line2);
            Assert.AreEqual(expectedFirstItem.Line3, actualFirstItem.Line3);
            Assert.AreEqual(expectedFirstItem.Line4, actualFirstItem.Line4);

            var expectedSecondItem = expected.Entries.ToArray()[1];
            var actualSecondItem = actual.Entries[1];
            Assert.AreEqual(expectedSecondItem.Line1, actualSecondItem.Line1);
            Assert.AreEqual(expectedSecondItem.Line2, actualSecondItem.Line2);
            Assert.AreEqual(expectedSecondItem.Line3, actualSecondItem.Line3);
            Assert.AreEqual(expectedSecondItem.Line4, actualSecondItem.Line4);

        }
    }
}
