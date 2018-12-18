using System.Collections.Generic;

namespace Kata.Features.BankOCR.Interfaces
{
    public interface IBankOCRService
    {
        IEnumerable<string> GenerateAccountNumbers(string fileName);
    }
}
