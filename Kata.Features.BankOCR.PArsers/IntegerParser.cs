using System;
using System.Collections.Generic;
using Kata.Features.BankOCR.Interfaces;
using Kata.Features.BankOCR.Models;

namespace Kata.Features.BankOCR.Parsers
{
    public class IntegerParser : IIntegerParser
    {
        public static readonly string InvalidNumberString = "?";
        public IntegerParserResponse Parse(IntegerParserRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var response = new IntegerParserResponse()
            {
                Numbers = new List<string>()
            };

            foreach (var entry in request.DigitalNumbers)
            {
                response.Numbers.Add(ParseEntry(entry));
            }

            return response;
        }

        private string ParseEntry(DigitalNumbers digitalNumbers)
        {
            var response = "";
            foreach (var digitalNumber in digitalNumbers.Numbers)
            {
                response += ParseNumber(digitalNumber);
            }

            return response;
        }

        private string ParseNumber(DigitalNumber digitalNumber)
        {
            var bitMask = CreateBitMask(digitalNumber);

            switch (bitMask)
            {
                case (int) BitMaskValues.zero:
                    return "0";
                case (int) BitMaskValues.one:
                    return "1";
                case (int) BitMaskValues.two:
                    return "2";
                case (int) BitMaskValues.three:
                    return "3";
                case (int) BitMaskValues.four:
                    return "4";
                case (int) BitMaskValues.five:
                    return "5";
                case (int) BitMaskValues.six:
                    return "6";
                case (int) BitMaskValues.seven:
                    return "7";
                case (int) BitMaskValues.eight:
                    return "8";
                case (int) BitMaskValues.nine:
                    return "9";
                default:
                    return InvalidNumberString;
            }
        }

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

        private static int CreateBitMask(DigitalNumber digitalNumber)
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
