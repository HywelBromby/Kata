using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Kata.Foundation.FileAccess.Interfaces;
using Kata.Foundation.FileAccess.Models;

namespace Kata.Foundation.FileAccess.Services
{
    public class FileParser : IFileParser
    {
        /// <summary>
        /// For The Purposes of this Kata it is assumed that only valid filenames will be provided and that the files are in the correct format
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public FileParserResponse Read(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            string[] readText = File.ReadAllLines(path);
            var fileParserResponse = new FileParserResponse()
            {
                Lines = readText.AsEnumerable()
            };

            return fileParserResponse;
        }

        public void Write(string path, IEnumerable<string> lines)
        {
            File.WriteAllLines(path,lines);
        }
    }
}
