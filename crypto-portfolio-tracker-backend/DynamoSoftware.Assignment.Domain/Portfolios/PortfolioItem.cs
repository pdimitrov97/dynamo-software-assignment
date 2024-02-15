using System;

namespace DynamoSoftware.Assignment.Domain.Portfolios
{
    internal sealed class PortfolioItem : PortfolioItemSimple, IPortfolioItem
	{
        public PortfolioItem(string coin, double amount, double buyPrice, double currentPrice) : base(coin, amount, buyPrice)
		{
            if (currentPrice < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(currentPrice));
            }

            this.CurrentPrice = currentPrice;
        }

        public PortfolioItem(PortfolioItemSimple parsedPortfolioItem, double currentPrice) : this(parsedPortfolioItem.Coin, parsedPortfolioItem.Amount, parsedPortfolioItem.BuyPrice, currentPrice)
        {
        }

        public double CurrentPrice { get; }

        public double InitialValue
        {
            get
            {
                return this.Amount * this.BuyPrice;
            }
        }

        public double CurrentValue
        {
            get
            {
                return this.Amount * this.CurrentPrice;
            }
        }

        public double ChangeValue
		{
            get
            {
				return this.CurrentValue - this.InitialValue;
			}
		}

        public double ChangePercentage
        {
            get
            {
                if (this.BuyPrice == 0)
                {
                    return 0;
                }

                var changePercentage = (this.CurrentPrice - this.BuyPrice) / this.BuyPrice * 100;
                return Math.Round(changePercentage, PortfolioConstants.PercentagePrecision);
            }
        }
    }
}