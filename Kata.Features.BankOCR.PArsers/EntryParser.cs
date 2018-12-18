using System;
using System.Collections.Generic;
using System.Linq;
using Kata.Features.BankOCR.Interfaces;
using Kata.Features.BankOCR.Models;

namespace Kata.Features.BankOCR.Parsers
{
    public class EntryParser : IEntryParser
    {
        public const int LINES_PER_ITEM = 4;

        public EntryParserResponse Parse(EntryParserRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var lines = request.Lines.ToArray();
            var linesCount = lines.Count();
            var entryCount = linesCount / LINES_PER_ITEM;

            var response = new EntryParserResponse()
            {
                Entries = new List<Entry>()
            };

            for (int i = 0; i < entryCount; i++)
            {
                var startPos = i * LINES_PER_ITEM;

                var entry = new Entry()
                {
                    Line1 = lines[startPos],
                    Line2 = lines[startPos + 1],
                    Line3 = lines[startPos + 2],
                    Line4 = lines[startPos + 3]
                };
                response.Entries.Add(entry);
            }

            return response;
        }
    }

}
