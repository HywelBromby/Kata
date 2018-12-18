namespace Kata.Features.BankOCR.Models
{
    /// <summary>
    /// An entry has exactly four lines the first three must be 27 chars long the last one must be blank
    /// </summary>
    public class Entry
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }

    }
}
