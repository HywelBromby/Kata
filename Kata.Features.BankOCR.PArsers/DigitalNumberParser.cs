using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Kata.Features.BankOCR.Interfaces;
using Kata.Features.BankOCR.Models;

namespace Kata.Features.BankOCR.Parsers
{
    public class DigitalNumberParser : IDigitalNumberParser
    {
        //TODO: Move this to a constants file...
        public const int NUMBER_OF_ITEMS_PER_LINE = 9;
        public const int CHARS_PER_NUMBER = 3;
        public DigitalNumberParserResponse Parse(DigitalNumberParserRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var response = new DigitalNumberParserResponse()
            {
                DigitalNumbers = new List<DigitalNumbers>()
            };

            foreach (var entry in request.Entries)
            {
                response.DigitalNumbers.Add(ParseEntry(entry));
            }
            
            return response;
        }

        private DigitalNumbers ParseEntry(Entry entry)
        {
            var digitalNumbers = new List<DigitalNumber>(9);
            
            for (int i = 0; i < NUMBER_OF_ITEMS_PER_LINE; i++)
            {
                int startPos = i * CHARS_PER_NUMBER;
                var digitalNumber = new DigitalNumber()
                {
                    Line1 = entry.Line1.Substring(startPos, CHARS_PER_NUMBER),
                    Line2 = entry.Line2.Substring(startPos, CHARS_PER_NUMBER),
                    Line3 = entry.Line3.Substring(startPos, CHARS_PER_NUMBER)
                };
                
                digitalNumbers.Add(digitalNumber);
            }

            var response = new DigitalNumbers()
            {
                Numbers = digitalNumbers
            };

            return response;
        }
    }

}
