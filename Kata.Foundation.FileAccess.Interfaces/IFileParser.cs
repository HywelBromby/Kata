using Kata.Foundation.FileAccess.Models;

namespace Kata.Foundation.FileAccess.Interfaces
{
    public interface IFileParser
    {
        FileParserResponse Parse(string FileName);
    }

}
