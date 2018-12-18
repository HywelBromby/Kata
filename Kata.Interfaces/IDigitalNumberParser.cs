using Kata.Features.BankOCR.Models;

namespace Kata.Features.BankOCR.Interfaces
{
    public interface IDigitalNumberParser
    {
        DigitalNumberParserResponse Parse(DigitalNumberParserRequest request);
    }
}