using Kata.Features.BankOCR.Models;

namespace Kata.Features.BankOCR.Interfaces
{
    public interface IIntegerParser
    {
        IntegerParserResponse Parse(IntegerParserRequest request);
    }
}