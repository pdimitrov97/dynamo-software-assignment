using System;

namespace DynamoSoftware.Assignment.Domain.Portfolios
{
	internal class PortfolioItemSimple : IPortfolioItemSimple
	{
        public PortfolioItemSimple(string coin, double amount, double buyPrice)
        {
            if (string.IsNullOrEmpty(coin))
            {
                throw new ArgumentOutOfRangeException(nameof(coin));
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            if (buyPrice < 0)
            {
                throw new ArgumentOutOfRangeException(nameof (buyPrice));
            }

            this.Coin = coin;
            this.Amount = amount;
            this.BuyPrice = buyPrice;
        }

        public string Coin { get; }

        public double Amount { get; }

        public double BuyPrice { get; }
    }
}