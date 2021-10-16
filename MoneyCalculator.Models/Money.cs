using MoneyCalculator.Models.Interfaces;

namespace MoneyCalculator.Models
{
    public class Money : IMoney
    {
        public decimal Amount { get; set; }

        public string Currency { get; set; }
    }
}
