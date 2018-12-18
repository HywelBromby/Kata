using Kata.Featres.CheckSum.Interfaces;
using System;

namespace Kata.Featres.CheckSum.Services
{
    public class CheckSumHelper : ICheckSumHelper
    {
        private const int StringLength = 9;
        private const int InvalidCheckSumValue = -1;
        
        /// <summary>
        /// account number:  3  4  5  8  8  2  8  6  5
        /// position names:  d9 d8 d7 d6 d5 d4 d3 d2 d1
        /// checksum calculation:
        /// ((1*d1) + (2*d2) + (3*d3) + ... + (9*d9)) mod 11 == 0
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool IsValidCheckSum(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException(nameof(number));
            }

            if (number.Length != StringLength)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            var calculatedCheckSum = CalculateCheckSum(number);
           
          
            return calculatedCheckSum == 0;
        }
        
        public string Format(string line, string invalidNumber= "?")
        {
            if (line.Contains(invalidNumber))
            {
                return line + " ILL";
            }

            if (!this.IsValidCheckSum(line))
            {
                return line + " ERR";
            }

            return line;
        }

        private static int CalculateCheckSum(string number)
        {
            int total = 0;

            // calculate ((1*d1) + (2*d2) + (3*d3) + ... + (9*d9))
            for (int i = 0; i < StringLength; i++)
            {
                if (int.TryParse(number.Substring(i, 1), out int currentNumber))
                {
                    total += currentNumber * (StringLength - i);
                }
                else
                {
                    return InvalidCheckSumValue;
                }
            }

            var calculatedCheckSum = total % 11;
            return calculatedCheckSum;
        }
    }
}
