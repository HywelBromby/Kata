using System;
using System.Collections.Generic;
using System.Linq;
using Kata.Features.BankOCR.Interfaces;
using Kata.Features.BankOCR.Models;
using Kata.Features.BankOCR.Parsers;
using Kata.Features.BankOCR.Servcices;
using Kata.Foundation.FileAccess.Interfaces;
using Kata.Foundation.FileAccess.Models;
using Kata.Foundation.FileAccess.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Kata.Features.BankOCR.Tests.Services
{
    [TestClass]
    public class BankOCRServiceTests
    {
        protected Mock<IFileParser> _mockFileParser;
        protected Mock<IEntryParser> _mockEntryParser;
        protected Mock<IDigitalNumberParser> _mockDigitalNumberParser;
        protected Mock<IIntegerParser> _mockIntegerParser;

        private FileParserResponse ValidFileParserResponse = new FileParserResponse() {Lines = new List<string>()};
        private EntryParserResponse ValidEntryParserResponse = new EntryParserResponse(){Entries = new List<Entry>()};
        private DigitalNumberParserResponse ValidDigitalNumberParserResponse = new DigitalNumberParserResponse(){DigitalNumbers = new List<DigitalNumbers>()};
        private IntegerParserResponse ValidIntegerParserResponse = new IntegerParserResponse(){Numbers = new List<string>(){"1234?6789"}};

        protected BankOCRService ItemUnderTest;

        [TestInitialize]
        public void Init()
        {
            _mockFileParser = new Mock<IFileParser>();
            _mockFileParser.Setup(i => i.Parse(It.IsAny<string>())).Returns(ValidFileParserResponse);

            _mockEntryParser = new Mock<IEntryParser>();
            _mockEntryParser.Setup(i => i.Parse(It.IsAny<EntryParserRequest>())).Returns(ValidEntryParserResponse);

            _mockDigitalNumberParser = new Mock<IDigitalNumberParser>();
            _mockDigitalNumberParser.Setup(i => i.Parse(It.IsAny<DigitalNumberParserRequest>()))
                .Returns(ValidDigitalNumberParserResponse);

            _mockIntegerParser = new Mock<IIntegerParser>();
            _mockIntegerParser.Setup(i => i.Parse(It.IsAny<IntegerParserRequest>())).Returns(ValidIntegerParserResponse);

            ItemUnderTest = new BankOCRService(
                _mockFileParser.Object,
                _mockEntryParser.Object,
                _mockDigitalNumberParser.Object,
                _mockIntegerParser.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Parse_ArgumentNull()
        {
            ItemUnderTest.GenerateAccountNumbers(null);
        }

        [TestMethod]
        public void GetAccountNumbers_FileParserCalled()
        {
            var passedFileName = "fileName";

            ItemUnderTest.GenerateAccountNumbers(passedFileName);

            _mockFileParser.Verify(i=>i.Parse(passedFileName));
        }

        [TestMethod]
        public void GetAccountNumbers_EntryParserCalled()
        {
            ItemUnderTest.GenerateAccountNumbers("fileName");

            _mockEntryParser.Verify(i => i.Parse(It.Is<EntryParserRequest>(j=>j.Lines.Equals(ValidFileParserResponse.Lines))));
        }

        [TestMethod]
        public void GetAccountNumbers_DigitalNumberParserCalled()
        {
            ItemUnderTest.GenerateAccountNumbers("fileName");

            _mockDigitalNumberParser.Verify(i => i.Parse(It.Is<DigitalNumberParserRequest>(j => j.Entries.Equals(ValidEntryParserResponse.Entries))));
        }

        [TestMethod]
        public void GetAccountNumbers_IntegerParserCalled()
        {
            ItemUnderTest.GenerateAccountNumbers("fileName");

            _mockIntegerParser.Verify(i => i.Parse(It.Is<IntegerParserRequest>(j => j.DigitalNumbers.Equals(ValidDigitalNumberParserResponse.DigitalNumbers))));
        }
        
    }
}
