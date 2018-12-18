using System;
using System.Collections.Generic;
using System.Linq;
using Kata.Featres.CheckSum.Interfaces;
using Kata.Features.BankOCR.Interfaces;
using Kata.Features.BankOCR.Models;
using Kata.Foundation.FileAccess.Interfaces;

namespace Kata.Features.BankOCR.Servcices
{
    public class BankOCRService : IBankOCRService
    {
        private readonly IFileParser FileParser;
        private readonly IEntryParser EntryParser;
        private readonly IDigitalNumberParser DigitalNumberParser;
        private readonly IIntegerParser IntegerParser;
        private readonly ICheckSumHelper _checkSumService;
        
        public BankOCRService(IFileParser fileParser, IEntryParser entryParser, IDigitalNumberParser digitalNumberParser, IIntegerParser inegerParser, ICheckSumHelper checkSumService)
        {
            this.FileParser = fileParser;
            this.EntryParser = entryParser;
            this.DigitalNumberParser = digitalNumberParser;
            this.IntegerParser = inegerParser;
            _checkSumService = checkSumService;
        }

        public IEnumerable<string> GenerateAccountNumbers(string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            //read the file
            var fileParserResponse = FileParser.Read(fileName);

            //extract the lines into entries
            var entryParserResponse = EntryParser.Parse(new EntryParserRequest() {Lines = fileParserResponse.Lines});

            //extract the digital numbers form the entries
            var digitalNumberParserResponse = DigitalNumberParser.Parse(new DigitalNumberParserRequest() {Entries = entryParserResponse.Entries});

            //convert the digital numbers to ints
            var integerParserResponse = IntegerParser.Parse(new IntegerParserRequest() {DigitalNumbers = digitalNumberParserResponse.DigitalNumbers});

            var formatedNumbers = integerParserResponse.Numbers.Select(i => _checkSumService.Format(i)).ToList();
            
            FileParser.Write(fileName+".out", formatedNumbers);

            return formatedNumbers;
        }
    }
}
