namespace Kata.Featres.CheckSum.Interfaces
{
    public interface ICheckSumHelper
    {
        bool IsValidCheckSum(string number);

        string Format(string line, string invalidNumber = "?");
    }
}
