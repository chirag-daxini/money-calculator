namespace MoneyCalculator.Models.Interfaces
{
    public interface IMoney
    {
        /// <summary>
        /// The amount of money this instance represents.
        /// </summary>
        decimal Amount { get; }

        /// <summary>
        /// The ISO currency code of this instance.
        /// </summary>
        string Currency { get; }
    }

}
