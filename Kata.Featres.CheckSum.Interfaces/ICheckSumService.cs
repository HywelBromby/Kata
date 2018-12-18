using System;

namespace Kata.Featres.CheckSum.Interfaces
{
    public interface ICheckSumService
    {
        bool IsValidCheckSum(string number);
    }
}
