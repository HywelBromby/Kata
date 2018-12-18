using System;
using System.Collections.Generic;
using System.Linq;
using Kata.Features.BankOCR.Models;
using Kata.Features.BankOCR.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.Features.BankOCR.Tests.Parsers
{
    [TestClass]
    public class DigitalNumberParserTests
    {
        protected DigitalNumberParser ItemUnderTest = new DigitalNumberParser();

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
        public void Parse_TwoEntries_Successfully()
        {
            DigitalNumberParserRequest request = new DigitalNumberParserRequest()
            {
                Entries = new List<Entry>()
                {
                    new Entry()
                    {
                        Line1 = " _  _  _  _  _  _  _  _  _ ",
                        Line2 = "| || || || || || || || || |",
                        Line3 = "|_||_||_||_||_||_||_||_||_|",
                        Line4 = ""
                    },
                    new Entry()
                    {
                        Line1 = "    _  _     _  _  _  _  _ ",
                        Line2 = "  | _| _||_||_ |_   ||_||_|",
                        Line3 = "  ||_  _|  | _||_|  ||_| _|",
                        Line4 = ""
                    }
                }
            };

            var expected = new DigitalNumberParserResponse()
            {
               DigitalNumbers = new List<DigitalNumbers>()
               {
                   new DigitalNumbers()
                   {
                       Numbers = new List<DigitalNumber>()
                       {
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = "| |",
                               Line3 = "|_|"
                           }
                       }
                   },
                   new DigitalNumbers()
                   {
                       Numbers = new List<DigitalNumber>()
                       {
                           new DigitalNumber()
                           {
                               Line1 = "   ",
                               Line2 = "  |",
                               Line3 = "  |"
                           }
                       }
                   },
               }
            };
            
            var actual = ItemUnderTest.Parse(request);

            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.DigitalNumbers);
            Assert.IsTrue(actual.DigitalNumbers.Count == 2);

            //Check Item Values
            var expectedFirstItem = expected.DigitalNumbers.ToArray()[0].Numbers.ToArray()[0];
            var actualFirstItem = actual.DigitalNumbers[0].Numbers.ToArray()[0];
            Assert.AreEqual(expectedFirstItem.Line1, actualFirstItem.Line1);
            Assert.AreEqual(expectedFirstItem.Line2, actualFirstItem.Line2);
            Assert.AreEqual(expectedFirstItem.Line3, actualFirstItem.Line3);


            var expectedSecondItem = expected.DigitalNumbers.ToArray()[1].Numbers.ToArray()[0];
            var actualSecondItem = actual.DigitalNumbers[1].Numbers.ToArray()[0];
            Assert.AreEqual(expectedSecondItem.Line1, actualSecondItem.Line1);
            Assert.AreEqual(expectedSecondItem.Line2, actualSecondItem.Line2);
            Assert.AreEqual(expectedSecondItem.Line3, actualSecondItem.Line3);
        }
    }
}
