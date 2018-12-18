using System.Collections.Generic;
using System.Linq;
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

        public BankOCRService(IFileParser fileParser, IEntryParser entryParser, IDigitalNumberParser digitalNumberParser, IIntegerParser inegerParser)
        {
            this.FileParser = fileParser;
            this.EntryParser = entryParser;
            this.DigitalNumberParser = digitalNumberParser;
            this.IntegerParser = inegerParser;
        }

        public IEnumerable<string> GenerateAccountNumbers(string fileName)
        {
            //read the file
            var fileParserResponse = FileParser.Parse(fileName);

            //extract the lines into entries
            var entryParserResponse = EntryParser.Parse(new EntryParserRequest() {Lines = fileParserResponse.Lines});

            //extract the digital numbers form the entries
            var digitalNumberParserResponse = DigitalNumberParser.Parse(new DigitalNumberParserRequest() {Entries = entryParserResponse.Entries});

            //convert the digital numbers to ints
            var integerParserResponse = IntegerParser.Parse(new IntegerParserRequest() {DigitalNumbers = digitalNumberParserResponse.DigitalNumbers});
            
            return integerParserResponse.Numbers ;
        }
    }
}
