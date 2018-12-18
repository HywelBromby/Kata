using System;
using System.Collections.Generic;
using System.IO;

namespace QuickNDirty
{
    [Obsolete]
    public class QuickNDirtyParser
    {
        private const int linesPerItem = 4;
        private const int numberOfItemsPerLine = 9;
        private const int charsPerNumber = 3;

        private enum BitMaskValues
        {
            zero = 490,
            one = 288,
            two = 242,
            three = 434,
            four = 312,
            five = 410,
            six = 474,
            seven = 290,
            eight = 506,
            nine = 442
        }

        [Obsolete]
        public static List<string> GetNumbers(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            return ParseLines(lines);
        }

        private static List<string> ParseLines(string[] lines)
        {
            List<string> response = new List<string>();
            for (int lineNumber = 0; lineNumber < lines.Length / linesPerItem; lineNumber++)
            {
                response.Add(ParseLine(lines, lineNumber));
            }

            return response;
        }

        private static string ParseLine(string[] lines, int lineNumber)
        {
            var response = "";

            var startPos = lineNumber * linesPerItem;
            var entry = new
            {
                Line1 = lines[startPos],
                Line2 = lines[startPos + 1],
                Line3 = lines[startPos + 2],
            };
            
            for (int digitNumber = 0; digitNumber < numberOfItemsPerLine; digitNumber++)
            {
                response += ParseEntry(entry,digitNumber);
            }

            return response;
        }

        private static string ParseEntry(dynamic entry,int digitNumber)
        {
            int startPos2 = digitNumber * charsPerNumber;
            var digitalNumber = new
            {
                Line1 = entry.Line1.Substring(startPos2, charsPerNumber),
                Line2 = entry.Line2.Substring(startPos2, charsPerNumber),
                Line3 = entry.Line3.Substring(startPos2, charsPerNumber)
            };

            return ParseNumber(digitalNumber);
        }

        private static string ParseNumber(dynamic digitalNumber)
        {
            var bitMask = CreateBitMask(digitalNumber);

            switch (bitMask)
            {
                case (int)BitMaskValues.zero:
                    return "0";
                case (int)BitMaskValues.one:
                    return "1";
                case (int)BitMaskValues.two:
                    return "2";
                case (int)BitMaskValues.three:
                    return "3";
                case (int)BitMaskValues.four:
                    return "4";
                case (int)BitMaskValues.five:
                    return "5";
                case (int)BitMaskValues.six:
                    return "6";
                case (int)BitMaskValues.seven:
                    return "7";
                case (int)BitMaskValues.eight:
                    return "8";
                case (int)BitMaskValues.nine:
                    return "9";
                default:
                    return "?";
            }
        }

      

        private static int CreateBitMask(dynamic digitalNumber)
        {
            int bitMask = 0;
            //create a bit mask

            bitMask += digitalNumber.Line1.Substring(0, 1) == "|" ? 1 : 0;
            bitMask += digitalNumber.Line1.Substring(1, 1) == "_" ? 2 : 0;
            bitMask += digitalNumber.Line1.Substring(2, 1) == "|" ? 4 : 0;

            bitMask += digitalNumber.Line2.Substring(0, 1) == "|" ? 8 : 0;
            bitMask += digitalNumber.Line2.Substring(1, 1) == "_" ? 16 : 0;
            bitMask += digitalNumber.Line2.Substring(2, 1) == "|" ? 32 : 0;

            bitMask += digitalNumber.Line3.Substring(0, 1) == "|" ? 64 : 0;
            bitMask += digitalNumber.Line3.Substring(1, 1) == "_" ? 128 : 0;
            bitMask += digitalNumber.Line3.Substring(2, 1) == "|" ? 256 : 0;
            return bitMask;
        }
    }
}
