using System;

namespace DynamoSoftware.Assignment.Domain.Portfolios.Builders
{
    internal class PortfolioItemSimpleBuilder
    {
        protected string coin;
        protected double amount;
        protected double buyPrice;

        public IPortfolioItemSimple BuildSimple()
        {
            return new PortfolioItemSimple(coin, amount, buyPrice);
        }

        public PortfolioItemSimpleBuilder CoinName(string coin)
        {
            if (string.IsNullOrEmpty(coin))
            {
                throw new ArgumentOutOfRangeException(nameof(coin));
            }

            this.coin = coin;
            return this;
        }

        public PortfolioItemSimpleBuilder Amount(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            this.amount = amount;
            return this;
        }

        public PortfolioItemSimpleBuilder BuyPrice(double buyPrice)
        {
            if (buyPrice < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(buyPrice));
            }

            this.buyPrice = buyPrice;
            return this;
        }
    }
}