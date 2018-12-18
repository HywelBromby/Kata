using System.Collections.Generic;

namespace Kata.Features.BankOCR.Models
{
    public class DigitalNumberParserRequest
    {
        public IEnumerable<Entry> Entries { get; set; }
    }
}
