using System;
using System.Collections.Generic;
using System.Linq;
using Kata.Foundation.FileAccess.Interfaces;
using Kata.Foundation.FileAccess.Models;
using Kata.Foundation.FileAccess.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.Foundation.FileAccess.Tests
{
    /// <summary>
    /// For The Purposes of this Kata it is assumed that only valid filenames will be provided and that the files are in the correct format And that no Exception handeling is needed
    /// </summary>
    [TestClass]
    public class FileParserTests
    {
        //Using FileParser as a concretion of IFileParser
        protected IFileParser ItemUnderTest = new FileParser();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParseNullArgument()
        {
            ItemUnderTest.Parse(null);
        }

        //Obviously we would not really want to do file access tests as they could be slow.. but Meh
        [TestMethod]
        public void ParseSuccess()
        {
            var expected = new FileParserResponse()
            {
                Lines = new List<string>() {
                    " _  _  _  _  _  _  _  _  _",
                    ""
                }
            };
            
            var actual = ItemUnderTest.Parse($"..\\..\\..\\FileParserTests.txt");
            
            Assert.AreEqual(expected.Lines.ToArray()[0],actual.Lines.ToArray()[0]);
            Assert.AreEqual(expected.Lines.ToArray()[1], actual.Lines.ToArray()[1]);
        }
    }
}
