using System.Collections.Generic;

namespace Kata.Features.BankOCR.Models
{
    public class EntryParserRequest
    {
        public IEnumerable<string> Lines { get; set; }
    }
}
