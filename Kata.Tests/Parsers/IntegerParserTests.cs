using System;
using System.Collections.Generic;
using Kata.Features.BankOCR.Models;
using Kata.Features.BankOCR.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.Features.BankOCR.Tests.Parsers
{
    [TestClass]
    public class IntegerParserTests
    {
        protected IntegerParser ItemUnderTest = new IntegerParser();

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
            IntegerParserRequest request = new IntegerParserRequest()
            {
                DigitalNumbers  = new List<DigitalNumbers>()
               {
                   new DigitalNumbers()
                   {
                       Numbers = new List<DigitalNumber>()
                       {
                           new DigitalNumber()
                           {
                               Line1 = "   ",
                               Line2 = "  |",
                               Line3 = "  |"
                           },
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = " _|",
                               Line3 = "|_ "
                           },
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = " _|",
                               Line3 = " _|"
                           },
                           new DigitalNumber()
                           {
                               Line1 = "   ",
                               Line2 = "|_|",
                               Line3 = "  |"
                           },
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = "|_ ",
                               Line3 = " _|"
                           },
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = "|_ ",
                               Line3 = "|_|"
                           },
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = "  |",
                               Line3 = "  |"
                           },
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = "|_|",
                               Line3 = "|_|"
                           },
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = "|_|",
                               Line3 = " _|"
                           },
                       }
                   },
                   new DigitalNumbers()
                   {
                       Numbers = new List<DigitalNumber>()
                       {
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = "| |",
                               Line3 = "|_|"
                           },
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = " | ",
                               Line3 = "|_|"
                           },
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = "| |",
                               Line3 = "|_|"
                           },
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = "| |",
                               Line3 = "|_|"
                           },
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = "| |",
                               Line3 = "|_|"
                           },
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = "| |",
                               Line3 = "|_|"
                           },
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = "| |",
                               Line3 = "|_|"
                           },
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = "| |",
                               Line3 = "|_|"
                           },
                           new DigitalNumber()
                           {
                               Line1 = " _ ",
                               Line2 = "| |",
                               Line3 = "|_|"
                           }
                       }
                   },
               }
            };

            var expected = new IntegerParserResponse()
            {
                Numbers = new List<string>()
                {
                    "123456789",
                    "0?0000000"
                }
            };

            var actual = ItemUnderTest.Parse(request);

            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Numbers);
            Assert.IsTrue(actual.Numbers.Count == 2);

            //Check Item Values
            var expectedFirstItem = expected.Numbers[0];
            var actualFirstItem = actual.Numbers[0];
            Assert.AreEqual(expectedFirstItem, actualFirstItem);

            var expectedSecondItem = expected.Numbers[1];
            var actualSecondItem = actual.Numbers[1];
            Assert.AreEqual(expectedSecondItem, actualSecondItem);
        }
    }
}
