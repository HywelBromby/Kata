using Kata.Features.BankOCR.Models;

namespace Kata.Features.BankOCR.Interfaces
{
    public interface IEntryParser
    {
        EntryParserResponse Parse(EntryParserRequest request);
    }
}