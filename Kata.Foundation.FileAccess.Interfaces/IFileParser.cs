using System.Collections.Generic;
using Kata.Foundation.FileAccess.Models;

namespace Kata.Foundation.FileAccess.Interfaces
{
    public interface IFileParser
    {
        FileParserResponse Read(string path);

        void Write(string path, IEnumerable<string> lines);
    }

}
